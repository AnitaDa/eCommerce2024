namespace Models.Cart
{
    public class InsertCartItem
    {
        public int? CartId { get; set; }

        public int? ProductId { get; set; }

        public int? Quantity { get; set; }

        public decimal? Price { get; set; }
    }
}
