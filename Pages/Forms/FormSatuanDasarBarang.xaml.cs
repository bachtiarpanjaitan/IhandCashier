using System.ComponentModel;
using IhandCashier.Bepe.Database;
using IhandCashier.Bepe.Interfaces;
using IhandCashier.Bepe.Services;
using IhandCashier.Bepe.Statics;
using IhandCashier.Bepe.ViewModels;

namespace IhandCashier.Pages.Forms;

public partial class FormSatuanDasarBarang : IForm
{
    BasicUnitService _service  = ServiceLocator.ServiceProvider.GetService<BasicUnitService>();
    BasicUnitViewModel _model = new();
    public FormSatuanDasarBarang()
    {
        Initialize();
    }
    
    public FormSatuanDasarBarang(BasicUnitViewModel model)
    {
        _model = model;
        Initialize();
    }

    public void Initialize()
    {
        InitializeComponent();
        _model.ErrorsChanged += OnErrorsChanged;
        BindingContext = _model;
        SetTitle("Form Satuan Dasar Barang").SetSize(500, 600).Create(Content);
        BtnClose.Clicked += BtnBatal_OnClicked;
        BtnSave.Clicked += BtnSimpan_OnClicked;
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
        
        bool accept = await Application.Current.MainPage.DisplayAlert("Simpan Satuan Dasar Barang",
            "Apakah anda yakin menyimpan satuan dasar ini ?",
            "Simpan", "Tidak");
        if (accept)
        {
            try
            {
                var data = _model.ToEntity();
                if (data.id > 0) await _service.UpdateAsync(data);
                else await _service.AddAsync(data).ConfigureAwait(true);
                Close();
                await Application.Current.MainPage.DisplayAlert("Berhasil", "Satuan dasar berhasil disimpan", "OK");
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