using CoreGraphics;
using Foundation;
using UIKit;

namespace IhandCashier;

[Register("AppDelegate")]
public class AppDelegate : MauiUIApplicationDelegate
{
	protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
	
	// public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
	// {
	// 	base.FinishedLaunching(application, launchOptions);
	//
	// 	// Set window size on macOS (MacCatalyst)
	// 	#if MACCATALYST
	// 		var window = UIApplication.SharedApplication.Windows.FirstOrDefault();
	// 		if (window != null)
	// 		{
	// 			var screen = UIScreen.MainScreen.Bounds;
	// 			var screenWidth = screen.Width;
	// 			var screenHeight = screen.Height;
	//
	// 			// Create a new CGRect with desired size
	// 			var frame = new CGRect(0, 0, screenWidth, screenHeight);
	// 			window.Frame = frame;
	//
	// 			// Calculate the center position
	// 			var centerX = (UIScreen.MainScreen.Bounds.Width - frame.Width) / 2;
	// 			var centerY = (UIScreen.MainScreen.Bounds.Height - frame.Height) / 2;
	// 			window.Frame = new CGRect(centerX, centerY, frame.Width, frame.Height);
	// 		}
	// 	#endif
	// 	return true;
	// }
}

