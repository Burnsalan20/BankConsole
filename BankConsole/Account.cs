using System;
using System.Collections.Generic;
using System.Text;

namespace BankConsole
{
    public class Account
    {

        public String firstName { get; set; }
        public String lastName { get; set; }
        public String address { get; set; }
        public String phoneNumber { get; set; }
        public float balance { get; set; }

        public Account(String firstName, String lastName, String address, String phoneNumber)
        {
            this.firstName = firstName;
            this.lastName = lastName;

            this.address = address;
            this.phoneNumber = phoneNumber;

            this.balance = 0;
        }

    }
}
