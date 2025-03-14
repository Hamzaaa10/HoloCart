namespace HoloCart.Data.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CategoryImage { get; set; }

        // Optional self-referencing for sub-categories
        public int? ParentCategoryId { get; set; }
        public virtual Category ParentCategory { get; set; }
        public virtual ICollection<Category> ChildCategories { get; set; }

        // One-to-many: A category has many products
        public virtual ICollection<Product> Products { get; set; }
    }
}
