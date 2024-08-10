using System;
using IhandCashier.Bepe.Configs;
using Microsoft.EntityFrameworkCore;

namespace IhandCashier.Bepe.Repositories
{
	public class BaseRepository
	{
		public AppDbContext DB;

		public BaseRepository()
		{
			var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
			optionsBuilder.UseSqlite(DatabaseConfig.DatabasePath());
			DB =  new AppDbContext(optionsBuilder.Options);
		}
	}
}

