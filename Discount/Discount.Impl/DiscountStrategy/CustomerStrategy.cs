using System;

namespace Discount.Impl.DiscountStrategy
{
    public class CustomerStrategy : AbstractDiscountStrategy
    {
        private Customer _customer;

        public CustomerStrategy(Customer customer)
        {
            _customer = customer;
        }

        protected override decimal ApplyCustomDiscount(decimal sale)
        {
            if(DateTime.Now.Year - _customer.JoinedDate.Year >= 2)
                return 0.95m * sale;
            return sale;
        }
    }
}