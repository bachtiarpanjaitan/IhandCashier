using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IhandCashier.Bepe.Constants;
using IhandCashier.Bepe.Database;
using IhandCashier.Bepe.Entities;
using IhandCashier.Bepe.Interfaces;
using IhandCashier.Bepe.Services;
using IhandCashier.Bepe.Statics;
using IhandCashier.Bepe.Types;
using IhandCashier.Bepe.ViewModels;
using Syncfusion.Maui.DataGrid;
using Syncfusion.Maui.Inputs;

namespace IhandCashier.Pages.Forms;

public partial class FormPenerimaanBarang : IForm
{
    ProductReceiptService _service  = ServiceLocator.ServiceProvider.GetService<ProductReceiptService>();
    SupplierService _supplierservice  = ServiceLocator.ServiceProvider.GetService<SupplierService>();
    ProductService _productService  = ServiceLocator.ServiceProvider.GetService<ProductService>();
    UnitService _unitService  = ServiceLocator.ServiceProvider.GetService<UnitService>();
    ProductReceiptViewModel _model = new();
    
    List<PickerOptionInt> _productOptions = new ();
    List<PickerOptionInt> _unitOptions = new ();

    private int _generateIndex = 0;
    
    Grid _detailGrid = new ()
    {
        Margin = new Thickness(5),
        ColumnDefinitions =
        {
            new ColumnDefinition { Width = GridLength.Star },
            new ColumnDefinition { Width = GridLength.Star },
            new ColumnDefinition { Width = GridLength.Star },
            new ColumnDefinition { Width = GridLength.Star },
            new ColumnDefinition { Width = GridLength.Star },
            new ColumnDefinition { Width = 60 },

        },
        ColumnSpacing = 5,
        RowSpacing = 5
    };
    
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
        if (_model.KodeTransaksi == null)
        {
            _model.KodeTransaksi = "PR-" + DateTime.Now.ToString("yyyyMMddHHmm");
            _model.Details = new List<ProductReceiptDetailViewModel>();
            _model.Details.Add( new ProductReceiptDetailViewModel()
            {
                Id = 0,
                ProductReceiptId = 0,
                HargaSatuan = 0,
                ProductId = 0,
                Jumlah = 0,
                UnitId = 0
            });
        }
        
        BindingContext = _model;
        SetTitle("Form Penerimaan Barang").SetSize(1000, 800).Create(Content);
        BtnClose.Clicked += BtnBatal_OnClicked;
        BtnSave.Clicked += BtnSimpan_OnClicked;
        
        DetailContainer.Add(new Frame()
        {
            Content = _detailGrid,
            BorderColor = Colors.Gray,
            BackgroundColor = Colors.Transparent,
            Padding = 0,
            Margin = new Thickness(10,0,0,0)
        });
        
        AddButton.Clicked += (sender, args) =>
        {
            _generateIndex = _detailGrid.RowDefinitions.Count -1;;
            var item = new ProductReceiptDetailViewModel()
            {
                Id = 0,
                ProductReceiptId = 0,
                HargaSatuan = 0,
                ProductId = 0,
                Jumlah = 0,
                UnitId = 0
            };
            _model.Details.Add(item);
            GenerateRow(item,_generateIndex);
        };
        
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
            
            var products = _productService.GetAsync();
            foreach (var b in products.ConfigureAwait(true).GetAwaiter().GetResult())
            {
                _productOptions.Add(new PickerOptionInt() { Label = b.nama, Value = b.id });
            }
            
            var units = _unitService.GetAsync();
            foreach (var b in units.ConfigureAwait(true).GetAwaiter().GetResult())
            {
                _unitOptions.Add(new PickerOptionInt() { Label = b.nama, Value = b.id });
            }
            
            foreach (var (item, index) in _model.Details.Select((item, index) => (item, index)))
            {
                GenerateRow(item,index);
            }
            
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private void GenerateRow(ProductReceiptDetailViewModel detail, int index)
    {
       _detailGrid.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
       var delBtn = new Button()
       {
           Text = "Hapus",
           CommandParameter = index++
       };
       
       var productCb = new SfComboBox()
       {
            Placeholder = "Pilih Barang",
            DisplayMemberPath = "Label",
            TextMemberPath = "Label",
            SelectedValuePath = "Value",
            TextSearchMode = ComboBoxTextSearchMode.Contains,
            SelectedItem = detail.ProductId,
            BindingContext = detail.ProductId,
            IsEditable = true,
            IsFilteringEnabled = true,
            ShowBorder = true,
            BackgroundColor = Colors.Transparent
       };
       
       var unitCb = new SfComboBox()
       {
           Placeholder = "Pilih Satuan",
           DisplayMemberPath = "Label",
           TextMemberPath = "Label",
           SelectedValuePath = "Value",
           TextSearchMode = ComboBoxTextSearchMode.Contains,
           SelectedItem = detail.UnitId,
           BindingContext = detail.UnitId,
           IsEditable = true,
           IsFilteringEnabled = true,
           ShowBorder = true,
           BackgroundColor = Colors.Transparent
       };
       
       productCb.ItemsSource = _productOptions;
       productCb.SelectedItem = _productOptions.FirstOrDefault(i => i.Value == detail.ProductId);
       unitCb.ItemsSource = _unitOptions;
       unitCb.SelectedItem = _unitOptions.FirstOrDefault(i => i.Value == detail.UnitId);
       
       _detailGrid.Add(productCb,0,index);
       _detailGrid.Add(unitCb,1,index);
       _detailGrid.Add(new Entry()
       {
           Placeholder = "Jumlah Barang",
           BindingContext = detail.Jumlah,
           Keyboard = Keyboard.Numeric
       },2,index);
       _detailGrid.Add(new Entry()
       {
           Placeholder = "Harga Satuan",
           BindingContext = detail.HargaSatuan,
           Keyboard = Keyboard.Numeric,
       },3,index);
       _detailGrid.Add(new Entry()
       {
           Text = detail.TotalHarga.ToString(),
           IsEnabled = false
       },4,index);
       _detailGrid.Add(delBtn,5,index);
       delBtn.Clicked += RemoveItemRow;
    }

    private void RemoveItemRow(object sender, EventArgs e)
    {
        var button = sender as Button;
        if (button != null && button.CommandParameter != null)
        {
            int rowIndexToRemove = (int)button.CommandParameter;

            // Hapus elemen di baris yang ingin dihapus
            foreach (var child in _detailGrid.Children.ToList())
            {
                if (_detailGrid.GetRow(child) == rowIndexToRemove)
                {
                    _detailGrid.Children.Remove(child);
                }
            }

            // Hapus RowDefinition yang sesuai
            if (rowIndexToRemove >= 0 && rowIndexToRemove < _detailGrid.RowDefinitions.Count)
            {
                _detailGrid.RowDefinitions.RemoveAt(rowIndexToRemove);
            }
            
            // Jika ada elemen setelah baris yang dihapus, perbarui barisnya
            foreach (var child in _detailGrid.Children)
            {
                if (_detailGrid.GetRow(child) > rowIndexToRemove)
                {
                    _detailGrid.SetRow(child, _detailGrid.GetRow(child) - 1);
                }
            }
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