using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using IhandCashier.Bepe.Database.Attributes;
using IhandCashier.Bepe.Entities;

namespace IhandCashier.Bepe.ViewModels;

public class BasicUnitViewModel: BaseViewModel
{
    private int _id;
    private string _nama;
    
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
    
    [Required(AllowEmptyStrings = false, ErrorMessage = "Nama tidak boleh kosong")]
    [MinLength(4, ErrorMessage = "Nama tidak boleh lebih kecil dari 4 karakter")]
    [Display(Prompt = "Masukkan Nama Satuan Dasar")]
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
    
    public BasicUnitViewModel()
    {
        ValidateAllProperties();
    }
    
    public BasicUnitViewModel(BasicUnit unit)
    {
        _id = unit.id;
        _nama = unit.nama;
    }

    public BasicUnit ToEntity()
    {
        return new BasicUnit
        {
            id = _id,
            nama = _nama
        };
    }
    
    public void ValidateAllProperties()
    {
        ValidateProperty(nameof(Nama));

    }
}