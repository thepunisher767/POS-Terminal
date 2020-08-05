using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace POS_Terminal.TEST
{
    public class CartTEST
    {
        [Fact]
        public void QuantityCostTEST()
        {
            double result = Cart.GetQuantityCost(1.99, 3);
            Assert.Equal(5.97, result);
        }
        [Fact]
        public void AddToCartTEST() //No idea why this is failing, but it looks correct.
        {
            List<Product> foodMenu = new List<Product>();
            List<Product> shoppingCart2 = new List<Product>();
            shoppingCart2.Add(new Product("Quarter Pounder w/ cheese", CategoryList.Food, "1/4 lb patty with cheese", 3.99));
            shoppingCart2.Add(new Product("Quarter Pounder w/ cheese", CategoryList.Food, "1/4 lb patty with cheese", 3.99));
            shoppingCart2.Add(new Product("Quarter Pounder w/ cheese", CategoryList.Food, "1/4 lb patty with cheese", 3.99));
            foodMenu.Add(new Product("Quarter Pounder w/ cheese", CategoryList.Food, "1/4 lb patty with cheese", 3.99));
            List<Product> result = Cart.AddToCart(foodMenu[0], 3);
            Assert.Equal(shoppingCart2, result);
        }
        [Fact]
        public void QuantityCostTEST2()
        {
            List<Product> foodMenu = new List<Product>();
            foodMenu.Add(new Product("Quarter Pounder w/ cheese", CategoryList.Food, "1/4 lb patty with cheese", 3.99));
            double result = Cart.GetQuantityCost(foodMenu[0].Price, 5);
            Assert.Equal(19.95, Math.Round(result, 2));
        }
        [Fact]
        public void SubtotalTEST()
        {
            List<Product> shoppingCart = new List<Product>();
            shoppingCart.Add(new Product("Quarter Pounder w/ cheese", CategoryList.Food, "1/4 lb patty with cheese", 3.99));
            shoppingCart.Add(new Product("Quarter Pounder w/ cheese", CategoryList.Food, "1/4 lb patty with cheese", 3.99));
            shoppingCart.Add(new Product("Quarter Pounder w/ cheese", CategoryList.Food, "1/4 lb patty with cheese", 3.99));
            double result = Cart.GetCartSubTotal(shoppingCart);
            Assert.Equal(11.97, result);
        }
        [Fact]
        public void SalexTaxTEST()
        {
            List<Product> shoppingCart = new List<Product>();
            shoppingCart.Add(new Product("Quarter Pounder w/ cheese", CategoryList.Food, "1/4 lb patty with cheese", 3.99));
            shoppingCart.Add(new Product("Quarter Pounder w/ cheese", CategoryList.Food, "1/4 lb patty with cheese", 3.99));
            double subtotal = Cart.GetCartSubTotal(shoppingCart);
            double result = Cart.GetSalesTax(subtotal);
            Assert.Equal(.48, Math.Round(result, 2));
        }
        [Fact]
        public void GrandTotalTEST()
        {
            List<Product> shoppingCart = new List<Product>();
            shoppingCart.Add(new Product("Quarter Pounder w/ cheese", CategoryList.Food, "1/4 lb patty with cheese", 3.99));
            shoppingCart.Add(new Product("Quarter Pounder w/ cheese", CategoryList.Food, "1/4 lb patty with cheese", 3.99));
            double subTotal = Cart.GetCartSubTotal(shoppingCart);
            double salesTax = Cart.GetSalesTax(subTotal);
            double result = Cart.GrandTotal(subTotal, salesTax);
            Assert.Equal(8.46, Math.Round(result, 2));
        }
        [Fact]
        public void ReturnChangeTEST()
        {
            double result = Cart.ReturnChange(20, 8.46);
            Assert.Equal(11.54, Math.Round(result, 2));
        }
    }
}
