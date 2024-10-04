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
            VerticalStackLayout sideMenu = sm.CreateSideMenu();
            _layout.SetSideMenu(sideMenu);
            foreach (var menu in sm.MenuButtons)
            {
                menu.Value.BackgroundColor = Colors.Transparent;
                menu.Value.FontSize = 14;
                menu.Value.TextColor = Colors.DimGray;
                menu.Value.HorizontalOptions = LayoutOptions.Fill;
                menu.Value.Clicked += (sender, args) =>
                {
                    var btn = sender as Button;
                    foreach (var item in sm.MenuButtons)
                    {
                        if (item.Key != btn.CommandParameter.ToString())
                        {
                            item.Value.IsEnabled = true;
                            item.Value.TextColor = Colors.DimGray;
                            item.Value.BorderWidth = 0;
                        }
                        else
                        {
                            item.Value.IsEnabled = false;
                            item.Value.BackgroundColor = Colors.Transparent;
                            item.Value.TextColor = Colors.DarkOrange;
                            item.Value.BorderWidth = 1;
                            item.Value.BorderColor = Colors.DarkOrange;

                        }
                    }
                    
                    var type = Type.GetType(menu.Key);
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
                };
            }
            
            Content = _layout.GenerateFrame();
        }
    }
}

