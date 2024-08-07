using System;
using IhandCashier.Bepe.Configs;
using Microsoft.Maui.Controls;

namespace IhandCashier.Bepe.Helpers
{
	public class UniqueTabBar : TabBar
	{
        private Dictionary<string, ShellContent> _tabs;
        public UniqueTabBar()
        {
            _tabs = new Dictionary<string, ShellContent>();

            Type type = Type.GetType(AppConfig.PAGES_NAMESPACE + "." + AppConfig.DEFAULT_TABPAGE);

            AddTab(AppConfig.DEFAULT_TABPAGE, type, "Beranda");
        }

        public void AddTab(string index, Type page, string title)
        {
            if (!_tabs.ContainsKey(index))
            {
                var newPage = createTab(index, page, title);
                _tabs.Add(newPage.AutomationId, newPage);
                Items.Add(newPage);
            }

            CurrentItem = _tabs[index];
        }

        private ShellContent createTab(string index, Type v, string title)
        {
            ShellContent tab = new ShellContent();
            tab.Title = title;
            tab.AutomationId = index;
            tab.ContentTemplate = new DataTemplate(v);
            return tab;
        }
    }
}

