using System;
using Discount.Impl;
using NUnit.Framework;

namespace Discount.Test
{
    [TestFixture]
    public class Tests
    {
        //If a user is an employee of the store, he gets 30% discount
        [Test]
        public void GivenAnEmployee_ThenReceive30pctDiscount()
        {
            var userBuilder = new UserBuilder();
            var user = userBuilder.CreateUser(UserType.Employee).Build();
            var invoice = new Invoice();
            SaleItem purchasedItem = new SaleItem {Price = 100};
            invoice.CreateInvoice(user);
            invoice.Buy(purchasedItem);
            var bill = invoice.Bill();
            Assert.AreEqual(70m,bill.Total);
        }
        
        [Test]
        public void GivenAnAffiliate_ThenReceive10pctDiscount()
        {
            var userBuilder = new UserBuilder();
            var user = userBuilder.CreateUser(UserType.Affiliate).Build();
            var invoice = new Invoice();
            SaleItem purchasedItem = new SaleItem {Price = 100};
            invoice.CreateInvoice(user);
            invoice.Buy(purchasedItem);
            var bill = invoice.Bill();
            Assert.AreEqual(90m,bill.Total);
        }
    }
}