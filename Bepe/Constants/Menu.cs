using System;
using IhandCashier.Pages;

namespace IhandCashier.Bepe.Constants
{
	public static class Menu
	{
        public enum MenuItemType
        {
            Home,
            Profile,
            Setting
        }

        public static Dictionary<Enum, Type> ListMenu()
        {

            return new Dictionary<Enum, Type>
            {
                { MenuItemType.Home, typeof(PageHome)},
                { MenuItemType.Profile, typeof(PageProfile)},
                { MenuItemType.Setting, typeof(PageSetting)},
            };
	    }

    }

	

	

}

