using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace BankConsole
{
    public class AccountManager
    {

        private List<Account> accounts = new List<Account>();

        public void NewAccount()
        {
            String firstName, lastName, address, phoneNumber;

            Console.Write("\nEnter the customers first name: ");
            firstName = Console.ReadLine();

            Console.Write("\nEnter the customers last name: ");
            lastName = Console.ReadLine();

            Console.Write("\nEnter the customers address: ");
            address = Console.ReadLine();

            Console.Write("\nEnter the customers phone number: ");
            phoneNumber = Console.ReadLine();

            accounts.Add(new Account(firstName, lastName, address, phoneNumber));
        }

        public void CloseAccount()
        {
            // Prompt to delete and verify using y/n

            Console.Clear();
            Console.WriteLine("********************************************************");
            Console.WriteLine("CLOSE ACCOUNT");

            string name = PromptForName();

            Console.Write("You are about close a customer account. Type Y to proceed or press any key to cancel and return to main menu: ");
            ConsoleKeyInfo cki = Console.ReadKey();

            if (cki.KeyChar.ToString() == "y")
            {
                Console.WriteLine("\nClosing the account belonging to " + name + "...");
                accounts.Remove(GetAccount(name));
            }

            PromptForContinue();
        }

        public void ModifyAccount()
        {
            String name = PromptForName();
            Account account = GetAccount(name);
            ShowAccount(account);

            String firstName, lastName, address, phoneNumber;

            Console.Write("\nEnter the customers new first name: ");
            firstName = Console.ReadLine();

            Console.Write("\nEnter the customers new last name: ");
            lastName = Console.ReadLine();

            Console.Write("\nEnter the customers new address: ");
            address = Console.ReadLine();

            Console.Write("\nEnter the customers new phone number: ");
            phoneNumber = Console.ReadLine();


            Console.Write("\nWould you like to save this information? Press y to confirm. Press any other button to cancel: ");
            ConsoleKeyInfo cki = Console.ReadKey();

            if (cki.KeyChar.ToString() == "y")
            {
                Console.WriteLine("\nSaving the account belonging to " + name + "...");
                account.firstName = firstName;
                account.lastName = lastName;
                account.address = address;
                account.phoneNumber = phoneNumber;
            }

            PromptForContinue();
        }

        public void DepositAmount()
        {
            String name = PromptForName();

            Console.Clear();
            Console.WriteLine("********************************************************");
            Console.WriteLine("                      DEPOSIT                           ");
            Console.WriteLine("                                                        ");
            float amount = PromptForAmount();

            Console.Write("\nWould you like to deposit " + amount + " dollars into " + name + "'s account? Press y to confirm. Press any other button to cancel: ");
            ConsoleKeyInfo cki = Console.ReadKey();

            if (cki.KeyChar.ToString() == "y")
            {
                Console.WriteLine("\nDepositing " + amount + " dollars into " + name + "'s account...");
                GetAccount(name).balance += amount;
            }

            PromptForContinue();
        }

        public void WithdrawAmount()
        {
            String name = PromptForName();
            Account account = GetAccount(name);

            Console.Clear();
            Console.WriteLine("********************************************************");
            Console.WriteLine("                      WITHDRAW                          ");
            Console.WriteLine("                                                        ");
            float amount = PromptForAmount();

            while (amount < 0 || account.balance <= 0)
            {
                Console.WriteLine("You do not have the necessary funds to make this withdraw. Try another amount.");
                amount = PromptForAmount();
            }

            Console.Write("\nWould you like to withdraw " + amount + " dollars from " + name + "'s account? Press y to confirm. Press any other button to cancel: ");
            ConsoleKeyInfo cki = Console.ReadKey();

            if (cki.KeyChar.ToString() == "y")
            {
                Console.WriteLine("\nWithdrawing " + amount + " dollars from " + name + "'s account...");
                GetAccount(name).balance -= amount;
            }

            PromptForContinue();
        }

        public void BalanceEnquiry()
        {
            String name = PromptForName();
            Account account = GetAccount(name);
            ShowAccount(account);
            PromptForContinue();
        }

        public void ListAccounts()
        {
            if (accounts.Count > 0)
            {
                int index = 0;
                Console.Clear();
                Console.WriteLine("********************************************************");
                Console.WriteLine("ACCOUNTS");
                Console.WriteLine("{0,0}{1,-15}{2,-15}", "", "Account", "Balance");
                foreach (Account account in accounts)
                {
                    Console.WriteLine("{0,0}{1,-15}{2,-15}", index + ". ", account.firstName + " " + account.lastName, "$" + account.balance);
                    index++;
                }
                Console.WriteLine("\n");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("There are currently no accounts to list.");
            }

            PromptForContinue();
        }

        public void ShowAccount(Account account)
        {
            Console.Clear();
            Console.WriteLine("********************************************************");
            Console.WriteLine("                  CUSTOMER ACCOUNT                      ");
            Console.WriteLine("                                                        ");
            Console.WriteLine("{0,-25}{1,-25}{2,-25}", "Name", "Address", "Phone Number");
            Console.WriteLine("{0,-25}{1,-25}{2,-25}", account.firstName + " " + account.lastName, account.address, account.phoneNumber);
            Console.WriteLine("                                                        ");
            Console.WriteLine("{0,-25}{1,-25}{2,-25}", "", "", "Balance: $" + account.balance);
        }

        String PromptForName()
        {
            String name = "";
            Console.Write("\nFind customer Account:");
            name = Console.ReadLine();

            if (name.Equals("cancel"))
                CancelAndReturn();

            while (GetAccount(name) == null)
            {
                Console.WriteLine("Error: No account exists with that name. Try again..");

                Console.Write("\nFind customer account: ");
                name = Console.ReadLine();
            }

            return name;
        }

        float PromptForAmount()
        {
            float amount;
            Console.Write("\nEnter an amount: ");
            String line = Console.ReadLine();

            if (line.Equals("cancel"))
                CancelAndReturn();

            bool isFloat = float.TryParse(line, out amount);

            while (!isFloat)
            {
                Console.Write("\nError: You must enter a correct dollar amount. Try again.");
                Console.Write("\nEnter an amount: ");
                line = Console.ReadLine();
                isFloat = float.TryParse(line, out amount);
            }

            return amount;
        }

        void CancelAndReturn()
        {
            Console.Clear();
            Console.WriteLine("Canceled Process. Returning to Main Menu.");
            PromptForContinue();
            Program.instance.GetMenuManager().ShowMainMenu();
            Program.instance.GetMenuManager().PromptMainMenu();
        }

        void PromptForContinue()
        {
            Console.Write("Press any button to continue...");
            ConsoleKeyInfo continueKI = Console.ReadKey();
            Console.Clear();
        }

        public Account GetAccount(int index)
        {
            if (accounts.Count > 0) return accounts[index];
            return null;
        }

        public Account GetAccount(string name)
        {
            if(accounts.Count > 0)
            {
                foreach (Account account in accounts)
                {
                    if ((account.firstName + " " + account.lastName).Equals(name))
                        return account;
                }
            }

            return null;
        }
    }
}
