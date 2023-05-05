using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogFoodOrderingSystem
{
    internal class DogFood
    {
        // read-only properties
        public string BrandName { get; }

        public double CanUnitPrice { get; }
        // read-write property
        public int NumCans { get; set; }

        // read-only computed property
        public double BrandTotal
        {
            get
            {
                return NumCans * CanUnitPrice;
            }
        }
        // constructor
        public DogFood(string brand, double unitPrice)
        {
            BrandName = brand;
            CanUnitPrice = unitPrice;
            NumCans = 0;
        }
        // method for formating string  
        public override string ToString()
        {
            string asterikLine = String.Format("*{0,42}{1,-42}*", "", "");
            string outputBrandName = String.Format("*{0,46}: {1,-36}*", "Brand name", BrandName);
            string outputUnitPrice = String.Format("*{0,46}: {1,-36:C2}*", "Unit price", CanUnitPrice);
            string outputNumCans = String.Format("*{0,46}: {1,-36}*", "Number of cans", NumCans);
            string outputBrandTotal = String.Format("*{0,46}: {1,-36:C2}*", "Total price", BrandTotal);
            string outputString = String.Format("{0}\n{1}\n{2}\n{3}\n{4}", outputBrandName, outputUnitPrice, outputNumCans, outputBrandTotal, asterikLine);
            return outputString;
        }

    }
}
