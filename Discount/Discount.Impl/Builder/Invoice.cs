using Discount.Impl.DiscountStrategy;
using Discount.Impl.Entity;
using Discount.Impl.Entity.User;

namespace Discount.Impl.Builder
{
    public class Invoice
    {
        private Bill _bill;
        private AbstractDiscountStrategy _abstractDiscountStrategy;
        
        public Invoice CreateInvoice(User user)
        {
            _bill = new Bill(user);
            if(user.GetType() == typeof(Employee))
            {
                _abstractDiscountStrategy = new EmployeeDiscountStrategy();
            }
            else if(user.GetType() == typeof(Affiliate))
            {
                _abstractDiscountStrategy = new AffiliateDiscountStrategy();
            }
            else if(user.GetType() == typeof(Customer))
            {
                _abstractDiscountStrategy = new CustomerDiscountStrategy(user as Customer);
            }
            return this;
        }
        
        public Invoice Buy(Product item)
        {
            var discountedPrice = (item.ProductType == ProductType.NonGrocery)
                ? _abstractDiscountStrategy.ApplyPercentageDiscount(item.Price)
                : item.Price;
            _bill.Total = _bill.Total + discountedPrice;
            return this;
        }
        
        public Bill Bill()
        {
            _bill.Total = _abstractDiscountStrategy.ApplyDiscount(_bill.Total);
            return _bill;
        }
    }
}