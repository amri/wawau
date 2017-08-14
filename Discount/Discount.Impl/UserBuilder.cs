namespace Discount.Impl
{
    public class UserBuilder
    {
        private User _user;

        public UserBuilder CreateUser(UserType userType)
        {
            if (userType == UserType.Employee)
            {
                _user = new Employee();
            }
            else if(userType == UserType.Affiliate)
            {
                _user = new Affiliate();
            }
            return this;
        }

        public User Build()
        {
            return _user;
        }
    }
}