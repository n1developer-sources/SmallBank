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

        private bool IsOkay = false;
        private void OnClosing(object sender, CancelEventArgs e)
        {
            if (!IsOkay)
                CurrentCustomer = null;
        }

        private (bool, string) ValidateCustomer(Customer cs)
        {
            //MessageBox.Show(cs.Id + "");
            if (IsInt(cs.Name))
                return (false, "Name can't be integer");

            foreach (var c in MainWindow.Customers)
            {
                if (c.Id == cs.Id)
                    continue;
                if (c.Name.ToLower().Trim().Equals(cs.Name.ToLower().Trim()) ||
                    c.CPR.ToLower().Trim().Equals(cs.CPR.ToLower().Trim()))
                    return (false, "Customer Already Exists!");
            }

            return (true, "");
        }
        private bool IsInt(string s)
        {
            try
            {
                Convert.ToInt64(s);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
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
            var (unique, message) = ValidateCustomer(new Customer(){Name = txtName.Text, CPR = txtCPR.Text, Id = CurrentCustomer.Id});

            if (!unique)
            {
                MessageBox.Show(message);
                return;
            }

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

            IsOkay = true;
            Close();
        }
    }
}
