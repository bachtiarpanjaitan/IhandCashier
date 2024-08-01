using System;
using IhandCashier.Bepe.Constants;

namespace IhandCashier.Bepe.Components
{
	public class SideMenu
	{
        private ContentPage page;
		public SideMenu(ContentPage page)
		{
            this.page = page;
		}

        public VerticalStackLayout CreateSideMenu()
        {
            var menuLayout = new VerticalStackLayout
            {
                WidthRequest = AppConfig.SIDE_MENU_WIDTH,
                Padding = new Thickness(5,5,5,10)
            };

            menuLayout.Add(ItemMenu("MENU 1"));
            menuLayout.Add(ItemMenu("MENU 2"));
            menuLayout.Add(ItemMenu("MENU 3"));

            return menuLayout;
        }

        private Button ItemMenu(string text)
        {
            var button = new Button
            {
                Text = text,
                BorderWidth = 1, // Optional: Border width
                CornerRadius = 5,
                Margin = 5
            };

            button.Clicked += OnItemTapped;

            return button;
        }

        private async void OnItemTapped(object sender, EventArgs e)
        {
            var frame = sender as Button;
            if (frame != null)
            {
                // Animasi: skala frame saat diklik
                await frame.ScaleTo(1.1, 25, Easing.CubicIn);
                await frame.ScaleTo(1, 25, Easing.CubicOut);

                // Menampilkan alert
                await page.DisplayAlert("Item Tapped", "A frame was tapped!", "OK");
            }
        }
    }
}

