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
                    menuLayout.Add(ItemMenu(mi.Value.Label, mi.Value.Page));
                }
            }
            return menuLayout;
        }

        private Button ItemMenu(string text, string page)
        {
            var button = new Button
            {
                Text = text,
                CornerRadius = 5,
                Margin = 5
            };

            button.Clicked += (s, e) => OnCLickItem(s, e, page);

            return button;
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

