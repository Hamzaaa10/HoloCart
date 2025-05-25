namespace HoloCart.Data.Entities
{
    public class CartItem
    {
        public int CartItemId { get; set; }

        public int CartId { get; set; }
        public virtual Cart Cart { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int? ProductColorId { get; set; } // <- Add this
        public virtual ProductColor ProductColor { get; set; }
        public int Quantity { get; set; }
    }
}

