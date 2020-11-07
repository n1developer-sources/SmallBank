using System;
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
    public partial class AccountPicker : Form
    {
        public AccountPicker()
        {
            InitializeComponent();
        }

        public Account CurrentAccount { get; set; }

        //when pick shared 
        private void btnPickSharedAccount_Click(object sender, EventArgs e)
        {
            var f = new PickAccount();
            f.ShowDialog();

            if (f.CurrentAccount == null) return;

            CurrentAccount = f.CurrentAccount;

            Hide();
        }

        //add new account button clicked
        private void btnAddNewAccount_Click(object sender, EventArgs e)
        {
            AccountForm f = new AccountForm();

            //open account form
            f.ShowDialog();

            if (f.CurrentAccount == null) return;

            //getting object from other form and setting to this form so that mainwindow class can get this object
            CurrentAccount = f.CurrentAccount;

            //hide this form
            Hide();
        }
    }
}
