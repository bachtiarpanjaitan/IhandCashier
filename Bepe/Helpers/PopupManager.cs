using CommunityToolkit.Maui.Views;

namespace IhandCashier.Bepe.Helpers;

public class PopupManager
{
    private readonly Dictionary<Type, Popup> _popupInstances = new();
    public void ShowPopup(Type popupType)
    {
        // Pastikan tipe yang diberikan adalah turunan dari Popup
        if (typeof(Popup).IsAssignableFrom(popupType))
        {
            if (!_popupInstances.TryGetValue(popupType, out var popupInstance))
            {
                // Buat instance baru jika belum ada
                popupInstance = (Popup)Activator.CreateInstance(popupType);
                _popupInstances[popupType] = popupInstance;

                // Tambahkan event handler untuk pembersihan
                if (popupInstance != null)
                    popupInstance.Closed += (s, e) =>
                    {
                        // Clean up resources and remove the instance
                        popupInstance.BindingContext = null;
                        _popupInstances.Remove(popupType);
                    };
            }
        }
        else
        {
            throw new ArgumentException("Type must be a subclass of Popup.");
        }
    }

    public void ShowPopup(Popup popup)
    {
        if (Application.Current != null)
            if (Application.Current.MainPage != null)
                Application.Current.MainPage.ShowPopup(popup);
    }
    
    public async Task ShowPopupAsync(Popup popup)
    {
        if (Application.Current != null)
            if (Application.Current.MainPage != null)
                await Application.Current.MainPage.ShowPopupAsync(popup);
    }

    public async Task ClosePopupAsync(Popup popup)
    {
        await popup.CloseAsync();
    }
}