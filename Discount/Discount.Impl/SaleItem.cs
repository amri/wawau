namespace Discount.Impl
{
    public class SaleItem
    {
        public SaleItem(decimal price, ItemType itemType)
        {
            Price = price;
            ItemType = itemType;
        }

        public decimal Price { get; }
        private ItemType ItemType { get; }
    }

    public enum ItemType
    {
        Grocery,
        NonGrocery
    }
}