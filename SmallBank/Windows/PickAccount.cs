﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SmallBank.Models;

namespace SmallBank.Windows
{
    public partial class PickAccount : Form
    {
        //ctr
        public PickAccount()
        {
            InitializeComponent();
            //disallow to generate auto columns
            dgv.AutoGenerateColumns = false;

            //load data into the dgv
            LoadData();
        }


        public Account CurrentAccount { get; set; }
        private void btnAddNewAccount_Click(object sender, EventArgs e)
        {
            try
            {
                //find customer from id
                int x = Convert.ToInt16(dgv.SelectedRows[0].Cells[0].Value);
                var customer = MainWindow.Customers.FirstOrDefault(c => c.Id == x);

                //setting customer object
                CurrentAccount = customer.Account;
                Hide();
            }
            catch (Exception exception)
            {

            }
        }
        public void LoadData()
        {
            BindingSource s = new BindingSource();
            dgv.DataSource = s;

            //load customer which have an active account into the data grid view
            s.DataSource = MainWindow.Customers.Where(c => c.Account != null).Where(c => c.Account.Shared).GroupBy(p => p.Account.Id)
                .Select(g => g.First()).ToList();
        }

        private void PickAccount_Load(object sender, EventArgs e)
        {

        }
    }
}
