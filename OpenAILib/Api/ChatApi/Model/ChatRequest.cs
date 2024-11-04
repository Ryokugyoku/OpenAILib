namespace OpenAILib.Api.ChatApi.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;
using System.Runtime.Serialization;

/// <summary>
/// リクエスト送信用クラス
/// </summary>
public class ChatRequest
{
    /// <summary>
    /// デフォルトはgpt-4o-mini
    /// </summary>
    [JsonProperty("model")] 
    public Model Model { get; set; } = Model.Gpt4OMini;

    [JsonProperty("messages")]
    public List<Message>? Messages { get; set; }
}
/// <summary>
/// メッセージを格納するためのクラス
/// </summary>
public class Message
{
    [JsonProperty("role")]
    [JsonConverter(typeof(StringEnumConverter))]
    public Role Role { get; set; }

    [JsonProperty("content", NullValueHandling = NullValueHandling.Ignore)]
    public string? Content { get; set; }
}

public class MessageImg : Message
{
    [JsonProperty("content", NullValueHandling = NullValueHandling.Ignore)]
    public List<Content>? Content { get; set; }
}

/// <summary>
/// メッセージの中のコンテンツを格納するためのクラス
/// </summary>
public class Content
{
    /// <summary>
    /// デフォルトはテキスト設定
    /// </summary>
    [JsonProperty("type")]
    public ContentType Type { get; set; } = ContentType.Text;

    [JsonProperty("text", NullValueHandling = NullValueHandling.Ignore)]
    public string? Text { get; set; }

    [JsonProperty("image_url", NullValueHandling = NullValueHandling.Ignore)]
    public ImageUrl ImageUrl { get; set; }
}

/// <summary>
/// 画像のURLを保存するためのクラス
/// </summary>
public class ImageUrl
{
    [JsonProperty("url")]
    public string? Url { get; set; }
}

/// <summary>
/// 送信指示のロールの設定
/// User : ユーザー
/// System : システム 主にGptの共通設定など
/// Assistant : アシスタント
/// </summary>
[JsonConverter(typeof(StringEnumConverter))]
public enum Role
{
    [EnumMember(Value = "user")]
    User,
    [EnumMember(Value = "system")]
    System,
    [EnumMember(Value = "assistant")]
    Assistant
}

/// <summary>
/// 利用可能なGPTモデル
/// </summary>
[JsonConverter(typeof(StringEnumConverter))]
public enum Model
{
    [EnumMember(Value = "gpt-4")]
    Gpt4,
    
    [EnumMember(Value = "gpt-4-turbo")]
    Gpt4Turbo,
    
    [EnumMember(Value = "gpt-4o")]
    Gpt4O,
    
    [EnumMember(Value = "gpt-3.5")]
    Gpt35,
    
    [EnumMember(Value = "gpt-4o-mini")]
    Gpt4OMini
}

[JsonConverter(typeof(StringEnumConverter))]
public enum ContentType
{
    Text,
    Image
}