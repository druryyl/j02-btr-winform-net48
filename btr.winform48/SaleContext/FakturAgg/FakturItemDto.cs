using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace btr.winform48.SaleContext.FakturAgg
{
    public class FakturItemDto
    {
        private double _discTotal = 0;
        private string _qtyString = string.Empty;
        private int _qty1 = 0;
        private int _qty2 = 0;
        private int _qtyBonus = 0;

        public FakturItemDto()
        {
            ListStokHargaSatuan = new List<FakturItemStokHargaSatuan>();
        }

        public string BrgId { get; set; }
        public string BrgName { get; set;}
        public string StokHarga 
        {
            get
            {
                return string.Join(Environment.NewLine, 
                    ListStokHargaSatuan
                    .Select(x => $"{x.Stok} {x.Satuan} @{x.Harga}"));
            } 
        }
        public string Qty 
        { 
            get => _qtyString; 
            set 
            { 
                _qtyString = value;
                var qtys = _qtyString.Split(';');
                if (qtys.Length == 0) { qtys[0] = "0"; qtys[1] = "0"; qtys[2] = "0"; }
                if (qtys.Length == 1) { qtys[1] = "0"; qtys[2] = "0"; }
                if (qtys.Length == 2) { qtys[2] = "0"; }
                _qty1 = Convert.ToInt32(qtys[0]);
                _qty2 = Convert.ToInt32(qtys[1]);
                _qtyBonus = Convert.ToInt32(qtys[2]);
            }
        }
        public string QtyDetil 
        { 
            get
            {
                var satBesar = ListStokHargaSatuan.First().Satuan;
                var satKecil = ListStokHargaSatuan.Last().Satuan;
                return $"{_qty1} {satBesar}\n{_qty2} {satKecil}\nBonus {_qtyBonus} {satKecil}";
            }
        }
        public double SubTotal 
        {
            get 
            {
                var result = _qty1 * ListStokHargaSatuan.First().Harga;
                result += _qty2 * ListStokHargaSatuan.Last().Harga;
                return result;
            }
        }
        public string Disc { get; set; }
        public string DiscRp 
        {
            get
            {
                var discs = Qty.Split(';');
                if (discs.Length == 0) { discs[0] = "0"; discs[1] = "0"; discs[2] = "0"; discs[3] = "0"; }
                if (discs.Length == 1) { discs[1] = "0"; discs[2] = "0"; discs[3] = "0"; }
                if (discs.Length == 2) { discs[2] = "0"; discs[3] = "0"; }
                if (discs.Length == 3) { discs[3] = "0"; }
                double[] discRp = new double[4];
                discRp[0] = SubTotal * Convert.ToDouble(discs[0]) / 100;
                var newSubTotal = SubTotal - discRp[0];
                discRp[1] =  newSubTotal * Convert.ToDouble(discs[1]) / 100;
                newSubTotal -= discRp[1];
                discRp[2] = newSubTotal * Convert.ToDouble(discs[2]) / 100;
                newSubTotal -= discRp[2];
                discRp[3] = newSubTotal * Convert.ToDouble(discs[3]) / 100;
                _discTotal = discRp[0] + discRp[1] + discRp[2] + discRp[3];

                var result = $"Disc-1: {discRp[0]}\n";
                result += $"Disc-2: {discRp[1]}\n";
                result += $"Disc-3: {discRp[2]}\n";
                result += $"Disc-4: {discRp[3]}\n";
                return result;
            }
        }
        public double DiscTotal { get => _discTotal; }
        public double Ppn { get; set; }
        public double PpnRp { get => (SubTotal - DiscTotal) * Ppn / 100; }
        public double Total { get => SubTotal - DiscTotal + PpnRp; }
        public List<FakturItemStokHargaSatuan> ListStokHargaSatuan { get; set; }
    }

    public class FakturItemStokHargaSatuan
    {
        public FakturItemStokHargaSatuan(int stok, double harga, string satuan)
        {
            Stok = stok;
            Harga = harga;
            Satuan = satuan;
        }
        public int Stok { get; set; }
        public double Harga { get; set; }
        public string Satuan { get; set; }
    }

}
