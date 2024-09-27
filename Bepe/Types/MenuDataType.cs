using System;
namespace IhandCashier.Bepe.Types
{
	public class MenuDataType
	{
		public string Label { get; set; }
		public string Class { get; set;}
        public List<MenuDataType> Child { get; set; }

        public bool Show { get; set; } = true;

        public MenuDataType()
		{
		}
	}
}

