namespace Discount.Impl.DiscountStrategy
{
    public interface IDiscountStrategy
    {
        decimal ApplyDiscount(decimal sale);
    }
}