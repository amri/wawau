namespace Discount.Impl.DiscountStrategy
{
    public class AffiliateStrategy : IDiscountStrategy
    {
        public decimal ApplyDiscount(decimal sale)
        {
            return 0.9m * sale;
        }
    }
}