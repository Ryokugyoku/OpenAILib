namespace OpenAILib.Api.ChatApi.Model;
using Newtonsoft.Json;
using System.Collections.Generic;

public class ChatResponse
{
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("object")]
    public string Object { get; set; }

    [JsonProperty("created")]
    public long Created { get; set; }

    [JsonProperty("model")]
    public string Model { get; set; } // 型を Model から string に変更

    [JsonProperty("system_fingerprint")]
    public string SystemFingerprint { get; set; }

    [JsonProperty("choices")]
    public List<Choice> Choices { get; set; }

    [JsonProperty("usage")]
    public Usage Usage { get; set; }
}

public class Choice
{
    [JsonProperty("index")]
    public int Index { get; set; }
    
    /// <summary>
    /// ChatGPTからのレスポンスメッセージが格納されたクラス
    /// </summary>
    [JsonProperty("message")]
    public Message Message { get; set; }

    [JsonProperty("logprobs")]
    public object Logprobs { get; set; }

    [JsonProperty("finish_reason")]
    public string FinishReason { get; set; }
}

public class Usage
{
    [JsonProperty("prompt_tokens")]
    public int PromptTokens { get; set; }

    [JsonProperty("completion_tokens")]
    public int CompletionTokens { get; set; }

    [JsonProperty("total_tokens")]
    public int TotalTokens { get; set; }

    [JsonProperty("prompt_tokens_details")]
    public PromptTokensDetails PromptTokensDetails { get; set; }

    [JsonProperty("completion_tokens_details")]
    public CompletionTokensDetails CompletionTokensDetails { get; set; }
}

public class PromptTokensDetails
{
    [JsonProperty("cached_tokens")]
    public int CachedTokens { get; set; }
}

public class CompletionTokensDetails
{
    [JsonProperty("reasoning_tokens")]
    public int ReasoningTokens { get; set; }
}