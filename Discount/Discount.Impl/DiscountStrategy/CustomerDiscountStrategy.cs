using System;
using Discount.Impl.Entity.User;

namespace Discount.Impl.DiscountStrategy
{
    public class CustomerDiscountStrategy : AbstractDiscountStrategy
    {
        private Customer _customer;

        public CustomerDiscountStrategy(Customer customer)
        {
            _customer = customer;
        }

        public override decimal ApplyPercentageDiscount(decimal sale)
        {
            if(DateTime.Now.Year - _customer.JoinedDate.Year >= 2)
                return 0.95m * sale;
            return sale;
        }
    }
}