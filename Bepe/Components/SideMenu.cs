using System.Collections.Generic;
using IhandCashier.Bepe.Constants;
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

        private Button ItemMenu(string text, Page page)
        {
            var button = new Button
            {
                Text = text,
                BorderWidth = 1,
                CornerRadius = 5,
                Margin = 5
            };

            button.Clicked += (s, e) => OnCLickItem(s, e, page);

            return button;
        }

        private async void OnCLickItem(object sender, EventArgs e, Page page)
        {
            var btn = sender as Button;
            if (btn != null)
            {
                // Animasi: skala frame saat diklik
                await btn.ScaleTo(1.05, 25, Easing.CubicIn);
                await btn.ScaleTo(1, 25, Easing.CubicOut);
                ItemTapped?.Invoke(this, new EventHandlerPageArgs(sender, e, page));
            }
        }

        public void SetMenuItems(Dictionary<String, MenuItemPage> items)
        {
            this.menuItems = items;
        }

    }
}

