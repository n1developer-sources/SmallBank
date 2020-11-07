using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using SmallBank.DbContext;
using SmallBank.Models;
using SmallBank.Windows;

namespace SmallBank
{
    public partial class MainWindow : Form
    {
        //database context object, to understand better learn entity framework
        private readonly CustomerDbContext _context;

        //constructor
        public MainWindow()
        {
            InitializeComponent();
            dgv.AutoGenerateColumns = false;
            CustomerDbContext.CurrentCustomerDbContext = new CustomerDbContext();
            _context = CustomerDbContext.CurrentCustomerDbContext;
            _context.Database.EnsureCreated();
            _context.Customers.Load();
            LoadData();
        }

        //load data into the data grid view
        public void LoadData()
        {
            BindingSource s = new BindingSource();
            dgv.DataSource = s;
            s.DataSource = _context.Customers.Include(c => c.Account).ToList();
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
                _context.Customers.Add(f.CurrentCustomer);

                //save changes to database
                _context.SaveChanges();

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
                int id = Convert.ToInt16(dgv.SelectedRows[0].Cells[0].Value);

                //getting customer object from database, using id
                var customer = _context.Customers.Include(c => c.Account).FirstOrDefault(c => c.Id == id);

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
                _context.Customers.Remove(GetSelectCustomer());
                _context.SaveChanges();
                LoadData();
            }
            catch (Exception exception)
            {

            }
        }

        //it will return selected customer in data grid view
        private Customer GetSelectCustomer()
        {
            int x = Convert.ToInt16(dgv.SelectedRows[0].Cells[0].Value);
            var customer = _context.Customers.FirstOrDefault(c => c.Id == x);

            return customer;
        }

        //when modify customer button clicked, this method will be fired
        private void btnModifyCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                var customer = GetSelectCustomer();

                CustomerForm f = new CustomerForm(customer);
                f.ShowDialog();

                if (f.CurrentCustomer.Name.Equals("")) return;
                if (f.CurrentCustomer.CPR.Equals("")) return;
                customer.Name = f.CurrentCustomer.Name;
                customer.CPR = f.CurrentCustomer.CPR;
                customer.Loan = f.CurrentCustomer.Loan;
                _context.SaveChanges();
                LoadData();
            }
            catch (Exception ex)
            {

            }
        }

        //when modify account button clicked, this method will be fired
        private void btnModifyAccount_Click(object sender, EventArgs e)
        {
            var win = new AccountPicker();

            win.ShowDialog();

            if (win.CurrentAccount == null) return;

            try
            {
                var customer = GetSelectCustomer();
                customer.Account = win.CurrentAccount;

                _context.SaveChanges();
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

            int x = Convert.ToInt16(dgv.SelectedRows[0].Cells[0].Value);
            var customer = _context.Customers.Include(c => c.Account).FirstOrDefault(c => c.Id == x);

            try
            {
                if (customer.Account == null)
                {
                    MessageBox.Show("Customer have no account");
                    return;
                }

                customer.Account.Balance = balance;
                _context.SaveChanges();
                LoadData();
            }
            catch (Exception exception)
            {

            }
        }
    }
}
