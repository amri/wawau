using System;

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
            else if(userType == UserType.Customer)
            {
                _user = new Customer();
            }
            return this;
        }

        public UserBuilder AddJoinDate(DateTime joinedDateTime)
        {
            var customer = _user as Customer;
            customer.JoinedDate = joinedDateTime;
            return this;
        }

        public User Build()
        {
            return _user;
        }
    }
}