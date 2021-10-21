using System;
using System.Collections.Generic;

namespace PromotionEngine
{
    /// <summary>
    /// Group and manage lists of skus.
    /// </summary>
    public class Cart
    {
        private List<string> _skus = new();

        public void AddItems(List<string> skus)
        {
            _skus.AddRange(skus);
        }

        public List<string> GetItems()
        {
            return new(_skus);
        }
    }
}
