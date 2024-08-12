using System;
using System.Reflection;
using IhandCashier.Bepe.Configs;
using Microsoft.EntityFrameworkCore;

namespace IhandCashier.Bepe.Database
{
	public class BaseRepository
	{
		protected AppDbContext DB;

		public BaseRepository()
		{
			var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
			optionsBuilder.UseSqlite(DatabaseConfig.DatabasePath());
			DB =  new AppDbContext(optionsBuilder.Options);
		}

		public IQueryable<T> GetData<T>() where T : class
		{
			return DB.Set<T>();
		}
	}
}

