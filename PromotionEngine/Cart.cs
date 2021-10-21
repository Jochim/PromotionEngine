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
        private readonly IPromotionEngine _engine;

        public decimal Total => SubTotal - Discount;
        public decimal SubTotal => _skus.Sum(sku => _unitPrices[sku]);
        public decimal Discount { get => _engine?.CalculateDiscount(_skus) ?? 0; }

        // We can have a cart without having any promotions
        public Cart(Dictionary<string, decimal> unitPrices) => _unitPrices = unitPrices;
        
        public Cart(Dictionary<string, decimal> unitPrices, IPromotionEngine engine)
        {
            _unitPrices = unitPrices;
            _engine = engine;
        }

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
