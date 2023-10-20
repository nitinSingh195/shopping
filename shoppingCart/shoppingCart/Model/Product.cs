namespace shoppingCart.Model
{
    public class Product
    {

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductImage { get; set; }
        public string ProductDescription { get; set; }
        public decimal ProductPrice { get; set; }
        public decimal DiscountedPrice { get; set; }
    }
}
