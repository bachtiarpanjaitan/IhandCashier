using System.Reflection;
using IhandCashier.Bepe.Configs;

namespace IhandCashier.Bepe.Helpers
{
	public class UniqueTabPage : TabbedPage
    {
        private Dictionary<string,ContentPage> _tabs;
        public UniqueTabPage()
		{
            _tabs = new Dictionary<string, ContentPage>();

            try
            {
                Type type = Type.GetType(AppConfig.PAGES_NAMESPACE + "." + AppConfig.DEFAULT_TABPAGE);
                object instance = Activator.CreateInstance(type);

                //DEFAULT TAB
                AddTab(AppConfig.DEFAULT_TABPAGE, (ContentView)instance, "Beranda");
            }
            catch (Exception e)
            {
                Console.WriteLine("Cannot Create tabbedpage because " + e.Message);
                Console.WriteLine("Stack Trace :  " + e.StackTrace);
            }
        }

        public void AddTab(String index, ContentView page, string title)
        {
           try
            {
                if (!_tabs.ContainsKey(index))
                {
                    var newPage = createTab(index, page, title);
                    _tabs.Add(newPage.AutomationId, newPage);
                    Children.Add(newPage);
                }

                var tab = _tabs[index];

                CurrentPage = tab;
            } catch(Exception ex)
            {
                DisplayAlert("Menu Error", ex.Message, "Ya");
            }

        }

        private ContentPage createTab(string index, ContentView v, string title)
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

