using RestSharp.Authenticators;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using btr.winform48.Helper;

namespace btr.winform48.Infrastructure.SalesContext
{
    public class SalesPersonService
    {
        private const string _baseUrl = "https://localhost:7003";
        public SalesPersonModel GetData(string id)
        {
            var result = Task.Run(() => GetDataAsync(id)).GetAwaiter().GetResult();
            return result;
        }
        public IEnumerable<SalesPersonModel> ListData()
        {
            var result = Task.Run(() => ListDataAsync()).GetAwaiter().GetResult();
            return result;
        }

        private async Task<SalesPersonModel> GetDataAsync(string salesPersonId)
        {
            var endpoint = $"{_baseUrl}/api/SalesPerson";
            var client = new RestClient(endpoint);
            var req = new RestRequest("{id}")
                .AddUrlSegment("id", salesPersonId);
            //  EXECUTE
            var response = await client.ExecuteGetAsync<JSend<SalesPersonModel>>(req);

            //  RETURN
            return JSendResponse.Read(response);
        }
        private async Task<IEnumerable<SalesPersonModel>> ListDataAsync()
        {
            //  PREPARE
            var endpoint = $"{_baseUrl}/api/SalesPerson/list";
            var client = new RestClient(endpoint);
            var req = new RestRequest();

            //  EXECUTE
            var response = await client.ExecuteGetAsync<JSend<IEnumerable<SalesPersonModel>>>(req);

            //  RETURN
            return JSendResponse.Read(response);
        }
    }
}
