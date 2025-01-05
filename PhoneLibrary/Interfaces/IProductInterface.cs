using PhoneLibrary.Models;
namespace PhoneLibrary.Interfaces
{
    public interface IProductInterface
    {
        Task<List<Product>> GetProductList(bool featured);
        Task<MyResponse> CreateProductRecords(Product product);
    }
}
