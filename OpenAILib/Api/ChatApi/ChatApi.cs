using Newtonsoft.Json;
using OpenAILib.Api.ChatApi.Model;
using System.Text;
namespace OpenAILib.Api.ChatApi;

/// <summary>
/// CHAT開始用API
/// 
/// </summary>
public class ChatApi : ApiBase
{
    private static readonly string Url = "chat/completions";
    
    public ChatApi(string apiKey) : base(apiKey)
    {
        
    }
    
    /// <summary>
    /// メッセージを送信するためのメソッド
    /// </summary>
    /// <param name="chatRequest"></param>
    /// <returns></returns>
    public async Task<ChatResponse?> SendMessageAsync(ChatRequest chatRequest)
    {
        using var form = new MultipartFormDataContent();
        
        var requestBody = JsonConvert.SerializeObject(chatRequest);
        var content = new StringContent(requestBody, Encoding.UTF8, "application/json");
        
        var response = await httpClient.PostAsync(Url, content);
        response.EnsureSuccessStatusCode();
        var responseBody = await response.Content.ReadAsStringAsync();
        var chatResponse = JsonConvert.DeserializeObject<ChatResponse>(responseBody);
        return chatResponse;
    }
}