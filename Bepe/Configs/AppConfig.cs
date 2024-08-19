
namespace IhandCashier.Bepe.Configs
{
	public static class AppConfig
	{
		public static string COMPANY_NAME = "HMP Basapadi";
        public static string PAGES_NAMESPACE = "IhandCashier.Pages";
        public static string RESOURCES_FOLDER = "IhandCashier.Resources";
        public static string PATH_FILE_MENU = RESOURCES_FOLDER + ".Datas.menu.json";
        public static string DEFAULT_TABPAGE = "PageHome";
        public static string DEFAULT_PATH = "IhandCashier"; //default penyimpanan sources
        public static int SIDE_MENU_WIDTH = 200; //pixel
        public static bool SAVE_DB_IN_APPDATA = true;
        public static int DATA_ROW_PER_PAGE = 20; // jumlah data per halaman di grid
        
	}
}

