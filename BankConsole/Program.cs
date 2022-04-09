using System;

namespace BankConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
        }

        public static Program instance;

        public int selection = 0;

        MenuManager menuManager;
        AccountManager accountManager;

        public Program()
        {
            instance = this;

            menuManager = new MenuManager();
            accountManager = new AccountManager();

            Console.WriteLine("Welcome to Fortunate Sons Nation Bank!");
            menuManager.ShowMainMenu();
            selection = menuManager.PromptMainMenu();
            menuManager.ProcessMainMenu(selection);
            while (selection != 8)
            {
                Console.Clear();
                menuManager.ShowMainMenu();
                selection = menuManager.PromptMainMenu();
                menuManager.ProcessMainMenu(selection);
            }
        }

        public AccountManager GetAccountManager()
        {
            return this.accountManager;
        }

        public MenuManager GetMenuManager()
        {
            return this.menuManager;
        }
    }
}
