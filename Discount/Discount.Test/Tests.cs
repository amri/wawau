using System;
using Discount.Impl;
using Discount.Impl.Builder;
using Discount.Impl.Entity;
using Discount.Impl.Entity.User;
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
            var user = userBuilder.CreateUser<Employee>().Build();
            var invoice = new Invoice();
            Product purchasedItem = new Product(90,ProductType.NonGrocery);
            invoice.CreateInvoice(user);
            invoice.Buy(purchasedItem);
            var bill = invoice.Bill();
            Assert.AreEqual(63m,bill.Total);
        }
        
        [Test]
        public void GivenAnAffiliate_ThenReceive10pctDiscount()
        {
            var userBuilder = new UserBuilder();
            var user = userBuilder.CreateUser<Affiliate>().Build();
            var invoice = new Invoice();
            Product purchasedItem = new Product(90, ProductType.NonGrocery);
            invoice.CreateInvoice(user);
            invoice.Buy(purchasedItem);
            var bill = invoice.Bill();
            Assert.AreEqual(81m,bill.Total);
        }
        
        [Test]
        public void GivenACustomer_WhenJoinedMoreThan2Years_ThenReceive5pctDiscount()
        {
            var userBuilder = new UserBuilder();
            var user = userBuilder.CreateUser<Customer>().AddJoinDate(DateTime.Now.AddYears(-2)).Build();
            var invoice = new Invoice();
            Product purchasedItem = new Product(90, ProductType.NonGrocery);
            invoice.CreateInvoice(user);
            invoice.Buy(purchasedItem);
            var bill = invoice.Bill();
            Assert.AreEqual(85.5m,bill.Total);
        }
        
        [Test]
        public void GivenEvery100s_ThenApply5DiscountEach()
        {
            var userBuilder = new UserBuilder();
            var user = userBuilder.CreateUser<Customer>().AddJoinDate(DateTime.Now.AddYears(-1)).Build();
            var invoice = new Invoice();
            Product purchasedItem = new Product(990m, ProductType.NonGrocery);
            invoice.CreateInvoice(user);
            invoice.Buy(purchasedItem);
            var bill = invoice.Bill();
            Assert.AreEqual(945m,bill.Total);
        }
        
        [Test]
        public void Given2MixedItemsPurchased_OnlyApplyDiscountsToNonGrocery()
        {
            var userBuilder = new UserBuilder();
            var user = userBuilder.CreateUser<Customer>().AddJoinDate(DateTime.Now.AddYears(-2)).Build();
            var invoice = new Invoice();
            Product nonGroceryItem = new Product(90m, ProductType.NonGrocery);
            Product groceryItem = new Product(90m, ProductType.Grocery);
            invoice.CreateInvoice(user);
            invoice.Buy(nonGroceryItem);
            invoice.Buy(groceryItem);
            var bill = invoice.Bill();
            Assert.AreEqual(170.5m,bill.Total);
        }
    }
}