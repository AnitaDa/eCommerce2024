using Models.Color;
using Models.Product;

namespace Models.OrderDetails
{
    public class MOrderDetails
    {
        public MProduct? Product { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public MColor? Color { get; set; }
    }
}
