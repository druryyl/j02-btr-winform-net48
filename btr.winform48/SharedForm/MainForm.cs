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
        
        public MainForm(SalesPersonForm salesPersonForm)
        {
            _salesPersonForm = salesPersonForm;
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

            _salesPersonForm.StartPosition = FormStartPosition.CenterScreen;
            _salesPersonForm.Show();

            //
            // var form = new PrintPreviewForm()
            // {
            //     StartPosition = FormStartPosition.CenterScreen,
            // };
            // form.Show();
        }
    }
}
