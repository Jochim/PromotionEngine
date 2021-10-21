using PromotionEngine;
using Xunit;

namespace PromotionEngineTests
{
    public class PromotionRuleTests
    {
        [Fact]
        public void RuleIsMatchIsTrue()
        {
            var promotionRule = new PromotionRule((skus)=> true, null, null);
            Assert.True(promotionRule.IsMatch(new()));
        }

        [Fact]
        public void RuleIsMatchIsFalse()
        {
            var promotionRule = new PromotionRule((skus) => false, null, null);
            Assert.False(promotionRule.IsMatch(new()));
        }

        [Fact]
        public void RuleCalculatesExpectedDiscount()
        {
            var promotionRule = new PromotionRule((skus) => true, (skus, unitprice) => 10, null);
            Assert.Equal(10, promotionRule.CalculateDiscount(null));
        }


    }
}
