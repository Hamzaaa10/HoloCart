namespace HoloCart.Data.Entities
{


    public class Payment
    {
        public int PaymentId { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }
        public PaymentMethod PaymentMethod { get; set; }

        // One-to-one: Each order has one payment.
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
    }

    public enum PaymentMethod
    {
        CreditCard,
        Paypal,
        BankTransfer
    }



}