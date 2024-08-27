using CommunityToolkit.Maui.Views;
using IhandCashier.Bepe.Components;
using IhandCashier.Bepe.Constants;
using IhandCashier.Bepe.Helpers;
using Syncfusion.Maui.DataGrid;

namespace IhandCashier.Bepe.Types
{
    public class ColumnType
    {
        public ColumnTypes Type { get; set; } = ColumnTypes.Text;
        public string MappingName { get; set; } = "id";
        public string HeaderText { get; set; } = "ID";
        public ColumnWidthMode ColumnMode { get; set; } = ColumnWidthMode.Fill;
        public double? Width { get; set; }

        public TextAlignment TextAlignment { get; set; } = TextAlignment.Start;

        public int ImageHeight = 20;
        public int ImageWidth = 20;

        public string Format { get; set; } = "";
        
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
                ColumnTypes.Date => new DataGridDateColumn()
                {
                    MappingName = MappingName, HeaderText = HeaderText, CellTextAlignment = TextAlignment, ColumnWidthMode = ColumnMode, Format = Format
                },
                ColumnTypes.Checkbox => new DataGridDateColumn()
                {
                    MappingName = MappingName, HeaderText = HeaderText, CellTextAlignment = TextAlignment, ColumnWidthMode = ColumnMode, Format = Format
                },
                ColumnTypes.Image => new DataGridTemplateColumn()
                {
                    Width =  Width??100, MappingName = MappingName, HeaderText = HeaderText, CellTextAlignment = TextAlignment, ColumnWidthMode = ColumnMode, CellTemplate = new DataTemplate(
                        () =>
                        {
                            Image image = new Image
                            {
                                HeightRequest = ImageHeight,
                                WidthRequest = ImageWidth
                            };
                            
                            var tapGestureRecognizer = new TapGestureRecognizer();
                            tapGestureRecognizer.Tapped += Image_Tapped;
                            image.GestureRecognizers.Add(tapGestureRecognizer);
                            image.SetBinding(Image.SourceProperty, MappingName);
                            return image;
                        })
                },
                _ => throw new ArgumentException("Invalid column type")
            };
            return column;
        }
        
        private async void Image_Tapped(object sender, EventArgs e)
        {
            if (sender is Image img)
            {
                var manager = new PopupManager();
                var imagePopup = new ImagePreviewPopup()
                {
                    CanBeDismissedByTappingOutsideOfPopup = false
                };
                imagePopup.SetImage(img.Source,500,500);
                await manager.ShowPopupAsync(imagePopup);
            }
        }

    }
}