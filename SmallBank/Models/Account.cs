namespace SmallBank.Models
{
    //account class
    public class Account
    {
        //primary key
        public int Id { get; set; }
        public int Balance { get; set; }

        //shared account
        public bool Shared { get; set; }

        //account type for friendly code usage
        public AccountType AccountType { get; set; }
    }

    //account type
    public enum AccountType
    {
        Payroll,
        Budget
    }
}
