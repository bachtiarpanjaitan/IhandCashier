using System.Reflection;
using SQLite;

namespace IhandCashier.Bepe.Database
{
	public class SQLiteBuilder
	{
        private readonly SQLiteAsyncConnection _database;

        public SQLiteBuilder(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
        }

        public void CreateTableAsync(Type table)
        {

            try
            {
                if (table != null)
                {
                    _database.CreateTableAsync(table).Wait();
                }
                else
                {
                    Console.WriteLine($"Tipe {table.Name} tidak ditemukan.");
                }
            } catch(TargetInvocationException e)
            {
                Console.WriteLine("Cannot Create Table because " + e.InnerException.Message);
                Console.WriteLine("Stack Trace :  " + e.InnerException.StackTrace);
            }
        }
    }
}

