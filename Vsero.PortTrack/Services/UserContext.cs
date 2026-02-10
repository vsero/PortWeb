using Microsoft.JSInterop;
using Vsero.UTrcak;
using U = Vsero.UTrcak;

namespace Vsero.PortTrack.Services;


public class UserContext
{
    public UserContext(IJSRuntime js) => _js = js;
    public event Action? OnChange;

    private bool _isMobile;
    private bool _isDarkMode;
    private bool _isTg;
    private string _culture = "ru-RU";
    private readonly IJSRuntime _js;



    public bool IsMobile
    {
        get => _isMobile;
        set
        {
            if (_isMobile != value)
            {
                _isMobile = value;
                NotifyChanged();
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
                NotifyChanged();
            }
        }
    }



    public bool IsTg
    {
        get => _isTg;
        //get => true;
        set
        {
            if (_isTg != value)
            {
                _isTg = value;
                NotifyChanged();
            }
        }
    }



    public string Culture
    {
        get => _culture;
        set
        {
            if (_culture != value)
            {
                _culture = value;
                NotifyChanged();
            }
        }
    }


    
    public U.TgUser? ApiTguser()
    {
        //return new()
        //{
        //    Id = 412798134,
        //    Username = "VitalySerokurov",
        //    FirstName = "Vitaly"
        //};

        if (TgUser is null)
            return null;

        return new U.TgUser
        {
            Id = TgUser.Id,
            Username = TgUser.Username,
            FirstName = TgUser.FirstName
        };
    }



    public async Task SetCultureAsync(string culture)
    {
        await _js.InvokeVoidAsync("localStorage.setItem", "selectedCulture", culture);
        Culture = culture;
    }



    public TgUser? TgUser { get; set; }



    private void NotifyChanged() => OnChange?.Invoke();

}




public class TgInitData
{
    public TgUser? User { get; set; }
    public string QueryId { get; set; } = string.Empty;
}



public class TgUser
{
    public long Id { get; set; }
    public string? Username { get; set; } = string.Empty;
    public string? FirstName { get; set; } = string.Empty;
}
