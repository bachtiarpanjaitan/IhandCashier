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
                var btn = args.Sender as Button;
                btn.TextColor = Colors.OrangeRed;
                btn.FontSize = 16;
                var type = Type.GetType(args.Page);
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

                var menuitems = sender as SideMenu;

                foreach (var m in menuitems.MenuButtons)
                {
                    if (m.Key != args.Page)
                    {
                        m.Value.TextColor = Colors.DarkOrange;
                        m.Value.FontSize = 14;
                        m.Value.IsEnabled = true;
                    }
                    else
                    {
                        m.Value.IsEnabled = false;
                        m.Value.BackgroundColor = Colors.Transparent;
                    }
                }
            };
            VerticalStackLayout sideMenu = sm.CreateSideMenu();
            _layout.SetSideMenu(sideMenu);
            Content = _layout.GenerateFrame();
        }
    }
}

