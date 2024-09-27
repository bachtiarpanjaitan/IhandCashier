using IhandCashier.Bepe.Configs;
using IhandCashier.Bepe.Helpers;
using IhandCashier.Bepe.Types;

namespace IhandCashier.Bepe.Components
{
	public class SideMenu
	{
        public event EventHandler<EventHandlerPageArgs> ItemTapped;
        private Dictionary<String, MenuItemPage> menuItems;
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

            if(menuItems != null)
            {
                foreach (var mi in menuItems)
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
                BorderColor = Colors.Transparent,
            };

            button.Clicked += (s, e) => OnCLickItem(s, e, item.Page);

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

        public void SetMenuItems(Dictionary<String, MenuItemPage> items)
        {
            this.menuItems = items;
        }

    }
}

