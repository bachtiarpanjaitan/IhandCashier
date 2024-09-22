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
using Syncfusion.Maui.Core;
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
    Dictionary<int, RowDefinition> DefRows = new Dictionary<int, RowDefinition>();
    private List<Button> ActionButtons = new List<Button>();
    
    private ObservableCollection<ProductReceiptDetailViewModel> Details = new();
    
    Grid _detailGrid = new ()
    {
        Margin = new Thickness(5),
        ColumnDefinitions =
        {
            new ColumnDefinition { Width = GridLength.Star },
            new ColumnDefinition { Width = GridLength.Star },
            new ColumnDefinition { Width = 50 },
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
        
        DefRows.Clear();
        DefRows.Add(0, new RowDefinition() { Height = 30 });
        
        _detailGrid.Add(new Label(){Text = "Barang", HorizontalTextAlignment = TextAlignment.Start},0,0);
        _detailGrid.Add(new Label(){Text = "Satuan", HorizontalTextAlignment = TextAlignment.Start},1,0);
        _detailGrid.Add(new Label(){Text = "Jumlah", HorizontalTextAlignment = TextAlignment.End},2,0);
        _detailGrid.Add(new Label(){Text = "Harga Satuan", HorizontalTextAlignment = TextAlignment.End},3,0);
        _detailGrid.Add(new Label(){Text = "Total Harga", HorizontalTextAlignment = TextAlignment.End},4,0);
        _detailGrid.Add(new Label(){Text = "Aksi", HorizontalTextAlignment = TextAlignment.Center},5,0);
        
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
            };

            var detail = Details.OrderByDescending(i => i.Index).FirstOrDefault();
            
            item.Index = detail != null ? detail.Index + 1 : Details.Count()+1;
            Details.Add(item);
            GenerateRow(item, DefRows.Count());
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
                item.Index =  index+1;
                GenerateRow(item, DefRows.Count(), true);
            }
            
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private void GenerateRow(ProductReceiptDetailViewModel detail, int index, bool edit = false)
    {
        
        var row = new RowDefinition() { Height = 30 };
        _detailGrid.RowDefinitions.Add(row);
        DefRows.TryAdd(detail.Index, row);

        foreach (var (item, i) in ActionButtons.Select((item, i) => (item, i)))
        {
            if (i < ActionButtons.Count()) item.IsVisible = false;
            else item.IsVisible = true;
        }

        var delBtn = new Button()
       {
           Text = "Hapus",
           CommandParameter = detail.Index
       };
       
       ActionButtons.Add(delBtn);
       
       var productCb = new SfComboBox()
       {
            Placeholder = "Pilih Barang",
            DisplayMemberPath = "Label",
            TextMemberPath = "Label",
            SelectedValuePath = "Value",
            TextSearchMode = ComboBoxTextSearchMode.Contains,
            SelectedItem = detail.ProductId,
            IsEditable = true,
            IsFilteringEnabled = false,
            ShowBorder = false,
            BackgroundColor = Colors.Transparent,
            IsEnabled = !edit
       };
       
       var unitCb = new SfComboBox()
       {
           Placeholder = "Pilih Satuan",
           DisplayMemberPath = "Label",
           TextMemberPath = "Label",
           SelectedValuePath = "Value",
           TextSearchMode = ComboBoxTextSearchMode.Contains,
           SelectedItem = detail.UnitId,
           IsEditable = false,
           IsFilteringEnabled = false,
           ShowBorder = true,
           BackgroundColor = Colors.Transparent,
           IsEnabled = !edit
       };
       
       productCb.BindingContext = detail;
       productCb.SetBinding(SfComboBox.SelectedValueProperty, new Binding(nameof(detail.ProductId), mode: BindingMode.TwoWay));
       productCb.ItemsSource = _productOptions;
       productCb.SelectedItem = _productOptions.FirstOrDefault(i => i.Value == detail.ProductId);
       
       unitCb.BindingContext = detail;
       unitCb.SetBinding(SfComboBox.SelectedValueProperty, new Binding(nameof(detail.UnitId), mode: BindingMode.TwoWay));
       unitCb.ItemsSource = _unitOptions;
       unitCb.SelectedItem = _unitOptions.FirstOrDefault(i => i.Value == detail.UnitId);

       var jumlahEntry = new Entry()
       {
           Placeholder = "Jumlah Barang",
           BindingContext = detail.Jumlah,
           HorizontalTextAlignment = TextAlignment.Center
       };
       jumlahEntry.SetBinding(Entry.TextProperty, new Binding("Jumlah", source: detail, mode: BindingMode.TwoWay));
       jumlahEntry.Text = detail.Jumlah.ToString();

       var hargaEntry = new Entry()
       {
           Placeholder = "Harga Satuan",
           BindingContext = detail.HargaSatuan,
           HorizontalTextAlignment = TextAlignment.End
       };
       hargaEntry.SetBinding(Entry.TextProperty, new Binding("HargaSatuan", source: detail, mode: BindingMode.TwoWay));
       hargaEntry.Text = detail.HargaSatuan.ToString();

       var totalHargaEntry = new Entry()
       {
           Text = detail.TotalHarga.ToString(),
           IsReadOnly = true,
           HorizontalTextAlignment = TextAlignment.End
       };
       
       totalHargaEntry.SetBinding(Entry.TextProperty, new Binding("TotalHarga", source: detail));
       totalHargaEntry.Text = Helper.FormatToCurrency(detail.TotalHarga);
       totalHargaEntry.TextChanged += OnTotalPriceEntryTextChanged;
       
       _detailGrid.Add(productCb,0, index);
       _detailGrid.Add(unitCb,1,index);
       _detailGrid.Add(jumlahEntry,2,index);
       _detailGrid.Add(hargaEntry,3,index);
       _detailGrid.Add(totalHargaEntry,4,index);
       _detailGrid.Add(delBtn,5,index);
       
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
                if (ActionButtons.Count > 1)
                {
                    ActionButtons.Remove(ActionButtons.Last());
                    ActionButtons.Last().IsVisible = true;
                }
                
                if (DefRows.TryGetValue(rowIndexToRemove, out var rowToRemove))
                {
                    var childrenToRemove = _detailGrid.Children
                        .Where(child => _detailGrid.GetRow(child) == rowIndexToRemove)
                        .ToList();

                    foreach (var child in childrenToRemove) _detailGrid.Children.Remove(child);
                    
                    _detailGrid.RowDefinitions.Remove(rowToRemove);
                    DefRows.Remove(rowIndexToRemove);
                    var myList = Details.ToList();
                    var deleted = myList.FirstOrDefault(x => x.Index == rowIndexToRemove);
                    if (deleted != null) myList.Remove(deleted);
                    
                    Details = new ObservableCollection<ProductReceiptDetailViewModel>(myList);
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
    
    private void OnTotalPriceEntryTextChanged(object sender, TextChangedEventArgs e)
    {
        var entry = (Entry)sender;
        
        if (int.TryParse(entry.Text, NumberStyles.Number, CultureInfo.CurrentCulture, out int amount))
        {
            entry.Text = Helper.FormatToCurrency(amount);
        }
    }
}