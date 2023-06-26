using btr.winform48.Helper;
using btr.winform48.SharedForm;
using Microsoft.SqlServer.Server;
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
    public partial class FakturForm : Form, IFakturView
    {

        public event EventHandler FakturIdBrowse;
        public event EventHandler SalesPersonIdBrowse;
        public event EventHandler CustomerIdBrowse;
        public event EventHandler WarehouseIdIdBrowse;
        public event EventHandler Save;
        public event EventHandler Delete;
        public event EventHandler Print;

        private List<FakturItemDto> _listItem = new List<FakturItemDto>();
        public FakturForm()
        {
            InitializeComponent();
            InitEvent();
            InitGrid();
        }

        private void InitEvent()
        {
            FakturIdButton.Click += delegate { FakturIdBrowse?.Invoke(this, EventArgs.Empty); };
            SalesPersonIdButton.Click += delegate { SalesPersonIdBrowse?.Invoke(this, EventArgs.Empty); };
            CustomerIdButton.Click += delegate { CustomerIdBrowse?.Invoke(this, EventArgs.Empty); };
            WarehouseIdButton.Click += delegate { WarehouseIdIdBrowse?.Invoke(this, EventArgs.Empty); };
            SaveButton.Click += delegate { Save?.Invoke(this, EventArgs.Empty); };
            DeleteButton.Click += delegate { Delete?.Invoke(this, EventArgs.Empty); };
            PrintButton.Click += delegate { Print?.Invoke(this, EventArgs.Empty); };
        }

        private void InitGrid()
        {
            //SeedSampleItem();
            RefreshGrid();
            foreach(DataGridViewColumn col in FakturItemGrid.Columns)
            {
                col.DefaultCellStyle.Font = new Font("Consolas", 8f);
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;
                if (col.ReadOnly)
                    col.DefaultCellStyle.BackColor = Color.Beige;
            }

            //  hide
            FakturItemGrid.Columns["DiscTotal"].Visible = false;
            FakturItemGrid.Columns["PpnRp"].Visible = false;
            //  width
            FakturItemGrid.Columns["BrgId"].Width = 50;
            FakturItemGrid.Columns["BrgName"].Width = 150;
            FakturItemGrid.Columns["StokHarga"].Width = 120;
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

        public string FakturId 
        { 
            get => FakturIdTextBox.Text; 
            set => FakturIdTextBox.Text = value; 
        }
        public DateTime FakturDate 
        { 
            get => FakturDateTextBox.Value; 
            set => FakturDateTextBox.Value = value; 
        }
        public string SalesPersonId 
        { 
            get => SalesPersonIdTextBox.Text; 
            set => SalesPersonIdTextBox.Text = value; 
        }
        public string SalesPersonaName 
        { 
            get => SalesPersonNameTextBox.Text; 
            set => SalesPersonNameTextBox.Text = value; 
        }
        public string CustomerId 
        { 
            get => CustomerIdTextBox.Text; 
            set => CustomerIdTextBox.Text = value; 
        }
        public string CustomerName 
        { 
            get => CustomerNameTextBox.Text; 
            set => CustomerNameTextBox.Text = value; 
        }
        public decimal Plafond 
        { 
            get => PlafondTextBox.Value; 
            set => PlafondTextBox.Value = value; 
        }
        public decimal CreditBalance 
        { 
            get => CreditBalanceTextBox.Value;
            set => CreditBalanceTextBox.Value = value; 
        }
        public string WarehouseId 
        { 
            get => WarehouseIdTextBox.Text;
            set => WarehouseIdTextBox.Text = value; 
        }
        public string WarehouseName 
        { 
            get => WarehouseIdTextBox.Text;
            set => WarehouseIdTextBox.Text = value; 
        }
        public DateTime TglRecanaKirim 
        { 
            get => TglRencanaKirimTextBox.Value;
            set => TglRencanaKirimTextBox.Value = value; 
        }
        public int TermOfPayment 
        {
            get => TermOfPaymentComboBox.SelectedIndex;
            set => TermOfPaymentComboBox.SelectedIndex = value; 
        }
        public string Note 
        { 
            get => NoteTextBox.Text;
            set => NoteTextBox.Text = value; 
        }
        public decimal Total 
        { 
            get => TotalTextBox.Value;
            set => TotalTextBox.Value = value; 
        }
        public decimal DiscountLain 
        { 
            get => DiscountLainTextBox.Value;
            set => DiscountLainTextBox.Value = value; 
        }
        public decimal BiayaLain 
        { 
            get => BiayaLainTextBox.Value;
            set => BiayaLainTextBox.Value = value; 
        }
        public decimal GrandTotal 
        { 
            get => GrandTotalTextBox.Value;
            set => GrandTotalTextBox.Value = value; 
        }
        public decimal UangMuka 
        { 
            get => UangMukaTextBox.Value;
            set => UangMukaTextBox.Value = value; 
        }
        public decimal Sisa 
        { 
            get => SisaTextBox.Value;
            set => SisaTextBox.Value = value; 
        }
        public List<FakturItemDto> ListItems 
        { 
            get => _listItem; 
            set => _listItem = value; 
        }


        #region RESEARCH
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
    }

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
