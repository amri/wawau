using Discount.Impl.DiscountStrategy;

namespace Discount.Impl
{
    public class Invoice
    {
        private Bill _bill;
        private IDiscountStrategy _discountStrategy;
        
        public Invoice CreateInvoice(User user)
        {
            _bill = new Bill(user);
            if(user.GetType() == typeof(Employee))
            {
                _discountStrategy = new EmployeeDiscount();
            }
            else if(user.GetType() == typeof(Affiliate))
            {
                _discountStrategy = new AffiliateStrategy();
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
            _bill.Total = _discountStrategy.ApplyDiscount(_bill.Total);
            return _bill;
        }
    }
}