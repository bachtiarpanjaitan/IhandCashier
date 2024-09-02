using System.Collections;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using IhandCashier.Bepe.Database.Attributes;
using IhandCashier.Bepe.Entities;

namespace IhandCashier.Bepe.ViewModels;

public class UnitViewModel : BaseViewModel
{

    private int _id;
    private int _basic_unit_id;
    private string _kode_satuan;
    private string _nama;
    private decimal _konversi;
    
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
    
    [Required(AllowEmptyStrings = false, ErrorMessage = "Satuan dasar tidak boleh kosong")]
    [Display(Prompt = "Masukkan Satuan Dasar")]
    public int BasicUnitId
    {
        get => _basic_unit_id;
        set
        {
            if (_basic_unit_id != value)
            {
                _basic_unit_id = value;
                OnPropertyChanged();
                ValidateProperty(nameof(BasicUnitId));
            }
        }
    }
    
    [Required(AllowEmptyStrings = false, ErrorMessage = "Kode satuan tidak boleh kosong")]
    [MaxLength(10, ErrorMessage = "Maksimal panjang kode satuan adalah 10 karakter")]
    [Display(Prompt = "Masukkan Kode Satuan")]
    public string KodeSatuan
    {
        get => _kode_satuan;
        set
        {
            if (_kode_satuan != value)
            {
                _kode_satuan = value;
                OnPropertyChanged();
                ValidateProperty(nameof(KodeSatuan));
            }
        }
    }
    
    [Required(AllowEmptyStrings = false, ErrorMessage = "Nama tidak boleh kosong")]
    [MinLength(4, ErrorMessage = "Nama tidak boleh lebih kecil dari 4 karakter")]
    [Display(Prompt = "Masukkan Nama Satuan")]
    public string Nama
    {
        get => _nama;
        set
        {
            if (_nama != value)
            {
                _nama = value;
                OnPropertyChanged();
                ValidateProperty(nameof(Nama));
            }
        }
    }
    
    [Required(AllowEmptyStrings = false, ErrorMessage = "Nilai konversi tidak boleh kosong")]
    [Display(Prompt = "Masukkan nilai konversi")]
    public decimal Konversi
    {
        get => _konversi;
        set
        {
            if (_konversi != value)
            {
                _konversi = value;
                OnPropertyChanged();
                ValidateProperty(nameof(Konversi));
            }
        }
    }

    public UnitViewModel()
    {
        ValidateAllProperties();
    }

    public UnitViewModel(Unit unit)
    {
        _id = unit.id;
        _basic_unit_id = unit.basic_unit_id;
        _kode_satuan = unit.kode_satuan;
        _nama = unit.nama;
        _konversi = unit.konversi;
        
        ValidateAllProperties();
    }

    public Unit ToUnit()
    {
        return new Unit
        {
            id = _id,
            basic_unit_id = _basic_unit_id,
            kode_satuan = _kode_satuan,
            nama = _nama,
            konversi = _konversi
        };
    }
    
    public void ValidateAllProperties()
    {
        // ValidateProperty(nameof(BasicUnitId), _basic_unit_id);
        // ValidateProperty(nameof(Nama), _nama);
        // ValidateProperty(nameof(KodeSatuan), _kode_satuan);
        // ValidateProperty(nameof(Konversi), _konversi);
        
        var properties = this.GetType().GetProperties()
            .Where(p => p.CanRead && p.CanWrite)
            .ToList();

        foreach (var property in properties)
        {
            ValidateProperty(property.Name); // Panggil metode dinamis untuk memvalidasi properti
        }

    }
}