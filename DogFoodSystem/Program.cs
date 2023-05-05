using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ChapaH_Assign1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DogFood dogFood1 = new DogFood("Purina", 2.67);
            DogFood dogFood2 = new DogFood("Pedigree", 1.98);
            DogFood dogFood3 = new DogFood("Ol'Roy", 1.47);

            GreetingMsg(dogFood1, dogFood2, dogFood3);

            UpdateNumCans(dogFood1);
            UpdateNumCans(dogFood2);
            UpdateNumCans(dogFood3);

            WriteLine("\nThe number of cans for each brand name has been entered\n");
            PerformAction(dogFood1, dogFood2, dogFood3);
        }


        // Method for greeting
        static void GreetingMsg(DogFood dogFood1, DogFood dogFood2, DogFood dogFood3)
        {
            string asterikLine = new string('*', 86);
            WriteLine(asterikLine);
            WriteLine("*{0,67}{1,-17}*", "Welcome to WoofYum Online Dog Foog Ordering System", "");
            WriteLine("*{0,52}{1,-32}*", "Place your order now!", "");
            WriteLine(asterikLine);
            WriteLine(asterikLine);
            WriteLine("*{0,61}{1,-23}*", "Dog Food Brands in stock given below", "");
            WriteLine("*{0,50}: {1,-32:C2}*", "Can Unit Price for " + dogFood1.BrandName, dogFood1.CanUnitPrice);
            WriteLine("*{0,50}: {1,-32:C2}*", "Can Unit Price for " + dogFood2.BrandName, dogFood2.CanUnitPrice);
            WriteLine("*{0,50}: {1,-32:C2}*", "Can Unit Price for " + dogFood3.BrandName, dogFood3.CanUnitPrice);
            WriteLine(asterikLine);
            WriteLine("\nLet us begin by entering the umber of cans you need for each of these dog food brands...");
        }

        // Method for updating the number of cans base on user input
        static void UpdateNumCans(DogFood dogFood)
        {
            string inputCans;
            Write("Enter the number of can for " + dogFood.BrandName + ": ");
            inputCans = ReadLine();
            // check the user input, it cannot be blank and 
            // it should be whole number and more than or equal 0
            while (!int.TryParse(inputCans, out int num) || num < 0)
            {
                Write("PLease re-enter (the answer must be a whole number): ");
                inputCans = ReadLine();
            }
            // update new value at NumCans in DogFood object
            dogFood.NumCans = int.Parse(inputCans);
        }

        // Method for asking user to do choose the action
        static void PerformAction(DogFood dogFood1, DogFood dogFood2, DogFood dogFood3)
        {
            WriteLine("\nWhat would you like to do?"); // add 1 empty space for easier to read
            WriteLine("Press 1 for View Order");
            WriteLine("Press 2 for Upadate Order");
            WriteLine("Press 3 for quitting the application");
            Write("Enter your option: ");
            string inputOption = ReadLine();

            // check the user input, it cannot be empty string and it should be number between 1 - 3  
            while (!int.TryParse(inputOption, out int num) || num < 0 || num > 3)
            {
                Write("PLease choose the option 1, 2 or 3) : ");
                inputOption = ReadLine();
            }

            // convert user input from string to int
            int option = int.Parse(inputOption);

            // check user option to provide a different path
            if (option == 1)
            {
                ViewOrder(dogFood1, dogFood2, dogFood3);
            }
            else if (option == 2)
            {
                UpdateOrder(dogFood1, dogFood2, dogFood3);
            }
            else
            {
                WriteLine("\nThank you for ordering the dog fodds with us. Good Bye!");
            }
        }

        // Method for display summary order
        static void ViewOrder(DogFood dogFood1, DogFood dogFood2, DogFood dogFood3)
        {
            double totalAfterDiscount = ComputeOrderSummary(dogFood1, dogFood2, dogFood3, out double totalBeforeDiscount, out double discountAmount);
            // totalAfterDiscount = (totalBeforeDiscount - discountAmount);

            // display output
            string asterikLine = new string('*', 86);
            WriteLine("\nYour dog food order\n");
            WriteLine(asterikLine);
            WriteLine(dogFood1);
            WriteLine(dogFood2);
            WriteLine(dogFood3);
            WriteLine("*{0,46}: {1,-36:C2}*", "Total price before discount", totalBeforeDiscount);
            WriteLine("*{0,46}: {1,-36:C2}*", "Discount", discountAmount);
            WriteLine("*{0,46}: {1,-36:C2}*", "Total price after discount", totalAfterDiscount);
            WriteLine(asterikLine);
            PerformAction(dogFood1, dogFood2, dogFood3);
        }

        // Method for culculating total price
        static double ComputeOrderSummary(DogFood dogFood1, DogFood dogFood2, DogFood dogFood3, out double totalBeforeDiscount, out double discountAmount)
        {
            totalBeforeDiscount = dogFood1.BrandTotal + dogFood2.BrandTotal + dogFood3.BrandTotal;

            // check if the total amount before discount exceed $75, then the customer gets 15% off
            if (totalBeforeDiscount >= 75)
            {
                discountAmount = totalBeforeDiscount * 0.15;
            }
            else
            {
                discountAmount = 0;
            }
            double totalAfterDiscount = (totalBeforeDiscount - discountAmount);

            return totalAfterDiscount;
        }

        // Method for updating order
        static void UpdateOrder(DogFood dogFood1, DogFood dogFood2, DogFood dogFood3)
        {
            WriteLine("\nUpdating your dog food order"); // add 1 empty space for easier to read
            WriteLine("Press 1 to update number of cans for " + dogFood1.BrandName);
            WriteLine("Press 2 to update number of cans for " + dogFood2.BrandName);
            WriteLine("Press 3 to update number of cans for " + dogFood3.BrandName);
            Write("Enter the number (option 1, 2 or 3): ");
            string inputOption = ReadLine();

            // check the user input, it cannot be empty string and it should be number between 1 - 3  
            while (!int.TryParse(inputOption, out int num) || num < 1 || num > 3)
            {
                Write("PLease re-enter the option 1, 2 or 3: ");
                inputOption = ReadLine();
            }

            // convert user input from string to int
            int option = int.Parse(inputOption);

            // check the user option by if condition method
            if (option == 1)
            {
                WriteLine("\n"); // add 1 empty space for easier to read
                UpdateNumCans(dogFood1);
                WriteLine("Great! Quantity for " + dogFood1.BrandName + " hase been updated to " + dogFood1.NumCans);
            }
            else if (option == 2)
            {
                WriteLine("\n"); // add 1 empty space for easier to read
                UpdateNumCans(dogFood2);
                WriteLine("Great! Quantity for " + dogFood2.BrandName + " hase been updated to " + dogFood2.NumCans);
            }
            else
            {
                WriteLine("\n"); // add 1 empty space for easier to read
                UpdateNumCans(dogFood3);
                WriteLine("Great! Quantity for " + dogFood1.BrandName + " hase been updated to " + dogFood3.NumCans);
            }
            PerformAction(dogFood1, dogFood2, dogFood3);
        }

    }
}
