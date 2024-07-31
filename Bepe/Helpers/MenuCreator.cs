using System;
using System.Reflection;
using IhandCashier.Bepe.Constants;
using IhandCashier.Bepe.Types;
using IhandCashier.Layouts;
using Microsoft.Maui.Controls;
using Newtonsoft.Json;
using static CoreFoundation.DispatchSource;

namespace IhandCashier.Bepe.Helpers
{
	public class MenuCreator
    {
		List<MenuDataType> menuItems = new List<MenuDataType>();
		List<MenuBarItem> menuBarItems = new List<MenuBarItem>();
		private string path;
        private UniqueTabPage context;

		public MenuCreator(string path, UniqueTabPage context)
		{
			this.path = path;
            this.context = context;
		}

		public async Task<List<MenuBarItem>>  CreateMenuAsync()
		{
			menuItems = await LoadMenuItemsAsync(path);

            foreach (var item in menuItems)
            {
                menuBarItems.Add(CreateMenuItem(item));
            }

            return menuBarItems;

        }

        private async Task<List<MenuDataType>> LoadMenuItemsAsync(string path)
        {
            var assembly = Assembly.GetExecutingAssembly();
            using var stream = assembly.GetManifestResourceStream(path);
            using var reader = new StreamReader(stream);
            var json = await reader.ReadToEndAsync();
            return JsonConvert.DeserializeObject<List<MenuDataType>>(json);
        }

        private MenuFlyout CreateMenuFlyout(MenuDataType menuItem)
        {
            var flyout = new MenuFlyout();

            // Menambahkan item ke MenuFlyout
            if (menuItem.Child != null && menuItem.Child.Count > 0)
            {
                foreach (var childItem in menuItem.Child)
                {
                    flyout.Add(CreateMenuFlyoutItem(childItem));
                }
            }

            return flyout;
        }

        private MenuFlyoutItem CreateMenuFlyoutItem(MenuDataType menuItem)
        {
            var flyoutItem = new MenuFlyoutItem
            {
                Text = menuItem.Label,
                CommandParameter = menuItem.Class
            };

            // Jika ada anak, tambahkan sebagai submenu
            if (menuItem.Child != null && menuItem.Child.Count > 0)
            {
                var submenu = CreateMenuFlyout(menuItem);
                flyoutItem.Command = new Command(() =>
                {
                    // Implementasikan perintah atau logika saat item diklik jika diperlukan
                    
                });
            }

            flyoutItem.Clicked += OnMenuItemClicked;
            return flyoutItem;
        }

        private MenuBarItem CreateMenuItem(MenuDataType menuItem)
        {
            var barItem = new MenuBarItem
            {
                Text = menuItem.Label
            };

            // Menambahkan child items ke MenuBarItem jika ada
            if (menuItem.Child != null && menuItem.Child.Count > 0)
            {
                foreach (var childItem in menuItem.Child)
                {
                    barItem.Add(CreateMenuFlyoutItem(childItem));
                }

            }

            return barItem;
        }


        private void OnMenuItemClicked(object sender, EventArgs e)
        {

            if (sender is MenuFlyoutItem menuBarItem)
            {

                var data = menuBarItem?.CommandParameter as String;
                Type type = Type.GetType(AppConfig.PAGES_NAMESPACE+"."+data);
                object instance = Activator.CreateInstance(type);
                context.AddTab(data, (Page)instance);
            }
        }
    }
}

