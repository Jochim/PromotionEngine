using PromotionEngine;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PromotionEngineTests
{
    static class PromotionEngineTestData
    {
        //Sku unit prices.
        public static readonly Dictionary<string, decimal> unitPrices = new() { ["A"] = 50, ["B"] = 30, ["C"] = 20, ["D"] = 15 };

        public static readonly Dictionary<string, IPromotionRule> promotionRules = new() {
            ["AAA"] = new PromotionRule(promotionCondition: skus => skus.Count(sku => sku == "A") >= 3,
                promotionDiscount: skus => 130 * Math.Floor(skus.Count(sku => sku == "A") / 3m)),

            ["BB"] = new PromotionRule(promotionCondition: skus => skus.Count(sku => sku == "B") >= 2,
                promotionDiscount: skus => 45 * Math.Floor(skus.Count(sku => sku == "B") / 2m)),

            ["CD"] = new PromotionRule(promotionCondition: skus => skus.Any(sku => sku == "C") && skus.Any(sku => sku == "D"),
                promotionDiscount: skus => 30 * Math.Min(skus.Count(sku => sku == "C"), skus.Count(sku => sku == "D")))
        };

        public static readonly IPromotionEngine promotionEngine = new PromotionsEngine(promotionRules.Values.ToList());
        
    }
}
