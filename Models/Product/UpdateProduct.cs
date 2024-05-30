namespace Models.Product
{
    public class UpdateProduct
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public int QuantityAvailable { get; set; }
        public int CategoryId { get; set; }
    }
}
