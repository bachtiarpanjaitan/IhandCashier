using System;
namespace IhandCashier.Bepe.Configs
{
	public class DatabaseConfig
	{
        public const string DatabaseFilename = "ihandcashier.db3";
        
        public static string DatabasePath()
        {
            if (AppConfig.SAVE_DB_IN_APPDATA)
            {
                var dir = Path.Combine(FileSystem.AppDataDirectory, AppConfig.DEFAULT_PATH);
                Directory.CreateDirectory(dir);
                return Path.Combine(dir, DatabaseFilename);
            } else
            {
                string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string path = Path.Combine(docPath, AppConfig.DEFAULT_PATH);
                try
                {
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                        Console.WriteLine("Folder created at: " + path);
                    }

                    return Path.Combine(path, DatabaseFilename);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error creating folder: " + ex.Message);
                    return null;
                }
            }
            

        }
            
            
    }
}

