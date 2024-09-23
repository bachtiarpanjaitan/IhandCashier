using System.Collections.ObjectModel;
using System.ComponentModel;
using IhandCashier.Bepe.Constants;
using IhandCashier.Bepe.Database;
using IhandCashier.Bepe.Helpers;
using IhandCashier.Bepe.Interfaces;
using IhandCashier.Bepe.Services;
using IhandCashier.Bepe.Statics;
using IhandCashier.Bepe.Types;
using IhandCashier.Bepe.ViewModels;
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
    private FormDetail<ProductReceiptDetailViewModel> FormDetail = new();
    
    public FormPenerimaanBarang()
    {
        Initialize();
    }

    public FormPenerimaanBarang(ProductReceiptViewModel model = null)
    {
        _model = model;
        if (model != null) FormDetail.Details = new ObservableCollection<ProductReceiptDetailViewModel>(model.Details);
        Initialize();
    }

    public void Initialize()
    {
        InitializeComponent();
        _model.ErrorsChanged += OnErrorsChanged;
        _model.Tanggal = DateTime.Now;
        if (_model.KodeTransaksi == null)  _model.KodeTransaksi = Helper.GenerateTransactionCode("PR");
        BindingContext = _model;
        
        SetTitle("Form Penerimaan Barang").SetSize(1000, 800).Create(Content);
        BtnClose.Clicked += BtnBatal_OnClicked;
        BtnSave.Clicked += BtnSimpan_OnClicked;

        FormDetail.DetailGrid.ColumnDefinitions = new ColumnDefinitionCollection()
        {
            new() { Width = GridLength.Star },
            new() { Width = GridLength.Star },
            new() { Width = 50 },
            new() { Width = GridLength.Star },
            new() { Width = GridLength.Star },
            new() { Width = 60 },
        };
        
        DetailContainer.Add(new Frame()
        {
            Content = FormDetail.DetailGrid,
            BorderColor = Colors.Gray,
            BackgroundColor = Colors.Transparent,
            Padding = 0,
            Margin = new Thickness(10,0,0,0)
        });
        
        FormDetail.DefenitionRows.Clear();
        FormDetail.DefenitionRows.Add(0, new RowDefinition() { Height = 30 });
        
        FormDetail.DetailGrid.Add(new Label(){Text = "Barang", HorizontalTextAlignment = TextAlignment.Start},0,0);
        FormDetail.DetailGrid.Add(new Label(){Text = "Satuan", HorizontalTextAlignment = TextAlignment.Start},1,0);
        FormDetail.DetailGrid.Add(new Label(){Text = "Jumlah", HorizontalTextAlignment = TextAlignment.End},2,0);
        FormDetail.DetailGrid.Add(new Label(){Text = "Harga Satuan", HorizontalTextAlignment = TextAlignment.End},3,0);
        FormDetail.DetailGrid.Add(new Label(){Text = "Total Harga", HorizontalTextAlignment = TextAlignment.End},4,0);
        FormDetail.DetailGrid.Add(new Label(){Text = "", HorizontalTextAlignment = TextAlignment.Center},5,0);
        
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

            var detail = FormDetail.Details.OrderByDescending(i => i.Index).FirstOrDefault();
            
            item.Index = detail != null ? detail.Index + 1 : FormDetail.Details.Count()+1;
            FormDetail.Details.Add(item);
            GenerateRow(item, FormDetail.DefenitionRows.Count());
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
            
            foreach (var (item, index) in FormDetail.Details.Select((item, index) => (item, index)))
            {
                item.Index =  index+1;
                GenerateRow(item, FormDetail.DefenitionRows.Count(), true);
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
        FormDetail.DetailGrid.RowDefinitions.Add(row);
        FormDetail.DefenitionRows.TryAdd(detail.Index, row);

        foreach (var (item, i) in FormDetail.ActionButtons.Select((item, i) => (item, i)))
        {
            if (i < FormDetail.ActionButtons.Count()) item.IsVisible = false;
            else item.IsVisible = true;
        }

        var delBtn = new Button()
       {
           Text = "Hapus",
           CommandParameter = detail.Index
       };
       
        FormDetail.ActionButtons.Add(delBtn);
       
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
            ShowBorder = true,
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
       totalHargaEntry.TextChanged += FormDetail.OnCurrencyEntryTextChanged;
       
       FormDetail.DetailGrid.Add(productCb,0, index);
       FormDetail.DetailGrid.Add(unitCb,1,index);
       FormDetail.DetailGrid.Add(jumlahEntry,2,index);
       FormDetail.DetailGrid.Add(hargaEntry,3,index);
       FormDetail.DetailGrid.Add(totalHargaEntry,4,index);
       FormDetail.DetailGrid.Add(delBtn,5,index);
       
       delBtn.Clicked += FormDetail.RemoveItemRow;
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
                data.Details = FormDetail.Details.Select(d => d.ToEntity()).ToList();
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
    
    private void OnErrorsChanged(object sender, DataErrorsChangedEventArgs e)
    {
        if (e.PropertyName != null)
        {
            OnPropertyChanged(e.PropertyName);
        }
    }
    
}