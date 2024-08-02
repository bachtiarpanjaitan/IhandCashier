using System;
namespace IhandCashier.Bepe.Helpers
{
	public class EventHandlerPageArgs : EventArgs
    {
        public object Sender { get; }
        public EventArgs OriginalEventArgs { get; }
        public Page Page { get; }

        public EventHandlerPageArgs(object sender, EventArgs originalEventArgs, Page page)
        {
            Sender = sender;
            OriginalEventArgs = originalEventArgs;
            Page = page;
        }
    }
}

