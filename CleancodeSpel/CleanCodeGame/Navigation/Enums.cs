using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeGame.Navigation
{
    public static class Enums
    {
        public enum MainMenu
        {
            Start,
            Create_Character,
            Settings,
            Help,
            Exit
        }

        public enum CreateCharacterMenu
        {
            Name,
            Class
        }

        public enum ProfileMenu
        {
            Home,
            TEST,
            Settings,
            Help,
            Exit
        }
    }
}
