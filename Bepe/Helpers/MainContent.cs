using System;
using View = Microsoft.EntityFrameworkCore.Metadata.Internal.View;

namespace IhandCashier.Bepe.Helpers
{
	public class MainContent: ContentView
	{
		public void ChangeContent (ContentView view)
		{
			Content = view;
		}
	}
}

