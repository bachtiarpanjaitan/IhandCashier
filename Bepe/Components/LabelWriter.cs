namespace IhandCashier.Bepe.Components;

using System.IO;
using System.Text;
using Microsoft.Maui.Controls;

public class LabelWriter : TextWriter
{
    private readonly Label _label;
    private readonly StringBuilder _content;

    public LabelWriter(Label label)
    {
        _label = label;
        _content = new StringBuilder();
    }

    public override Encoding Encoding => Encoding.UTF8;

    public override void Write(char value)
    {
        _content.Append(value);
        UpdateLabel();
    }

    public override void Write(string value)
    {
        _content.Append(value);
        UpdateLabel();
    }

    public override void WriteLine(string value)
    {
        _content.AppendLine(value);
        UpdateLabel();
    }

    private void UpdateLabel()
    {
        // Update Label di UI Thread
        MainThread.BeginInvokeOnMainThread(() =>
        {
            _label.Text = "Log :: " + _content.ToString();
        });
    }
}
