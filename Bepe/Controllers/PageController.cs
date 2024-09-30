using System.Reflection;
using IhandCashier.Bepe.Components;
using IhandCashier.Bepe.Helpers;
using IhandCashier.Bepe.Interfaces;
using IhandCashier.Bepe.Types;
using IhandCashier.Pages.Views;

namespace IhandCashier.Bepe.Controllers
{
	public class PageController : ContentView
	{
        private ContentView _contentView = new();
        public Dictionary<string, MenuItemPage> SideMenus = new();
        private ContentLayoutTwoColumn _layout = new();
        public PageController() { }

        public void DefineLayoutTwoColumn()
        {
            var sm = new SideMenu();
            sm.SetMenuItems(SideMenus);
            sm.ItemTapped += (sender, args) =>
            {
                Type type = Type.GetType(args.Page);
                if(type != null)
                {
                    try
                    {
                        _contentView = (ContentView)Activator.CreateInstance(type);
                        _layout.SetContent(_contentView);
                    }
                    catch (TargetInvocationException ex)
                    {
                        Console.WriteLine("Cannot create layout " + ex.InnerException?.Message);
                    }
                }
            } ;
            VerticalStackLayout sideMenu = sm.CreateSideMenu();
            _layout.SetSideMenu(sideMenu);
            Content = _layout.GenerateFrame();
        }
    }
}

