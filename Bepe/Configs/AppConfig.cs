namespace IhandCashier.Bepe.Configs
{
	public static class AppConfig
	{
		public static string APP_KEY = "G3Q5sFdf+WcME6r1t3yU9zNH8g1Pj5xT0B+S7N3kXwM=";
		public static string COMPANY_NAME = "HMP Basapadi";
        public static string PAGES_NAMESPACE = "IhandCashier.Pages";
        public static string RESOURCES_FOLDER = "IhandCashier.Resources";
        public static string PATH_FILE_MENU = RESOURCES_FOLDER + ".Datas.menu.json";
        public static string DEFAULT_TABPAGE = "PageHome";
        public static string DEFAULT_PATH = "IhandCashier"; //default penyimpanan sources
        public static int SIDE_MENU_WIDTH = 200; //pixel
        public static bool SAVE_DB_IN_APPDATA = true;
        public static int DATA_ROW_PER_PAGE = 20; // jumlah data per halaman di grid
        public static bool CLEAR_SESSION_WHEN_START = false;
        public static int MAIN_WIDTH = 1280;
        public static int MAIN_HEIGHT = 720;
        
        
        static AppConfig()
        {
	        
        }
        
	}
}

