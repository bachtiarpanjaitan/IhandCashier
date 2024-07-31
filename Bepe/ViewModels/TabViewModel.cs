using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace IhandCashier.Bepe.ViewModels;

public class TabViewModel : INotifyPropertyChanged
{
	public TabViewModel()
	{
		
	}

    public event PropertyChangedEventHandler PropertyChanged;

    private string _title;
    private ContentPage _contentPage;

    public string Title
    {
        get => _title;
        set
        {
            _title = value;
            OnPropertyChanged();
        }
    }

    public ContentPage ContentPage
    {
        get => _contentPage;
        set
        {
            _contentPage = value;
            OnPropertyChanged();
        }
    }

    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
