using IhandCashier.Bepe.Configs;
using IhandCashier.Bepe.Constants;
using IhandCashier.Bepe.Services;
using IhandCashier.Bepe.Types;
using Syncfusion.Maui.DataForm;
using SelectionChangedEventArgs = Syncfusion.Maui.Inputs.SelectionChangedEventArgs;

namespace IhandCashier.Pages.Views;

public partial class SettingApplication
{
    private static AppSetting _settings;
    private SfDataForm _dataSqliteForm = new();
    private SfDataForm _dataMySqlForm = new();
    private Dictionary<Enum, string> _dbtypes = AppEnumeration.GetDbTypes;
    public SettingApplication()
    {
        InitializeComponent();
        _settings = AppSettingConfig.LoadSettings();
        if (_settings == null) _settings = AppSettingService.Settings;
        
        Application.Current.UserAppTheme = (_settings.Thema.Selected == "Dark") ? AppTheme.Dark : AppTheme.Light;
        BindingContext = _settings;
        ThemeSelector.SelectionChanged += OnThemeChanged;
        SelectedDbConfig.Clear();
        LoadDatabaseConfig();
    }

    private void LoadDatabaseConfig()
    {
        if (_settings.Database.DbType == _dbtypes[DbTypes.SqLite])
        {
            _dataSqliteForm.DataObject = _settings.Database.SqLite;
            _dataSqliteForm.ValidationMode = DataFormValidationMode.LostFocus;
            _dataSqliteForm.LayoutType = DataFormLayoutType.TextInputLayout;
            _dataSqliteForm.CommitMode = DataFormCommitMode.PropertyChanged;
            _dataSqliteForm.Padding = new Thickness(0);
            SelectedDbConfig.Add(_dataSqliteForm);
        }
        else
        {
            
            _dataMySqlForm.DataObject = _settings.Database.MySql;
            _dataMySqlForm.ValidationMode = DataFormValidationMode.LostFocus;
            _dataMySqlForm.LayoutType = DataFormLayoutType.TextInputLayout;
            _dataMySqlForm.CommitMode = DataFormCommitMode.LostFocus;
            _dataMySqlForm.Padding = new Thickness(0);
            SelectedDbConfig.Add(_dataMySqlForm);
        }
    }

    private void OnThemeChanged(object sender, SelectionChangedEventArgs selectionChangedEventArgs)
    {
        Application.Current.UserAppTheme = (_settings.Thema.Selected == "Dark") ? AppTheme.Dark : AppTheme.Light;
        AppSettingConfig.SaveToAppSettings(_settings);
    }
}