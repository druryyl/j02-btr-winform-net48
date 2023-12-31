﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using btr.application.SalesContext.SalesPersonAgg.Contracts;
using btr.domain.SalesContext.SalesPersonAgg;

namespace btr.winform48
{
    public partial class SalesPersonForm : Form
    {
        private BindingSource _bindingSource;
        private readonly ISalesPersonDal _salesPersonDal;
        private List<SalesPersonModel> _listPerson;
        public SalesPersonForm(ISalesPersonDal salesPersonDal)
        {
            _salesPersonDal = salesPersonDal;
            InitializeComponent();
            //_salesPersonService = new SalesPersonService();

            _listPerson = new List<SalesPersonModel>();

            LoadSalesPerson();
            ReBinding();
        }

        private void LoadSalesPerson()
        {
            _listPerson.Clear();
            _listPerson = _salesPersonDal.ListData().ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ReBinding();
        }

        private void ReBinding()
        {
            _bindingSource = new BindingSource
            {
                DataSource = _listPerson
            };
            ListGrid.DataSource = _bindingSource;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var x = "5 + 2";
            DataTable dt = new DataTable();
            var result = dt.Compute(x, "");
            NameTextBox.Text = result.ToString();
        }
    }
}
