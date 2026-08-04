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

    public SaleListResponseModel GetSales()
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

    public SaleByIdResponseModel GetSaleById(int saleId)
    {
        HttpClient client = new HttpClient();

        HttpResponseMessage httpResponse =
            client.GetAsync($"{_baseUrl}/{saleId}").Result;

        string content =
            httpResponse.Content.ReadAsStringAsync().Result;

        var response =
            JsonConvert.DeserializeObject<SaleByIdResponseModel>(
                content);

        return response ?? new SaleByIdResponseModel
        {
            IsSuccess = false,
            Message = "Unable to retrieve sale data."
        };
    }
}