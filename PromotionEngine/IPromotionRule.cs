using System.Collections.Generic;

namespace PromotionEngine
{
        public interface IPromotionRule
        {
            bool IsMatch(List<string> skus);            
        }  
}
