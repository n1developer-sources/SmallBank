using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using SmallBank.Models;

namespace SmallBank.DbContext
{
    class CustomerDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public static CustomerDbContext CurrentCustomerDbContext;
        public CustomerDbContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //configuring database here
            optionsBuilder.UseMySql(new MySqlConnectionStringBuilder()
            {
                Server = "localhost",
                Port = 3306,
                Database = "smallbank",
                UserID = "root",
                Password = ""
            }.ToString());
            base.OnConfiguring(optionsBuilder);
        }

        //customers database 
        public DbSet<Customer> Customers { get; set; }
    }
}
