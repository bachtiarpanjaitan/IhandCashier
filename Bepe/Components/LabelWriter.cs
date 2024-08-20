namespace IhandCashier.Bepe.Components;

using System.IO;
using System.Text;
using Microsoft.Maui.Controls;

public class LabelWriter : TextWriter
{
    private readonly Label _label;

    public LabelWriter(Label label)
    {
        _label = label;
    }

    public override Encoding Encoding => Encoding.UTF8;

    public override void WriteLine(string value)
    {
        UpdateLabel(value);
    }

    private void UpdateLabel(string text)
    {
        // Update Label di UI Thread
        MainThread.BeginInvokeOnMainThread(() =>
        {
            _label.Text = "Log :: " + text;
        });
    }
}
