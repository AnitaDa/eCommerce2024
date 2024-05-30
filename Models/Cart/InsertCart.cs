namespace Models.Cart
{
    public class InsertCart
    {
        public required int CustomerId { get; set; }
        public List<InsertCartItem>? CartItems { get; set; }
    }
}
