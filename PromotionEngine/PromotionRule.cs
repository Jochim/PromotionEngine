using System;
using System.Collections.Generic;

namespace PromotionEngine
{
    public class PromotionRule : IPromotionRule
    {
        private readonly Predicate<List<string>> _promotionCondition;
        private readonly Func<List<string>, decimal> _promotionDiscount;        

        public PromotionRule(Predicate<List<string>> promotionCondition,
            Func<List<string>, decimal> promotionDiscount)
        {
            _promotionCondition = promotionCondition;
            _promotionDiscount = promotionDiscount;
        }
        public bool IsMatch(List<string> skus)
        {
            return _promotionCondition(skus);
        }

        public decimal CalculateDiscount(List<string> skus)
        {
            return _promotionDiscount(skus);
        }
    }
}
