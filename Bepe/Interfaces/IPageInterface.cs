using System;
using IhandCashier.Bepe.Helpers;
using IhandCashier.Bepe.Types;

namespace IhandCashier.Bepe.Interfaces
{
	public interface IPageInterface
	{
		void OnClickSideMenuItemAsync(object obj, EventHandlerPageArgs args);
		void DefineLayoutTwoColumn();

    }
}

