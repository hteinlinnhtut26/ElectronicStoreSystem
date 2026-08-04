using ElectronicStore.Domain.Models.Sale;
using Newtonsoft.Json;
using System.Text;

namespace ElectronicStore.WinForms.Clients;

public class SaleClient
{
    private readonly string _baseUrl;

    public SaleClient()
    {
        _baseUrl = "https://localhost:7050/api/Sale";
    }

    public SaleCreateResponseModel CreateSale(
        SaleCreateRequestModel request)
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
                JsonConvert.DeserializeObject<SaleCreateResponseModel>(
                    content);

            return response ?? new SaleCreateResponseModel
            {
                IsSuccess = false,
                Message = "Unable to create sale."
            };
        }
        catch
        {
            return new SaleCreateResponseModel
            {
                IsSuccess = false,
                Message = "Cannot connect to the API server."
            };
        }
    }

    public SaleListResponseModel GetSales()
    {
        try
        {
            HttpClient client = new HttpClient();

            HttpResponseMessage httpResponse =
                client.GetAsync(_baseUrl).Result;

            string content =
                httpResponse.Content.ReadAsStringAsync().Result;

            var response =
                JsonConvert.DeserializeObject<SaleListResponseModel>(
                    content);

            return response ?? new SaleListResponseModel
            {
                IsSuccess = false,
                Message = "Unable to retrieve sale list."
            };
        }
        catch
        {
            return new SaleListResponseModel
            {
                IsSuccess = false,
                Message = "Cannot connect to the API server."
            };
        }
    }

    public SaleByIdResponseModel GetSaleById(int saleId)
    {
        try
        {
            HttpClient client = new HttpClient();

            HttpResponseMessage httpResponse =
                client.GetAsync($"{_baseUrl}/{saleId}")
                    .Result;

            string content =
                httpResponse.Content
                    .ReadAsStringAsync()
                    .Result;

            var response =
                JsonConvert.DeserializeObject<SaleByIdResponseModel>(
                    content);

            return response ?? new SaleByIdResponseModel
            {
                IsSuccess = false,
                Message = "Unable to retrieve sale data."
            };
        }
        catch
        {
            return new SaleByIdResponseModel
            {
                IsSuccess = false,
                Message = "Cannot connect to the API server."
            };
        }
    }

    public SaleSearchResponseModel SaleSearch(SaleSearchRequestModel model)
    {
        try
        {
            string json = JsonConvert.SerializeObject(model);
            StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");

            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.PostAsync($"{_baseUrl}/Search", stringContent).Result;
            if (response.IsSuccessStatusCode)
            {
                string content = response.Content.ReadAsStringAsync().Result;

                SaleSearchResponseModel? responseModel = JsonConvert.DeserializeObject<SaleSearchResponseModel>(content);

                return responseModel ?? new SaleSearchResponseModel
                {
                    IsSuccess = false,
                    Message = "Unable to search sale ",
                };
            }

            return new SaleSearchResponseModel
            {
                IsSuccess = false,
                Message = "Unable to search sale ",
            };
        }
        catch
        {
            return new SaleSearchResponseModel
            {
                IsSuccess = false,
                Message = "Cannot connect to the API server"
            };
        }

    }
}