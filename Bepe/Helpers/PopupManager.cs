using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Views;

namespace IhandCashier.Bepe.Helpers
{
    public class PopupManager : IDisposable
    {
        private readonly Dictionary<Type, Popup> _popupInstances = new();
        private bool _isDisposed;

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
                    {
                        popupInstance.Closed += Popup_Closed;
                        Application.Current.MainPage.ShowPopup(popupInstance);
                    }
                       
                }
            }
            else
            {
                throw new ArgumentException("Type must be a subclass of Popup.");
            }
        }

        private void Popup_Closed(object? sender, PopupClosedEventArgs e)
        {
            if (sender is Popup popup)
            {
                // Clean up resources and remove the instance
                popup.BindingContext = null;
                _popupInstances.Remove(popup.GetType());

                // Unsubscribe from the event
                popup.Closed -= Popup_Closed;
            }
        }

        public void ShowPopup(Popup popup)
        {
            if (Application.Current?.MainPage != null)
            {
                var type = typeof(Popup);
                _popupInstances[type] = popup;
                popup.Closed += Popup_Closed;
                Application.Current.MainPage.ShowPopup(popup);
            }
        }

        public async Task ShowPopupAsync(Popup popup)
        {
            if (Application.Current?.MainPage != null)
            {
                var type = typeof(Popup);
                _popupInstances[type] = popup;
                popup.Closed += Popup_Closed;
                await Application.Current.MainPage.ShowPopupAsync(popup);
            }
        }

        // Implementasi IDisposable
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_isDisposed) return;

            if (disposing)
            {
                // Clean up all popups and unsubscribe event handlers
                foreach (var popupInstance in _popupInstances.Values)
                {
                    if (popupInstance != null)
                    {
                        popupInstance.BindingContext = null;
                        popupInstance.Closed -= Popup_Closed;
                    }
                }

                _popupInstances.Clear();
            }

            _isDisposed = true;
        }
    }
}
