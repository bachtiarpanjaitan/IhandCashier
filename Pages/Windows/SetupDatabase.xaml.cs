using IhandCashier.Bepe.Configs;
using IhandCashier.Bepe.Constants;
using IhandCashier.Bepe.Database;
using IhandCashier.Bepe.Entities;
using IhandCashier.Bepe.Helpers;
using IhandCashier.Bepe.Interfaces;
using IhandCashier.Bepe.Services;
using IhandCashier.Bepe.Statics;
using IhandCashier.Bepe.Types;
using IhandCashier.Bepe.ViewModels;
using IhandCashier.Layouts;
using Syncfusion.Maui.DataForm;
using SelectionChangedEventArgs = Syncfusion.Maui.Inputs.SelectionChangedEventArgs;
using SQLite;

namespace IhandCashier.Pages.Windows;

public partial class SetupDatabase
{
    private AppSetting _setting = new();
    private IcSqLite _sqlite = new();
    private IcMySql _mysql = new();
    private SfDataForm _dataSqliteForm = new();
    private SfDataForm _dataMySqlForm = new();
    private Dictionary<Enum, string> _dbtypes = AppEnumeration.GetDbTypes;
    UserService _user  = ServiceLocator.ServiceProvider.GetService<UserService>();
    private readonly IFolderPicker _folderPicker;
    public SetupDatabase(IFolderPicker folderPicker)
    {
        _folderPicker = folderPicker;
        // WindowHelper.SetWindowSize(600,650);
        InitializeComponent();
        WellcomeText.Text = "Selamat datang di Aplikasi Ihand Cashier";
        WellcomeDescription.Text = "Silahkan pilih tipe koneksi dan isi pengaturan koneksi database";
        LoadForm();
    }

    private void LoadForm()
    {
        var _options = new List<PickerOption>();
        foreach (var type in _dbtypes)
        {
            _options.Add(new PickerOption { Value = type.Value, Label = type.Key.ToString() });
        }

        _setting = AppSettingConfig.LoadInitSettings();
        
        _setting.Database.SqLite = _sqlite;
        _setting.Database.MySql = _mysql;
        
        DbType.ItemsSource = _options;
        DbType.SelectionChanged += OnDbTypeChanged;
        BtnAutoCreate.Clicked += OnClickAutoCreated;
    }

    private void OnClickAutoCreated(object sender, EventArgs e)
    {
        if(DbType.SelectedValue != null) _setting.Database.DbType = DbType.SelectedValue.ToString();    
        
        if (DbType.SelectedValue.ToString() == _dbtypes[DbTypes.SqLite])
        {
            _setting.Database.SqLite = _sqlite;
        }

        AutoCreateNewDatabase();
    }

    private async void AutoCreateNewDatabase()
    {
        try
        {
            // var pickedFolder = await _folderPicker.PickFolder();
            // var path = new Uri(pickedFolder).LocalPath;
            var path = AppSettingConfig.CreateAppPath("Resources");
            var dbpath = Path.Combine(AppSettingConfig.CreateAppPath("Data"), DatabaseConfig.DatabaseFilename);
            _setting.Database.SqLite.DbSource = dbpath;
            _setting.Database.SqLite.Version = "3";
            _setting.AppPath = path;
            _setting.Initial = false;
            
            var settingFile = Path.Combine(path, "settings.xml");
            AppSettingConfig.SaveToAppSettings(_setting, settingFile);

            //Execute query file
            var stream = ResourceHelper.ReadAsStreamReader(AppConfig.RESOURCES_FOLDER + ".Datas.sqlite_schema.sql");
            if (stream != null)
            {
                var sql = stream.ReadToEnd();
                if(File.Exists(dbpath)) File.Delete(dbpath);
                
                var sqlite = new SQLiteConnection(dbpath);
                var queries = sql.Split(new[] { ';' }, StringSplitOptions.TrimEntries);
                foreach (var query in queries)
                {
                    if(query != "") sqlite.Execute(query.Trim());
                }
            }

            if (Application.Current != null)
            {
               
                var admin = new User
                {
                    nama = "Admin",
                    username = "admin",
                    password = Crypto.Encrypt("12345678", AppConfig.APP_KEY),
                    email = "admin@admin.com",
                    is_admin = true,
                    is_active = true,
                };
                await _user.AddAsync(admin).ConfigureAwait(true);
                
                DisplayAlert("Berhasil", "Berhasil membuat database, silahkan Login menggunakan username: admin dan password: 12345678. Jangan lupa untuk mengganti password setelah login.", "OK,");
                Application.Current.MainPage = new LoginForm();
            }
               
            Console.WriteLine("Database berhasil dibuat");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Gagal membuat database karena {e.Message}");
            DisplayAlert("Gagal membuat database karena ", e.Message, "OK");
        }
    }

    private void OnDbTypeChanged(object sender, SelectionChangedEventArgs e)
    {
        SelectedDbConfig.Clear();
        if (DbType.SelectedValue.ToString() == _dbtypes[DbTypes.SqLite])
        {
            BtnAutoCreate.IsVisible = true;
            SelectSqLite();
        }
        else
        {
            BtnAutoCreate.IsVisible = false;
            SelectMySql();
        }
    }

    private void SelectSqLite()
    {
        BindingContext = new SqLiteViewModel();
        _dataSqliteForm.DataObject = _sqlite;
        _dataSqliteForm.ValidationMode = DataFormValidationMode.LostFocus;
        _dataSqliteForm.LayoutType = DataFormLayoutType.TextInputLayout;
        _dataSqliteForm.CommitMode = DataFormCommitMode.PropertyChanged;
        _dataSqliteForm.Padding = new Thickness(0);
        SelectedDbConfig.Add(_dataSqliteForm);
    }

    private void SelectMySql()
    {
        BindingContext = new MySqlViewModel();
        _dataMySqlForm.DataObject = _mysql;
        _dataMySqlForm.ValidationMode = DataFormValidationMode.LostFocus;
        _dataMySqlForm.LayoutType = DataFormLayoutType.TextInputLayout;
        _dataMySqlForm.CommitMode = DataFormCommitMode.LostFocus;
        _dataMySqlForm.Padding = new Thickness(0);
        SelectedDbConfig.Add(_dataMySqlForm);
    }
}