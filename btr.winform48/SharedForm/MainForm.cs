using btr.winform48.SaleContext.FakturAgg;
using btr.winform48.SharedForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace btr.winform48.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            Controls.OfType<MdiClient>().FirstOrDefault().BackColor = Color.White;
        }

        private void PoButton_Click(object sender, EventArgs e)
        {
            var form = new FakturForm
            {
                StartPosition = FormStartPosition.CenterScreen,
                MdiParent = this
            };
            form.Show();
        }

        private void ReportPoButton_Click(object sender, EventArgs e)
        {
            var form = new PrintPreviewForm()
            {
                StartPosition = FormStartPosition.CenterScreen,
            };
            form.Show();
        }
    }
}
