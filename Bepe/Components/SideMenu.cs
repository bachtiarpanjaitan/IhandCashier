using IhandCashier.Bepe.Configs;
using IhandCashier.Bepe.Helpers;
using IhandCashier.Bepe.Types;

namespace IhandCashier.Bepe.Components
{
	public class SideMenu
	{
        public event EventHandler<EventHandlerPageArgs> ItemTapped;
        public Dictionary<string, MenuItemPage> MenuItems;
        public Dictionary<string, Button> MenuButtons = new();
        public SideMenu()
		{
            
		}

        public VerticalStackLayout CreateSideMenu()
        {
            var menuLayout = new VerticalStackLayout
            {
                WidthRequest = AppConfig.SIDE_MENU_WIDTH,
                Padding = new Thickness(5,5,5,10)
            };

            if(MenuItems != null)
            {
                foreach (var mi in MenuItems)
                {
                    menuLayout.Add(ItemMenu(mi.Value));
                }
            }
            return menuLayout;
        }

        private HorizontalStackLayout ItemMenu(MenuItemPage item)
        {
            var icon = new Image()
            {
                Source = new FontImageSource()
                {
                    Glyph = item.Icon, //
                    FontFamily = "MaterialIcons",
                    Size = 20,
                    Color = Colors.DarkOrange
                },
                HorizontalOptions = LayoutOptions.Start
            };
            var button = new Button
            {
                Text = item.Label,
                FontAttributes = FontAttributes.Bold,
                Margin = 5,
                TextColor = item.TextColor,
                IsEnabled = item.Enable,
                BorderColor = Colors.Transparent,
            };
            
            button.Clicked += (s, e) => OnCLickItem(s, e, item.Page);
            MenuButtons.Add(item.Page, button);

            return new HorizontalStackLayout()
            {
                Children =
                {
                    icon,
                    button
                },
                Margin = new Thickness(10,0)
            };
        }

        private async void OnCLickItem(object sender, EventArgs e, string page)
        {
            var btn = sender as Button;
            if (btn == null) return;
            // Animasi: skala frame saat diklik
            await btn.ScaleTo(1, 5, Easing.CubicIn);
            await btn.ScaleTo(1, 5, Easing.CubicOut);
            ItemTapped?.Invoke(this, new EventHandlerPageArgs(sender, e, page));
        }

        public void SetMenuItems(Dictionary<string, MenuItemPage> items)
        {
            MenuItems = items;
        }

    }
}

