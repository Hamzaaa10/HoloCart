namespace HoloCart.Data.Entities
{

    public class Discount
    {
        public int DiscountId { get; set; }
        public string Code { get; set; }
        public decimal Percentage { get; set; }  // For example, 15 means 15% off.
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        // A discount can be applied to many products.
        public virtual ICollection<Product> Products { get; set; }
    }

}
