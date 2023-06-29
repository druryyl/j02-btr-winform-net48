//using btr.winform48.Helper;
//using RestSharp;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace btr.winform48.SaleContext.SalesPersonAgg.Services
//{
//    public interface IGetSalesPersonService : IGetDataService<GetSalesPersonResponse>
//    {
//    }

//    public class GetSalesPersonResponse
//    {
//        public string SalesPersonId { get; set; }
//        public string SalesPersonName { get; set; }
//    }


//    public class GetSalesPersonService :  IGetSalesPersonService
//    {
//        public GetSalesPersonResponse Execute(string id)
//        {
//            var result = Task.Run(() => Execute_(id)).GetAwaiter().GetResult();
//            return result;
//        }
//        private const string _baseUrl = "https://localhost:7003";

//        private async Task<GetSalesPersonResponse> Execute_(string id)
//        {
//            var endpoint = $"{_baseUrl}/api/SalesPerson/";
//            var client = new RestClient(endpoint);
//            var req = new RestRequest("{id}")
//                .AddUrlSegment("id", id);

//            //  EXECUTE
//            var response = await client.ExecuteGetAsync<JSend<GetSalesPersonResponse>>(req);

//            //  RETURN
//            var result = JSendResponse.Read(response);
//            return result;
//        }
//    }
//}
