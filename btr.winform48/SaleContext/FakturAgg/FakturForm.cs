using btr.winform48.SaleContext.FakturAgg.Services;
using btr.winform48.SharedForm;
using Syncfusion.Windows.Forms.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using MediatR;
using btr.application.InventoryContext.WarehouseAgg.UseCases;
using btr.application.SalesContext.CustomerAgg.UseCases;
using btr.application.SalesContext.SalesPersonAgg.UseCases;
using System.Threading.Tasks;
using Polly;
using btr.nuna.Domain;
using btr.application.SalesContext.FakturAgg.UseCases;
using System.Linq;

namespace btr.winform48.SaleContext.FakturAgg
{
    public partial class FakturForm : Form
    {
        private List<FakturItemDto> _listItem = new List<FakturItemDto>();

        private readonly IMediator _mediator;
        private readonly IFakturBrowser _fakturBrowser;

        public FakturForm(IMediator mediator, 
            IFakturBrowser fakturBrowser)
        {
            InitializeComponent();
            InitGrid();
            _mediator = mediator;
            _fakturBrowser = fakturBrowser;
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
            var now = DateTime.Now.ToString("yyyy-MM-dd");
            var query = new ListFakturQuery(now, now);
            var form = new BrowserForm<ListFakturResponse, string>(_fakturBrowser, SalesPersonIdTextBox.Text, x => x.CustomerName);
            var resultDialog = form.ShowDialog();
            if (resultDialog == DialogResult.OK)
                FakturIdTextBox.Text = form.ReturnedValue;
            SalesPersonIdTextBox.Focus();
        }

        private async void FakturIdTextBox_Validating(object sender, CancelEventArgs e)
        {
            var textbox = (ButtonEdit)sender;
            var policy = Policy<GetFakturResponse>
                .Handle<KeyNotFoundException>()
                .FallbackAsync(new GetFakturResponse());
            var query = new GetFakturQuery(textbox.Text);
            Task<GetFakturResponse> queryTask() => _mediator.Send(query);
            var result = await policy.ExecuteAsync(queryTask);

            result.RemoveNull();
            CustomerNameTextBox.Text = result.CustomerName;

            FakturDateTextBox.Value = result.FakturDate.ToDate();
            SalesPersonIdTextBox.Text = result.SalesPersonId;
            SalesPersonNameTextBox.Text = result.SalesPersonName;
            CustomerIdTextBox.Text = result.CustomerId;
            CustomerNameTextBox.Text = result.CustomerName;
            PlafondTextBox.Value = (decimal)result.Plafond;
            CreditBalanceTextBox.Value = (decimal)result.CreditBalance;
            WarehouseIdTextBox.Text = result.WarehouseId;
            WarehouseNameTextBox.Text = result.WarehouseName;
            TglRencanaKirimTextBox.Value = result.TglRencanaKirim.ToDate();
            TotalTextBox.Value = (decimal)result.Total;
            GrandTotalTextBox.Value = (decimal)result.GrandTotal;

            _listItem.Clear();

            foreach (var item in result.ListItem)
            {
                var qtyString = string.Join(";", item.ListQtyHarga.Select(x => x.Qty.ToString()));
                var discString = string.Join(";", item.ListDiscount.Select(x => x.DiscountProsen.ToString()));
                var listQtyHarga = item.ListQtyHarga
                    .Where(x => x.HargaJual != 0)
                    .Select(x => new FakturItemStokHargaSatuan(x.Qty, x.HargaJual, x.Satuan));
                var newItem = new FakturItemDto(_mediator)
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
            //var grid = (DataGridView)sender;
            //if (e.ColumnIndex == grid.Columns["Find"].Index && e.RowIndex >= 0)
            //{
            //    if (WarehouseIdTextBox.Text.Length == 0)
            //        return;

            //    var service = new ListBrgStokService();
            //    var form = new BrowserForm<ListBrgStokResponse, string>(service, FakturIdTextBox.Text, WarehouseIdTextBox.Text, x => x.BrgName);
            //    var resultDialog = form.ShowDialog();
            //    if (resultDialog == DialogResult.OK)
            //        grid.CurrentRow.Cells["BrgId"].Value = form.ReturnedValue;
            //}
        }

        private async void SalesPersonIdButton_Click(object sender, EventArgs e)
        {
            var query = new ListDataSalesPersonQuery();
            var list = await _mediator.Send(query);
            var form = new BrowserForm<ListDataSalesPersonResponse, string>(list, SalesPersonIdTextBox.Text, x => x.SalesPersonName);
            var resultDialog = form.ShowDialog();
            if (resultDialog == DialogResult.OK)
                SalesPersonIdTextBox.Text = form.ReturnedValue;
            CustomerIdTextBox.Focus();
        }

        private async void SalesPersonIdTextBox_Validating(object sender, CancelEventArgs e)
        {
            var textbox = (ButtonEdit)sender;
            var policy = Policy<GetSalesPersonResponse>
                .Handle<KeyNotFoundException>()
                .FallbackAsync(new GetSalesPersonResponse());
            var query = new GetSalesPersonQuery(textbox.Text);
            Task<GetSalesPersonResponse> queryFunc() => _mediator.Send(query);

            var result = await policy.ExecuteAsync(queryFunc);
            result.RemoveNull();
            SalesPersonNameTextBox.Text = result.SalesPersonName;
        }

        private async void CustomerIdButton_Click(object sender, EventArgs e)
        {
            var query = new ListCustomerQuery();
            var result = await _mediator.Send(query);
            var form = new BrowserForm<ListCustomerResponse, string>(result, CustomerIdTextBox.Text, x => x.CustomerName);
            var resultDialog = form.ShowDialog();
            if (resultDialog == DialogResult.OK)
                CustomerIdTextBox.Text = form.ReturnedValue;
            WarehouseIdTextBox.Focus();
        }

        private async void CustomerIdTextBox_ValidatingAsync(object sender, CancelEventArgs e)
        {
            var textbox = (ButtonEdit)sender;
            var policy = Policy<GetCustomerResponse>
                .Handle<KeyNotFoundException>()
                .FallbackAsync(new GetCustomerResponse());
            var query = new GetCustomerQuery(textbox.Text);
            Task<GetCustomerResponse> queryTask() => _mediator.Send(query);

            var result = await policy.ExecuteAsync(queryTask);
            result.RemoveNull();
            CustomerNameTextBox.Text = result.CustomerName;
        }

        private async void WarehouseIdButton_Click(object sender, EventArgs e)
        {
            var query = new ListWarehouseQuery();
            var list = await _mediator.Send(query);
            var form = new BrowserForm<ListWarehouseResponse, string>(list, WarehouseIdTextBox.Text, x => x.WarehouseName);
            var resultDialog = form.ShowDialog();
            if (resultDialog == DialogResult.OK)
                WarehouseIdTextBox.Text = form.ReturnedValue;
            WarehouseIdTextBox.Focus();
        }

        private async void WarehouseIdTextBox_Validating(object sender, CancelEventArgs e)
        {
            var textbox = (ButtonEdit)sender;
            var policy = Policy<GetWarehouseResponse>
                .Handle<KeyNotFoundException>()
                .FallbackAsync(new GetWarehouseResponse());
            var query = new GetWarehouseQuery(textbox.Text);
            Task<GetWarehouseResponse> queryFunc() => _mediator.Send(query);

            var result = await policy.ExecuteAsync(queryFunc);
            result.RemoveNull();
            WarehouseNameTextBox.Text = result.WarehouseName;
        }
    }
}
