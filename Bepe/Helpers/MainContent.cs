using System;
namespace IhandCashier.Bepe.Helpers
{
	public class MainContent: ContentView
	{
		private ContentView CurrentContent = new();
		public MainContent()
		{

		}

		public void ChangeContent (ContentView view)
		{
			Content = view;
		}
	}
}

