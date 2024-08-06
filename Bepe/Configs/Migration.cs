using System;
using IhandCashier.Bepe.Entities;
namespace IhandCashier.Bepe.Configs
{
	public static class Migration
	{
		public static Dictionary<int, Type> Entities()
		{
			return new Dictionary<int, Type>
			{
				{1, typeof(Unit) },
				{2, typeof(BasicUnit) },
				{3, typeof(Product) },
				{4, typeof(User) },
            };
		}

	}
}

