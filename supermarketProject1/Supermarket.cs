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

        private double currentFunds;
        public double CurrentFunds
        {
            get { return currentFunds; }
        }
        private double previousFunds;

        private double netProfit;
        public double NetProfit
        {
            get { return netProfit; }
        }
        private double customerMultiplier;
        public double CustomerMultiplier
        {
            get { return customerMultiplier; }
        }
        private int stockAmount;

        private string[] stockShop;

        private bool[] stockAvailable = new bool[Program.LenStockRange];

        private double stockAvailableMultiplier;

        private string userSupplier;

        private double qualityMultiplier;

        private double supplierCost;

        private double itemPrices;
        public double ItemPrices
        {
            get { return itemPrices; }
        }

        private double oldItemPrices;

        private double itemPricesMultiplier;

        private double advertisementInvestment;

        private double advertismentMultiplier;

        private double securityInvestment;

        private double numberOfPayingCustomers;

        private int amountOfWorkers;
        public int AmountOfWorkers
        {
            get { return amountOfWorkers; }
        }
        private double amountOfWorkersMultiplier;
        private double workerWage;
        public double WorkerWage
        {
            get { return workerWage; }
        }

        private const double WorkerWageAverage = 11.36;

        private double workerWageMultiplier;

        private double onlineCustomerMultiplier;
        public double OnlineCustomerMultiplier
        {
            get { return onlineCustomerMultiplier; }
        }

        private int onlineAmountOfWorkers;
        public int OnlineAmountOfWorkers
        {
            get { return onlineAmountOfWorkers; }
        }
        private double onlineWorkerWage;
        public double OnlineWorkerWage
        {
            get { return onlineWorkerWage; }
        }

        private const double OnlineWorkerWageAverage = 12.39;

        private double onlineWorkerWageMultiplier;

        private double onlineAmountOfWorkersMultiplier;

        private const int WorkerHours = 28;

        private const int DeliveryWorkerHours = 31;

        private const int AverageShoppingMassKg = 21;

        private double overspent;
        public double Overspent
        {
            get { return overspent; }
        }

        public Supermarket()
        {

        }
        public virtual void calcCustomerMultiplier()
        {
            //multiply all the calculated multipliers together to create a combined multiplier
            //this combined multiplier used to work out the number of customers
            customerMultiplier = stockAvailableMultiplier * qualityMultiplier * itemPricesMultiplier * advertismentMultiplier
                * amountOfWorkersMultiplier * workerWageMultiplier
                * onlineAmountOfWorkersMultiplier * onlineWorkerWageMultiplier * numberOfPayingCustomers;
        }
        public virtual void calcCurrentFunds(int numCust, int onlineNumCust)
        {
            //numOfCustomers, onlineNumOfCustomer
            //stockAmount, supplierCost, itemPrices, 
            //workerWage, amountOfWorkers, onlineWorkerWage, onlineAmountOfWorkers

            //This method calculates the current funds of the supermarket
            //calculate the profits of the supermarket
            //total number of customers
            int totalAmountOfCusotmers = onlineNumCust + numCust;
            //average mass that a customer buys from a supermarket is 21
            double profit = totalAmountOfCusotmers * itemPrices * AverageShoppingMassKg;
            //work out all the expenses
            //the workers work 28 hours
            double expenses = workerWage * amountOfWorkers * WorkerHours;
            //the delivery workers work 31 hours
            expenses = expenses + onlineWorkerWage * onlineAmountOfWorkers * DeliveryWorkerHours;
            expenses = expenses + supplierCost * stockAmount;
            expenses = expenses + advertisementInvestment;
            expenses = expenses + securityInvestment;

            currentFunds = currentFunds + profit - expenses;
        }

        //this function calculates the expenses and the current funds that the supermarket can use 
        //and calculates whether the current funds is negative, meaning the user's turn was invalid
        public virtual bool checkCurrentFundsNegative()
        {
            //the workers work 28 hours
            double expenses = workerWage * amountOfWorkers * WorkerHours;
            //the delivery drivers work 31 hours
            expenses = expenses + onlineWorkerWage * onlineAmountOfWorkers * DeliveryWorkerHours;
            expenses = expenses + supplierCost * stockAmount;
            expenses = expenses + advertisementInvestment;
            expenses = expenses + securityInvestment;

            if (currentFunds < expenses)
            {
                //this means we can work out the amount that the user has overspent by
                overspent = expenses - currentFunds;
                return true;
            }
            else
            {
                return false;
            }
        }
        public virtual void calcNetProfit()
        {
            //currentFunds, previousFunds
            //find the difference between the current funds and the previous funds to work out the net profit
            netProfit = currentFunds - previousFunds;
        }
        public virtual void checkStockAvailable(string[] stRange)
        {
            //Supplier.stockRange, stockShop, stockAvailable
            //use a for loop to go through the list of all the types of stock checking which ones are available and not
            for (int i = 0; i < stRange.Length; i++)
            {
                if (stRange[i] == stockShop[i])
                {
                    stockAvailable[i] = true;
                }
                else
                {
                    stockAvailable[i] = false;
                }
            }
        }
        public virtual void stockAvailableChangeProfit()
        {

            //stockAvailable

            //deafult that they have all the different types of stock and the multiplier is 1 ()
            //won't change anything if the multiplier is 1
            stockAvailableMultiplier = 1;
            //count how many types of stock which aren't present in the supermarket
            int numOfUnavailableStock = 0;
            for (int i = 0; i < stockAvailable.Length; i++)
            {
                if (stockAvailable[i] == false)
                {
                    numOfUnavailableStock++;
                }
            }
            //for each unavailables stock the multiplier will shrink by 25%
            //if there unavailableStock = 0, it show skip this for loop
            for (int i = 0; i < numOfUnavailableStock; i++)
            {
                stockAvailableMultiplier = stockAvailableMultiplier * 0.75;
            }

        }
        public virtual void calcQualityMultiplier(string[] supQual, double[] suppQualMult)
        {
            //userSupplier
            //Supplier.suppliersQuality, Supplier.suppliersQualityMultiplier

            //go through the list to check the number in the list that the userSupplier refers to in the supplier lists
            for (int i = 0; i < supQual.Length; i++)
            {
                //if statement to check whether the userSupplier is reffering to the right place in the list
                if (userSupplier == supQual[i])
                {
                    //when the if statement is true the i refers to the correct number in the list which user supplier
                    //refers to
                    //when i is correct put the supplier quality multiplier[i] into the return variable
                    //quality multiplier 
                    qualityMultiplier = suppQualMult[i];
                }

            }
        }
        public virtual void calcSupplierCost(double[] suppPrice, string[] suppQual)
        {
            //userSupplier, Supplier.supplierPrices, stockAmount, Supplier.suppliersQuality
            //go through list which has names of all the different types of quality
            for (int i = 0; i < suppQual.Length; i++)
            {
                //if the user supplier has the same quality as the supplier quality, then
                //set the supplier cost to the relevant i
                if (userSupplier == suppQual[i])
                {
                    supplierCost = suppPrice[i];
                }
            }
        }
        public virtual void calcItemPricesMultiplier()
        {
            //itemPrices, oldItemPrices
            //this multiplier works by dividing the new item prices by the old item prices
            //itemPrices/oldItemPrices
            if (oldItemPrices > 0)
            {
                itemPricesMultiplier = itemPrices / oldItemPrices;
            }
            //the old itemPrices will start at 0 so the multiplier shouldn't change the
            //customerMultiplier in the first turn
            else
            {
                itemPricesMultiplier = 1;
            }
        }
        public virtual void calcAdvertisementMultiplier(double avAdInv)
        {
            //advertisementInvestment, Area.averageAreaAdvertisementInvestment
            //this multiplier is calculated by dividing the advertisementInvestment by the 
            //average area investment
            advertismentMultiplier = advertisementInvestment / avAdInv;
        }


        //need to change this name to calculate the number of paying customers
        public virtual void calcNumOfPayingCustomers(double shpLifRat, double avSecInv)
        {
            //Area.shopliftingRate, Area.averageSecurityInvesmtent
            //the shoplifting rate is a decimal representation of a percentage

            //first i am going to divide the security investment by the average security investment
            //if the security investment > average security investment then the answer will be greater
            //than one 
            //to show how this will effect the shoplifting rate, we will divide the shoplifting rate by
            //the (security investmment/average security investment)
            //multiply this value with the shoplifting rate
            //This will then cause the new shoplifting rate to decrease if the calculated value is greater than the 
            //shoplifting rate and will increase if the calculated value is smaller than the shoplifting rate
            //with the new calculated shoplifting rate the number of customers who have shoplifted
            //can be calculated and then taken off the number of customers

            numberOfPayingCustomers = securityInvestment / avSecInv;
            numberOfPayingCustomers = numberOfPayingCustomers * shpLifRat;
            //these two steps below are to change the calculated value from the number of customers who shoplifted
            // (as a percentage), to the number of customers who paid (as a decimal percentage)
            numberOfPayingCustomers = numberOfPayingCustomers * -1;
            numberOfPayingCustomers = numberOfPayingCustomers + 1;

            if (Program.UserArea == "Rural")
            {
                numberOfPayingCustomers = 1;
            }
        }

        public virtual void calcWorkerWageMultiplier()
        {
            //for the worker wage multiplier multiply divide the worker wage by the average worker wage

            workerWageMultiplier = workerWage / WorkerWageAverage;
        }
        public virtual void calcAmountOfWorkersMultiplier(int avAmWork)
        {
            //amountOfWorkers, Area.averageAmountOfWorkers
            //work out a multiplier by dividing the amountOfWorkers by the average amount of workers in the area
            amountOfWorkersMultiplier = Convert.ToDouble(amountOfWorkers) / Convert.ToDouble(avAmWork);
        }
        public virtual void calcOnlineCustomerMultiplier()
        {
            //stockAvailableMultiplier, qualityMultiplier, itemPricesMultiplier, advertisementMultiplier
            //onlineAmountOfWOrkersMultiplier, onlineWorkerWageMultiplier

            //this is a multiplier representing all the multipliers together for the online shop
            //it will be used to work out how many customers  the supermarket will have
            //can be calculated by multiplying all the multipliers together
            onlineCustomerMultiplier = stockAvailableMultiplier * qualityMultiplier * itemPricesMultiplier * advertismentMultiplier
                 * onlineAmountOfWorkersMultiplier * onlineWorkerWageMultiplier;
        }
        public virtual void calcOnlineAmountOfWorkersMultiplier(int areaOnAvAmWork)
        {
            //onlineAmountOfWorkers, Area.onlineAverageAmountOfWorkers
            //work out a multiplier by dividing the onlineAmountOfWorkers
            //by the average amount of delivery workers in the area
            onlineAmountOfWorkersMultiplier = Convert.ToDouble(onlineAmountOfWorkers) / Convert.ToDouble(areaOnAvAmWork);
            //this is a multiplier that represents how a change in the number of delivery workers
        }
        public virtual void calcOnlineWorkerWageMultiplier()
        {
            //divide the delivery worker wage by the average delivery worker wage to get the online worker wage multiplier
            onlineWorkerWageMultiplier = onlineWorkerWage / OnlineWorkerWageAverage;
        }

        //function that sets a value to the supermarket current funds
        public virtual void setValueToCurrentFunds(double currFund)
        {
            currentFunds = currFund;
        }

        //sets a value to previous funds
        public virtual void setValueToPrevFunds(double prevFund)
        {
            previousFunds = prevFund;
        }
        //sets the stock amount to a value
        public virtual void setValueToStockAmount(int stAm)
        {
            stockAmount = stAm;
        }
        //sets values to stock shop
        public virtual void setValuesToStockShop(string[] stShop)
        {
            stockShop = stShop;
        }

        //sets value to user supplier
        public virtual void setValueToUserSupplier(string usSup)
        {
            userSupplier = usSup;
        }
        //sets item prices to a value
        public virtual void setValueToItemPrices(double price)
        {
            itemPrices = price;
        }
        //sets old item prices to a value
        public virtual void setValueToOldItemPrices(double oldPrice)
        {
            oldItemPrices = oldPrice;
        }
        //sets a value to the advertisement investment
        public virtual void setValueToAdInvest(double adInvest)
        {
            advertisementInvestment = adInvest;
        }
        //sets a variable to security investment
        public virtual void setValueToSecInvest(double secInv)
        {
            securityInvestment = secInv;
        }
        //set a value to amount of workers
        public virtual void setValueToAmountOfWorkers(int amWork)
        {
            amountOfWorkers = amWork;
        }
        //set value to worker wage
        public virtual void setValueToWorkerWage(double workWage)
        {
            workerWage = workWage;
        }
        //set value to online amount of workers
        public virtual void setValueToOnilneAmountOfWorkers(int onlineAmWork)
        {
            onlineAmountOfWorkers = onlineAmWork;
        }
        //set value to online worker wage
        public virtual void setValueToOnlineWorkerWage(double onlineWorkWage)
        {
            onlineWorkerWage = onlineWorkWage;
        }
    }
}
