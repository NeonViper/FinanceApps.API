namespace FinanceApp.API.Models
{
    public class Account
    {
        public int Id { get; set; }
        public double CreditLimit { get; set; }
        public double Balance { get; set; }
        public double Available { get; set; }
    }
}