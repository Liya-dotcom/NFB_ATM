using System;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using System.Configuration.Assemblies;

namespace NFB_ATM
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // In your Program.cs
            Timing perfTimer = new Timing();

            // Start timing
            perfTimer.StartTime();

            // Code to measure
            ATMOperations();

            // Stop timing
            perfTimer.StopTime();

            // Get results
            Console.WriteLine($"Execution time: {perfTimer.ElapsedMilliseconds()} ms");
            Console.WriteLine($"Formatted time: {perfTimer.GetFormattedTime()}");
            //Sets the Title of the Console
            Console.Title = "NFB ATM SERVICES";
            Console.ForegroundColor = ConsoleColor.Yellow;

            //Usernames username = new Usernames();

            //Declaration of Variables
            double bankBal = 0, deposit = 0, withdrawal;
            int choise;
            string pin = "";
            // This will all the user to input their pin, take and store under Pin
            Console.Write("Enter your 4-digit PIN: ");
            pin = Console.ReadLine();
            //The if statement will check the length of the pin, if it meets the requirements then it will accept it.
            //Then it will check it against the one's on the system,encrypte it to make it secured.
            if (pin.Length == 4 || pin.Length == 5)
            {
                //This line will read if the Pin meets the standard criteria of the Pin
                ReadPin();
                Console.WriteLine("\nPIN OK");
                EncryptPin(pin);
                while (true)
                {
                    //Possible option to choose from
                    Console.WriteLine("\n **********WELCOME TO PROJECT NFB ATM SERVICES***********\n");
                    Console.WriteLine("\n 1. Deposit Cash");
                    Console.WriteLine("\n 2. Check balance");
                    Console.WriteLine("\n 3. Withdraw Cash");
                    Console.WriteLine("\n 4. Quit");
                    Console.WriteLine("\n *********************************************************\n");

                    // In this line we try and execute the code, then after catch any errors that might occure
                    try
                    {
                        //This line ask for the user input, take it and store in in Choise
                        Console.Write("\n Please select from the above choises: ");
                        choise = int.Parse(Console.ReadLine());
                        //Switch statement that contains 4 cases of line that will execute the options above.
                        switch (choise)
                        {
                            //This line of code allows the user to deposit any amount to their acoount, calculate it and store it to BankaBal
                            case 1:
                                Console.Write("Please insert the money to the counter: ");
                                bankBal = double.Parse(Console.ReadLine());
                                bankBal += deposit;//Here the deposited amount will be add to bankBal.
                                Console.WriteLine("Your money is deposited successfully! ");
                                double total = bankBal + deposit;//Then here the amount which is the bankBal and the deposited amount will be add together to make a total.
                                break;

                            case 2:
                                //In this line of code will allow the user to check their bank balance amount.
                                Console.WriteLine($"\nYour balance is: R{bankBal:F2}");
                                break;

                            case 3:
                                //Cases three does a lot of things, but in all it is for a bank withdrawal
                                Console.Write("\n Please enter an amount you would like to withdraw: \n");
                                withdrawal = double.Parse(Console.ReadLine());
                                if (withdrawal % 100 !=0 )
                                {
                                    Console.WriteLine("PLEASE ENTER AN AMOUNT IN MULTIPLIES OF 50: ");

                                }
                                else if (withdrawal > (bankBal))
                                {
                                    Console.WriteLine("\n YOU HAVE AN INSUFFICIENT BALANCE ");
                                }
                                else
                                {
                                    bankBal -= withdrawal;//Subtract the withdrawal amount from the bank balance
                                    Console.WriteLine("\n Please collect your money ");
                                    Console.WriteLine("\n YOUR CURRENT BALANCE NOW IS: " + bankBal.ToString("C"));
                                }
                                break;

                            case 4:
                                Console.WriteLine("\nThank you for using NFB ATM, Goodbye ");
                                Environment.Exit(0);//Quits the program
                                break;

                            default:
                                Console.WriteLine("\nYou have entered an incorrect entry ");
                                break;
                        }
                        // Ask user if they want to make another transaction
                        Console.Write("\nWould you like to make another transaction? (y/n): ");
                        string response = Console.ReadLine().ToLower();

                        if (response != "y")
                        {
                            Console.WriteLine("\nThank you for using NFB ATM, Goodbye\n");
                            break; // Exit loop
                        }

                    }
                    catch
                    {
                        Console.WriteLine("\nPlease enter a correct transaction\n");

                    }
                }
                                
            }
            else
            {
                Console.WriteLine("PIN is incorrect");
            }
           Console.ReadKey();
        }
        //This method is responsible for prompting User to see if they are interested in making another transaction
        public static void GetResponse()
        {

            try
            {
                //Ask the user if they want to make another transaction.
                Console.WriteLine("\n Would you like to make another transaction? (y/n): ");
                string response = Console.ReadLine().ToLower(); 

                if (response != "y")
                {
                    Console.WriteLine("\n Thank you for using NFB ATM, Goodbye\n");
                }

                
            }
            catch
            {
                Console.WriteLine("\n PLEASE CHOOSE YES OR NO...\n");

            }
        }
        public static void PinRequest()
        {
            // Getting input from the User
            Console.WriteLine("Enter your Pin:");
            string pin = Console.ReadLine();


            //Encrypt the Pin using SHA-256
            string encryptedPin = EncryptPin(pin);


            Console.WriteLine("Encrypted PIN:" + encryptedPin);
            Console.WriteLine("PIN store securely.");


            //Wait for user input before exiting
            Console.ReadLine();

        }

        public static string ReadPin()
        {
            StringBuilder pinBuilder = new StringBuilder();
            ConsoleKeyInfo keyInfo;

            do
            {
                keyInfo = Console.ReadKey(true);
                //Ignore any key that is not a number or backspace
                if (char.IsDigit(keyInfo.KeyChar) || keyInfo.Key == ConsoleKey.Backspace)
                {
                    if (keyInfo.Key == ConsoleKey.Backspace && pinBuilder.Length > 0)
                    {
                        //Remove the last character backspace is passed
                        pinBuilder.Remove(pinBuilder.Length - 1, 1);
                        Console.Write("\b \b");
                    }
                    else if (Char.IsDigit(keyInfo.KeyChar))
                    {
                        //Append the digit to the Pin and display an asterisk
                        pinBuilder.Append(keyInfo.KeyChar);
                        Console.Write("*");
                    }
                }
            } while (keyInfo.Key != ConsoleKey.Enter);
            {
                Console.WriteLine("");
                return pinBuilder.ToString();
            }
            

        }
        public static string EncryptPin(string pin)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] pinBytes = Encoding.UTF8.GetBytes(pin);
                byte[] hashBytes = sha256.ComputeHash(pinBytes);

                StringBuilder hashBuilder = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    hashBuilder.Append(b.ToString("x2"));
                }
                return hashBuilder.ToString();
            }

        }
        // Add the missing ATMOperations method to fix the CS0103 error
        public static void ATMOperations()
        {
            // Placeholder for ATM operations code
            // You can add the actual implementation here
            Console.WriteLine("ATM operations are being executed...");
        }

        
    }

}
