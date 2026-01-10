using System.Text.Json.Serialization;

namespace TrackingPage.Services;

public class UserContext
{
    public event Action? OnContextChanged;

    private bool _isMobile;
    private bool _isDarkMode;

    public bool IsMobile
    {
        get => _isMobile;
        set
        {
            if (_isMobile != value)
            {
                _isMobile = value;
                OnContextChanged?.Invoke();
            }
        }
    }

    public bool IsDarkMode
    {
        get => _isDarkMode;
        set
        {
            if (_isDarkMode != value)
            {
                _isDarkMode = value;
                OnContextChanged?.Invoke();
            }
        }
    }

    public bool IsTg { get; set; }
    public long TgUserId { get; set; }
    public string TgUserName { get; set; } = string.Empty;
    public string TgChatId { get; set; } = string.Empty;

}

public class TgInitData
{
    [JsonPropertyName("user")] 
    public TgUser? User { get; set; }

    [JsonPropertyName("query_id")]
    public string? QueryId { get; set; }
}

public class TgUser
{
    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("username")]
    public string? Username { get; set; }

    [JsonPropertyName("first_name")]
    public string? FirstName { get; set; }
}
