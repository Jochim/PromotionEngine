using System;
using System.Collections.Generic;

namespace PromotionEngine
{
    public class PromotionRule : IPromotionRule
    {
        private readonly Predicate<List<string>> _promotionCondition;       

        public PromotionRule(Predicate<List<string>> promotionCondition)
        {
            _promotionCondition = promotionCondition;
        }
        public bool IsMatch(List<string> skus)
        {
            return _promotionCondition(skus);
        }     
    }
}
