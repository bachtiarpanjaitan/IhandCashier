using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IhandCashier.Bepe.Constants;
using IhandCashier.Bepe.Types;
using Syncfusion.Maui.Inputs;
using SelectionChangedEventArgs = Syncfusion.Maui.Inputs.SelectionChangedEventArgs;

namespace IhandCashier.Pages.Windows;

public partial class SetupDatabase : ContentPage
{
    private AppSetting _setting = new();
    public SetupDatabase()
    {
        InitializeComponent();
        WellcomeText.Text = "Selamat datang di aplikasi Ihand Cashier";
        WellcomeDescription.Text = "Silahkan pilih type koneksi dan isi pengaturan koneksi database";
        LoadForm();
    }

    private void LoadForm()
    {
        var _options = new List<PickerOption>();
        foreach (var type in AppEnumeration.GetDbTypes)
        {
            _options.Add(new PickerOption { Value = type.Key.ToString(), Label = type.Value});
        }

        DbType.BindingContext  = _setting;
        DbType.ItemsSource = _options;
        DbType.SelectionChanged += OnDbTypeChanged;
    }

    private void OnDbTypeChanged(object sender, SelectionChangedEventArgs e)
    {
        
    }
}