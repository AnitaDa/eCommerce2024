using Models.Color;
using Models.Product;

namespace Models.CartItem
{
    public class MCartItem
    {
        public MProduct? Product { get; set; }
        public int Quantity { get; set; } = 0;
        public MColor? Color { get; set; }
    }
}
