namespace Discount.Impl.DiscountStrategy
{
    public class AffiliateStrategy : AbstractDiscountStrategy
    {
        protected override decimal ApplyCustomDiscount(decimal sale)
        {
            return 0.9m * sale;
        }
    }
}