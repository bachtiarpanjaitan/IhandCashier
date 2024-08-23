using System.ComponentModel;
using IhandCashier.Bepe.Database;
using IhandCashier.Bepe.Services;
using IhandCashier.Bepe.Statics;
using IhandCashier.Bepe.ViewModels;

namespace IhandCashier.Pages.Forms;

public partial class FormBarang
{
    ProductService _service  = ServiceLocator.ServiceProvider.GetService<ProductService>();
    ProductViewModel _model = new();
    public FormBarang()
    {
        InitializeComponent();
        _model.ErrorsChanged += OnErrorsChanged;
        BindingContext = _model;
        
    }

    private void OnErrorsChanged(object sender, DataErrorsChangedEventArgs e)
    {
        if (e.PropertyName != null)
        {
            OnPropertyChanged(e.PropertyName);
        }
    }

    private async void BtnSimpan_OnClicked(object sender, EventArgs e)
    {
        FormValidation.ShowErrors(ErrorContainer, _model.Errors);
        if (_model.Errors.Count > 0) return;
        
        bool accept = await Application.Current.MainPage.DisplayAlert("Simpan Produk",
            "Apakah anda yakin menyimpan produk ini ?",
            "Simpan", "Tidak");
        if (accept)
        {
            try
            {
                var data = _model.ToProduct();
                _service.AddAsync(data).ConfigureAwait(true);
                Close();
                await Application.Current.MainPage.DisplayAlert("Berhasil", "Produk berhasil ditambahkan", "OK");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        
    }

    private void BtnBatal_OnClicked(object sender, EventArgs e)
    {
        Close();
    }

    private async void OnPickImageClicked(object sender, EventArgs e)
    {
        var result = await FilePicker.Default.PickAsync();
        if (result != null)
        {
            _model.Gambar = result.FullPath;
        }
    }
}