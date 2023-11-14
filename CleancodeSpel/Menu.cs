using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleancodeSpel
{
    public class Menu
    {

        public static void Show()
        {
            bool loop = true;
            while (loop)
            {

                foreach (int i in Enum.GetValues(typeof(Enums.MenuList)))
                {
                    Console.WriteLine($"{i}. {Enum.GetName(typeof(Enums.MenuList), i).Replace('_', ' ')}");
                }

                int nr;
                Enums.MenuList menu = (Enums.MenuList)99; // Default
                if (int.TryParse(Console.ReadKey(true).KeyChar.ToString(), out nr))
                {
                    menu = (Enums.MenuList)nr;
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("Fel inmatning");
                }

                switch (menu)
                {
                    case Enums.MenuList.Hello_World:
                        Console.WriteLine("Hejsan världen");
                        break;
                    case Enums.MenuList.Time:
                        Console.WriteLine(DateTime.Now);
                        break;
                    case Enums.MenuList.Quit:
                        loop = false;
                        break;
                    case Enums.MenuList.Visa_alla_produkter:
                        Console.WriteLine("Ost, mjölk...");
                        break;
                    case Enums.MenuList.Level1_Right:
                        Console.WriteLine("Här händer något på höger sida");
                        break;
                }

            }
        }
    }
}
