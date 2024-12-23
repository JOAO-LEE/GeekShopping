using GeekShopping.Web.Models;
using GeekShopping.Web.Services.IServices;
using GeekShopping.Web.Utils;

namespace GeekShopping.Web.Services
{
  public class ProductService : IProductService
  {
    private readonly HttpClient _client;
    public const string BasePath = "api/v1/product";

    public ProductService(HttpClient client)
    {
      _client = client;
    }
    public async Task<IEnumerable<ProductModel>> FindAllProducts()
    {
      var response = await _client.GetAsync(BasePath);
      return await response.ReadContentAs<List<ProductModel>>();
    }

    public async Task<ProductModel> FindProductById(long id)
    {
      var response = await _client.GetAsync($"{BasePath}/{id}");
      return await response.ReadContentAs<ProductModel>();
    }

    public async Task<ProductModel> CreateProduct(ProductModel productModel)
    {
      var response = await _client.PostAsJson(BasePath, productModel);
      if (response.IsSuccessStatusCode)
        return await response.ReadContentAs<ProductModel>();
      else throw new Exception("Something went wrong calling the API.");
    }

    public async Task<ProductModel> UpdateProduct(ProductModel productModel)
    {
      var response = await _client.PutAsJson(BasePath, productModel);
      if (response.IsSuccessStatusCode)
        return await response.ReadContentAs<ProductModel>();
      else
      {
        var errorContent = await response.Content.ReadAsStringAsync();
        throw new Exception($"API Error: {response.ReasonPhrase}. Details: {errorContent}");
      }
    }

    public async Task<bool> DeleteProductById(long id)
    {
      var response = await _client.DeleteAsync($"{BasePath}/{id}");
      if (response.IsSuccessStatusCode)
      {
        return true;
      }
      else
      {
        var errorContent = await response.Content.ReadAsStringAsync();
        throw new Exception($"API Error: {response.ReasonPhrase}. Details: {errorContent}");
      }
    }
  }
}