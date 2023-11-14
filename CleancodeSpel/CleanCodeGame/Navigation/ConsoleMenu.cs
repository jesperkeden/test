using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanCodeGame.Helpers;


namespace CleanCodeGame.Navigation
{
    public class ConsoleMenu
    {
        private static Stack<MenuItem> menuStack = new Stack<MenuItem>();
        private static int selection = 0;

        public static void InitializeMenus()
        {
            // Root menu
            var mainMenu = new MenuItem("Main Menu");
            var goBack = new MenuItem("Go back", PreviousPage);

            // New Game submenu
            var newGameMenu = new MenuItem("New Game");

            // Create Character submenu under New Game
            var createCharacterMenu = new MenuItem("Create Character");
            createCharacterMenu.AddSubItem(new MenuItem("Name", CharacterRelated.GenerateName));
            createCharacterMenu.AddSubItem(new MenuItem("Race", CharacterRelated.ChooseRace));
            createCharacterMenu.AddSubItem(new MenuItem("Save and go back", PreviousPage));
            newGameMenu.AddSubItem(createCharacterMenu);
            newGameMenu.AddSubItem(goBack);

            // Load Game submenu
            var loadGameMenu = new MenuItem("Load Game", LoadGame);
            loadGameMenu.AddSubItem(new MenuItem("Choose save", FindSavesOnPc));
            // Maybe add some kind of list here of the saves??
            loadGameMenu.AddSubItem(goBack);

            // Quit option
            var quitOption = new MenuItem("Quit", QuitApplication);


            // Add all top-level options to Main Menu
            mainMenu.AddSubItem(newGameMenu);
            mainMenu.AddSubItem(loadGameMenu);
            mainMenu.AddSubItem(quitOption);

            menuStack.Push(mainMenu);
        }


        private static void PreviousPage()
        {
            
            if (menuStack.Count > 1)
            {                
                menuStack.Pop();              
                selection = 0;
            }
        }

        private static void QuitApplication()
        {
            Environment.Exit(0);
        }

        private static void LoadGame()
        {
            // Placeholder for LoadGame functionality
            Console.WriteLine("Loading a game is not implemented yet.");
            Console.ReadKey(); // Wait for key press to continue
        }



        private static void FindSavesOnPc()
        {
            // Placeholder for FindSavesOnPc functionality
            Console.WriteLine("Looking through a list of saved files is not implemented yet.");
            Console.ReadKey(); // Wait for key press to continue
        }

        public static void MenuNavigation()
        {
            try
            {
                InitializeMenus();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }


            Console.CursorVisible = false;
            bool continueMenuLoop = true;

            while (continueMenuLoop)
            {
                DisplayMenu(menuStack.Peek());
                var key = Console.ReadKey();

                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        MoveUp();
                        break;
                    case ConsoleKey.DownArrow:
                        MoveDown();
                        break;
                    case ConsoleKey.Enter:
                        SelectItem();
                        break;
                    case ConsoleKey.Escape:
                        GoBack();
                        break;
                }
            }
        }

        private static void MoveUp()
        {
            if (selection > 0)
            {
                selection--;
            }
        }

        private static void MoveDown()
        {
            if (selection < menuStack.Peek().SubItems.Count - 1)
            {
                selection++;
            }
        }

        private static void SelectItem()
        {
            var currentMenu = menuStack.Peek();
            var selectedItem = currentMenu.SubItems[selection];

            if (selectedItem.SubItems.Count > 0)
            {
                menuStack.Push(selectedItem);
                selection = 0; // Reset selection when entering a sub-menu
            }
            else
            {
                selectedItem.Action?.Invoke();
            }
        }

        private static void GoBack()
        {
            if (menuStack.Count > 1)
            {
                menuStack.Pop();
                selection = 0; // Reset selection when going back
            }
        }

        private static void DisplayMenu(MenuItem currentMenu)
        {
            Console.Clear();
            for (int i = 0; i < currentMenu.SubItems.Count; i++)
            {
                if (i == selection)
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                }

                Console.WriteLine(currentMenu.SubItems[i].Title);
                Console.ResetColor();
            }
        }

    }
}


