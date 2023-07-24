using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using btr.winform48.SaleContext.FakturAgg;
using Microsoft.Extensions.DependencyInjection;

namespace btr.winform48.SharedForm
{
    public partial class MainForm : Form
    {
        private readonly SalesPersonForm _salesPersonForm;
        private readonly FakturForm _fakturForm;
        private readonly Faktur2Form _faktur2Form;

        public MainForm(SalesPersonForm salesPersonForm,
            FakturForm fakturForm,
            Faktur2Form faktur2Form)
        {
            InitializeComponent();
            Controls.OfType<MdiClient>().FirstOrDefault().BackColor = Color.White;

            _fakturForm = fakturForm;
            _salesPersonForm = salesPersonForm;
            _faktur2Form = faktur2Form;
        }

        private void PoButton_Click(object sender, EventArgs e)
        {
            _fakturForm.StartPosition = FormStartPosition.CenterScreen;
            _fakturForm.MdiParent = this;
            _fakturForm.Show();
        }

        private void ReportPoButton_Click(object sender, EventArgs e)
        {

            _salesPersonForm.StartPosition = FormStartPosition.CenterScreen;
            _salesPersonForm.Show();
        }

        private void FakturButton_Click(object sender, EventArgs e)
        {
            _faktur2Form.StartPosition = FormStartPosition.CenterScreen;
            _faktur2Form.MdiParent = this;
            _faktur2Form.Show();
        }
    }
}
