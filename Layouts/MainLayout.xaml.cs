using IhandCashier.Bepe.Constants;
using IhandCashier.Bepe.Helpers;

namespace IhandCashier.Layouts;

public partial class MainLayout : UniqueTabPage
{

    public MainLayout()
	{
		InitializeComponent();
        _ = LoadMenu();

    }

    private async Task LoadMenu()
    {
        try
        {
            List<MenuBarItem> menuCreator = await new MenuCreator(AppConfig.PATH_FILE_MENU, this.MainTabbedPage).CreateMenuAsync();
            foreach (var item in menuCreator)
            {
                this.MenuBarItems.Add(item);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"MENU ERROR: {ex.Message} {ex.Source}");
        }
    }

}
