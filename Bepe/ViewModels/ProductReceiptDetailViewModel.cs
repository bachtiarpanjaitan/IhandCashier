using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using IhandCashier.Bepe.Database.Attributes;
using IhandCashier.Bepe.Entities;

namespace IhandCashier.Bepe.ViewModels;

public class ProductReceiptDetailViewModel : BaseViewModel
{
    private int _id { get; set; }
    private int _index { get; set; }
    private int _product_receipt_id { get; set; }
    private int _product_id { get; set; }
    private int _unit_id { get; set; }
    private decimal _jumlah { get; set; }
    private decimal _harga_satuan { get; set; }
    private decimal _total_harga { get; set; }
    
    [Bindable(false)]
    [IdProperty]
    public int Id
    {
        get => _id;
        set
        {
            if (_id != value)
            {
                _id = value;
                OnPropertyChanged();
            }
        }
    }
    
    public int Index
    {
        get => _index;
        set
        {
            if (_index != value)
            {
                _index = value;
                OnPropertyChanged();
            }
        }
    }
    
    [Bindable(false)]
    public int ProductReceiptId
    {
        get => _product_receipt_id;
        set
        {
            if (_product_receipt_id != value)
            {
                _product_receipt_id = value;
                OnPropertyChanged();
            }
        }
    }
    
    [Display(Name = "Barang")]
    public int ProductId
    {
        get => _product_id;
        set
        {
            if (_product_id != value)
            {
                _product_id = value;
                OnPropertyChanged();
            }
        }
    }
    
    [Display(Name = "Satuan")]
    public int UnitId
    {
        get => _unit_id;
        set
        {
            if (_unit_id != value)
            {
                _unit_id = value;
                OnPropertyChanged();
            }
        }
    }
    
    [Display(Name = "Jumlah")]
    public decimal Jumlah
    {
        get => _jumlah;
        set
        {
            if (_jumlah != value)
            {
                _jumlah = value;
                OnPropertyChanged();
            }
        }
    }
    
    [Display(Name = "Harga Satuan")]
    public decimal HargaSatuan
    {
        get => _harga_satuan;
        set
        {
            if (_harga_satuan != value)
            {
                _harga_satuan = value;
                OnPropertyChanged();
            }
        }
    }
    
    [Display(Name = "Total Harga")]
    public decimal TotalHarga
    {
        get => _total_harga;
        set
        {
            if (_total_harga != value)
            {
                _total_harga = value;
                OnPropertyChanged();
            }
        }
    }
    
    public ProductReceiptDetailViewModel()
    {
        ValidateAllProperties();
    }

    private void ValidateAllProperties()
    {
        ValidateProperty(nameof(ProductId));
        ValidateProperty(nameof(UnitId));
        ValidateProperty(nameof(Jumlah));
        ValidateProperty(nameof(HargaSatuan));
    }
    
    public ProductReceiptDetail ToEntity()
    {
        return new ProductReceiptDetail
        {
            id = _id,
            product_receipt_id = _product_receipt_id,
            product_id = _product_id,
            unit_id = _unit_id,
            jumlah = _jumlah,
            harga_satuan = _harga_satuan,
        };
    }
}