﻿using Microsoft.SqlServer.Server;
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
            FakturItemGrid.Columns["Disc"].Width = 50;
            FakturItemGrid.Columns["DiscRp"].Width = 120;
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
                Qty = "5",
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