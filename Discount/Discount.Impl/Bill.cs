namespace Discount.Impl
{
    public class Bill
    {
        private readonly User _user;

        public Bill(User user)
        {
            _user = user;
        }

        public decimal Total { get; set; }
    }
}