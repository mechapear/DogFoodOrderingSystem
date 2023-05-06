using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace DogFoodOrderingSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<DogFood> DogFoodlist = new List<DogFood>();

            DogFood purina = new DogFood("Purina", 2.67);
            DogFood pedigree = new DogFood("Pedigree", 1.98);
            DogFood olRoy = new DogFood("Ol'Roy", 1.47);

            DogFoodlist.Add(purina);
            DogFoodlist.Add(pedigree);
            DogFoodlist.Add(olRoy);

            GreetingMsg(DogFoodlist);

            foreach (DogFood eachBrand in DogFoodlist)
            {
                UpdateNumCans(eachBrand);
            }

            WriteLine("\nThe number of cans for each brand name has been entered\n");
            PerformAction(DogFoodlist);
        }

        // Method for greeting
        static void GreetingMsg(List<DogFood> dogFoodList)
        {
            string asterikLine = new string('*', 86);
            WriteLine(asterikLine);
            WriteLine("*{0,67}{1,-17}*", "Welcome to WoofYum Online Dog Foog Ordering System", "");
            WriteLine("*{0,52}{1,-32}*", "Place your order now!", "");
            WriteLine(asterikLine);
            WriteLine(asterikLine);
            WriteLine("*{0,61}{1,-23}*", "Dog Food Brands in stock given below", "");

            foreach (DogFood eachBrand in dogFoodList)
            {
                WriteLine("*{0,50}: {1,-32:C2}*", "Can Unit Price for " + eachBrand.BrandName, eachBrand.CanUnitPrice);
            }
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
        static void PerformAction(List<DogFood> dogFoodList)
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
                ViewOrder(dogFoodList);
            }
            else if (option == 2)
            {
                UpdateOrder(dogFoodList);
            }
            else
            {
                WriteLine("\nThank you for ordering the dog fodds with us. Good Bye!\n\n");
            }
        }

        // Method for display summary order
        static void ViewOrder(List<DogFood> dogFoodList)
        {
            double totalAfterDiscount = ComputeOrderSummary(dogFoodList, out double totalBeforeDiscount, out double discountAmount);
            // totalAfterDiscount = (totalBeforeDiscount - discountAmount);

            // display output
            string asterikLine = new string('*', 86);
            WriteLine("\nYour dog food order\n");
            WriteLine(asterikLine);

            foreach (DogFood eachBrand in dogFoodList)
            {
                WriteLine(eachBrand);
            }

            WriteLine("*{0,46}: {1,-36:C2}*", "Total price before discount", totalBeforeDiscount);
            WriteLine("*{0,46}: {1,-36:C2}*", "Discount", discountAmount);
            WriteLine("*{0,46}: {1,-36:C2}*", "Total price after discount", totalAfterDiscount);
            WriteLine(asterikLine);
            PerformAction(dogFoodList);
        }

        // Method for culculating total price
        static double ComputeOrderSummary(List<DogFood> dogFoodList, out double totalBeforeDiscount, out double discountAmount)
        {
            totalBeforeDiscount = dogFoodList[0].BrandTotal + dogFoodList[1].BrandTotal + dogFoodList[2].BrandTotal;

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
        static void UpdateOrder(List<DogFood> dogFoodList)
        {
            WriteLine("\nUpdating your dog food order"); // add 1 empty space for easier to read

            for (int index = 0; index < dogFoodList.Count; index++)
            {
                WriteLine("Press " + (index + 1) + " to update number of cans for " + dogFoodList[index].BrandName);
            }

            Write("Enter the number (option 1, 2 or 3): ");
            string inputOption = ReadLine();

            // check the user input, it cannot be empty string and it should be number between 1 - 3  
            while (!int.TryParse(inputOption, out int num) || num < 1 || num > dogFoodList.Count)
            {
                Write("PLease re-enter the option 1, 2 or 3: ");
                inputOption = ReadLine();
            }

            // convert user input from string to int
            int option = int.Parse(inputOption);

            // Update the number of can
            WriteLine("\n"); // add 1 empty space for easier to read
            UpdateNumCans(dogFoodList[option - 1]);
            WriteLine("Great! Quantity for " + dogFoodList[option - 1].BrandName + " hase been updated to " + dogFoodList[option - 1].NumCans);

            PerformAction(dogFoodList);
        }
    }
}
