using PromotionEngine;
using System.Collections.Generic;
using Xunit;

namespace PromotionEngineTests
{
    public class CartTests
    {
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
    }
}
