
using System.Collections.Generic;

namespace PromotionEngine
{
    public interface IPromotionEngine
    {
        decimal CalculateDiscount(List<string> skus);
    }
}
