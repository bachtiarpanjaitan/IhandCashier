using System.ComponentModel;
using IhandCashier.Bepe.Database;
using IhandCashier.Bepe.Interfaces;
using IhandCashier.Bepe.Services;
using IhandCashier.Bepe.Types;
using IhandCashier.Bepe.ViewModels;

namespace IhandCashier.Pages.Forms;

public sealed partial class FormSatuanBarang : IForm
{
    UnitService _service  = ServiceLocator.ServiceProvider.GetService<UnitService>();
    BasicUnitService _basicUnitService = ServiceLocator.ServiceProvider.GetService<BasicUnitService>();
    UnitViewModel _model = new();
    public FormSatuanBarang()
    {
        Initialize();
    }

    public FormSatuanBarang(UnitViewModel model)
    {
        _model = model;
        Initialize();
    }

    public void Initialize()
    {
        InitializeComponent();
        BasicUnitSelectBox.ItemsSource = new List<PickerOption>();
        _model.ErrorsChanged += OnErrorsChanged;
        BindingContext = _model;
        SetTitle("Form Satuan Barang").SetSize(500, 600).Create(Content);
        BtnClose.Clicked += BtnBatal_OnClicked;
        BtnSave.Clicked += BtnSimpan_OnClicked;

        try
        {
            var bunit = _basicUnitService.GetAsync();
            var options = new List<PickerOptionInt>();
            foreach (var b in bunit.ConfigureAwait(true).GetAwaiter().GetResult())
            {
                options.Add(new PickerOptionInt() { Label = b.nama, Value = b.id });
            }

            BasicUnitSelectBox.ItemsSource = options;
            BasicUnitSelectBox.SelectedItem = options.FirstOrDefault(i => i.Value == _model.BasicUnitId);

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    
    private void OnErrorsChanged(object sender, DataErrorsChangedEventArgs e)
    {
        if (e.PropertyName != null)
        {
            OnPropertyChanged(e.PropertyName);
        }
    }

    public void BtnSimpan_OnClicked(object sender, EventArgs e)
    {
       
    }

    public void BtnBatal_OnClicked(object sender, EventArgs e)
    {
        Close();
    }
}