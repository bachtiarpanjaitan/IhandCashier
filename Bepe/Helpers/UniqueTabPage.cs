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
            if (_tabs.ContainsKey(index))
            {
                CurrentPage = _tabs[index];
            } else
            {
                _tabs.Add(index, page);
                Children.Add(page);
            }
            
        }
    }
}

