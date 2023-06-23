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
        private string _disc = string.Empty;
        private string _discRp = string.Empty;
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
                if (qtys.Length == 0) 
                { 
                    _qty1 = 0; 
                    _qty2 = 0; 
                    _qtyBonus = 0; 
                }
                if (qtys.Length == 1)
                {
                    _qty1 = Convert.ToInt32(qtys[0]);
                    _qty2 = 0;
                    _qtyBonus = 0;
                }
                if (qtys.Length == 2)
                {
                    _qty1 = Convert.ToInt32(qtys[0]);
                    _qty2 = Convert.ToInt32(qtys[1]); ;
                    _qtyBonus = 0;
                }
                if (qtys.Length == 3)
                {
                    _qty1 = Convert.ToInt32(qtys[0]);
                    _qty2 = Convert.ToInt32(qtys[1]);
                    _qtyBonus = Convert.ToInt32(qtys[2]); 
                }
            }
        }
        public string QtyDetil 
        { 
            get
            {
                var satBesar = ListStokHargaSatuan.FirstOrDefault()?.Satuan??string.Empty;
                var satKecil = ListStokHargaSatuan.LastOrDefault()?.Satuan??string.Empty;
                return $"{_qty1} {satBesar}\n{_qty2} {satKecil}\nBonus {_qtyBonus} {satKecil}";
            }
        }
        public double SubTotal 
        {
            get 
            {
                var result = _qty1 * ListStokHargaSatuan.FirstOrDefault()?.Harga??0;
                result += _qty2 * ListStokHargaSatuan.LastOrDefault()?.Harga??0;
                return result;
            }
        }
        public string Disc 
        { 
            get => _disc; 
            set
            {
                _disc = value;
                var discs = (_disc == string.Empty ? "0" : _disc).Split(';').ToList();
                if (discs.Count <= 0) discs.Add("0");
                if (discs.Count <= 1) discs.Add("0");
                if (discs.Count <= 2) discs.Add("0");
                if (discs.Count <= 3) discs.Add("0");

                double[] discRp = new double[4];
                discRp[0] = SubTotal * Convert.ToDouble(discs[0]) / 100;
                var newSubTotal = SubTotal - discRp[0];
                discRp[1] = newSubTotal * Convert.ToDouble(discs[1]) / 100;
                newSubTotal -= discRp[1];
                discRp[2] = newSubTotal * Convert.ToDouble(discs[2]) / 100;
                newSubTotal -= discRp[2];
                discRp[3] = newSubTotal * Convert.ToDouble(discs[3]) / 100;
                _discTotal = discRp[0] + discRp[1] + discRp[2] + discRp[3];

                var result = $"Disc-1: {discRp[0]}\n";
                result += $"Disc-2: {discRp[1]}\n";
                result += $"Disc-3: {discRp[2]}\n";
                result += $"Disc-4: {discRp[3]}";
                _discRp = result;
            }
        }
        public string DiscRp { get => _discRp; }
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
