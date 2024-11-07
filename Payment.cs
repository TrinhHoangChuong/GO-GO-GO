namespace Libs
{
    public class Payment
    {
        public string PaymentID { get; set; }
        public double Amount { get; set; }
        public string PaymentMethod { get; set; }
        public string PaymentStatus { get; set; }

        public Payment(string paymentID, double amount, string paymentMethod, string paymentStatus)
        {
            PaymentID = paymentID;
            Amount = amount;
            PaymentMethod = paymentMethod;
            PaymentStatus = paymentStatus;
        }
    }
}