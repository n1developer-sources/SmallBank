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
using SmallBank.Windows;

namespace SmallBank
{
    public partial class MainWindow : Form
    {
        //constructor
        public MainWindow()
        {
            InitializeComponent();
            dgv.AutoGenerateColumns = false;
            AddDumpCustomers();
            LoadData();
        }

        //load data into the data grid view
        public void LoadData()
        {
            BindingSource s = new BindingSource();
            dgv.DataSource = s;
            s.DataSource = Customers;
        }

        //when add new customer button clicked, this method going to fire
        private void btnAddNewCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                CustomerForm f = new CustomerForm();
                f.ShowDialog();

                if (f.CurrentCustomer == null) return;

                if (f.CurrentCustomer.Name.Equals("")) return;
                if (f.CurrentCustomer.CPR.Equals("")) return;

                AddCustomer(f.CurrentCustomer);

                //refresh the data
                LoadData();
            }
            catch (Exception exception)
            {

            }
        }

        //when row selection changed, we have to update the balance in the text field
        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                var customer = GetSelectCustomer();

                txtBalance.Text = customer.Account.Balance.ToString();
                btnUpdateAccountBalance.Enabled = true;
                txtBalance.Enabled = true;
            }
            catch (Exception exception)
            {
                txtBalance.Enabled = false;
                txtBalance.Text = "No Account";
                btnUpdateAccountBalance.Enabled = false;
            }
        }

        //when delete button clicked this method will going to fire
        private void btnDeleteCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                DeleteCustomer(GetSelectCustomer());
                LoadData();
            }
            catch (Exception exception)
            {

            }
        }

        //it will return selected customer in data grid view
        private Customer GetSelectCustomer()
        {
            try
            {
                int x = Convert.ToInt16(dgv.SelectedRows[0].Cells[0].Value);

                return GetCustomerById(x);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        //when modify customer button clicked, this method will be fired
        private void btnModifyCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                var customer = GetSelectCustomer();

                CustomerForm f = new CustomerForm(customer);
                f.ShowDialog();

                if (f.CurrentCustomer == null)
                    return;

                customer.Name = f.CurrentCustomer.Name;
                customer.CPR = f.CurrentCustomer.CPR;
                customer.Loan = f.CurrentCustomer.Loan;

                UpdateCustomer(customer);

                LoadData();
            }
            catch (Exception ex)
            {

            }
        }

        //when modify account button clicked, this method will be fired
        private void btnModifyAccount_Click(object sender, EventArgs e)
        {
            if (GetSelectCustomer() == null)
            {
                return;
            }

            var win = new AccountPicker();

            win.ShowDialog();

            if (win.CurrentAccount == null) return;

            try
            {
                var customer = GetSelectCustomer();

                customer.Account = win.CurrentAccount;

                UpdateCustomer(customer);

                LoadData();
            }
            catch (Exception exception)
            {

            }
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {

        }



        //when update account button clicked, this method will be fired
        private void btnUpdateAccountBalance_Click(object sender, EventArgs e)
        {
            int balance = 0;

            try
            {
                balance = Convert.ToInt32(txtBalance.Text);
            }
            catch (Exception exception)
            {
                MessageBox.Show("Enter Corrent Balance");
                return;
            }

            var customer = GetSelectCustomer();

            try
            {
                if (customer.Account == null)
                {
                    MessageBox.Show("Customer have no account");
                    return;
                }

                customer.Account.Balance = balance;

                UpdateCustomer(customer);

                LoadData();
            }
            catch (Exception exception)
            {

            }
        }

        public static readonly List<Customer> Customers = new List<Customer>();

        //add customer at startup
        private void AddDumpCustomers()
        {
            var a = new Account { AccountType = AccountType.Budget, Shared = true, Id = 1, Balance = 1200 };

            var c1 = new Customer
            {
                Id = 1,
                Account = a,
                CPR = "CPR",
                Loan = 1100,
                Name = "Customer 1"
            };

            var c2 = new Customer
            {
                Id = 2,
                Account = a,
                CPR = "CPR",
                Loan = 1100,
                Name = "Customer 2"
            };

            Customers.Add(c1);
            Customers.Add(c2);
        }

        //find customer by id
        private Customer GetCustomerById(int id)
        {
            return Customers.FirstOrDefault(c => c.Id == id);
        }

        //delete customer
        private void DeleteCustomer(Customer customer)
        {
            Customers.Remove(customer);
        }

        //update customer data
        private void UpdateCustomer(Customer newCustomer)
        {
            for (var x = 0; x < Customers.Count; x++)
            {
                if (Customers[x].Id != newCustomer.Id) continue;

                Customers[x] = newCustomer;

                return;
            }
        }

        //add new customer in the list
        private void AddCustomer(Customer newCustomer)
        {
            var lastId = Customers.OrderByDescending(c => c.Id).FirstOrDefault()?.Id + 1 ?? 1;

            newCustomer.Id = lastId;

            Customers.Add(newCustomer);
        }
    }
}
