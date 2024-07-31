using Microsoft.Maui.Controls;
using System.Collections.Generic;
using System.Linq;

namespace IhandCashier.Layouts
{
	public class UniqueTabPage : TabbedPage
    {
        private Dictionary<Enum,Page> _tabs;

        public UniqueTabPage()
		{
            _tabs = new Dictionary<Enum,Page>();
        }

        public void AddTab(Enum index, Page page)
        {
            if (!_tabs.ContainsKey(index))
            {
                _tabs.Add(index, page);
                Children.Add(page);
            }
            CurrentPage = _tabs[index];

        }
    }
}

