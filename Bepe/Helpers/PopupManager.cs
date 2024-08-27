using CommunityToolkit.Maui.Views;

namespace IhandCashier.Bepe.Helpers;

public class PopupManager
{
    public void ShowPopup(Type popupType)
    {
        // Pastikan tipe yang diberikan adalah turunan dari Popup
        if (typeof(Popup).IsAssignableFrom(popupType))
        {
            // Buat instance baru dari popupType
            var popupInstance = (Popup)Activator.CreateInstance(popupType);

            // Tampilkan popup
            if (popupInstance != null)
            {
                Application.Current.MainPage.ShowPopup(popupInstance);
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