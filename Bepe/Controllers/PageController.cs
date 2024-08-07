using System;
using System.Reflection;
using IhandCashier.Bepe.Components;
using IhandCashier.Bepe.Constants;
using IhandCashier.Bepe.Helpers;
using IhandCashier.Bepe.Interfaces;
using IhandCashier.Bepe.Types;

namespace IhandCashier.Bepe.Controllers
{
	public class PageController : ContentView,IPageInterface
	{
        private ContentView contentView = new();
        public Dictionary<string, MenuItemPage> SideMenus = new();
        private ContentLayoutTwoColumn layout = new ContentLayoutTwoColumn();
        public PageController()
		{

		}

        public void DefineLayoutTwoColumn()
        {
            SideMenu sm = new();
            sm.SetMenuItems(SideMenus);
            sm.ItemTapped += OnClickSideMenuItemAsync;
            VerticalStackLayout sideMenu = sm.CreateSideMenu();
            
            layout.SetSideMenu(sideMenu);
            Content = layout.GenerateFrame();
        }

        public void OnClickSideMenuItemAsync(object obj, EventHandlerPageArgs e)
        {
            var clickedSender = e.Sender;
            var originalEventArgs = e.OriginalEventArgs;
            Type type = Type.GetType(e.Page);
            if(type != null)
            {
               try {
                    ContentView instance = (ContentView)Activator.CreateInstance(type);
                    layout.SetContent(instance);
                }
                catch (TargetInvocationException ex)
                {
                    Console.WriteLine("Cannot create instance " + ex.InnerException.Message);
                    Console.WriteLine("Stack Trace :  " + ex.InnerException.StackTrace);
                }
            }
           
        }
    }
}

