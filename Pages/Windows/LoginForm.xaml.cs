using IhandCashier.Bepe.Database;
using IhandCashier.Bepe.Helpers;
using IhandCashier.Bepe.Services;
using IhandCashier.Bepe.ViewModels;
using Syncfusion.Maui.DataForm;

namespace IhandCashier.Pages.Windows;

public partial class LoginForm : ContentPage
{
    private SfDataForm _form = new();
    private DataLogin _dataLogin = new();
    UserService _user  = ServiceLocator.ServiceProvider.GetService<UserService>();
    public LoginForm()
    {
        InitializeComponent();
        WidthRequest = 500;
        HeightRequest = 520;
        WellcomeText.Text = "Selamat datang di Aplikasi Ihand Cashier";
        Copyright.Text = $"\u00a9 {DateTime.Now.Year} HMP Basapadi";
        LoadForm();
    }

    private void LoadForm()
    {
        BindingContext = new UserLoginViewModel();
        _form.DataObject = _dataLogin;
        _form.ValidationMode = DataFormValidationMode.LostFocus;
        _form.CommitMode = DataFormCommitMode.PropertyChanged;
        _form.LayoutType = DataFormLayoutType.TextInputLayout;
        FormLogin.Add(_form);

        BtnLogin.Clicked += OnClickBtnLogin;
    }

    private void OnClickBtnLogin(object sender, EventArgs e)
    {
        bool isValid = _form.Validate();
        if (isValid)
        {   
            LoadingIndicator.IsRunning = true;
            LoadingIndicator.IsVisible = true;

            try
            {
                if (_user.Login(_dataLogin).IsLogin)
                {
                    LoadingIndicator.IsRunning = false;
                    LoadingIndicator.IsVisible = false;
                    if (Application.Current != null) Application.Current.MainPage = new AppShell();
                }
            }
            catch (Exception exception)
            {
                DisplayAlert("Gagal Masuk", $"Gagal masuk karena {exception.Message}", "OK");
                LoadingIndicator.IsRunning = false;
                LoadingIndicator.IsVisible = false;
            }
        }
        
    }
}