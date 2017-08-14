namespace Discount.Impl.DiscountStrategy
{
    public class EmployeeDiscountStrategy : AbstractDiscountStrategy
    {
        public override decimal ApplyPercentageDiscount(decimal sale)
        {
            return 0.7m * sale;
        }
    }
}