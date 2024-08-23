using System.Collections;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using IhandCashier.Bepe.Entities;

namespace IhandCashier.Bepe.ViewModels
{
    public class ProductViewModel : INotifyPropertyChanged, INotifyDataErrorInfo
    {
        private int _id;
        private string _kode;
        private string _nama;
        private string _gambar;
        public readonly Dictionary<string, List<string>> Errors = new();
        
        public bool HasErrors
        {
            get => Errors.Any();
            private set { }
        }

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

        [Required(AllowEmptyStrings = false, ErrorMessage = "Kode tidak boleh kosong")]
        [MinLength(4, ErrorMessage = "Kode tidak boleh lebih kecil dari 4 karakter")]
        [MaxLength(20, ErrorMessage = "Maksimal panjang kode adalah 20 karakter")]
        [Display(Prompt = "Masukkan Kode Barang")]
        public string Kode
        {
            get => _kode;
            set
            {
                if (_kode != value)
                {
                    _kode = value;
                    OnPropertyChanged();
                    ValidateProperty(nameof(Kode), value);
                }
            }
        }
        
        [Required(AllowEmptyStrings = false, ErrorMessage = "Nama tidak boleh kosong")]
        [MinLength(4, ErrorMessage = "Nama barang tidak boleh lebih kecil dari 4 karakter")]
        [MaxLength(20, ErrorMessage = "Maksimal panjang nama barang adalah 20 karakter")]
        [Display(Prompt = "Masukkan Nama Barang")]
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
        
        [FileExtensions(Extensions = "jpg,jpeg,png", ErrorMessage = "Hanya format gambar yang diperbolehkan.")]
        public string Gambar
        {
            get => _gambar;
            set
            {
                if (_gambar != value)
                {
                    _gambar = value;
                    OnPropertyChanged();
                    ValidateProperty(nameof(Gambar), value);
                }
            }
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            if (propertyName != null)
            {
                ValidateProperty(propertyName, GetType().GetProperty(propertyName)?.GetValue(this));
            }
        }

        public ProductViewModel(Product product)
        {
            _id = product.id;
            _kode = product.kode;
            _nama = product.nama;
            _gambar = product.gambar;
        }

        public ProductViewModel()
        {
            ValidateAllProperties();
        }

        public Product ToProduct()
        {
            return new Product
            {
                id = _id,
                kode = _kode,
                nama = _nama,
                gambar = _gambar
            };
        }

        public IEnumerable GetErrors(string propertyName)
        {
            return Errors.TryGetValue(propertyName, out var errors) ? errors : null;
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



        IEnumerable INotifyDataErrorInfo.GetErrors(string propertyName)
        {
            return GetErrors(propertyName);
        }
        
        protected virtual void OnErrorsChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }
        
        private void ValidateAllProperties()
        {
            ValidateProperty(nameof(Kode), _kode);
            ValidateProperty(nameof(Nama), _nama);
            ValidateProperty(nameof(Gambar), _gambar);
        }
    }
}