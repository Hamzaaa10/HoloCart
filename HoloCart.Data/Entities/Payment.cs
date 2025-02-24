using System.ComponentModel.DataAnnotations.Schema;

namespace HoloCart.Data.Entities
{


    public class Payment
    {
        public int Id { get; set; }

        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        public virtual Order Order { get; set; }

        public PaymentMethod PaymentMethod { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Amount { get; set; }

        public DateTime PaymentDate { get; set; } = DateTime.Now;

        public PaymentStatus Status { get; set; }

    }
    public enum PaymentMethod
    {
        CreditCard,
        Paypal,
        BankTransfer
    }

    public enum PaymentStatus
    {
        Pending,
        Completed,
        Failed
    }

}