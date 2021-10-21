using PromotionEngine;
using Xunit;

namespace PromotionEngineTests
{
    public class PromotionRuleTests
    {
        [Fact]
        public void RuleIsMatchIsTrue()
        {
            var promotionRule = new PromotionRule((skus)=> true);
            Assert.True(promotionRule.IsMatch(new()));
        }

        [Fact]
        public void RuleIsMatchIsFalse()
        {
            var promotionRule = new PromotionRule((skus) => false);
            Assert.False(promotionRule.IsMatch(new()));
        }

        


    }
}
