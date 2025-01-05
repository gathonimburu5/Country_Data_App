using Microsoft.EntityFrameworkCore;
using PhoneBackend.Data;
using PhoneLibrary.Interfaces;
using PhoneLibrary.Models;

namespace PhoneBackend.Repository
{
    public class ProductService : IProductInterface
    {
        private readonly ApplicationContextDb context;
        public ProductService(ApplicationContextDb context)
        {
            this.context = context;
        }
        public async Task<MyResponse> CreateProductRecords(Product product)
        {
            MyResponse response = new MyResponse();
            using (var trans = context.Database.BeginTransaction())
            {
                try
                {
                    var checkingNameExist = context.Products.FirstOrDefault(x => x.Name == product.Name);
                    if(checkingNameExist != null)
                    {
                        response.Code = 400;
                        response.Message = "product name must be unique";
                        return response;
                    }
                    Product prod = new Product
                    {
                        Name = product.Name,
                        Description = product.Description,
                        Price = product.Price,
                        Quantity = product.Quantity,
                        ProductImage = product.ProductImage,
                        IsFeatured = product.IsFeatured,
                        CreatedOn = DateTime.UtcNow
                    };
                    await context.Products.AddAsync(prod);
                    await context.SaveChangesAsync();
                    trans.Commit();
                    response.Code = 200;
                    response.Message = "product records successfully created.";
                    return response;
                }
                catch (Exception e)
                {
                    trans.Rollback();
                    context.Dispose();
                    response.Code = 400;
                    response.Message = "failed to create product records!!";
                    throw e;
                    return response;
                }
            }
        }

        public async Task<List<Product>> GetProductList(bool featured)
        {
            if (featured) return await context.Products.Where(x => x.IsFeatured == featured).ToListAsync();
            else return await context.Products.Where(y => y.IsFeatured == featured).ToListAsync();
        }
    }
}
