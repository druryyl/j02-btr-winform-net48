using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace btr.winform48.SaleContext.FakturAgg
{
    public partial class FakturForm : Form
    {
        private List<FakturItemDto> _listItem = new List<FakturItemDto>();
        public FakturForm()
        {
            InitializeComponent();
            InitGrid();
        }

        private void InitGrid()
        {
            SeedSampleItem();
            RefreshGrid();
            //  hide
            FakturItemGrid.Columns["Satuan"].Visible = false;
            //  width
            FakturItemGrid.Columns["BrgId"].Width = 20;
            FakturItemGrid.Columns["BrgName"].Width = 100;
            FakturItemGrid.Columns["StokHarga"].Width = 80;
            FakturItemGrid.Columns["Qty"].Width = 30;
            FakturItemGrid.Columns["QtyDetil"].Width = 50;
            FakturItemGrid.Columns["SubTotal"].Width = 50;
            FakturItemGrid.Columns["Disc"].Width = 20;
            FakturItemGrid.Columns["DiscDetil"].Width = 50;
            FakturItemGrid.Columns["Ppn"].Width = 10;
            FakturItemGrid.Columns["Total"].Width = 50;
            //  right align
            FakturItemGrid.Columns["SubTotal"].ValueType = typeof(double);
            FakturItemGrid.Columns["Total"].ValueType = typeof(double);
            //  multi-line
            FakturItemGrid.Columns["StokHarga"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            FakturItemGrid.Columns["QtyDetil"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            FakturItemGrid.Columns["DiscDetil"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
        }
        private void RefreshGrid()
        {
            var binding = new BindingSource
            {
                DataSource = _listItem
            };
            FakturItemGrid.DataSource = binding;
        }

        private void SeedSampleItem()
        {
            _listItem.Clear();
            _listItem.Add(new FakturItemDto
            {
                BrgId = "BR012A",
                BrgName = "Indomie Goreng",
                Qty = "10;5;6",
                Disc = "10;0;0;0",
                Ppn = 11,
                ListStokHargaSatuan = new List<FakturItemStokHargaSatuan>
                {
                    new FakturItemStokHargaSatuan(120,35000,"karton"),
                    new FakturItemStokHargaSatuan(25,2450,"pcs"),
                }
            });
            _listItem.Add(new FakturItemDto
            {
                BrgId = "BR031B",
                BrgName = "Indomie Rebus Ayam Bawang",
                Qty = "5 karton\n",
                Disc = "10;0;0;0",
                Ppn = 11,
                ListStokHargaSatuan = new List<FakturItemStokHargaSatuan>
                {
                    new FakturItemStokHargaSatuan(80,33000,"karton"),
                    new FakturItemStokHargaSatuan(12,2350,"pcs"),
                }
            });
        }
    }
}
