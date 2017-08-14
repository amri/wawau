namespace Discount.Impl.DiscountStrategy
{
    public class EmployeeAbstractDiscount : AbstractDiscountStrategy
    {
        protected override decimal ApplyCustomDiscount(decimal sale)
        {
            return 0.7m * sale;
        }
    }
}