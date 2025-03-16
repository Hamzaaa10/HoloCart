using HoloCart.Data.Entities;

namespace HoloCart.Core.Features.ProductFeatures.Command.Requests
{
    public class CreateProductCommand
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal BasePrice { get; set; }

        // Main image used on product listing
        public string MainImageUrl { get; set; }

        // FK to Category
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        // Optional discount
        public int? DiscountId { get; set; }
        public virtual Discount Discount { get; set; }
    }
}
