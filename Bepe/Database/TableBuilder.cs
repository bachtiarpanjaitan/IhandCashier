using System.Reflection;
using IhandCashier.Bepe.Configs;

namespace IhandCashier.Bepe.Database
{
	public static class TableBuilder
	{
        private static SQLiteBuilder db = new SQLiteBuilder(DatabaseConfig.DatabasePath());

        public static bool Build()
        {
            if (!AppConfig.ALWAYS_BUILD_TABLES) return true;
            try
            {
                var assembly = Assembly.GetExecutingAssembly();
                string targetNamespace = "IhandCashier.Bepe.Migrations";
                var types = assembly.GetTypes()
                    .Where(t => t.IsClass && t.Namespace == targetNamespace)
                    .ToList();

                foreach (var t in types)
                {
                    if (t != null && t.IsAbstract && t.IsSealed)
                    {
                        FieldInfo[] fieldInfos = t.GetFields(BindingFlags.Static | BindingFlags.Public);
                        foreach (var fieldInfo in fieldInfos)
                        {
                            string fn = fieldInfo.Name;
                            object fv = fieldInfo.GetValue(null);

                            if (fn != "Table") continue;
                            if (fv != null) db.CreateTableAsync(Type.GetType(fv.ToString()));
                        }

                    }
                }
            }
            catch (TargetInvocationException e)
            {
                if (e.InnerException != null)
                {
                    Console.WriteLine("Cannot Create Table because " + e.InnerException.Message);
                    Console.WriteLine("Stack Trace :  " + e.InnerException.StackTrace);
                }
            }

            return true;
        }
	}
}

