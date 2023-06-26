using btr.winform48.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace btr.winform48.SharedForm
{
    public partial class BrowserForm<T, TKey> : Form
    {
        public IEnumerable<T> ListData { get; set; }
        public string ReturnedValue { get; set; }

        private IEnumerable<T> ListDataFiltered { get; set; }
        //  property selector untuk field yang akan di-filter
        private Func<T, TKey> PropertySelector { get; set; }
        private IDateBrowser<T> DateBrowser { get; set; }

        //  constructor standard
        public BrowserForm(IEnumerable<T> listData, string returnedValue, Func<T, TKey> propertySelector)
        {
            InitializeComponent();

            FilterDate1TextBox.Visible = false;
            FilterDate2TextBox.Visible = false;
            SearchButton.Visible = false;
            const int shiftUp = 30;
            panel1.Size = new Size(panel1.Size.Width, panel1.Size.Height - shiftUp);
            BrowserGrid.Location = new Point(BrowserGrid.Location.X, BrowserGrid.Location.Y - shiftUp);
            BrowserGrid.Size = new Size(BrowserGrid.Width, BrowserGrid.Height + shiftUp);

            ListData = listData;
            PropertySelector = propertySelector;
            RefreshGrid();
            ReturnedValue = returnedValue;
        }
        
        //  constructor dengan date filter
        public BrowserForm(IDateBrowser<T> browseDate, string returnedValue, Func<T, TKey> propertySelector)
        {
            InitializeComponent();

            FilterDate1TextBox.Visible = true;
            FilterDate2TextBox.Visible = true;
            SearchButton.Visible = true;

            DateBrowser = browseDate;
            ListData = DateBrowser.Browse(new Periode(DateTime.Now));
            PropertySelector = propertySelector;
            RefreshGrid();
            ReturnedValue = returnedValue;
        }

        private void RefreshGrid()
        {
            var keyword = FilterTextBox.Text.Trim();
            if (keyword.Length == 0)
            {
                ListDataFiltered = ListData;
            }
            else
            {
                var keywords = keyword.ToLower().Split(' ');
                ListDataFiltered = ListData
                    .Where(x => keywords.All(word => PropertySelector(x).ToString().ToLower().Contains(word)))
                    .ToList();
            }

            var binding = new BindingSource();
            binding.DataSource = ListDataFiltered;
            BrowserGrid.DataSource = binding;
            BrowserGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            BrowserGrid.AutoResizeColumns();
        }

        private void BrowserGrid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            int allColWidth = 0;
            int colIndex = 0;
            foreach (DataGridViewColumn col in BrowserGrid.Columns)
            {
                allColWidth += (int)col.FillWeight;
                colIndex++;
            }
            int allColWidth2 =
                BrowserGrid.Columns.Cast<DataGridViewColumn>()
                    .Sum(x => x.Width)
                    + (BrowserGrid.RowHeadersVisible ? BrowserGrid.RowHeadersWidth : 0);

            var maxWidth = 1200;
            var minWidth = 300;
            var margin = 20;
            if (allColWidth2 <= maxWidth)
                this.Width = allColWidth2 + margin;

            if (allColWidth2 <= minWidth)
                this.Width = minWidth + margin;
        }

        private void BrowserGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            var dataGrid = (DataGridView)sender;
            ReturnedValue = dataGrid.Rows[e.RowIndex].Cells[0].Value.ToString();
            DialogResult = DialogResult.OK;
        }

        private void FilterTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                RefreshGrid();
            }
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            ListData = DateBrowser.Browse(new Periode(FilterDate1TextBox.Value, FilterDate2TextBox.Value));
            RefreshGrid();
        }
    }
}
