using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using btr.winform48.Helper;
using RestSharp;

namespace btr.winform48.SaleContext.CustomerAgg.Services
{
    //public interface IListCustomerService
    //{
    //    IEnumerable<ListCustomerResponse> Execute();
    //}
    //public class ListCustomerResponse
    //{
    //    public string CustomerId { get; set; }
    //    public string CustomerName { get; set; }
    //}

    //public class ListCustomerService : IListCustomerService
    //{
    //    private const string _baseUrl = "https://localhost:7003";

    //    public IEnumerable<ListCustomerResponse> Execute()
    //    {
    //        var result = Task.Run(() => Execute_()).GetAwaiter().GetResult();
    //        return result;
    //    }
    //    private async Task<IEnumerable<ListCustomerResponse>> Execute_()
    //    {
    //        var endpoint = $"{_baseUrl}/api/Customer/";
    //        var client = new RestClient(endpoint);
    //        var req = new RestRequest("List");

    //        //  EXECUTE
    //        var response = await client.ExecuteGetAsync<JSend<IEnumerable<ListCustomerResponse>>>(req);

    //        //  RETURN
    //        List<ListCustomerResponse> result;
    //        try
    //        {
    //            result = JSendResponse.Read(response)?.ToList();
    //        }
    //        catch (ArgumentException)
    //        {
    //            result = new List<ListCustomerResponse>();
    //        }
    //        return result;
    //    }
    //}
}
