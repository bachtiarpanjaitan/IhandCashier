using System.Collections;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using IhandCashier.Bepe.Entities;

namespace IhandCashier.Bepe.ViewModels;

public class UnitViewModel : INotifyPropertyChanged, INotifyDataErrorInfo
{

    private int _id;
    private int _basic_unit_id;
    private string _kode_satuan;
    private string _nama;
    private decimal _konversi;
    
    public readonly Dictionary<string, List<string>> Errors = new();
    
    [Bindable(false)]
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
                ValidateProperty(nameof(BasicUnitId), value);
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
                ValidateProperty(nameof(KodeSatuan), value);
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
                ValidateProperty(nameof(Nama), value);
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
                ValidateProperty(nameof(Konversi), value);
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
    
    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        if (propertyName != null)
        {
            ValidateProperty(propertyName, GetType().GetProperty(propertyName)?.GetValue(this));
        }
    }
    
    public event PropertyChangedEventHandler PropertyChanged;
    public IEnumerable GetErrors(string propertyName)
    {
        return Errors.TryGetValue(propertyName, out var errors) ? errors : null;
    }

    public bool HasErrors
    {
        get => Errors.Any();
        private set { }
    }
    
    private void ValidateProperty(string propertyName, object value)
    {
        var validationContext = new ValidationContext(this) { MemberName = propertyName };
        var results = new List<ValidationResult>();

        // Validasi properti menggunakan Validator
        bool isValid = Validator.TryValidateProperty(value, validationContext, results);

        // Menyimpan hasil validasi ke dictionary _errors
        if (isValid)
        {
            Errors.Remove(propertyName);
        }
        else
        {
            Errors[propertyName] = results.Select(x => x.ErrorMessage).ToList();
        }

        // Memperbarui status HasErrors
        HasErrors = Errors.Any();

        // Notifikasi bahwa error telah berubah
        ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
    }
    
    private void ValidateAllProperties()
    {
        ValidateProperty(nameof(BasicUnitId), _basic_unit_id);
        ValidateProperty(nameof(Nama), _nama);
        ValidateProperty(nameof(KodeSatuan), _kode_satuan);
        ValidateProperty(nameof(Konversi), _konversi);

    }
    
    public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
}