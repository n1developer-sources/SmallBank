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
    public partial class CustomerForm : Form
    {
        //ctr
        public CustomerForm()
        {
            InitializeComponent();
            CurrentCustomer = new Customer();
            this.Closing += OnClosing;
        }

        private void OnClosing(object sender, CancelEventArgs e)
        {

        }

        public Customer CurrentCustomer { get; set; }
        public CustomerForm(Customer customer) : this()
        {
            CurrentCustomer = customer;
            Text = "Modify Customer";
            txtCPR.Text = customer.CPR;
            txtName.Text = customer.Name;
            txtLoan.Text = customer.Loan.ToString();
        }

        //when confirm button clicked
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            int x = 0;
            try
            {
                x = Convert.ToInt32(txtLoan.Text);
            }
            catch (Exception exception)
            {
                MessageBox.Show("Enter Int Value in loan!");
                return;
            }
            CurrentCustomer.CPR = txtCPR.Text;
            CurrentCustomer.Name = txtName.Text;
            CurrentCustomer.Loan = x;

            //closing form
            Close();
        }
    }
}
