using System;

namespace Discount.Impl
{
    public class User
    {
    }

    public class Customer : User
    {
        public DateTime JoinedDate { get; set; }
    }

    public class Affiliate : User
    {
    }
}