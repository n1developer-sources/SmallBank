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
    public partial class AccountForm : Form
    {
        public AccountForm()
        {
            InitializeComponent();

            //set the account default type to payroll
            cbAccountType.SelectedIndex = 0;
        }

        public Account CurrentAccount { get; set; }

        //when confirm button clicked
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            int balance = 0;
            try
            {
                //converting text to int
                balance = Convert.ToInt32(txtBalance.Text);
            }
            catch (Exception exception)
            {
                MessageBox.Show("Enter Balance in Int!");
                return;
            }

            //setting data to this object
            CurrentAccount = new Account();
            CurrentAccount.AccountType = cbAccountType.SelectedIndex == 0 ? AccountType.Payroll : AccountType.Budget;

            CurrentAccount.Shared = chkShare.Checked;

            CurrentAccount.Balance = balance;

            Hide();
        }
    }
}
