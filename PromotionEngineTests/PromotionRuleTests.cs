using PromotionEngine;
using System.Collections.Generic;
using Xunit;

namespace PromotionEngineTests
{
    public class PromotionRuleTests
    {
        [Fact]
        public void RuleIsMatchIsTrue()
        {
            var promotionRule = new PromotionRule((skus)=> true, null);
            Assert.True(promotionRule.IsMatch(new()));
        }

        [Fact]
        public void RuleIsMatchIsFalse()
        {
            var promotionRule = new PromotionRule((skus) => false, null);
            Assert.False(promotionRule.IsMatch(new()));
        }

        [Fact]
        public void RuleCalculatesExpectedDiscount()
        {
            var promotionRule = new PromotionRule((skus) => true, (skus) => 10);
            Assert.Equal(10, promotionRule.CalculateDiscount(null));
        }

        [Fact]
        public void RuleCalculatesExpectedDiscountForAGivenUnitPrice()
        {
            var promotionRule = new PromotionRule((skus) => true, (skus) => 10);
        }

        // With more time we'd refactor these into a data driven theory to avoid having to repeat the code for individual test cases.
        [Fact]
        public void AAAPromotionRuleReturnsNoDiscount()
        {
            var testSkus = new List<string> { "A", "B", "C"};
            var rule = PromotionEngineTestData.promotionRules["AAA"];

            var expectedDiscount = 0;
            var discount = rule.CalculateDiscount(testSkus);
            Assert.Equal(expectedDiscount, discount);
        }

        [Fact]
        public void AAAPromotionRuleReturnsExpectedDiscount()
        {
            var testSkus = new List<string> { "A", "A", "A", "B", "C" };
            var rule = PromotionEngineTestData.promotionRules["AAA"];

            var expectedDiscount = 130;
            var discount = rule.CalculateDiscount(testSkus);
            Assert.Equal(expectedDiscount, discount);
        }

        [Fact]
        public void AAAPromotionRuleReturnsExpectedDiscountWithMultipleMatches()
        {
            var testSkus = new List<string> { "A", "A", "A", "A", "A", "A", "B", "C" };
            var rule = PromotionEngineTestData.promotionRules["AAA"];

            var expectedDiscount = 260;
            var discount = rule.CalculateDiscount(testSkus);
            Assert.Equal(expectedDiscount, discount);
        }      
    }
}
