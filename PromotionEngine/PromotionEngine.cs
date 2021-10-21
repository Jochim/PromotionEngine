using System.Collections.Generic;
using System.Linq;

namespace PromotionEngine
{
    public class PromotionEngine : IPromotionEngine
    {
        private readonly List<IPromotionRule> _promotionRules;
        public PromotionEngine(List<IPromotionRule> promotionRules)
        {
            _promotionRules = promotionRules ?? new List<IPromotionRule>();
        }

        public decimal CalculateDiscount(List<string> skus)
        {
            var applicablePromotions = _promotionRules.Where(rule => rule.IsMatch(skus));
            return applicablePromotions.Sum(rule => rule.CalculateDiscount(skus));
        }
    }
}
