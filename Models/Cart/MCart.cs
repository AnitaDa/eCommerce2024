using Models.CartItem;

namespace Models.Cart
{
    public class MCart
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<MCartItem>? CartItems { get; set; }
    }
}
