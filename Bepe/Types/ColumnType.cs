using IhandCashier.Bepe.Constants;
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
                _ => throw new ArgumentException("Invalid column type")
            };
            return column;
        }

    }
}