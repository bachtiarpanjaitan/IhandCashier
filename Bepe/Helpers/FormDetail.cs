using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using IhandCashier.Bepe.Interfaces;
using IhandCashier.Bepe.Statics;

namespace IhandCashier.Bepe.Helpers;

public class FormDetail<T> where T : IIndexable
{
    public Grid DetailGrid = new ()
    {
        Margin = new Thickness(5),
        ColumnSpacing = 5,
        RowSpacing = 5
    };
    
    public Dictionary<int, RowDefinition> DefenitionRows = new Dictionary<int, RowDefinition>();
    public ObservableCollection<T> Details = new();
    public List<Button> ActionButtons = new List<Button>();

    public FormDetail()
    {
        
    }

    public void RemoveItemRow(object sender, EventArgs e)
    {
        var button = sender as Button;
        if (button != null && button.CommandParameter != null)
        {
            
            int rowIndexToRemove = (int)button.CommandParameter;
            if (Details.ToList().Count > 1)
            {
                if (ActionButtons.Count > 1)
                {
                    ActionButtons.Remove(ActionButtons.Last());
                    ActionButtons.Last().IsVisible = true;
                }
                
                if (DefenitionRows.TryGetValue(rowIndexToRemove, out var rowToRemove))
                {
                    var childrenToRemove = DetailGrid.Children
                        .Where(child => DetailGrid.GetRow(child) == rowIndexToRemove)
                        .ToList();

                    foreach (var child in childrenToRemove) DetailGrid.Children.Remove(child);
                    
                    DetailGrid.RowDefinitions.Remove(rowToRemove);
                    DefenitionRows.Remove(rowIndexToRemove);
                    var myList = Details.ToList();
                    var deleted = myList.FirstOrDefault(x => x.Index == rowIndexToRemove);
                    if (deleted != null) myList.Remove(deleted);
                    
                    Details = new ObservableCollection<T>(myList);
                }
            }
        }
    }
    
    public void OnCurrencyEntryTextChanged(object sender, TextChangedEventArgs e)
    {
        var entry = (Entry)sender;
        
        if (int.TryParse(entry.Text, NumberStyles.Number, CultureInfo.CurrentCulture, out int amount))
        {
            entry.Text = Helper.FormatToCurrency(amount);
        }
    }
}