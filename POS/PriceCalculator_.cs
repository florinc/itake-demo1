using POS.DAL;

namespace POS
{
    public class PriceCalculator2 : IPriceCalulator
    {
        public decimal GetPrice(Product product)
        {
            decimal currentPrice = product.Price;

            bool regionalApplied = false;
            if (product.Tax.HasFlag(TaxingType.RegionalTax))
            {
                currentPrice = currentPrice + product.Price * 0.1m;
                regionalApplied = true;
            }

            if (product.Tax.HasFlag(TaxingType.Tva) && !regionalApplied)
            {
                currentPrice = currentPrice + product.Price * 0.22m;
            }

            if (product.Tax.HasFlag(TaxingType.Discount))
            {
                currentPrice = currentPrice - currentPrice * 0.3m;
            }

            if (currentPrice < 0)
                return 0;

            return currentPrice;
        }
    }
}