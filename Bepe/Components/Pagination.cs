using IhandCashier.Bepe.Configs;

namespace IhandCashier.Bepe.Components
{
    public class Pagination : ContentView
    {
        public int PageIndex = 0;
        public int PageSize = 0;
        public int Total = 0;
        public int PageCount = 0;
        public Pagination()
        {
            PageIndex = 0;
            PageSize = AppConfig.DATA_ROW_PER_PAGE;
           
        }
    }
}

