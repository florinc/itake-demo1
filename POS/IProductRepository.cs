using POS.DAL;

namespace POS
{
    public interface IProductRepository
    {
        Product GetProduct(string barcode);
    }
}