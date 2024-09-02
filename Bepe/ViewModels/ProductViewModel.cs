using System.Collections;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using IhandCashier.Bepe.Database.Attributes;
using IhandCashier.Bepe.Entities;

namespace IhandCashier.Bepe.ViewModels
{
    public class ProductViewModel : BaseViewModel
    {
        private int _id;
        private string _kode;
        private string _nama;
        private string _gambar;

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
                    ValidateProperty(nameof(Kode));
                }
            }
        }
        
        [Required(AllowEmptyStrings = false, ErrorMessage = "Nama tidak boleh kosong")]
        [MinLength(4, ErrorMessage = "Nama barang tidak boleh lebih kecil dari 4 karakter")]
        [MaxLength(20, ErrorMessage = "Maksimal panjang nama barang adalah 100 karakter")]
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
                    ValidateProperty(nameof(Nama));
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
                    ValidateProperty(nameof(Gambar));
                }
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
        
        private void ValidateAllProperties()
        {
            ValidateProperty(nameof(Kode));
            ValidateProperty(nameof(Nama));
            ValidateProperty(nameof(Gambar));
        }
    }
}
