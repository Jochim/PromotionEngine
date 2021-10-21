using PromotionEngine;
using System.Collections.Generic;
using Xunit;

namespace PromotionEngineTests
{
    public class CartTests
    {
        //Sku unit prices.
        private static readonly Dictionary<string, decimal> unitPrices = new() { ["A"] = 50, ["B"] = 30, ["C"] = 20, ["D"] = 15 };

        [Fact]
        public void CanAddItemsToCart()
        {
            var cart = new Cart();
            var testItems = new List<string> { "A", "B", "C" };
            cart.AddItems(testItems);
            Assert.Equal(cart.GetItems(), testItems);
        }

        [Fact]
        public void CanAddDuplicateItemsToCast()
        {
            var cart = new Cart();
            var testItems = new List<string> { "A", "A", "B", "C" };
            cart.AddItems(testItems);
            Assert.Equal(cart.GetItems(), testItems);
        }

        [Fact]
        public void CanClearCart()
        {
            var cart = new Cart();
            var testItems = new List<string> { "A", "B", "C" };
            cart.AddItems(testItems);
            Assert.Equal(cart.GetItems(), testItems);
            cart.ClearCart();
            Assert.Empty(cart.GetItems());
        }

        [Fact]
        public void CartCalculatesTotalWhenEmpty()
        {
            var cart = new Cart(unitPrices);
            Assert.Equal(0, cart.Total);
        }

        [Fact]
        public void CartCalculatesTotalWhenEmptied()
        {
            var cart = new Cart(unitPrices);
            var testItems = new List<string> { "A", "B", "C" };
            cart.AddItems(testItems);            
            cart.ClearCart();
            
            Assert.Equal(0, cart.Total);
        }

        [Fact]
        public void CartCalculatesTotal()
        {
            var cart = new Cart(unitPrices);
            var testItems = new List<string> { "A", "B", "C" };
            cart.AddItems(testItems);
            cart.ClearCart();
            var expectedTotal = unitPrices["A"] + unitPrices["B"] + unitPrices["C"];
            Assert.Equal(expectedTotal, cart.Total);
        }
        
    }
}
