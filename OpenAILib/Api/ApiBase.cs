namespace OpenAILib.Api;
using System.Net.Http.Headers;
public class ApiBase
{
    protected static readonly HttpClient httpClient;
    
    static ApiBase()
    {
        httpClient = new HttpClient();
        httpClient.BaseAddress = new Uri("https://api.openai.com/v1/");
    }
    
    protected ApiBase(string apiKey)
    {
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
    }
}