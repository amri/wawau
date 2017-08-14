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
            SaleItem purchasedItem = new SaleItem(90,ItemType.NonGrocery);
            invoice.CreateInvoice(user);
            invoice.Buy(purchasedItem);
            var bill = invoice.Bill();
            Assert.AreEqual(63m,bill.Total);
        }
        
        [Test]
        public void GivenAnAffiliate_ThenReceive10pctDiscount()
        {
            var userBuilder = new UserBuilder();
            var user = userBuilder.CreateUser(UserType.Affiliate).Build();
            var invoice = new Invoice();
            SaleItem purchasedItem = new SaleItem(90, ItemType.NonGrocery);
            invoice.CreateInvoice(user);
            invoice.Buy(purchasedItem);
            var bill = invoice.Bill();
            Assert.AreEqual(81m,bill.Total);
        }
        
        [Test]
        public void GivenACustomer_WhenJoinedMoreThan2Years_ThenReceive5pctDiscount()
        {
            var userBuilder = new UserBuilder();
            var user = userBuilder.CreateUser(UserType.Customer).AddJoinDate(DateTime.Now.AddYears(-2)).Build();
            var invoice = new Invoice();
            SaleItem purchasedItem = new SaleItem(90, ItemType.NonGrocery);
            invoice.CreateInvoice(user);
            invoice.Buy(purchasedItem);
            var bill = invoice.Bill();
            Assert.AreEqual(85.5m,bill.Total);
        }
        
        [Test]
        public void GivenEvery100s_ThenApply5DiscountEach()
        {
            var userBuilder = new UserBuilder();
            var user = userBuilder.CreateUser(UserType.Customer).AddJoinDate(DateTime.Now.AddYears(-1)).Build();
            var invoice = new Invoice();
            SaleItem purchasedItem = new SaleItem(990m, ItemType.NonGrocery);
            invoice.CreateInvoice(user);
            invoice.Buy(purchasedItem);
            var bill = invoice.Bill();
            Assert.AreEqual(945m,bill.Total);
        }
        
        [Test]
        public void GivenEvery100s_ThenApply5DiscountEach()
        {
            var userBuilder = new UserBuilder();
            var user = userBuilder.CreateUser(UserType.Customer).AddJoinDate(DateTime.Now.AddYears(-1)).Build();
            var invoice = new Invoice();
            SaleItem purchasedItem = new SaleItem(990m, ItemType.NonGrocery);
            invoice.CreateInvoice(user);
            invoice.Buy(purchasedItem);
            var bill = invoice.Bill();
            Assert.AreEqual(945m,bill.Total);
        }
    }
}