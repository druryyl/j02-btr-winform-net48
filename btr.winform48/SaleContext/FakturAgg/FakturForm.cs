using btr.winform48.Helper;
using btr.winform48.SaleContext.FakturAgg.Services;
using btr.winform48.SharedForm;
using Syncfusion.Windows.Forms.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using btr.winform48.InventoryContext.StokAgg.Services;
using MediatR;
using btr.application.InventoryContext.WarehouseAgg.UseCases;
using btr.application.SalesContext.CustomerAgg.UseCases;
using btr.application.SalesContext.SalesPersonAgg.UseCases;
using System.Threading.Tasks;
using System.Security.Authentication.ExtendedProtection;
using Polly;
using btr.nuna.Domain;
using btr.application.SalesContext.FakturAgg.UseCases;

namespace btr.winform48.SaleContext.FakturAgg
{
    public partial class FakturForm : Form
    {
        private List<FakturItemDto> _listItem = new List<FakturItemDto>();

        private readonly IMediator _mediator;

        public FakturForm(IMediator mediator)
        {
            InitializeComponent();
            InitGrid();
            _mediator = mediator;
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

        private async void FakturIdButton_Click(object sender, EventArgs e)
        {
            //var form = new BrowserForm<ListFakturResponse, string>(_listFakturService, FakturIdTextBox.Text, x => x.CustomerName);
            //var resultDialog = form.ShowDialog();
            //if (resultDialog == DialogResult.OK)
            //    FakturIdTextBox.Text = form.ReturnedValue;
            //FakturDateTextBox.Focus();

            var now = DateTime.Now.ToString("yyyy-MM-dd");
            var query = new ListFakturQuery(now, now);
            var list = await _mediator.Send(query);
            var form = new BrowserForm<ListDataSalesPersonResponse, string>(list, SalesPersonIdTextBox.Text, x => x.SalesPersonName);
            var resultDialog = form.ShowDialog();
            if (resultDialog == DialogResult.OK)
                SalesPersonIdTextBox.Text = form.ReturnedValue;
            CustomerIdTextBox.Focus();
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

            //FakturDateTextBox.Value = faktur.FakturDate.ToDate();
            SalesPersonIdTextBox.Text = faktur.SalesPersonId;
            SalesPersonNameTextBox.Text = faktur.SalesPersonName;
            CustomerIdTextBox.Text = faktur.CustomerId;
            CustomerNameTextBox.Text = faktur.CustomerName;
            PlafondTextBox.Value = (decimal)faktur.Plafond;
            CreditBalanceTextBox.Value = (decimal)faktur.CreditBalance;
            WarehouseIdTextBox.Text = faktur.WarehouseId;
            WarehouseNameTextBox.Text = faktur.WarehouseName;
            //TglRencanaKirimTextBox.Value = faktur.TglRencanaKirim.ToDate();
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
            Task<GetCustomerResponse> queryFunc() => _mediator.Send(query);

            var result = await policy.ExecuteAsync(queryFunc);
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
