using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace supermarketProject1
{
    public class Supplier
    {
        public string[] stockRange = new string[Program.LenStockRange];
        public double[] suppliersPrices = new double[Program.LenSuppliers];
        public string[] suppliersQuality = new string[Program.LenSuppliers];
        public double[] suppliersQualityMultiplier = new double[Program.LenSuppliers];

        public Supplier()
        {
            //set up all the different types of stock
            stockRange[0] = "Vegetables";
            stockRange[1] = "Meat";
            stockRange[2] = "Snack";
            stockRange[3] = "Household";

            //set up all the different suppliers prices
            suppliersPrices[0] = 3.43;
            suppliersPrices[1] = 2.65;
            suppliersPrices[2] = 2.35;
            suppliersPrices[3] = 2.25;
            suppliersPrices[4] = 2.09; 

            //set up all the different types of quality 
            suppliersQuality[0] = "Excellent";
            suppliersQuality[1] = "Great";
            suppliersQuality[2] = "Average";
            suppliersQuality[3] = "Bad";
            suppliersQuality[4] = "Poor";

            //set up all the different types of multipliers for every different quality;
            suppliersQualityMultiplier[0] = 1.5;
            suppliersQualityMultiplier[1] = 1.25;
            suppliersQualityMultiplier[2] = 1;
            suppliersQualityMultiplier[3] = 0.75;
            suppliersQualityMultiplier[4] = 0.5;

        }
        
       
    }
}
