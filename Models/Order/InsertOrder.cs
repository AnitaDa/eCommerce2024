using Models.Customer;
using Models.OrderDetails;

namespace Models.Order
{
    public class InsertOrder
    {
        public int? CustomerId { get; set; }
        public decimal TotalAmount { get; set; }
        public MCustomer? Customer { get; set; }                
        public List<MOrderDetails> OrderDetails { get; set; } = new List<MOrderDetails>();
    }
}
