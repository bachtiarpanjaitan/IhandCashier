using System.Globalization;
using IhandCashier.Bepe.Components;
using IhandCashier.Bepe.Constants;
using IhandCashier.Bepe.Helpers;
using Syncfusion.Maui.DataGrid;

namespace IhandCashier.Bepe.Types
{
    public class ColumnType : IDisposable
    {
        public ColumnTypes Type { get; set; } = ColumnTypes.Text;
        public string MappingName { get; set; } = "id";
        public string MappingImage { get; set; } = "";
        public string HeaderText { get; set; } = "ID";
        public ColumnWidthMode ColumnMode { get; set; } = ColumnWidthMode.Fill;
        public double? Width { get; set; }

        public TextAlignment TextAlignment { get; set; } = TextAlignment.Start;

        public int ImageHeight = 20;
        public int ImageWidth = 20;
        public string Format { get; set; } = "";
        
        private readonly PopupManager _popupManager = new();
        private TapGestureRecognizer _tapGestureRecognizer;
        private EventHandler<TappedEventArgs> _imageTappedHandler;
        private EventHandler _buttonClickedHandler;
        
        public DataGridColumn Create()
        {
            DataGridColumn column = Type switch
            {
                ColumnTypes.Text => new DataGridTextColumn
                {
                    MappingName = MappingName, HeaderText = HeaderText, CellTextAlignment = TextAlignment, ColumnWidthMode = ColumnMode, Format = Format
                },
                ColumnTypes.Numeric => new DataGridNumericColumn()
                {
                    MappingName = MappingName, HeaderText = HeaderText, CellTextAlignment = TextAlignment, ColumnWidthMode = ColumnMode, Format = Format
                },
                ColumnTypes.Currency => new DataGridNumericColumn()
                {
                    MappingName = MappingName, 
                    HeaderText = HeaderText, 
                    CellTextAlignment = TextAlignment.End, 
                    ColumnWidthMode = ColumnMode, 
                    Format = "C2",
                    CultureInfo = new CultureInfo("id-ID")
                },
                ColumnTypes.Date => new DataGridTextColumn()
                {
                    MappingName = MappingName, 
                    HeaderText = HeaderText, 
                    CellTextAlignment = TextAlignment.Start, 
                    ColumnWidthMode = ColumnMode, 
                    Format = Format != "" ? Format : "dddd, yyyy-MM-dd",
                    CultureInfo = new CultureInfo("id-ID")
                },
                ColumnTypes.Datetime => new DataGridTextColumn()
                {
                    MappingName = MappingName, 
                    HeaderText = HeaderText, 
                    CellTextAlignment = TextAlignment.Start, 
                    ColumnWidthMode = ColumnMode, 
                    Format =  "dddd, yyyy-MM-dd HH:mm:ss",
                    CultureInfo = new CultureInfo(Format != "" ? Format :"id-ID")
                },
                ColumnTypes.Checkbox => new DataGridCheckBoxColumn()
                {
                    MappingName = MappingName, HeaderText = HeaderText, CellTextAlignment = TextAlignment, ColumnWidthMode = ColumnMode, Format = Format
                },
                ColumnTypes.Image => CreateImageColumn(),
                ColumnTypes.Detail => CreateDetailColumn(),
                _ => throw new ArgumentException("Invalid column type")
            };
            column.CellStyle = new Style(typeof(DataGridCell))
            {
                Setters = { 
                    new Setter
                    {
                        Property = DataGridCell.PaddingProperty,
                        Value = new Thickness(8,3)
                    },
                    new Setter
                    {
                        Property = DataGridCell.MarginProperty,
                        Value = new Thickness(8,3)
                    }
                }
            };
            return column;
        }
        
        private DataGridColumn CreateImageColumn()
        {
            _tapGestureRecognizer = new TapGestureRecognizer();
            _imageTappedHandler = (s, args) => Image_Tapped(s, args);
            _tapGestureRecognizer.Tapped += _imageTappedHandler;
            
            return new DataGridTemplateColumn
            {
                Width = Width ?? 100,
                MappingName = MappingName,
                HeaderText = HeaderText,
                CellTextAlignment = TextAlignment,
                ColumnWidthMode = ColumnMode,
                CellTemplate = new DataTemplate(() =>
                {
                    var img = new Image
                    {
                        WidthRequest = ImageWidth,
                        HeightRequest = ImageHeight
                    };
                    
                    img.SetBinding(Image.SourceProperty, MappingName);
                    img.GestureRecognizers.Add(_tapGestureRecognizer);
                    return img;
                })
            };
        }
        
        private DataGridColumn CreateDetailColumn()
        {
            _buttonClickedHandler = (s, args) => ShowDetail(s, args);

            return new DataGridTemplateColumn
            {
                Width = Width ?? 100,
                HeaderText = HeaderText,
                CellTextAlignment = TextAlignment,
                ColumnWidthMode = ColumnMode,
                CellTemplate = new DataTemplate(() =>
                {
                    var btn = new Button
                    {
                        Text = "Detail",
                        TextColor = Colors.Coral,
                        BorderColor = Colors.Transparent,
                        Margin = new Thickness(0)
                    };
                    btn.SetBinding(Button.CommandParameterProperty, ".");
                    btn.Clicked += _buttonClickedHandler;
                    return btn;
                })
            };
        }

        private void ShowDetail(object sender, EventArgs e)
        {
            
            if (sender is Button btn)
            {
                dynamic context = btn?.CommandParameter;
                
                var popup = new DetailPreviewPopup()
                {
                    CanBeDismissedByTappingOutsideOfPopup = false
                };

                if (context != null)
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        popup.SetData(context.Views);
                        _popupManager.ShowPopup(popup);
                    });
                }
                
            }
        }

        private void Image_Tapped(object sender, EventArgs e)
        {
            if (sender is Image img)
            {
                var popup = new ImagePreviewPopup()
                {
                    CanBeDismissedByTappingOutsideOfPopup = false
                };
                if (img.Source is FileImageSource source)
                {
                    string path = source.File.Replace("/Thumbnails","");
                    popup.SetImage(path,500,500);
                    _popupManager.ShowPopupAsync(popup).ConfigureAwait(true);
                }
            }
        }

        public void Dispose()
        {
            if (_tapGestureRecognizer != null)
            {
                _tapGestureRecognizer.Tapped -= _imageTappedHandler;
                _tapGestureRecognizer = null;
                _imageTappedHandler = null;
            }

            if (_buttonClickedHandler != null) _buttonClickedHandler = null;

            // If PopupManager holds resources, dispose it too
            _popupManager?.Dispose();
        }
    }
}