using System.Collections.Generic;
using System.Linq;

namespace PromotionEngine
{
    public class PromotionsEngine : IPromotionEngine
    {
        private readonly List<IPromotionRule> _promotionRules;
        public PromotionsEngine(List<IPromotionRule> promotionRules)
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
