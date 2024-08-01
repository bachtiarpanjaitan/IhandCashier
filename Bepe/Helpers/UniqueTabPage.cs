using IhandCashier.Bepe.Constants;

namespace IhandCashier.Layouts
{
	public class UniqueTabPage : TabbedPage
    {
        private Dictionary<String,Page> _tabs;
        public UniqueTabPage()
		{
            _tabs = new Dictionary<String,Page>();

            Type type = Type.GetType(AppConfig.PAGES_NAMESPACE + "." + AppConfig.DEFAULT_TABPAGE);
            object instance = Activator.CreateInstance(type);

            //DEFAULT TAB
            AddTab(AppConfig.DEFAULT_TABPAGE, (Page)instance);
        }

        public void AddTab(String index, Page page)
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

