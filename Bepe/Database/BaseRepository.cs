using IhandCashier.Bepe.Configs;
using Microsoft.EntityFrameworkCore;

namespace IhandCashier.Bepe.Database
{
	public class BaseRepository
	{
		protected readonly AppDbContext Db;

		public BaseRepository()
		{
			var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
			optionsBuilder.UseSqlite(DatabaseConfig.DatabasePath());
			Db =  new AppDbContext(optionsBuilder.Options);
		}

		public IQueryable<T> Query<T>() where T : class
		{
			return Db.Set<T>();
		}
	}
}

