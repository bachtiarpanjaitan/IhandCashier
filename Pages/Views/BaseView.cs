using IhandCashier.Bepe.Components;
using IhandCashier.Bepe.Helpers;
using IhandCashier.Bepe.Types;
using IhandCashier.Core.Maui.Providers;

namespace IhandCashier.Pages.Views;

public class BaseView : ContentView
{
    private static EventHandler _RefreshlickedHandlerRef;
    private static EventHandler _EditClickedHandlerRef;
    private static EventHandler _DeleteClickedHandlerRef;
    public event EventHandler ViewDisappeared;
    
    public static MenuFlyoutItem RefreshMenu = new() { Text = "Refresh Data"};
    public static MenuFlyoutItem EditMenu = new() { Text = "Ubah Data"};
    public static MenuFlyoutItem DeleteMenu = new() { Text = "Hapus Data"};
    public void ResetView()
    {
        DatagridProvider.Reset();
    }

    public void SetDatagridColumns(List<ColumnType> columns)
    {
        foreach (var c in columns.Select(col => col.Create()))
        {
            DatagridProvider.DataGrid.Columns.Add(c);
        }
    }

    public void SetContextMenuHandler(MenuFlyout ContextMenu, ContextMenuHandlers handler)
    {
        if (_RefreshlickedHandlerRef != null)RefreshMenu.Clicked -= _RefreshlickedHandlerRef;
        if (_EditClickedHandlerRef != null) EditMenu.Clicked -= _EditClickedHandlerRef;
        if (_DeleteClickedHandlerRef != null) DeleteMenu.Clicked -= _DeleteClickedHandlerRef;
        
        if(handler.RefreshHandler != null) ContextMenu.Add(RefreshMenu);
        if(handler.EditHandler != null) ContextMenu.Add(EditMenu);
        if (handler.DeleteHandler != null)
        {
            ContextMenu.Add(new MenuFlyoutSeparator());
            ContextMenu.Add(DeleteMenu);
        }

        
        _RefreshlickedHandlerRef = handler.RefreshHandler;
        _EditClickedHandlerRef = handler.EditHandler;
        _DeleteClickedHandlerRef = handler.DeleteHandler;

        RefreshMenu.Clicked += _RefreshlickedHandlerRef;
        EditMenu.Clicked += _EditClickedHandlerRef;
        DeleteMenu.Clicked += _DeleteClickedHandlerRef;
    }
    
}

public class ContextMenuHandlers
{
    public EventHandler? RefreshHandler { get; set; }
    public EventHandler? EditHandler { get; set; }
    public EventHandler? DeleteHandler { get; set; }
}
