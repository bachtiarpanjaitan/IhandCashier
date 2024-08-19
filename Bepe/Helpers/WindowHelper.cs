namespace IhandCashier.Bepe.Helpers;

public static class WindowHelper
{
    public static void SetWindowSize(int width, int height)
    {
        Microsoft.Maui.Handlers.WindowHandler.Mapper.AppendToMapping(nameof(IWindow),
            (handler, view) =>
            {
                if (DeviceInfo.Platform == DevicePlatform.MacCatalyst)
                {
                    var size = new CoreGraphics.CGSize(width, height);
                    handler.PlatformView.WindowScene.SizeRestrictions.MinimumSize = new CoreGraphics.CGSize(200, 200);
                    handler.PlatformView.WindowScene.SizeRestrictions.MaximumSize = new CoreGraphics.CGSize(1600, 1600);
                }
                else if (DeviceInfo.Platform == DevicePlatform.WinUI)
                {
                    //TODO : Riset tentang mengubah ukuran window di windows
                    // var appWindow = Microsoft.UI.Windowing.AppWindow.GetFromWindowId(Microsoft.UI.Win32Interop.GetWindowIdFromWindow(WinRT.Interop.WindowNative.GetWindowHandle(handler.PlatformView)));
                    // appWindow.Resize(new SizeInt32(width, height));
                }
            });
    }
}