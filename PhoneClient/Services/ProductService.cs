using PhoneLibrary.Interfaces;
using PhoneLibrary.Models;

namespace PhoneClient.Services
{
    public class ProductService(IHttpHelperClass helperClass, HttpClient client) : IProductInterface
    {
        //private const string BaseUrl = "api/Product";
        public async Task<MyResponse> CreateProductRecords(Product product)
        {
            var content = helperClass.GenarateStringContetnt(product);
            var response = await client.PostAsync("api/Product/CreateProducts", content);
            if (response.IsSuccessStatusCode)
            {
                //var apiResponse = response.Content.ReadAsStringAsync().Result;
                return await helperClass.DeserializeJsonString<MyResponse>(response);
            }
            return new MyResponse
            {
                Code = (int)response.StatusCode,
                Message = "Error Occured while Creating product records!!"
            };
        }

        public async Task<List<Product>> GetProductList(bool featured)
        {
            var url = $"api/Product/GetAllProducts?featured={featured}";
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                return await helperClass.DeserializeJsonStringList<Product>(response);
            }
            return null;
        }
    }
}
