using System;
using System.Collections.Generic;
using System.Text;

namespace BankConsole
{
    public class MenuManager
    {

        private int selection;

        public MenuManager()
        {
            selection = 0;
        }

        public void ShowMainMenu()
        {
            Console.WriteLine("********************************************************");
            Console.WriteLine("MAIN MENU");
            Console.WriteLine("01. NEW ACCOUNT");
            Console.WriteLine("02. DEPOSIT AMOUNT");
            Console.WriteLine("03. WITHDRAW AMOUNT");
            Console.WriteLine("04. BALANCE ENQUIRY");
            Console.WriteLine("05. ALL ACCOUNT HOLDER LIST");
            Console.WriteLine("06. CLOSE AN ACCOUNT");
            Console.WriteLine("07. MODIFY AN ACCOUNT");
            Console.WriteLine("08. EXIT");
            Console.WriteLine("********************************************************");
        }

        public int PromptMainMenu()
        {
            Console.Write("Select Your Option (1-8): ");
            ConsoleKeyInfo cki = Console.ReadKey();
            int n;
            while (!Int32.TryParse(cki.KeyChar.ToString(), out n) ||
                (n < 1 || n > 8))
            {
                Console.WriteLine("\nPlease make sure your input is 1-8! Try again. " + n);
                Console.Write("Select Your Option (1-8): \n");
                cki = Console.ReadKey();
            }

            n = Int32.Parse(cki.KeyChar.ToString());
            return n;

            //            if (n == 1)
            //                return 1;
            //            else if (n == 2)
            //                return 2;
            //            else if (n == 3)
            //                return 3;
            //            else if (n == 4)
            //                return 4;
            //            else if (n == 5)
            //                return 5;
            //            else if (n == 6)
            //                return 6;
            //            else if (n == 7)
            //                return 7;
            //            else if (n == 8)
            //                return 8;
            //            else
            //                return 8;
        }

        public void ProcessMainMenu(int selection)
        {
            if (selection == 1)
                Program.instance.GetAccountManager().NewAccount();
            else if (selection == 2)
                Program.instance.GetAccountManager().DepositAmount();
            else if (selection == 3)
                Program.instance.GetAccountManager().WithdrawAmount();
            else if (selection == 4)
                Program.instance.GetAccountManager().BalanceEnquiry();
            else if (selection == 5)
                Program.instance.GetAccountManager().ListAccounts();
            else if (selection == 6)
                Program.instance.GetAccountManager().CloseAccount();
            else if (selection == 7)
                Program.instance.GetAccountManager().ModifyAccount();
        }
    }
}
