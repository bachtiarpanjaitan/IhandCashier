using Foundation;
using UIKit;

namespace IhandCashier;

[Register("AppDelegate")]
public class AppDelegate : MauiUIApplicationDelegate
{
	protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
	
	public override void BuildMenu(IUIMenuBuilder builder)
	{
		base.BuildMenu(builder);
		var formatMenuIdentifier = UIMenuIdentifier.Format.GetConstant();
		builder.RemoveMenu(formatMenuIdentifier);
	}
}

