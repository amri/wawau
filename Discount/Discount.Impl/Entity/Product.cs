namespace Discount.Impl.Entity
{
    public class Product
    {
        public Product(decimal price, ProductType productType)
        {
            Price = price;
            ProductType = productType;
        }

        public decimal Price { get; }
        public ProductType ProductType { get; }
    }

    public enum ProductType
    {
        Grocery,
        NonGrocery
    }
}