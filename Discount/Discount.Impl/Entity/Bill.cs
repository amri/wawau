namespace Discount.Impl.Entity
{
    public class Bill
    {
        private readonly Impl.User _user;

        public Bill(Impl.User user)
        {
            _user = user;
        }

        public decimal Total { get; set; }
    }
}