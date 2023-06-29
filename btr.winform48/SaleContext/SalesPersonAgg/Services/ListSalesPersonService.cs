using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using btr.winform48.Helper;
using RestSharp;

namespace btr.winform48.SaleContext.SalesPersonAgg.Services
{
    public interface IListSalesPersonService
    {
        IEnumerable<ListSalesPersonResponse> Execute();
    }
    public class ListSalesPersonResponse
    {
        public string SalesPersonId { get; set; }
        public string SalesPersonName { get; set; }
    }

    public class ListSalesPersonService : IListSalesPersonService
    {
        private const string _baseUrl = "https://localhost:7003";

        public IEnumerable<ListSalesPersonResponse> Execute()
        {
            var result = Task.Run(() => Execute_()).GetAwaiter().GetResult();
            return result;
        }
        private async Task<IEnumerable<ListSalesPersonResponse>> Execute_()
        {
            var endpoint = $"{_baseUrl}/api/SalesPerson/";
            var client = new RestClient(endpoint);
            var req = new RestRequest("List");

            //  EXECUTE
            var response = await client.ExecuteGetAsync<JSend<IEnumerable<ListSalesPersonResponse>>>(req);

            //  RETURN
            List<ListSalesPersonResponse> result;
            try
            {
                result = JSendResponse.Read(response)?.ToList();
            }
            catch (ArgumentException)
            {
                result = new List<ListSalesPersonResponse>();
            }
            return result;
        }
    }
}
