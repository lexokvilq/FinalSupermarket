using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace supermarketProject1
{
    public class Supermarket
    {
        //The current funds that the supermarket has
        private double currentFunds;
        public double CurrentFunds
        {
            get { return currentFunds; }
        }

        //The previous funds that the supermarket had in the last week
        private double previousFunds;

        //The net profit that the supermarket makes
        private double netProfit;
        public double NetProfit
        {
            get { return netProfit; }
        }

        //The customer multiplier, which represents the percentage (a decimal percentage) of customers that a supermarket will get 
        private double customerMultiplier;
        public double CustomerMultiplier
        {
            get { return customerMultiplier; }
        }

        //This is the amount of stock that a supermarket will buy
        private int stockAmount;

        //This is an array that contains all the types of stock that the supermarket buys
        private string[] stockShop;

        //This is an array of boolean values, which show what types of supermarket stock that the supermarket has
        //by comparing the stock shop with the all the types of stock possible to buy (stock range in Supplier).
        private bool[] stockAvailable = new bool[Program.LengthOfStockRange];

        //This is a multiplier which shows how the percentage of customers will change as the types of stock available from the supermarket changes
        private double stockAvailableMultiplier;

        //This is the supplier type that the user has chosen
        private string userSupplier;

        //This is a multiplier that shows how different qualities of stock will affect the percentage of customers
        private double qualityMultiplier;

        //This is how much the supermarket spends on buying stock from the supplier
        private double supplierCost;

        //This is the item prices for the supermarket
        private double itemPrices;
        public double ItemPrices
        {
            get { return itemPrices; }
        }

        //This is the old item prices, from the previous week
        private double oldItemPrices;

        //This is a multiplier that shows how changing the item prices can affect the number of customers
        private double itemPricesMultiplier;

        //This is the amount spent into advertisements by the user
        private double advertisementInvestment;

        //This is a multiplier that shows how changing the amount spent on advertising will change the percentage of customers
        private double advertismentMultiplier;

        //This is the amount spent in security for the supermarket
        private double securityInvestment;

        //This is the percentage of paying customers that the supermarket gets
        private double percentageOfPayingCustomers;

        //This is the amount of workers that the supermarket employs
        private int amountOfWorkers;
        public int AmountOfWorkers
        {
            get { return amountOfWorkers; }
        }

        //This is a multiplier that shows how changing the amount of workers in the supermarket, can change the percentage of customers
        private double amountOfWorkersMultiplier;

        //This is the wage of all the workers
        private double workerWage;
        public double WorkerWage
        {
            get { return workerWage; }
        }

        //This is a constant which shows the average wage for a regular supermarket worker
        private const double WorkerWageAverage = 11.36;
        public  double WorkerWageAverageConstant
        {
            get { return WorkerWageAverage; }
        }

        //This is a multiplier which shows how the distance the supermarket's worker wage from the average wage, can effect the productivity of workers,
        //so will change the percentage of customers 
        private double workerWageMultiplier;

        //The online customer multiplier shows the percentage of online customers that will buy from this supermarket
        private double onlineCustomerMultiplier;
        public double OnlineCustomerMultiplier
        {
            get { return onlineCustomerMultiplier; }
        }

        //This is the amount of online workers that the supermarket will employ (amount of delivery workers)
        private int onlineAmountOfWorkers;
        public int OnlineAmountOfWorkers
        {
            get { return onlineAmountOfWorkers; }
        }

        //This is the wage for all the online workers working in the supermarket (delivery workers)
        private double onlineWorkerWage;
        public double OnlineWorkerWage
        {
            get { return onlineWorkerWage; }
        }

        //This constant is the average wage of a delivery (online) worker
        private const double OnlineWorkerWageAverage = 12.39;
        public double OnlineWorkerWageAverageConstant
        {
            get { return OnlineWorkerWageAverage; }
        }
        //This shows how the distance away the supermarket's online worker wage is from the average will affect the percentage of customers
        private double onlineWorkerWageMultiplier;

        //This shows how changing the amount of online workers (delivery workers) will affect the percentage of customers
        private double onlineAmountOfWorkersMultiplier;

        //This constant is the amount of hours that a supermarket worker, works per week
        private const int WorkerHours = 28;

        //This constant is the amount of hours that a delivery worker will work per week
        private const int DeliveryWorkerHours = 31;

        //This constant is the average mass of a customer's shopping
        private const int AverageShoppingMassKg = 21;

        //This is the amount the supermarket has overspent by (if the supermarket has overspent)
        private double overspent;
        public double Overspent
        {
            get { return overspent; }
        }

        //This is the actual number of customers that a supermarket will get
        private int actualNumberOfCustomers;
        public int ActualNumberOfCustommers
        {
            get { return actualNumberOfCustomers; }
        }

        //The supermarket constructor
        public Supermarket()
        {
        }

        //This calculates the customers multiplier
        public virtual void calcCustomerMultiplier()
        {
            //multiply all the calculated multipliers together to create a combined multiplier
            //this combined multiplier is used to work out the number of customers that a supermarket will get
            customerMultiplier = stockAvailableMultiplier * qualityMultiplier * itemPricesMultiplier * advertismentMultiplier
                * amountOfWorkersMultiplier * workerWageMultiplier
                * onlineAmountOfWorkersMultiplier * onlineWorkerWageMultiplier * percentageOfPayingCustomers;
        }

        //This calculates how much funds the supermarket has left over
        public virtual void calcCurrentFunds()
        {
            //The profit is calculated by multiplying the item prices (Per Kg) by the average mass of a customer's shopping (21KG) and
            //then multiplied by the actual number of customers that a supermarket will get
            double profit = actualNumberOfCustomers * itemPrices * AverageShoppingMassKg;
            
            //The expenses is calculated by multiplying the amount of workers by the wage of the workers (per hour), and
            //then multiplied by the number of hours that they work (28 hours a week)
            double expenses = workerWage * amountOfWorkers * WorkerHours;

            //Then the expenses of all the online workers is calculated
            expenses = expenses + onlineWorkerWage * onlineAmountOfWorkers * DeliveryWorkerHours;

            //Then the supplier cost, advertisement investment and security investment are all added to the expenses
            expenses = expenses + supplierCost + advertisementInvestment + securityInvestment;

            //Work out the current funds for the supermarekt by adding the profit and taking away the expenses from the current funds
            currentFunds = currentFunds + profit - expenses;
        
            //Round the current funds to the nearest penny, to the nearest 2 decimal places
            currentFunds = Math.Round(currentFunds, 2);
        }

        //This function checks whether the current funds will be negative after the user's inputs
        //and returns true if the user has over spent or false if the user hasn't overspent
        public virtual bool checkCurrentFundsNegative()
        {
            //The expenses is calculated by multiplying the amount of workers by the wage of the workers (per hour), and
            //then multiplied by the number of hours that they work (28 hours a week)
            double expenses = workerWage * amountOfWorkers * WorkerHours;

            //Then the expenses of all the online workers is calculated
            expenses = expenses + onlineWorkerWage * onlineAmountOfWorkers * DeliveryWorkerHours;

            //calculate the supplier cost
            

            //Then the supplier cost, advertisement investment and security investment are all added to the expenses
            expenses = expenses + supplierCost + advertisementInvestment + securityInvestment;

            //The expenses are rounded to the nearest penny before it is compared with the current funds (the current funds are also rounded to the nearest penny)
            expenses = Math.Round(expenses, 2);

            //The current funds and expenses are compared
            if (currentFunds < expenses)
            {
                //The player's supermarket has overspent

                //calculate how much the supermarket has overspent by
                overspent = expenses - currentFunds;

                //return true, which shows that the player has overspent
                return true;
            }
            else
            {
                //The player's supermarket has not overspent

                //return false, showing that the player has not overspent
                return false;
            }
        }

        //This function calculates the net profit of the supermarket
        public virtual void calcNetProfit()
        {
            //Find the difference between the current funds and the previous funds (funds from the last week)
            netProfit = currentFunds - previousFunds;
        }

        //Check what stock the supermarket has available
        //Pass in Supplier.stockRange
        public virtual void checkStockAvailable(string[] stRange)
        {
            //The value passed in is an array of strings which contain all the different types of avaialable stock, to buy
            for (int i = 0; i < stRange.Length; i++)
            {
                //Compare the stock that the supermarket has with the list of all the avaiable types of stock
                //Both the Supplier.stockRange and the stockShop are both the same length and store their stocks in the same index
                //If a stock type is not avaialable in stock shop it will be stored in the array as a null value
                if (stRange[i] == stockShop[i])
                {
                    //The supermarket has the available item so the stockAvailable is set to true for this item
                    stockAvailable[i] = true;
                }
                else
                {
                    //The supermarket does not have the available item so the stockAvailable is set to false for this item
                    stockAvailable[i] = false;
                }
            }
        }

        //This function calculates the stock available multiplier
        public virtual void stockAvailableChangeProfit()
        {
            //first the stockAvialbleMultiplier is set to 1, the default value, which assumes that all the stock avaialble is true
            stockAvailableMultiplier = 1;

            //This is a count which shows how many unavailable stock types there are
            //The default value is 0 which assumes that all the different types of stock are available
            int numOfUnavailableStock = 0;

            //This for loop will go through all the data items in the stockAvailable list
            for (int i = 0; i < stockAvailable.Length; i++)
            {
                //This checks if the stock item is not available
                if (stockAvailable[i] == false)
                {
                    //if it is not available then the number of unavialble stock types is incremented by 1
                    numOfUnavailableStock++;
                }

                //if the stock type is present the number of unavailable stock will stay at its same value
            }

            //This for loop will repeat for the number of unavailable stock types
            //if there are no unavialble stock types then the for loop will be skipped and the stock available multiplier will remain at its default value 1
            for (int i = 0; i < numOfUnavailableStock; i++)
            {
                //Decrease the stock available multiplier by 75 percent for each unavailable stock
                stockAvailableMultiplier = stockAvailableMultiplier * 0.75;
            }
        }

        //This function calculates the qualityMultiplier for the supermarket
        //The Supplier.suppliersQuality and the Supplier.suppliersQualityMultiplier are both passed in
        public virtual void calcQualityMultiplier(string[] supQual, double[] suppQualMult)
        {
            //This for loop goes through all the supplier quality types in the suppliersQuality array
            for (int i = 0; i < supQual.Length; i++)
            {
                //Checks to see if the supermarket's supplier is the current supplier quality
                if (userSupplier == supQual[i])
                {
                    //The user's supplier is the current supplier quality so the supplier quality multiplier index can be found
                    //in the supplierQualityMultipliers list by using the same index that the supplier quality was found in
                    //The supplierQuality array and the supplierQualityMultipliers array both directly relate to each other, so the indexs in both arrays directly relate to each other
                    qualityMultiplier = suppQualMult[i];
                }
            }
        }

        //The function calculates the supplier cost
        //The Supplier.suppliersPrices and the Supplier.suppliersQuality are both passed in
        public virtual void calcSupplierCost(double[] suppPrice, string[] suppQual)
        {
            //This for loop goes through all the items in the supplier qualities array
            for (int i = 0; i < suppQual.Length; i++)
            {
                //checks if the user supplier is found in the supplier quality
                if (userSupplier == suppQual[i])
                {
                    //The supplier cost can be found by using the index in which the supplier quality was found
                    //Both the supplierPrices and suppliersQuality arrays directly relate to each other, so the index can be used to link both arrays
                    supplierCost = suppPrice[i];
                }
            }

            //The supplierPrices list only contains the price per kg, so the price needs to be multiplied by the stock amount that the supermarket bought
            //in order to work out the actual amount the supermarket has spent on buying stock, supplier cost
            supplierCost = supplierCost * stockAmount;
        }

        //This function caclualtes the item prices multiplier
        public virtual void calcItemPricesMultiplier()
        {
            //This checks if the old item prices is its default value 0
            if (oldItemPrices == 0)
            {
                //The old item prices are set to 0 as default, so the item prices multiplier should also be its default
                //value, which is 1, a multiplier of 1 will have no effect on the customer multiplier
                itemPricesMultiplier = 1;
            }
            //if the old item prices have a value set to them
            else
            {
                //if the new item prices are smaller than the old item prices the multiplier will be bigger than if the old item prices 
                //were smaller than the item prices
                itemPricesMultiplier = oldItemPrices / itemPrices;
            }
        }

        //This function calculates the advertisement multipleir
        //the average area advertisement investment is passed in
        public virtual void calcAdvertisementMultiplier(double avAdInv)
        {
            //The advertisement investment multiplier is calculated by dividing the advertisement multiplier
            //by the average area advertisement multiplier
            advertismentMultiplier = advertisementInvestment / avAdInv;
        }

        //This function calculates the percentage of paying customers
        //The shoplifting rate for the area and the average security investment for the area is passed in
        public virtual void calcPercentageOfPayingCustomers(double shpLifRat, double avSecInv)
        {
            //to calculate the percentage of paying customers, the security investment is divided by the average security investment
            //to see how far away the security investment is away from the average security investment
            percentageOfPayingCustomers = securityInvestment / avSecInv;
            //Then this value calcualted is multiplied by the shoplifting rate for the area to work out a percentage (decimal) of the number of shoplifting customers
            percentageOfPayingCustomers = percentageOfPayingCustomers * shpLifRat;

            //both these lines convert the number of shoplifting customers to the number of paying customers
            percentageOfPayingCustomers = percentageOfPayingCustomers * -1;
            percentageOfPayingCustomers = percentageOfPayingCustomers + 1;

            //check if the user area is rural
            if (Program.UserArea == "Rural")
            {
                //rural area there is no security or shoplifting, so percentage of paying customers is set to 1, so it doesn't change the overall customer multiplier
                percentageOfPayingCustomers = 1;
            }
        }

        //This function calculates the worker wage multiplier
        public virtual void calcWorkerWageMultiplier()
        {
            //The worker wage multiplier is calculated by dividing the supermarket's worker wage by the average wage (constant)
            workerWageMultiplier = workerWage / WorkerWageAverage;
        }

        //This function calculates the amount of worker multiplier
        //the average amount of workers for an area is passed in
        public virtual void calcAmountOfWorkersMultiplier(int avAmWork)
        {
            //the amount of workers multiplier is calculated by dividing the amount of workers to the average amount of workers
            //to work out how far the amount of workers is from the average
            //the amount of workers and average amount of workers need to be converted to a double so that the value calculated is also a deimcal and is not rounded
           amountOfWorkersMultiplier = Convert.ToDouble(amountOfWorkers) / Convert.ToDouble(avAmWork);
        }

        //calculate the online customer multiplier
        public virtual void calcOnlineCustomerMultiplier()
        {
            //all the multipliers, that effect the online shop, are multiplied together to make the online customer multiplier
            onlineCustomerMultiplier = stockAvailableMultiplier * qualityMultiplier * itemPricesMultiplier * advertismentMultiplier
                 * onlineAmountOfWorkersMultiplier * onlineWorkerWageMultiplier;
        }

        //Calculate the online amount of workers multiplier
        //the online average amount of workers is passed in
        public virtual void calcOnlineAmountOfWorkersMultiplier(int areaOnAvAmWork)
        {
            //the supermarket's online amount of workers is divided by the average amount of online workers (dependent on the area)
            //to create the onlineAmountOfWorkersMultiplier
            //both values need to be converted to doubles, so the answer is not rounded to an integer
            onlineAmountOfWorkersMultiplier = Convert.ToDouble(onlineAmountOfWorkers) / Convert.ToDouble(areaOnAvAmWork);
        }

        //This function calculates the online worker wage multiplier
        public virtual void calcOnlineWorkerWageMultiplier()
        {
            //divide the supermarket's delivery worker wage by the average delivery worker wage to get the online worker wage multiplier
            onlineWorkerWageMultiplier = onlineWorkerWage / OnlineWorkerWageAverage;
        }

        //This function sets the value passed in to the current funds
        public virtual void setValueToCurrentFunds(double currFund)
        {
            currentFunds = currFund;
        }

        //This function sets the current funds for a supermarket, in a new game
        //The number of players and user area are passed in
        public virtual void setCurrentFunds(int numOfPlay, string area)
        {
            //for different areas there will be different starting current funds
            switch (area)
            {
                case "Urban":
                    //For different numbers of players there will be different starting current funds
                    switch (numOfPlay)
                    {
                        case 2:
                            currentFunds = 313003.24;
                            break;
                        case 3:
                            currentFunds = 212740.49;
                            break;
                        case 4:
                            currentFunds = 162610.29;
                            break;
                        case 5:
                            currentFunds = 132530.29;
                            break;
                        default:
                            break;
                    }
                    break;
                case "Suburb":
                    switch (numOfPlay)
                    {
                        case 2:
                            currentFunds = 148063.9;
                            break;
                        case 3:
                            currentFunds = 101056.85;
                            break;
                        case 4:
                            currentFunds = 77554.5;
                            break;
                        case 5:
                            currentFunds = 63452.15;
                            break;
                        default:
                            break;
                    }
                    break;
                case "Rural":
                    switch (numOfPlay)
                    {
                        case 2:
                            currentFunds = 111370.28;
                            break;
                        case 3:
                            currentFunds = 75491.83;
                            break;
                        case 4:
                            currentFunds = 57554.28;
                            break;
                        case 5:
                            currentFunds = 46788.93;
                            break;
                        default:
                            break;
                    }
                    break;
            }
        }

        //In this function the supermarkets previous funds are set a value
        public virtual void setValueToPrevFunds(double prevFund)
        {
            //The value passed in is set to the previous funds
            previousFunds = prevFund;
        }

        //In this function the stock amount is set a value
        public virtual void setValueToStockAmount(int stAm)
        {
            //the stock amount is set to the value passed in
            stockAmount = stAm;
        }

        //In this function stock shop array of a supermarket is set a value
        public virtual void setValuesToStockShop(string[] stShop)
        {
            //The value passed in is set to the supermarket's stock shop
            stockShop = stShop;
        }

        //In this function user supplier is assigned a value 
        public virtual void setValueToUserSupplier(string usSup)
        {
            //the value passed into the function is set to the user supplier
            userSupplier = usSup;
        }

        //In this function the supermarket's item prices are assigned a value
        public virtual void setValueToItemPrices(double price)
        {
            //the value passed in is set to item prices
            itemPrices = price;
        }

        //In this function the supermarket's old item prices are assigned a value
        public virtual void setValueToOldItemPrices(double oldPrice)
        {
            //the value passed in is set to the old item prices
            oldItemPrices = oldPrice;
        }

        //In this function advertisement investment is assigned a value 
        public virtual void setValueToAdInvest(double adInvest)
        {
            //the value passed in is set to advertisement investment
            advertisementInvestment = adInvest;
        }

        //In this function security investment is assigned a value
        public virtual void setValueToSecInvest(double secInv)
        {
            //The value passed in is set to the supermarkets security investment
            securityInvestment = secInv;
        }

        //In this function amount of workers is set a value 
        public virtual void setValueToAmountOfWorkers(int amWork)
        {
            //the value passed in is set to the amount of workers
            amountOfWorkers = amWork;
        }

        //In this function worker wage is set a value 
        public virtual void setValueToWorkerWage(double workWage)
        {
            //the value passed in is set to worker wage
            workerWage = workWage;
        }

        //In this function the online amount of workers is set to a value
        public virtual void setValueToOnilneAmountOfWorkers(int onlineAmWork)
        {
            //the value passed in is set to the online amount of workers
            onlineAmountOfWorkers = onlineAmWork;
        }

        //In this function the online worker wage is set to a value
        public virtual void setValueToOnlineWorkerWage(double onlineWorkWage)
        {
            //The value passed in is set to the online worker wage
            onlineWorkerWage = onlineWorkWage;
        }

        //In this function the actual number of customers is calculated
        //the potential number of customers and the potential number of online customers are passed in
        public virtual void calcActualNumOfCustomers(int potentialNumCust, int potentialOnlineNumCust)
        {
            //the total number of potential customers is calculated by adding the potential number of customers with the potential number of online customers
            int totalNumOfPotentialCust = potentialNumCust + potentialOnlineNumCust;

            //The maximum number of customers the supermarket can supply for, is calulated by dividing the amount of stock bought by
            //the average shopping mass of a customer, this number is then rounded
            int maxNumOfCust = Convert.ToInt32(Math.Round(Convert.ToDouble(stockAmount))/Convert.ToDouble(AverageShoppingMassKg));

            //if the total number of potential customers is greater than the maximum number of customers then the supermarket does not
            //enough stock to feed all the customers that they could potential get
            if (totalNumOfPotentialCust > maxNumOfCust)
            {
                //The number of customers the supermarket gets is limited by the amount of stock the supermarket bought
                actualNumberOfCustomers = maxNumOfCust;
            }
            //The supermarket has enough stock for all the customers they get
            else
            {
                //the supermarket could supply for all the customers they got
                actualNumberOfCustomers = totalNumOfPotentialCust;
            }
        }
    }
}
