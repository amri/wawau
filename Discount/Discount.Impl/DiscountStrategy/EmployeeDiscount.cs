namespace Discount.Impl.DiscountStrategy
{
    public class EmployeeDiscount : IDiscountStrategy
    {
        public decimal ApplyDiscount(decimal sale)
        {
            return 0.7m * sale;
        }
    }
}