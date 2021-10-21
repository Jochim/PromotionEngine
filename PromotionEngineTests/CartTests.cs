using PromotionEngine;
using System.Collections.Generic;
using Xunit;

namespace PromotionEngineTests
{
    public class CartTests {           

        [Fact]
        public void CanAddItemsToCart()
        {
            var cart = new Cart(PromotionEngineTestData.unitPrices);
            var testItems = new List<string> { "A", "B", "C" };
            cart.AddItems(testItems);
            Assert.Equal(cart.GetItems(), testItems);
        }

        [Fact]
        public void CanAddDuplicateItemsToCast()
        {
            var cart = new Cart(PromotionEngineTestData.unitPrices);
            var testItems = new List<string> { "A", "A", "B", "C" };
            cart.AddItems(testItems);
            Assert.Equal(cart.GetItems(), testItems);
        }

        [Fact]
        public void CanClearCart()
        {
            var cart = new Cart(PromotionEngineTestData.unitPrices);
            var testItems = new List<string> { "A", "B", "C" };
            cart.AddItems(testItems);
            Assert.Equal(cart.GetItems(), testItems);
            cart.ClearCart();
            Assert.Empty(cart.GetItems());
        }

        [Fact]
        public void CartCalculatesTotalWhenEmpty()
        {
            var cart = new Cart(PromotionEngineTestData.unitPrices);
            Assert.Equal(0, cart.Total);
        }

        [Fact]
        public void CartCalculatesTotalWhenEmptied()
        {
            var cart = new Cart(PromotionEngineTestData.unitPrices);
            var testItems = new List<string> { "A", "B", "C" };
            cart.AddItems(testItems);            
            cart.ClearCart();            
            Assert.Equal(0, cart.Total);
        }

        [Fact]
        public void CartCalculatesTotal()
        {
            var cart = new Cart(PromotionEngineTestData.unitPrices);
            var testItems = new List<string> { "A", "B", "C" };
            cart.AddItems(testItems);            
            var expectedTotal = PromotionEngineTestData.unitPrices["A"] + PromotionEngineTestData.unitPrices["B"] + PromotionEngineTestData.unitPrices["C"];
            Assert.Equal(expectedTotal, cart.Total);
        }

        [Fact]
        public void CartCalculatesDiscount()
        {
            var cart = new Cart(PromotionEngineTestData.unitPrices, PromotionEngineTestData.promotionEngine);
            var testItems = new List<string> { "A", "A", "A", "B", "C" };
            cart.AddItems(testItems);
            var expectedDiscount = PromotionEngineTestData.unitPrices["A"] * 3 - 130;
            Assert.Equal(expectedDiscount, cart.Discount);
        }

        [Fact]
        public void CartAppliesDiscountToTotal()
        {
            var cart = new Cart(PromotionEngineTestData.unitPrices, PromotionEngineTestData.promotionEngine);
            var testItems = new List<string> { "A", "A", "A", "B", "C" };
            cart.AddItems(testItems);
            var expectedTotal = 130 + PromotionEngineTestData.unitPrices["B"] + PromotionEngineTestData.unitPrices["C"];
            Assert.Equal(expectedTotal, cart.Total);
        }

    }
}
