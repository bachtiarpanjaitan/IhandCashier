using System.ComponentModel;
using IhandCashier.Bepe.Database;
using IhandCashier.Bepe.Interfaces;
using IhandCashier.Bepe.Services;
using IhandCashier.Bepe.Statics;
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

    public async void BtnSimpan_OnClicked(object sender, EventArgs e)
    {
        _model.ValidateAllProperties();
        FormValidation.ShowErrors(ErrorContainer, _model.Errors);
        if (_model.Errors.Count > 0) return;
        
        bool accept = await Application.Current.MainPage.DisplayAlert("Simpan Satuan Barang",
            "Apakah anda yakin menyimpan satuan barang ini ?",
            "Simpan", "Tidak");
        if (accept)
        {
            try
            {
                var data = _model.ToUnit();
                if (data.id > 0) await _service.UpdateAsync(data);
                else await _service.AddAsync(data).ConfigureAwait(true);
                Close();
                await Application.Current.MainPage.DisplayAlert("Berhasil", "Satuan barang berhasil disimpan", "OK");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                await Application.Current.MainPage.DisplayAlert("Gagal", ex.Message, "OK");
            }
        }
    }

    public void BtnBatal_OnClicked(object sender, EventArgs e)
    {
        Close();
    }
}