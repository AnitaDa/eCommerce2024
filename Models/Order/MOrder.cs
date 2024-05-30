using Models.Customer;
using Models.OrderDetails;

namespace Models.Order
{
    public class MOrder
    {
        public int Id { get; set; }
        public List<MOrderDetails> OrderDetails { get; set; } = new List<MOrderDetails>();
        public DateOnly OrderDate { get; set; }
        public MCustomer? Customer { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
