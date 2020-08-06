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
        public void AddToCartTEST()
        {
            List<Product> foodMenu = new List<Product>();
            foodMenu.Add(new Product("Quarter Pounder w/ cheese", CategoryList.Food, "1/4 lb patty with cheese", 3.99));
            Dictionary<Product, int> shoppingCart = new Dictionary<Product, int>();
            shoppingCart[foodMenu[0]] = 3;
            Dictionary<Product, int> cartResult = Cart.AddToCart(foodMenu[0], 3);
            Assert.Equal(shoppingCart, cartResult);
        }
        [Fact]
        public void QuantityCostTEST2()
        {
            List<Product> foodMenu = new List<Product>();
            foodMenu.Add(new Product("Quarter Pounder w/ cheese", CategoryList.Food, "1/4 lb patty with cheese", 3.99));
            double quantityResult = Cart.GetQuantityCost(foodMenu[0].Price, 5);
            Assert.Equal(19.95, Math.Round(quantityResult, 2));
        }
        [Fact]
        public void SubtotalTEST()
        {
            List<Product> foodMenu = new List<Product>();
            foodMenu.Add(new Product("Quarter Pounder w/ cheese", CategoryList.Food, "1/4 lb patty with cheese", 3.99));
            Dictionary<Product, int> shoppingCart = Cart.AddToCart(foodMenu[0], 3);
            double subTotalResult = Cart.GetCartSubTotal(shoppingCart);
            Assert.Equal(11.97, subTotalResult);
        }
        [Fact]
        public void SalexTaxTEST()
        {
            List<Product> foodMenu = new List<Product>();
            foodMenu.Add(new Product("Quarter Pounder w/ cheese", CategoryList.Food, "1/4 lb patty with cheese", 3.99));
            Dictionary<Product, int> shoppingCart = Cart.AddToCart(foodMenu[0], 2);
            double subTotal = Cart.GetCartSubTotal(shoppingCart);
            double result = Cart.GetSalesTax(subTotal);
            Assert.Equal(.48, Math.Round(result, 2));
        }
        [Fact]
        public void GrandTotalTEST()
        {
            List<Product> foodMenu = new List<Product>();
            foodMenu.Add(new Product("Quarter Pounder w/ cheese", CategoryList.Food, "1/4 lb patty with cheese", 3.99));
            Dictionary<Product, int> shoppingCart = Cart.AddToCart(foodMenu[0], 2);
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
