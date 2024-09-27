
using System;
using System.Reflection;
using IhandCashier.Bepe.Configs;
using IhandCashier.Bepe.Types;
using IhandCashier.Layouts;
using Newtonsoft.Json;

namespace IhandCashier.Bepe.Helpers
{
	public class MenuCreator
    {
		List<MenuDataType> menuItems = new ();
		List<MenuBarItem> menuBarItems = new ();
        public Dictionary<string, MenuFlyoutItem> ListMenu = new();
		private string path;
        private MainContent context;

		public MenuCreator(string path, MainContent context)
		{
			this.path = path;
            this.context = context;
		}
        
        public MenuCreator(MainContent context, IList<MenuBarItem> MenuBar)
        {
            this.context = context;
            CreateMenu(MenuBar);
        }
        
        public MenuCreator(IList<MenuBarItem> MenuBar)
        {
            CreateMenu(MenuBar);
        }
        
        public MenuCreator(){}

		public Dictionary<string, MenuFlyoutItem>  CreateMenu(IList<MenuBarItem> MenuBar)
		{
			// menuItems = await LoadMenuItemsAsync(path).ConfigureAwait(false);
            menuItems = MenuConfig.GetMenus();
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
                MenuBar.Add(menuBar);
            }

            return ListMenu;

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
                // flyoutItem.Clicked += OnMenuItemClicked;

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
            ListMenu.Add(menuItem.Class, flyoutItem);
            // flyoutItem.Clicked += OnMenuItemClicked;
            
            return flyoutItem;
        }

        private void OnMenuItemClicked(object sender, EventArgs e)
        {

            if (sender is MenuFlyoutItem menuBarItem)
            {

                try
                {
                    var data = menuBarItem?.CommandParameter as String;
                    var type = Type.GetType(AppConfig.PAGES_NAMESPACE + "." + data);
                    if (type == null) return;
                    var instance = Activator.CreateInstance(type);
                    // context.ChangeContent((ContentView)instance);
                } catch (Exception ex)
                {
                    Console.WriteLine($"Error Click : {ex.Message}");
                }
            }
        }
    }
}

