using System;
namespace IhandCashier.Bepe.Helpers
{
	public class EventHandlerPageArgs : EventArgs
    {
        public object Sender { get; }
        public EventArgs OriginalEventArgs { get; }
        public string Page { get; }

        public EventHandlerPageArgs(object sender, EventArgs originalEventArgs, string page)
        {
            Sender = sender;
            OriginalEventArgs = originalEventArgs;
            Page = page;
        }
    }
}

