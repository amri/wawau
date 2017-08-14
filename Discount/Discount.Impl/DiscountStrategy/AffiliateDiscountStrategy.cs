namespace Discount.Impl.DiscountStrategy
{
    public class AffiliateDiscountStrategy : AbstractDiscountStrategy
    {
        public override decimal ApplyPercentageDiscount(decimal sale)
        {
            return 0.9m * sale;
        }
    }
}