using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using btr.winform48.Helper;
using btr.winform48.SharedForm;
using RestSharp;

namespace btr.winform48.InventoryContext.StokAgg.Services
{
    public interface IListStokService
    {
        IEnumerable<ListBrgStokResponse> Execute(string brgId, string warehouseId);
    }
    public class ListBrgStokResponse
    {
        public string BrgId { get; set; }
        public string BrgName { get; set; }
        public int Qty { get; set; }
    }

    public class ListBrgStokService : IListStokService, IStringBrowser<ListBrgStokResponse>
    {
        private const string _baseUrl = "https://localhost:7003";

        public IEnumerable<ListBrgStokResponse> Execute(string brgId, string warehouseId)
        {
            var result = Task.Run(() => Execute_(brgId, warehouseId)).GetAwaiter().GetResult();
            return result;
        }
        
        private async Task<IEnumerable<ListBrgStokResponse>> Execute_(string brgId, string warehouseId)
        {
            var endpoint = $"{_baseUrl}/api/Stok/";
            var client = new RestClient(endpoint);
            var req = new RestRequest("List/{brgId}/{warehouseId}")
                .AddUrlSegment("brgId", brgId)
                .AddUrlSegment("warehouseId", warehouseId);

            //  EXECUTE
            var response = await client.ExecuteGetAsync<JSend<IEnumerable<ListBrgStokResponse>>>(req);

            //  RETURN
            List<ListBrgStokResponse> result;
            try
            {
                result = JSendResponse.Read(response)?.ToList();
            }
            catch (ArgumentException)
            {
                result = new List<ListBrgStokResponse>();
            }
            return result;
        }

        public IEnumerable<ListBrgStokResponse> Browse(string keyword, string filter)
        {
            var result = Execute(keyword, filter);
            return result;
        }
    }
}
