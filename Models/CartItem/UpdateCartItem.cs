namespace Models.Cart
{
    public class UpdateCartItem
    {
        public int? Id { get; set; }

        public int? ProductId { get; set; }

        public int? Quantity { get; set; }

        public decimal? Price { get; set; }
    }
}
