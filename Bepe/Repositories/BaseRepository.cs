using System;
using IhandCashier.Bepe.Configs;
using Microsoft.EntityFrameworkCore;

namespace IhandCashier.Bepe.Repositories
{
	public static class BaseRepository
	{
		public static AppDbContext Context()
		{
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlite(DatabaseConfig.DatabasePath());

            return new AppDbContext(optionsBuilder.Options);
        }
	}
}

