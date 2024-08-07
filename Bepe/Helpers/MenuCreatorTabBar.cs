
using System.Reflection;
using IhandCashier.Bepe.Configs;
using IhandCashier.Bepe.Types;
using IhandCashier.Layouts;
using Microsoft.Maui.Controls;
using Newtonsoft.Json;

namespace IhandCashier.Bepe.Helpers
{
	public class MenuCreatorTabBar
    {
		List<MenuDataType> menuItems = new List<MenuDataType>();
		List<MenuBarItem> menuBarItems = new List<MenuBarItem>();
		private string path;
        private Shell context;
        private UniqueTabBar tabBar;

        public MenuCreatorTabBar(string path, Shell context, UniqueTabBar tabBar)
		{
			this.path = path;
            this.context = context;
            this.tabBar = tabBar;
		}

		public async Task<List<MenuBarItem>>  CreateMenuAsync()
		{
			menuItems = await LoadMenuItemsAsync(path);
            
            foreach (var item in menuItems)
            {
                var menuBar = new MenuBarItem { Text = item.Label };
                if (item.Child != null && item.Child.Count > 0)
                {
                    foreach(var i in item.Child)
                    {
                        if (i.Child != null && i.Child.Count > 0)
                        {
                            menuBar.Add(CreateMenuFlyoutSubItem(i));
                        } else
                        {
                            menuBar.Add(CreateMenuFlyoutItem(i));
                        }
                    }
                }
                else menuBar.Add(CreateMenuFlyoutItem(item));
                menuBarItems.Add(menuBar);
            }

            return menuBarItems;

        }

        private async Task<List<MenuDataType>> LoadMenuItemsAsync(string path)
        {
            try
            {
                var assembly = Assembly.GetExecutingAssembly();
                using var stream = assembly.GetManifestResourceStream(path);
                using var reader = new StreamReader(stream);
                var json = await reader.ReadToEndAsync();
                return JsonConvert.DeserializeObject<List<MenuDataType>>(json);
            } catch (TargetInvocationException e)
            {
                Console.WriteLine("Cannot Create Table because " + e.InnerException.Message);
                Console.WriteLine("Stack Trace :  " + e.InnerException.StackTrace);
                return null;
            }
        }


        private MenuFlyoutSubItem CreateMenuFlyoutSubItem(MenuDataType menuItem)
        {
            MenuFlyoutSubItem flyoutItem = new()
            {
                Text = menuItem.Label,
                CommandParameter = menuItem.Class
            };


            // Jika ada anak, tambahkan sebagai submenu
            if (menuItem.Child != null && menuItem.Child.Count > 0)
            {
                foreach (var childItem in menuItem.Child)
                {
                    flyoutItem.Add(CreateMenuFlyoutItem(childItem));
                }
                flyoutItem.Clicked += OnMenuItemClicked;

            }
            return flyoutItem;

        }

        private MenuFlyoutItem CreateMenuFlyoutItem(MenuDataType menuItem)
        {
            MenuFlyoutItem flyoutItem = new()
            {
                Text = menuItem.Label,
                CommandParameter = menuItem.Class
            };

            flyoutItem.Clicked += OnMenuItemClicked;
            return flyoutItem;
        }

        private void OnMenuItemClicked(object sender, EventArgs e)
        {

            if (sender is MenuFlyoutItem menuBarItem)
            {

                var data = menuBarItem?.CommandParameter as String;
                Type type = Type.GetType(AppConfig.PAGES_NAMESPACE+"."+data);
                if(type != null)
                {
                    //object instance = Activator.CreateInstance(type);
                    //ShellContent tab = new ShellContent();
                    //tab.Title = menuBarItem.Text;
                    //tab.ContentTemplate = new DataTemplate(type);
                    tabBar.AddTab(data,type,menuBarItem.Text);
                }
            }
        }
    }
}

