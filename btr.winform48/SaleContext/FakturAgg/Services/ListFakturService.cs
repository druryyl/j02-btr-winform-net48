using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using btr.nuna.Domain;
using btr.winform48.Helper;
using btr.winform48.SharedForm;
using RestSharp;

namespace btr.winform48.SaleContext.FakturAgg.Services
{
    public interface IListFakturService : IDateBrowser<ListFakturResponse>
    {
        IEnumerable<ListFakturResponse> Execute(string tgl1, string tgl2);
    }
    public class ListFakturResponse
    {
        public string FakturId { get; set; }
        public string FakturDate { get; set; }
        public string CustomerName { get; set; }
    }

    public class ListFakturService : IListFakturService
    {
        private const string _baseUrl = "https://localhost:7003";

        public IEnumerable<ListFakturResponse> Execute(string tgl1, string tgl2)
        {
            var result = Task.Run(() => Execute_(tgl1, tgl2)).GetAwaiter().GetResult();
            return result;
        }
        private async Task<IEnumerable<ListFakturResponse>> Execute_(string tgl1, string tgl2)
        {
            var endpoint = $"{_baseUrl}/api/Faktur/";
            var client = new RestClient(endpoint);
            var req = new RestRequest("List/{tgl1}/{tgl2}")
                .AddUrlSegment("tgl1", tgl1)
                .AddUrlSegment("tgl2", tgl2);

            //  EXECUTE
            var response = await client.ExecuteGetAsync<JSend<IEnumerable<ListFakturResponse>>>(req);

            //  RETURN
            List<ListFakturResponse> result;
            try
            {
                result = JSendResponse.Read(response)?.ToList();
            }
            catch (ArgumentException)
            {
                result = new List<ListFakturResponse>();
            }
            return result;
        }

        public IEnumerable<ListFakturResponse> Browse(Periode periode)
        {
            var result = Execute(
                periode.Tgl1.ToString("yyyy-MM-dd"),
                periode.Tgl2.ToString("yyyy-MM-dd"));
            return result;
        }

    }
}
