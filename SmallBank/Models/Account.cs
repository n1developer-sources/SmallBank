using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallBank.Models
{
    //account class
    public class Account
    {
        //primary key
        [Key]
        public int Id { get; set; }
        public int Balance { get; set; }

        //value to put in database
        public int Type
        {
            get => AccountType == AccountType.Budget ? 1 : 2;
            set => AccountType = value == 1 ? AccountType.Budget : AccountType.Payroll;
        }

        //shared account
        public bool Shared { get; set; }

        //account type for friendly code usage
        [NotMapped]
        public AccountType AccountType { get; set; }
    }

    //account type
    public enum AccountType
    {
        Payroll,
        Budget
    }
}
