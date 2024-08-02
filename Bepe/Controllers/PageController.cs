using System;
using IhandCashier.Bepe.Components;
using IhandCashier.Bepe.Constants;
using IhandCashier.Bepe.Helpers;
using IhandCashier.Bepe.Interfaces;
using IhandCashier.Bepe.Types;

namespace IhandCashier.Bepe.Controllers
{
	public class PageController : ContentPage,IPageInterface
	{
        private VerticalStackLayout contentView = new();
        public Dictionary<string, MenuItemPage> SideMenus = new();

        public PageController()
		{

		}

        public void DefineLayoutTwoColumn()
        {
            SideMenu sm = new();
            sm.SetMenuItems(SideMenus);
            VerticalStackLayout sideMenu = sm.CreateSideMenu();

            sm.ItemTapped += OnClickSideMenuItemAsync;
            Frame frame = new ContentLayoutTwoColumn(sideMenu, contentView).GenerateFrame();

            Content = frame;
        }

        public void OnClickSideMenuItemAsync(object obj, EventHandlerPageArgs e)
        {
            var clickedSender = e.Sender;
            var originalEventArgs = e.OriginalEventArgs;
            var page = e.Page;
            contentView.Clear();
            contentView.Children.Add(page);
        }
    }
}

