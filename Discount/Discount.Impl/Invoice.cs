using System.Collections;
using Discount.Impl.DiscountStrategy;

namespace Discount.Impl
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
                _abstractDiscountStrategy = new EmployeeAbstractDiscount();
            }
            else if(user.GetType() == typeof(Affiliate))
            {
                _abstractDiscountStrategy = new AffiliateStrategy();
            }
            else if(user.GetType() == typeof(Customer))
            {
                _abstractDiscountStrategy = new CustomerStrategy(user as Customer);
            }
            return this;
        }
        
        public Invoice Buy(SaleItem item)
        {
            _bill.Total = _bill.Total + item.Price;
            return this;
        }
        
        public Bill Bill()
        {
            _bill.Total = _abstractDiscountStrategy.ApplyDiscount(_bill.Total);
            return _bill;
        }
    }
}