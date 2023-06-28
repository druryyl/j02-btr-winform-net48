using btr.winform48.Helper;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace btr.winform48.SaleContext.FakturAgg.Services
{
    public interface IGetFakturService : IGetDataService<GetFakturResponse>
    {
    }

    public class GetFakturService : IGetFakturService
    {
        public GetFakturResponse Execute(string id)
        {
            var result = Task.Run(() => Execute_(id)).GetAwaiter().GetResult();
            return result;
        }
        private const string _baseUrl = "https://localhost:7003";

        private async Task<GetFakturResponse> Execute_(string id)
        {
            var endpoint = $"{_baseUrl}/api/Faktur/";
            var client = new RestClient(endpoint);
            var req = new RestRequest("{id}")
                .AddUrlSegment("id", id);

            //  EXECUTE
            var response = await client.ExecuteGetAsync<JSend<GetFakturResponse>>(req);

            //  RETURN
            var result = JSendResponse.Read(response);
            return result;
        }
    }
    public class GetFakturResponse
    {
        public string FakturId { get; set; }
        public string FakturDate { get; set; }

        public string SalesPersonId { get; set; }
        public string SalesPersonName { get; set; }

        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
        public double Plafond { get; set; }
        public double CreditBalance { get; set; }

        public string WarehouseId { get; set; }
        public string WarehouseName { get; set; }
        public string TglRencanaKirim { get; set; }

        public string TermOfPayment { get; set; }

        public double Total { get; set; }
        public double DiscountLain { get; set; }
        public double BiayaLain { get; set; }
        public double GrandTotal { get; set; }

        public double UangMuka { get; set; }
        public double KurangBayar { get; set; }

        public string CreateTime { get; set; }
        public string LastUpdate { get; set; }
        public string UserId { get; set; }

        public List<GetFakturResponseItem> ListItem { get; set; }
    }

    public class GetFakturResponseItem
    {
        public string FakturId { get; set; }
        public string FakturItemId { get; set; }
        public int NoUrut { get; set; }

        public string BrgId { get; set; }
        public string BrgName { get; set; }

        public int AvailableQty { get; set; }
        public int Qty { get; set; }
        public double HargaJual { get; set; }
        public double SubTotal { get; set; }
        public double DiscountRp { get; set; }
        public double PpnProsen { get; set; }
        public double PpnRp { get; set; }
        public double Total { get; set; }

        public List<GetFakturResponseQtyHarga> ListQtyHarga { get; set; }
        public List<GetFakturResponseDiscount> ListDiscount { get; set; }
    }

    public class GetFakturResponseQtyHarga
    {
        public string FakturId { get; set; }
        public string FakturItemId { get; set; }
        public string FakturQtyHargaId { get; set; }
        public int NoUrut { get; set; }

        public string BrgId { get; set; }
        public string Satuan { get; set; }
        public int Conversion { get; set; }
        public int Qty { get; set; }
        public double HargaJual { get; set; }
    }

    public class GetFakturResponseDiscount
    {
        public string FakturId { get; set; }
        public string FakturItemId { get; set; }
        public string FakturDiscountId { get; set; }
        public int NoUrut { get; set; }

        public string BrgId { get; set; }
        public double DiscountProsen { get; set; }
        public double DiscountRp { get; set; }
    }

}
