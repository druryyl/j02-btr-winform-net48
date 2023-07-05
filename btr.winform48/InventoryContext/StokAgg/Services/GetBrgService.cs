//using System;
//using System.Collections.Generic;
//using System.Threading.Tasks;
//using btr.winform48.Helper;
//using RestSharp;

//namespace btr.winform48.InventoryContext.StokAgg.Services
//{
//    public interface IGetBrgHargaService
//    {
//        GetBrgHargaResponse Execute(string brgId);
//    }
//    public class GetBrgHargaResponse
//    {
//        public string BrgId { get; set; }
//        public string BrgName { get; set; }
//        public List<GetBrgHargaResponseSatuanHrg> ListSatuanHarga { get; set; }
//    }

//    public class GetBrgHargaResponseSatuanHrg
//    {
//        public string BrgId { get; set; }
//        public string Satuan { get; set; }
//        public int Conversion { get; set; }
//        public int Stok { get; set; }
//        public double HargaJual { get; set; }
//    }

//    public class GetBrgHargaService : IGetBrgHargaService
//    {
//        private const string _baseUrl = "https://localhost:7003";

//        public GetBrgHargaResponse Execute(string brgId)
//        {
//            var result = Task.Run(() => Execute_(brgId)).GetAwaiter().GetResult();
//            return result;
//        }

//        private async Task<GetBrgHargaResponse> Execute_(string brgId)
//        {
//            var endpoint = $"{_baseUrl}/api/Brg/";
//            var client = new RestClient(endpoint);
//            var req = new RestRequest("{id}")
//                .AddUrlSegment("id", brgId);

//            //  EXECUTE
//            var response = await client.ExecuteGetAsync<JSend<GetBrgHargaResponse>>(req);

//            //  RETURN
//            GetBrgHargaResponse result;
//            try
//            {
//                result = JSendResponse.Read(response);
//            }
//            catch (ArgumentException)
//            {
//                result = new GetBrgHargaResponse();
//            }
//            return result;
//        }
//    }
//}
