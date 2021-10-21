using PromotionEngine;
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

    }
}
