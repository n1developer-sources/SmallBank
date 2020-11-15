using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging.Abstractions;

namespace SmallBank.Models
{

    //customer object
    public class Customer
    {
        //primary key
        public int Id { get; set; }
        public string Name { get; set; }
        public string CPR { get; set; }
        public int Loan { get; set; }

        //temp balance to show in data grid view
        public int Balance => Account?.Balance ?? 0;

        //customer account
        public Account Account { get; set; }
    }
}
