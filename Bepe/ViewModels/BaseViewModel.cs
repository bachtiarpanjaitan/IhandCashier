using System.Collections;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using IhandCashier.Bepe.Database.Attributes;

namespace IhandCashier.Bepe.ViewModels;

public class BaseViewModel : INotifyPropertyChanged, INotifyDataErrorInfo
{
    public readonly Dictionary<string, List<string>> Errors = new();
    
    public bool HasErrors
    {
        get => Errors.Any();
        private set { }
    }
    
    public void ValidateProperty(string propertyName)
    {
        // Menggunakan refleksi untuk mendapatkan nilai properti
        var property = this.GetType().GetProperty(propertyName);
        if (property == null) return; // Jika properti tidak ditemukan, keluar dari metode

        var value = property.GetValue(this);

        var validationContext = new ValidationContext(this) { MemberName = propertyName };
        var results = new List<ValidationResult>();

        // pengecualian pengecekan nilai untuk property Id apabila bernilai 0
        bool isIdProperty = property.GetCustomAttributes(typeof(IdPropertyAttribute), false).Any();

        // Validasi menggunakan Validator
        bool isValid = Validator.TryValidateProperty(value, validationContext, results);
        bool isStatusProperty = property.GetCustomAttributes(typeof(StatusPropertyAttribute), false).Any();
        if (!isStatusProperty && !isIdProperty)
        {
            var displayAttribute = property.GetCustomAttributes(typeof(DisplayAttribute), false)
                .FirstOrDefault() as DisplayAttribute;
            var displayName = displayAttribute != null ? displayAttribute.Name : propertyName;
            
            if (property.PropertyType == typeof(int) && value != null && (int) value == 0)
            {
                results.Add(new ValidationResult($"{displayName} tidak boleh bernilai 0 atau kosong", new[] { propertyName }));
                isValid = false;
            } else if (property.PropertyType == typeof(decimal) && value != null && (decimal)value == 0m)
            {
                results.Add(new ValidationResult($"{displayName} tidak boleh bernilai 0 atau kosong", new[] { propertyName }));
                isValid = false;
            }
        }

        if (isValid)
        {
            Errors.Remove(propertyName);
        }
        else
        {
            Errors[propertyName] = results.Select(x => x.ErrorMessage).ToList();
        }

        HasErrors = Errors.Any();

        ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
    }
    
    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        if (propertyName != null)
        {
            ValidateProperty(propertyName);
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;
    public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
    public IEnumerable GetErrors(string propertyName)
    {
        return Errors.TryGetValue(propertyName, out var errors) ? errors : null;
    }
    
    IEnumerable INotifyDataErrorInfo.GetErrors(string propertyName)
    {
        return GetErrors(propertyName);
    }
    
    public virtual void OnErrorsChanged(string propertyName)
    {
        ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
    }
}