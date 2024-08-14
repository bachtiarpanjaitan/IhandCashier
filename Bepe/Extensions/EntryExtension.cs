using Timer = System.Timers.Timer;

namespace IhandCashier.Bepe.Extensions;

public static class EntryExtensions
{
    public static void DebounceTextChanged(this Entry entry, EventHandler<TextChangedEventArgs> handler, int debounceTime = 1000)
    {
        Timer debounceTimer = new Timer(debounceTime);
        debounceTimer.AutoReset = false;

        debounceTimer.Elapsed += (sender, e) =>
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                handler.Invoke(entry, new TextChangedEventArgs(entry.Text, entry.Text));
            });
        };

        entry.TextChanged += (sender, e) =>
        {
            if (debounceTimer.Enabled)
            {
                debounceTimer.Stop();
            }

            debounceTimer.Start();
        };
    }
}