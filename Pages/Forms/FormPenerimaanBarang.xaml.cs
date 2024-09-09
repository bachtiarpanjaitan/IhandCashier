using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IhandCashier.Bepe.Constants;
using IhandCashier.Bepe.Database;
using IhandCashier.Bepe.Interfaces;
using IhandCashier.Bepe.Services;
using IhandCashier.Bepe.Statics;
using IhandCashier.Bepe.Types;
using IhandCashier.Bepe.ViewModels;

namespace IhandCashier.Pages.Forms;

public partial class FormPenerimaanBarang : IForm
{
    ProductReceiptService _service  = ServiceLocator.ServiceProvider.GetService<ProductReceiptService>();
    SupplierService _supplierservice  = ServiceLocator.ServiceProvider.GetService<SupplierService>();
    ProductReceiptViewModel _model = new();
    public FormPenerimaanBarang()
    {
        Initialize();
    }

    public FormPenerimaanBarang(ProductReceiptViewModel model = null)
    {
        _model = model;
        Initialize();
    }

    public void Initialize()
    {
        InitializeComponent();
        _model.ErrorsChanged += OnErrorsChanged;
        _model.Tanggal = DateTime.Now;
        _model.KodeTransaksi = "PR-" + DateTime.Now.ToString("yyyyMMddHHmm");
        BindingContext = _model;
        SetTitle("Form Penerimaan Barang").SetSize(800, 800).Create(Content);
        BtnClose.Clicked += BtnBatal_OnClicked;
        BtnSave.Clicked += BtnSimpan_OnClicked;
        
        try
        {
            var bunit = _supplierservice.GetAsync();
            var sOptions = new List<PickerOptionInt>();
            foreach (var b in bunit.ConfigureAwait(true).GetAwaiter().GetResult())
            {
                sOptions.Add(new PickerOptionInt() { Label = b.nama, Value = b.id });
            }

            SupplierSelectBox.ItemsSource = sOptions;
            SupplierSelectBox.SelectedItem = sOptions.FirstOrDefault(i => i.Value == _model.SupplierId);
            
            //status options
            var statOptions = new List<PickerOptionInt>();
            foreach (ReceiptStatus status in Enum.GetValues(typeof(ReceiptStatus)))
            {
                
                statOptions.Add(new PickerOptionInt() { Label = status.ToString(), Value = (int)status });
            }
            
            StatusSelectBox.ItemsSource = statOptions;
            StatusSelectBox.SelectedItem = statOptions.FirstOrDefault(i => i.Value == _model.Status);

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
        FormValidation.ShowErrors(ErrorContainer, _model.Errors);
        if (_model.Errors.Count > 0) return;
        
        bool accept = await Application.Current.MainPage.DisplayAlert("Simpan Penerimaan Barang",
            "Apakah anda yakin menyimpan penerimaan ini ?",
            "Simpan", "Tidak");
        if (accept)
        {
            try
            {
                var data = _model.ToEntity();
                if (data.id > 0) await _service.UpdateAsync(data).ConfigureAwait(true);
                else await _service.AddAsync(data).ConfigureAwait(true);
                
                Close();
                await Application.Current.MainPage.DisplayAlert("Berhasil", "Penerimaan barang berhasil disimpan", "OK");
            } catch (Exception ex)
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