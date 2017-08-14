namespace Discount.Impl.DiscountStrategy
{
    public abstract class AbstractDiscountStrategy
    {
        protected abstract decimal ApplyCustomDiscount(decimal sale);

        public decimal ApplyDiscount(decimal sale)
        {
            var quotient = (int)sale / 100;
            var basicSale = sale - (quotient * 5);
            return ApplyCustomDiscount(basicSale);
        }
    }
}