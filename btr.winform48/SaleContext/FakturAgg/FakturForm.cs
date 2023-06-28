using btr.winform48.Helper;
using btr.winform48.SaleContext.FakturAgg.Services;
using btr.winform48.SaleContext.SalesPersonAgg.Services;
using btr.winform48.SaleContext.StokAgg;
using btr.winform48.SharedForm;
using Microsoft.SqlServer.Server;
using Syncfusion.Windows.Forms.Tools;
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
        private readonly IListFakturService _listFakturService;
        private readonly IGetFakturService _getFakturService;
        private readonly IListSalesPersonService _listSalesPersonService;
        private readonly IGetSalesPersonService _getSalesPersonService;

        public FakturForm()
        {
            InitializeComponent();
            InitGrid();
            _listFakturService = new ListFakturService();
            _getFakturService = new GetFakturService();
            _listSalesPersonService = new ListSalesPersonService();
            _getSalesPersonService = new GetSalesPersonService();
        }

        private void InitGrid()
        {
            //SeedSampleItem();
            RefreshGrid();
            foreach(DataGridViewColumn col in FakturItemGrid.Columns)
            {
                col.DefaultCellStyle.Font = new Font("Consolas", 8.25f);
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;
                if (col.ReadOnly)
                    col.DefaultCellStyle.BackColor = Color.Beige;
            }
            DataGridViewButtonColumn buttonCol = new DataGridViewButtonColumn();
            buttonCol.HeaderText = "Find"; // Set the column header text
            buttonCol.Text = "..."; // Set the button text
            buttonCol.Name= "Find"; // Set the button text
            buttonCol.DefaultCellStyle.BackColor = Color.Brown;
            FakturItemGrid.Columns.Insert(1,buttonCol);

            //  hide
            FakturItemGrid.Columns["DiscTotal"].Visible = false;
            FakturItemGrid.Columns["PpnRp"].Visible = false;
            //  width
            FakturItemGrid.Columns["BrgId"].Width = 50;
            FakturItemGrid.Columns["Find"].Width = 20;
            FakturItemGrid.Columns["BrgName"].Width = 150;
            FakturItemGrid.Columns["StokHarga"].Width = 100;
            FakturItemGrid.Columns["Qty"].Width = 50;
            FakturItemGrid.Columns["QtyDetil"].Width = 80;
            FakturItemGrid.Columns["SubTotal"].Width = 80;
            FakturItemGrid.Columns["Disc"].Width = 65;
            FakturItemGrid.Columns["DiscRp"].Width = 100;
            FakturItemGrid.Columns["Ppn"].Width = 25;
            FakturItemGrid.Columns["Total"].Width = 80;
            //  right align
            FakturItemGrid.Columns["StokHarga"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;
            FakturItemGrid.Columns["QtyDetil"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;
            FakturItemGrid.Columns["SubTotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;
            FakturItemGrid.Columns["Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;
            //  multi-line
            FakturItemGrid.Columns["StokHarga"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            FakturItemGrid.Columns["QtyDetil"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            FakturItemGrid.Columns["DiscRp"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            //  number-format
            FakturItemGrid.Columns["SubTotal"].DefaultCellStyle.Format = "#,##0.00";
            FakturItemGrid.Columns["Total"].DefaultCellStyle.Format = "#,##0.00";
            //  auto-resize-rows
            FakturItemGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            FakturItemGrid.AutoResizeRows();
        }

        private void RefreshGrid()
        {
            var binding = new BindingSource
            {
                DataSource = _listItem
            };
            FakturItemGrid.DataSource = binding;
        }

        private void FakturIdButton_Click(object sender, EventArgs e)
        {
            var form = new BrowserForm<ListFakturResponse, string>(_listFakturService, FakturIdTextBox.Text, x => x.CustomerName);
            var resultDialog = form.ShowDialog();
            if (resultDialog == DialogResult.OK)
                FakturIdTextBox.Text = form.ReturnedValue;
            FakturDateTextBox.Focus();
        }

        private void FakturIdTextBox_Validating(object sender, CancelEventArgs e)
        {
            var textbox = (ButtonEdit)sender;
            if (textbox.Text.Length == 0)
            {
                e.Cancel = false;
                return;
            }

            GetFakturResponse faktur = null;
            try
            {
                faktur = _getFakturService.Execute(textbox.Text);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (faktur is null)
            {
                e.Cancel = true;
                return;
            }

            FakturDateTextBox.Value = faktur.FakturDate.ToDate();
            SalesPersonIdTextBox.Text = faktur.SalesPersonId;
            SalesPersonNameTextBox.Text = faktur.SalesPersonName;
            CustomerIdTextBox.Text = faktur.CustomerId;
            CustomerNameTextBox.Text = faktur.CustomerName;
            PlafondTextBox.Value = (decimal)faktur.Plafond;
            CreditBalanceTextBox.Value = (decimal)faktur.CreditBalance;
            WarehouseIdTextBox.Text = faktur.WarehouseId;
            WarehouseNameTextBox.Text = faktur.WarehouseName;
            TglRencanaKirimTextBox.Value = faktur.TglRencanaKirim.ToDate();
            TotalTextBox.Value = (decimal)faktur.Total;
            GrandTotalTextBox.Value = (decimal)faktur.GrandTotal;

            _listItem.Clear();
            foreach(var item in faktur.ListItem)
            {
                var qtyString = string.Join(";", item.ListQtyHarga.Select(x => x.Qty.ToString()));
                var discString = string.Join(";", item.ListDiscount.Select(x => x.DiscountProsen.ToString()));
                var listQtyHarga = item.ListQtyHarga
                    .Where(x => x.HargaJual != 0)
                    .Select(x => new FakturItemStokHargaSatuan(x.Qty, x.HargaJual, x.Satuan));
                var newItem = new FakturItemDto
                {
                    BrgId = item.BrgId,
                    Qty = qtyString,
                    Disc = discString,
                    ListStokHargaSatuan = listQtyHarga.ToList(),
                };
                newItem.SetBrgName(item.BrgName);
                newItem.ReCalc();
                _listItem.Add(newItem);
            }
            RefreshGrid();
        }

        private void FakturItemGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var grid = (DataGridView)sender;
            if (e.ColumnIndex == grid.Columns["Find"].Index && e.RowIndex >= 0)
            {
                if (WarehouseIdTextBox.Text.Length == 0)
                    return;

                var service = new ListBrgStokService();
                var form = new BrowserForm<ListBrgStokResponse, string>(service, FakturIdTextBox.Text, WarehouseIdTextBox.Text, x => x.BrgName);
                var resultDialog = form.ShowDialog();
                if (resultDialog == DialogResult.OK)
                    grid.CurrentRow.Cells["BrgId"].Value = form.ReturnedValue;
            }
        }

        private void SalesPersonIdButton_Click(object sender, EventArgs e)
        {
            var list = _listSalesPersonService.Execute();
            var form = new BrowserForm<ListSalesPersonResponse, string>(list, SalesPersonIdTextBox.Text, x => x.SalesPersonName);
            var resultDialog = form.ShowDialog();
            if (resultDialog == DialogResult.OK)
                SalesPersonIdTextBox.Text = form.ReturnedValue;
            WarehouseIdTextBox.Focus();
        }

        private void SalesPersonIdTextBox_Validating(object sender, CancelEventArgs e)
        {
            var textbox = (ButtonEdit)sender;
            if (textbox.Text.Length == 0)
            {
                e.Cancel = false;
                return;
            }

            GetSalesPersonResponse model = null;
            try
            {
                model = _getSalesPersonService.Execute(textbox.Text);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (model is null)
            {
                e.Cancel = true;
                return;
            }
            SalesPersonNameTextBox.Text = model.SalesPersonName;
        }
    }

        #region RESEARCH INSIDE FORM
        //private void SeedSampleItem()
        //{
        //    _listItem.Clear();
        //    _listItem.Add(new FakturItemDto
        //    {
        //        BrgId = "BR012A",
        //        Qty = "10;5;6",
        //        Disc = "10;0;0;0",
        //        Ppn = 11,
        //        ListStokHargaSatuan = new List<FakturItemStokHargaSatuan>
        //        {
        //            new FakturItemStokHargaSatuan(120,35000,"box"),
        //            new FakturItemStokHargaSatuan(25,2450,"pcs"),
        //        }
        //    });
        //    _listItem.Last().ReCalc();
        //    _listItem.Last().SetBrgName("Indomie Goreng");
        //    _listItem.Add(new FakturItemDto
        //    {
        //        BrgId = "BR031B",
        //        Qty = "5",
        //        Disc = "10;0;0;0",
        //        Ppn = 11,
        //        ListStokHargaSatuan = new List<FakturItemStokHargaSatuan>
        //        {
        //            new FakturItemStokHargaSatuan(80,33000,"box"),
        //            new FakturItemStokHargaSatuan(12,2350,"pcs"),
        //        }
        //    });
        //    _listItem.Last().ReCalc();
        //    _listItem.Last().SetBrgName("Indomie Rebus Ayam Bawang");
        //}

        //private void CustomerIdButton_Click(object sender, EventArgs e)
        //{
        //    var list = new List<BrgModel>
        //    {
        //        new BrgModel("BR001", "Indomie Goreng",10, "box"),
        //        new BrgModel("BR002", "Indomie Rebus Ayam Bawang asd asdf asdf asdf asdf asdf asdf asdf asdf asdf asdf asdf ",13,"box"),
        //        new BrgModel("BR003", "Indomie Rebus Soto",13,"box"),
        //        new BrgModel("BR004", "Indomie Goreng Padang",14,"box"),
        //        new BrgModel("BR005", "Indomie Goreng Telor Asin",15,"box"),
        //        new BrgModel("BR006", "Indomie Goreng Sambal Matah",16,"box"),
        //        new BrgModel("BR007", "Indomie Goreng Sambal Bajak",21,"box"),
        //        new BrgModel("BR008", "Mi Sedap Goreng",7,"box"),
        //        new BrgModel("BR009", "Mi Sedap Rebus White Curry",110,"box"),
        //        new BrgModel("BR00A", "Mi Sedap Rebus Soto",130,"box"),
        //        new BrgModel("BR00B", "Mi Sedap Rebus Kaldu Sapi",75,"box"),
        //        new BrgModel("BR00C", "Mi Sedap Goreng Hype Korea",25,"box"),
        //        new BrgModel("BR00D", "Mi Sedap Rebus Kaldu Ayam",130,"box"),
        //    };

        //    var form = new BrowserForm<BrgModel, string>(list, CustomerIdTextBox.Text, x => x.BrgName);
        //    var resultDialog = form.ShowDialog();
        //    if (resultDialog == DialogResult.OK)
        //        CustomerIdTextBox.Text = form.ReturnedValue;
        //}

        //private void WarehouseIdButton_Click(object sender, EventArgs e)
        //{
        //    var fakturBrowser = new FakturBrowser();
        //    var form = new BrowserForm<FakturModel, string>(fakturBrowser, WarehouseIdTextBox.Text, x => x.CustomerName);
        //    var resultDialog = form.ShowDialog();
        //    if (resultDialog == DialogResult.OK)
        //        WarehouseIdTextBox.Text = form.ReturnedValue;
        //}
        #endregion

        #region RESEARCH
        //public class BrgModel
        //{
        //    public BrgModel(string id, string name, int qty, string satuan)
        //    {
        //        BrgId = id;
        //        BrgName = name;
        //        Stok = qty;
        //        Satuan= satuan;
        //    }
        //    public string BrgId { get; set; }
        //    public string BrgName { get; set; }
        //    public int Stok { get; set; }
        //    public string Satuan { get; set; }
        //}

        //public class FakturBrowser : IDateBrowser<FakturModel>
        //{
        //    public IEnumerable<FakturModel> Browse(Periode periode)
        //    {
        //        var list = new List<FakturModel>
        //        {
        //            new FakturModel("BR001", new DateTime(2023,6,26), "Indomaret"),
        //            new FakturModel("BR002", new DateTime(2023,6,26), "Alfamart"),
        //            new FakturModel("BR003", new DateTime(2023,6,26), "Alfamart"),
        //            new FakturModel("BR004", new DateTime(2023,6,27), "Wallpart"),
        //            new FakturModel("BR005", new DateTime(2023,6,27), "Gading Mart"),
        //            new FakturModel("BR006", new DateTime(2023,6,27), "Mirota"),
        //            new FakturModel("BR007", new DateTime(2023,6,28), "Indomaret"),
        //            new FakturModel("BR008", new DateTime(2023,6,28), "Mirota"),
        //            new FakturModel("BR009", new DateTime(2023,6,28), "Cemara 7"),
        //            new FakturModel("BR00A", new DateTime(2023,6,29), "Cemara 7"),
        //            new FakturModel("BR00B", new DateTime(2023,6,29), "Gading Mart"),
        //            new FakturModel("BR00C", new DateTime(2023,6,29), "Alfamart"),
        //            new FakturModel("BR00D", new DateTime(2023,6,29), "Wallmart"),
        //        };

        //        return list
        //            .Where(x => x.FakturDate >= periode.Tgl1)
        //            .Where(x => x.FakturDate <= periode.Tgl2);
        //    }
        //}

        //public class FakturModel
        //{
        //    public FakturModel(string fakturId, DateTime fakturDate, string customerName)
        //    {
        //        FakturId = fakturId;
        //        FakturDate = fakturDate;
        //        CustomerName = customerName;
        //    }
        //    public string FakturId { get; set; }
        //    public DateTime FakturDate { get; set; }
        //    public string CustomerName { get; set; }

        //}
        #endregion
    }
