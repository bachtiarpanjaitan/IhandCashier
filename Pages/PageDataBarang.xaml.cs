using System.Collections.ObjectModel;
using IhandCashier.Bepe.Constants;
using IhandCashier.Bepe.Components;
using IhandCashier.Bepe.Types;
using IhandCashier.Bepe.Helpers;

namespace IhandCashier.Pages;

public partial class PageDataBarang : ContentPage
{
    public ObservableCollection<SideMenuItem> Items { get; set; }
    public SideMenuItem SelectedItem { get; set; }
    public PageDataBarang()
	{
		InitializeComponent();

        defineLayout();
	}

    private void defineLayout()
    {
        VerticalStackLayout sideMenu = new SideMenu(this).CreateSideMenu();
        VerticalStackLayout contentView = new();
        Frame frame = new ContentLayoutTwoColumn(sideMenu,contentView).GenerateFrame();

        Content = frame;
    }
}