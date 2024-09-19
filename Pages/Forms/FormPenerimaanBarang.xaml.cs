using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
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
using SelectionChangedEventArgs = Syncfusion.Maui.Inputs.SelectionChangedEventArgs;

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
    
    private ObservableCollection<ProductReceiptDetailViewModel> Details = new();
    
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
        if (model != null) Details = new ObservableCollection<ProductReceiptDetailViewModel>(model.Details);
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
            Details.Add( new ProductReceiptDetailViewModel()
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
            var item = new ProductReceiptDetailViewModel()
            {
                Id = 0,
                ProductReceiptId = 0,
                HargaSatuan = 0,
                ProductId = 0,
                Jumlah = 0,
                UnitId = 0,
                Index = _detailGrid.RowDefinitions.Count
            };
            Details.Add(item);
            GenerateRow(Details.FirstOrDefault(x => x == item),item.Index);
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
            
            foreach (var (item, index) in Details.Select((item, index) => (item, index)))
            {
                GenerateRow(item,index);
            }
            
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private void GenerateRow(ProductReceiptDetailViewModel detail, int idx)
    {
       _detailGrid.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
       var delBtn = new Button()
       {
           Text = "Hapus",
           CommandParameter = idx
       };
       
       var productCb = new SfComboBox()
       {
            Placeholder = "Pilih Barang",
            DisplayMemberPath = "Label",
            TextMemberPath = "Label",
            SelectedValuePath = "Value",
            TextSearchMode = ComboBoxTextSearchMode.Contains,
            SelectedItem = detail.ProductId,
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
           IsEditable = true,
           IsFilteringEnabled = true,
           ShowBorder = true,
           BackgroundColor = Colors.Transparent
       };
       
       productCb.BindingContext = detail;
       productCb.SetBinding(SfComboBox.SelectedValueProperty, new Binding(nameof(detail.ProductId), mode: BindingMode.TwoWay));
       productCb.ItemsSource = _productOptions;
       productCb.SelectedItem = _productOptions.FirstOrDefault(i => i.Value == detail.ProductId);
       
       unitCb.BindingContext = detail;
       unitCb.SetBinding(SfComboBox.SelectedValueProperty, new Binding(nameof(detail.UnitId), mode: BindingMode.TwoWay));
       unitCb.ItemsSource = _unitOptions;
       unitCb.SelectedItem = _unitOptions.FirstOrDefault(i => i.Value == detail.UnitId);
       
       _detailGrid.Add(productCb,0,idx);
       _detailGrid.Add(unitCb,1,idx);

       var jumlahEntry = new Entry()
       {
           Placeholder = "Jumlah Barang",
           BindingContext = detail.Jumlah,
           Keyboard = Keyboard.Numeric
       };
       jumlahEntry.SetBinding(Entry.TextProperty, new Binding("Jumlah", source: detail, mode: BindingMode.TwoWay));
       jumlahEntry.Text = Helper.FormatToCurrency(detail.Jumlah);
       jumlahEntry.TextChanged += OnAmountEntryTextChanged;
       _detailGrid.Add(jumlahEntry,2,idx);

       var hargaEntry = new Entry()
       {
           Placeholder = "Harga Satuan",
           BindingContext = detail.HargaSatuan,
           Keyboard = Keyboard.Numeric,
       };
       hargaEntry.SetBinding(Entry.TextProperty, new Binding("HargaSatuan", source: detail, mode: BindingMode.TwoWay));
       hargaEntry.Text = Helper.FormatToCurrency(detail.HargaSatuan);
       hargaEntry.TextChanged += OnAmountEntryTextChanged;
       _detailGrid.Add(hargaEntry,3,idx);

       var totalHargaEntry = new Entry()
       {
           Text = detail.TotalHarga.ToString(),
           IsReadOnly = true
       };
       
       totalHargaEntry.SetBinding(Entry.TextProperty, new Binding("TotalHarga", source: detail));
       totalHargaEntry.Text = Helper.FormatToCurrency(detail.TotalHarga);
       totalHargaEntry.TextChanged += OnAmountEntryTextChanged;
       _detailGrid.Add(totalHargaEntry,4,idx);
       
       _detailGrid.Add(delBtn,5,idx);
       delBtn.Clicked += RemoveItemRow;
    }

    private void RemoveItemRow(object sender, EventArgs e)
    {
        var button = sender as Button;
        if (button != null && button.CommandParameter != null)
        {
            int rowIndexToRemove = (int)button.CommandParameter;
            if (Details.ToList().Count > 1)
            {
                var myList = Details.ToList();
                // // Hapus elemen di baris yang ingin dihapus
                foreach (var child in _detailGrid.Children.ToList())
                {
                    if (_detailGrid.GetRow(child) == rowIndexToRemove)
                    {
                        _detailGrid.Children.Remove(child);
                    }
                }

                myList.RemoveAll(item => item.Index == rowIndexToRemove);
                Details = new ObservableCollection<ProductReceiptDetailViewModel>(myList);
                
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
                data.Details = Details.Select(d => d.ToEntity()).ToList();
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
    
    private void OnAmountEntryTextChanged(object sender, TextChangedEventArgs e)
    {
        var entry = (Entry)sender;

        // Menghapus format lama (misalnya ketika user mengedit nilai)
        if (decimal.TryParse(entry.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out decimal amount))
        {
            // Mengupdate nilai entry dengan format mata uang (IDR)
            entry.TextChanged -= OnAmountEntryTextChanged;  // Remove event handler to avoid infinite loop
            entry.Text = Helper.FormatToCurrency(amount);
            entry.TextChanged += OnAmountEntryTextChanged;  // Add the event handler back
        }
    }
    
    
}