using ElectronicStore.Domain.Models.Product;
using Newtonsoft.Json;
using System.Text;

namespace ElectronicStore.WinForms.Clients;

public class ProductClient
{
    private readonly string _baseUrl;

    public ProductClient()
    {
        _baseUrl = "https://localhost:7050/api/Product";
    }

    public ProductListResponseModel GetProducts()
    {
        HttpClient client = new HttpClient();

        HttpResponseMessage httpResponse =
            client.GetAsync(_baseUrl).Result;

        string content =
            httpResponse.Content.ReadAsStringAsync().Result;

        var response =
            JsonConvert.DeserializeObject<ProductListResponseModel>(
                content);

        return response ?? new ProductListResponseModel
        {
            IsSuccess = false,
            Message = "Unable to retrieve product list."
        };
    }

    public ProductCreateResponseModel CreateProduct(
        ProductCreateRequestModel request)
    {
        string json =
            JsonConvert.SerializeObject(request);

        var stringContent = new StringContent(
            json,
            Encoding.UTF8,
            "application/json");

        HttpClient client = new HttpClient();

        HttpResponseMessage httpResponse =
            client.PostAsync(_baseUrl, stringContent).Result;

        string content =
            httpResponse.Content.ReadAsStringAsync().Result;

        var response =
            JsonConvert.DeserializeObject<ProductCreateResponseModel>(
                content);

        return response ?? new ProductCreateResponseModel
        {
            IsSuccess = false,
            Message = "Unable to create product."
        };
    }

    public ProductUpdateResponseModel UpdateProduct(
        ProductUpdateRequestModel request)
    {
        string json =
            JsonConvert.SerializeObject(request);

        var stringContent = new StringContent(
            json,
            Encoding.UTF8,
            "application/json");

        HttpClient client = new HttpClient();

        HttpResponseMessage httpResponse =
            client.PutAsync(_baseUrl, stringContent).Result;

        string content =
            httpResponse.Content.ReadAsStringAsync().Result;

        var response =
            JsonConvert.DeserializeObject<ProductUpdateResponseModel>(
                content);

        return response ?? new ProductUpdateResponseModel
        {
            IsSuccess = false,
            Message = "Unable to update product."
        };
    }

    public ProductDeleteResponseModel DeleteProduct(int productId)
    {
        HttpClient client = new HttpClient();

        HttpResponseMessage httpResponse =
            client.DeleteAsync($"{_baseUrl}/{productId}").Result;

        string content =
            httpResponse.Content.ReadAsStringAsync().Result;

        var response =
            JsonConvert.DeserializeObject<ProductDeleteResponseModel>(
                content);

        return response ?? new ProductDeleteResponseModel
        {
            IsSuccess = false,
            Message = "Unable to delete product."
        };
    }
}