using System;
using Discount.Impl.Entity;
using Discount.Impl.Entity.User;

namespace Discount.Impl.Builder
{
    public class UserBuilder
    {
        private User _user;

        public UserBuilder CreateUser<T>() where T:User
        {
            _user = Activator.CreateInstance(typeof(T)) as User;
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