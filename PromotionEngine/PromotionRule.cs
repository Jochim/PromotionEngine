using System;
using System.Collections.Generic;

namespace PromotionEngine
{
    public class PromotionRule : IPromotionRule
    {
        private readonly Predicate<List<string>> _promotionCondition;
        private readonly Func<List<string>, Dictionary<string, decimal>, decimal> _promotionDiscount;
        private readonly Dictionary<string, decimal> _unitPrices;

        public PromotionRule(Predicate<List<string>> promotionCondition, Func<List<string>,
            Dictionary<string, decimal>, decimal> promotionDiscount,
            Dictionary<string, decimal> unitPrices)
        {
            _promotionCondition = promotionCondition;
            _promotionDiscount = promotionDiscount;
            _unitPrices = unitPrices;
        }
        public bool IsMatch(List<string> skus)
        {
            return _promotionCondition(skus);
        }

        public decimal CalculateDiscount(List<string> skus)
        {
            return _promotionDiscount(skus, _unitPrices);
        }
    }
}
