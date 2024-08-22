using IhandCashier.Bepe.ViewModels;
using Syncfusion.Maui.DataForm;

namespace IhandCashier.Pages.Forms;

public partial class FormBarang
{
    private SfDataForm _dataForm = new();
    public FormBarang()
    {
        InitializeComponent();
        _dataForm.DataObject = new ProductViewModel();
        _dataForm.ValidationMode = DataFormValidationMode.LostFocus;
        _dataForm.LayoutType = DataFormLayoutType.TextInputLayout;
        _dataForm.CommitMode = DataFormCommitMode.PropertyChanged;
        _dataForm.Padding = new Thickness(0);
        _dataForm.HeightRequest = 600;
        _dataForm.GenerateDataFormItem += AutoGeneratingDataFormItem;
        Form.Add(_dataForm);
        
    }

    private void AutoGeneratingDataFormItem(object sender, GenerateDataFormItemEventArgs e)
    {
        if (e.DataFormItem.FieldName == nameof(ProductViewModel.Gambar))
        {
            // Misalnya mengganti dengan custom file picker control
            e.DataFormItem.LayoutType = DataFormLayoutType.Default;
        }
    }

    private void BtnSimpan_OnClicked(object sender, EventArgs e)
    {
        Close();
    }

    private void BtnBatal_OnClicked(object sender, EventArgs e)
    {
        Close();
    }
}