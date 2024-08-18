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
                    handler.PlatformView.WindowScene.SizeRestrictions.MinimumSize = size;
                    handler.PlatformView.WindowScene.SizeRestrictions.MaximumSize = size;
                }
                else if (DeviceInfo.Platform == DevicePlatform.WinUI)
                {
                    //TODO : Riset tentang mengubah ukuran window di windows
                }
            });
    }
}