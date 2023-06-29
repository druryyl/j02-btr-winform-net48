using btr.winform48.Helper;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace btr.winform48.InventoryContext.WarehouseAgg.Services
{
    //public interface IGetWarehouseService : IGetDataService<GetWarehouseResponse>
    //{
    //}

    //public class GetWarehouseService : IGetWarehouseService
    //{
    //    public GetWarehouseResponse Execute(string id)
    //    {
    //        var result = Task.Run(() => Execute_(id)).GetAwaiter().GetResult();
    //        return result;
    //    }
    //    private const string _baseUrl = "https://localhost:7003";

    //    private async Task<GetWarehouseResponse> Execute_(string id)
    //    {
    //        var endpoint = $"{_baseUrl}/api/Warehouse/";
    //        var client = new RestClient(endpoint);
    //        var req = new RestRequest("{id}")
    //            .AddUrlSegment("id", id);

    //        //  EXECUTE
    //        var response = await client.ExecuteGetAsync<JSend<GetWarehouseResponse>>(req);

    //        //  RETURN
    //        var result = JSendResponse.Read(response);
    //        return result;
    //    }
    //}
    //public class GetWarehouseResponse
    //{
    //    public string WarehouseId { get; set; }
    //    public string WarehouseName { get; set; }
    //}

}
