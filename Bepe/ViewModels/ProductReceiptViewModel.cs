using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using IhandCashier.Bepe.Database.Attributes;
using IhandCashier.Bepe.Entities;

namespace IhandCashier.Bepe.ViewModels;

public class ProductReceiptViewModel : BaseViewModel
{
    private int _id;
    private string _kode_transaksi;
    private int _supplier_id;
    private string _penerima;
    private DateTime _tanggal;
    private string _keterangan;
    private int _status;
    private List<ProductReceiptDetailViewModel> _details;
    
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
    
    [Display(Name = "Kode Penerimaan")]
    public string KodeTransaksi
    {
        get => _kode_transaksi;
        set
        {
            if (_kode_transaksi != value)
            {
                _kode_transaksi = value;
                OnPropertyChanged();
                ValidateProperty(nameof(KodeTransaksi));
            }
        }
    }
    
    [Required(AllowEmptyStrings = false, ErrorMessage = "Pemasok tidak boleh kosong")]
    [Display(Prompt = "Pilih Nama Pemasok",Name = "Pemasok")]
    public int SupplierId
    {
        get => _supplier_id;
        set
        {
            if (_supplier_id != value)
            {
                _supplier_id = value;
                OnPropertyChanged();
                ValidateProperty(nameof(SupplierId));
            }
        }
    }
    
    [Required(AllowEmptyStrings = false, ErrorMessage = "Tanggal tidak boleh kosong")]
    [Display(Prompt = "Pilih Tanggal Transaksi")]
    public DateTime Tanggal
    {
        get => _tanggal;
        set
        {
            if (_tanggal != value)
            {
                _tanggal = value;
                OnPropertyChanged();
                ValidateProperty(nameof(Tanggal));
            }
        }
    }
    
    public string Keterangan
    {
        get => _keterangan;
        set
        {
            if (_keterangan != value)
            {
                _keterangan = value;
                OnPropertyChanged();
                ValidateProperty(nameof(Keterangan));
            }
        }
    }
    
    [Required(AllowEmptyStrings = false, ErrorMessage = "Status tidak boleh kosong")]
    [Display(Prompt = "Pilih Status Transaksi")]
    [StatusProperty]
    public int Status
    {
        get => _status;
        set
        {
            if (_status != value)
            {
                _status = value;
                OnPropertyChanged();
                ValidateProperty(nameof(Status));
            }
        }
    }
    
    [Required(AllowEmptyStrings = false, ErrorMessage = "Penerima tidak boleh kosong")]
    [MinLength(4, ErrorMessage = "Penerima tidak boleh lebih kecil dari 4 karakter")]
    [Display(Prompt = "Masukkan Nama Penerima")]
    public string Penerima
    {
        get => _penerima;
        set
        {
            if (_penerima != value)
            {
                _penerima = value;
                OnPropertyChanged();
                ValidateProperty(nameof(Penerima));
            }
        }
    }

    public List<ProductReceiptDetailViewModel> Details
    {
        get => _details;
        set
        {
            if (_details != value)
            {
                _details = value;
                OnPropertyChanged();
                ValidateProperty(nameof(ProductReceiptDetailViewModel));
            }
        }
    }

    public ProductReceiptViewModel()
    {
        ValidateAllProperties();
    }

    public ProductReceiptViewModel(ProductReceipt item)
    {
        _id = item.id;
        _kode_transaksi = item.kode_transaksi;
        _supplier_id = item.supplier_id;
        _penerima = item.penerima;
        _tanggal = item.tanggal;
        _keterangan = item.keterangan;
        _status = item.status;
        _details = item.Details.Select(x => new ProductReceiptDetailViewModel()
        {
          Id = x.id,
          ProductReceiptId = x.product_receipt_id,
          ProductId = x.product_id,
          UnitId = x.unit_id,
          Jumlah = x.jumlah,
          HargaSatuan = x.harga_satuan,
        }).ToList();

    }
    
    public ProductReceipt ToEntity()
    {
        return new ProductReceipt
        {
            id = _id,
            kode_transaksi = _kode_transaksi,
            supplier_id = _supplier_id,
            penerima = _penerima,
            tanggal = _tanggal,
            keterangan = _keterangan,
            status = _status
        };
    }

    public void ValidateAllProperties()
    {
        ValidateProperty(nameof(SupplierId));
        ValidateProperty(nameof(Penerima));
        ValidateProperty(nameof(Tanggal));
        ValidateProperty(nameof(Status));
    }
}