using OpenAILib.Api.ChatApi;
using OpenAILib.Api.ChatApi.Model;
namespace OpenAILib.Tests;
using Xunit;

public class ChatApiTest
{
    private string _apikey = "Your_API_Key";
    
    [Fact]
    public void Test1()
    {
        var chat = new ChatApi(_apikey);
        var chatRequest = new ChatRequest()
        {
            Messages = new List<Message>()
            {
                new Message()
                {
                    Role = Role.User,
                    Content = "こんにちは"
                }
            }
        };
        
        var chatResponse = chat.SendMessageAsync(chatRequest).Result;
        Assert.NotNull(chatResponse);
    }
    /// <summary>
    /// メッセージを保存するには、メッセージをリストに追加してください
    /// </summary>
    [Fact]
    public void SystemRoleTest()
    {
        var chat = new ChatApi(_apikey);
        var msglist = new List<Message>()
        {
            new Message()
            {
                Role = Role.System,
                Content = "日本語で回答してください。〇〇を実行してくださいと言われたときn<Exe>〇〇</Exe>と返信してください。※〇〇はアプリケーション名なので、変わります"
            }
        };
        var chatRequest = new ChatRequest()
        {
            Messages = msglist
        };
        
        var chatResponse = chat.SendMessageAsync(chatRequest).Result;
        Assert.NotNull(chatResponse);
        
        msglist.Add(chatRequest.Messages[0]);
        msglist.Add(new Message()
        {
            Role = Role.User,
            Content = "Testを実行してください"
        });
        var chatRequest1 = new ChatRequest()
        {
            Messages = msglist
        };
        
        var chatResponse1 = chat.SendMessageAsync(chatRequest1).Result;
        Assert.NotNull(chatResponse1);
    }
}