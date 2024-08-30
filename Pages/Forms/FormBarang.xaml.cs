using System.ComponentModel;
using IhandCashier.Bepe.Configs;
using IhandCashier.Bepe.Database;
using IhandCashier.Bepe.Interfaces;
using IhandCashier.Bepe.Services;
using IhandCashier.Bepe.Statics;
using IhandCashier.Bepe.ViewModels;

namespace IhandCashier.Pages.Forms;

public sealed partial class FormBarang : IForm
{
    ProductService _service  = ServiceLocator.ServiceProvider.GetService<ProductService>();
    ProductViewModel _model = new();
    private FileResult _imageStream = null;
    private string _fileName = null;
    public FormBarang(ProductViewModel model = null)
    {
        _model = model;
        Initialize();
        if (_model.Gambar != null)
        {
            UploadedImage.Source = ImageSource.FromFile(Path.Combine(AppSettingConfig.CreateAppPath("Images"), _model.Gambar));
        }
    }

    public FormBarang()
    {
        Initialize();
    }

    public void Initialize()
    {
        InitializeComponent();
        _model.ErrorsChanged += OnErrorsChanged;
        BindingContext = _model;
        SetTitle("Form Barang").SetSize(500, 450).Create(Content);
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
                if (data.id > 0) await _service.UpdateAsync(data).ConfigureAwait(true);
                else await _service.AddAsync(data).ConfigureAwait(true);

                if (_fileName != null)
                {
                    var path = AppSettingConfig.CreateAppPath("Images");
                    var destination = Path.Combine(path, _fileName);
                    using var fileStream = new FileStream(destination, FileMode.Create, FileAccess.Write);
                    using var stream = await _imageStream.OpenReadAsync();
                    await stream.CopyToAsync(fileStream);
                }

                Close();
                await Application.Current.MainPage.DisplayAlert("Berhasil", "Produk berhasil disimpan", "OK");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        
    }

    public void BtnBatal_OnClicked(object sender, EventArgs e)
    {
        Close();
    }

    private async void OnPickImageClicked(object sender, EventArgs e)
    {
        var result = await FilePicker.Default.PickAsync();
        if (result != null)
        {
            _imageStream = result;
            _fileName = result.FileName;
            _model.Gambar = result.FileName;
            using (var stream = await _imageStream.OpenReadAsync())
            {
                var memoryStream = new MemoryStream();
                await stream.CopyToAsync(memoryStream);
                memoryStream.Seek(0, SeekOrigin.Begin);
                UploadedImage.Source = ImageSource.FromStream(() => memoryStream);
            }
            
        }
    }
}