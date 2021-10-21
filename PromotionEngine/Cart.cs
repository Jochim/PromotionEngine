using System.Collections.Generic;
using System.Linq;

namespace PromotionEngine
{
    /// <summary>
    /// Group and manage lists of skus.
    /// </summary>
    public class Cart
    {
        private List<string> _skus = new();
        private readonly Dictionary<string, decimal> _unitPrices = new();

        public decimal Total => _skus.Sum(sku => _unitPrices[sku]);
        
        public Cart(Dictionary<string, decimal> unitPrices) => _unitPrices = unitPrices;         

        public void AddItems(List<string> skus)
        {
            _skus.AddRange(skus);
        }

        public List<string> GetItems()
        {
            return new(_skus);
        }

        public void ClearCart()
        {
            _skus = new();
        }

    }
}
