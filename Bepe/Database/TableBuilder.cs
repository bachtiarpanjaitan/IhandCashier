using System;
using System.Reflection;
using System.Xml.Linq;
using IhandCashier.Bepe.Configs;
using Microsoft.Maui.Storage;

namespace IhandCashier.Bepe.Database
{
	public static class TableBuilder
	{
        //private static Builder _database = new Builder(DatabaseConfig.DatabasePath());

        public static bool Build()
        {
            if (AppConfig.ALWAYS_BUILD_TABLES)
            {


                //var assembly = Assembly.GetExecutingAssembly();
                //string targetNamespace = "IhandCashier.Bepe.Entities";
                //var types = assembly.GetTypes()
                //                    .Where(t => t.IsClass && t.Namespace == targetNamespace)
                //                    .ToList();



                //foreach (var t in types)
                //{
                //    _database.CreateTableAsync(t);
                //}

                //Dictionary<int, Type> types = Migration.Entities();
                //foreach (var t in types)
                //{
                //    _database.CreateTableAsync(t.Value);
                //}
            }
            
            return true;
        }
	}
}

