using System.Collections.Generic;

namespace PromotionEngine
{
    public interface IPromotionRule
    {
        public bool IsMatch(List<string> skus);
        public decimal CalculateDiscount(List<string> skus);       
    }  
}
