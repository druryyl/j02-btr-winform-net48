using btr.winform48.Helper;
using btr.winform48.SharedForm;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace btr.winform48.InventoryContext.WarehouseAgg.Services
{
    public interface IListWarehouseService
    {
        IEnumerable<ListWarehouseResponse> Execute();
    }
    public class ListWarehouseResponse
    {
        public string WarehouseId { get; set; }
        public string WarehouseName { get; set; }
    }

    public class ListWarehouseService : IListWarehouseService
    {
        private const string _baseUrl = "https://localhost:7003";

        public IEnumerable<ListWarehouseResponse> Execute()
        {
            var result = Task.Run(() => Execute_()).GetAwaiter().GetResult();
            return result;
        }
        private async Task<IEnumerable<ListWarehouseResponse>> Execute_()
        {
            var endpoint = $"{_baseUrl}/api/Warehouse/";
            var client = new RestClient(endpoint);
            var req = new RestRequest("List");

            //  EXECUTE
            var response = await client.ExecuteGetAsync<JSend<IEnumerable<ListWarehouseResponse>>>(req);

            //  RETURN
            List<ListWarehouseResponse> result;
            try
            {
                result = JSendResponse.Read(response)?.ToList();
            }
            catch (ArgumentException)
            {
                result = new List<ListWarehouseResponse>();
            }
            return result;
        }
    }
}
