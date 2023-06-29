//using btr.winform48.Helper;
//using RestSharp;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace btr.winform48.SaleContext.CustomerAgg.Services
//{
//    public interface IGetCustomerService : IGetDataService<GetCustomerResponse>
//    {
//    }

//    public class GetCustomerService : IGetCustomerService
//    {
//        public GetCustomerResponse Execute(string id)
//        {
//            var result = Task.Run(() => Execute_(id)).GetAwaiter().GetResult();
//            return result;
//        }
//        private const string _baseUrl = "https://localhost:7003";

//        private async Task<GetCustomerResponse> Execute_(string id)
//        {
//            var endpoint = $"{_baseUrl}/api/Customer/";
//            var client = new RestClient(endpoint);
//            var req = new RestRequest("{id}")
//                .AddUrlSegment("id", id);

//            //  EXECUTE
//            var response = await client.ExecuteGetAsync<JSend<GetCustomerResponse>>(req);

//            //  RETURN
//            var result = JSendResponse.Read(response);
//            return result;
//        }
//    }
//    public class GetCustomerResponse
//    {
//        public string CustomerId { get; set; }
//        public string CustomerName { get; set; }
//        public double Plafond { get; set; }
//        public double CreditBalance { get; set; }
//    }
//}
