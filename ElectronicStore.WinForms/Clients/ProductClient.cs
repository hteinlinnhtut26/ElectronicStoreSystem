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
        try
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
        catch
        {
            return new ProductListResponseModel
            {
                IsSuccess = false,
                Message = "Cannot connect to the API server."
            };
        }
    }

    public ProductCreateResponseModel CreateProduct(
        ProductCreateRequestModel request)
    {
        try
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
        catch
        {
            return new ProductCreateResponseModel
            {
                IsSuccess = false,
                Message = "Cannot connect to the API server."
            };
        }
    }

    public ProductUpdateResponseModel UpdateProduct(
        ProductUpdateRequestModel request)
    {
        try
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
        catch
        {
            return new ProductUpdateResponseModel
            {
                IsSuccess = false,
                Message = "Cannot connect to the API server."
            };
        }
    }

    public ProductDeleteResponseModel DeleteProduct(int productId)
    {
        try
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
        catch
        {
            return new ProductDeleteResponseModel
            {
                IsSuccess = false,
                Message = "Cannot connect to the API server."
            };
        }
    }

    public ProductSearchResponseModel SearchProduct(ProductSearchRequestModel model)
    {
        try
        {
            string json = JsonConvert.SerializeObject(model);
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();
            var response = client.PostAsync($"{_baseUrl}/Search",stringContent).Result;
            if (response.IsSuccessStatusCode)
            {
               var content = response.Content.ReadAsStringAsync().Result;
               var responseModel = JsonConvert.DeserializeObject<ProductSearchResponseModel>(content);
                return responseModel ?? new ProductSearchResponseModel
                {
                    IsSuccess = false,
                    Message = "Unable to search product"
                };
            }
            return new ProductSearchResponseModel
            {
                Message = "Unable to search product"
            };

        }
        catch (Exception)
        {
            return new ProductSearchResponseModel
            {
                Message = "Cannot connect to the API server"
            };
            
        }
    }
}