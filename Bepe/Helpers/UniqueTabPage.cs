using IhandCashier.Bepe.Configs;

namespace IhandCashier.Layouts
{
	public class UniqueTabPage : TabbedPage
    {
        private Dictionary<String,Page> _tabs;
        public UniqueTabPage()
		{
            _tabs = new Dictionary<String, Page>();

            Type type = Type.GetType(AppConfig.PAGES_NAMESPACE + "." + AppConfig.DEFAULT_TABPAGE);
            object instance = Activator.CreateInstance(type);

            //DEFAULT TAB
            AddTab(AppConfig.DEFAULT_TABPAGE, (ContentView)instance, "Beranda");
        }

        public void AddTab(String index, ContentView page, string title)
        {
            if (!_tabs.ContainsKey(index))
            {
                var newPage = createTab(index, page, title);
                _tabs.Add(newPage.AutomationId, newPage);
                Children.Add(newPage);
            }
            CurrentPage = _tabs[index];

        }

        private Page createTab(string index, ContentView v, string title)
        {
            ContentPage contentPage = new ContentPage
            {
                AutomationId = index,
                Title = title

            };
            var page = contentPage;
            page.Content = v;
            return page;
        }
    }
}

