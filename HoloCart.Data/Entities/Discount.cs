using System.ComponentModel.DataAnnotations;

namespace HoloCart.Data.Entities
{
    public class Discount
    {
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string Code { get; set; }

        public string Description { get; set; }

        [Required]
        public decimal DiscountPercentage { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public bool Active { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public virtual ICollection<ProductDiscount> ProductDiscounts { get; set; }
    }


}
