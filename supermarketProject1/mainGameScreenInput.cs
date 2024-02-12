using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace supermarketProject1
{
    public partial class mainGameScreenInput : Form
    {

        //here adding all the variables in supermarket which the user can control
        //these variables will be added to their specific supermarket objects in program.cs
        //these variables will change every time that the mainGameScreen is called
        private static string userSupplier;

        private static string[] stockShop = new string[Program.LenStockRange];
        
        private static int stockAmount;

        private static double itemPrices;

        private static double advertisementInvestment;

        private static double securityInvestment;

        private static int amountOfWorkers;
       
        private static double workerWage;
        
        private static int onlineAmountOfWorkers;

        private static double onlineWorkerWage;

        //set up the valid
        private static bool valid;

        private static Supermarket[] supermarkets = new Supermarket[Program.NumOfPlayers];
        
        private static Area area;
       
        private static Supplier supplier;

        //this is a list containing all the number of customers for all the supermarkets
        private static int[] numberOfCustomers = new int[Program.NumOfPlayers];
        //this is a list contatining the number of online customers for all the supermarkets
        private static int[] onlineNumberOfCustomers = new int[Program.NumOfPlayers];

        //this is a list contatining all the multipliers for the supermarkets
        private static double[] customerMultipliers = new double[Program.NumOfPlayers];
        //different list for the online supermarkets
        private static double[] onlineCustomerMultipliers = new double[Program.NumOfPlayers];

        //count is used to see what supermarket is being looked at
        private static int count;

       
        public mainGameScreenInput()
        {
            InitializeComponent();

            //need to set up the stock range list so that it can be used throughout the program
            for (int i = 0; i < stockShop.Length; i++)
            {
                stockShop[i] = " ";
            }
            count = 0;

            area = new Area(Program.UserArea);

            //initialise the supplier object
            supplier = new Supplier();

            if (Program.UserLoadedFile == true)
            {
                //initialise all the supermarket objects for the right number of players
                for (int i = 0; i < Program.NumOfPlayers; i++)
                {
                    supermarkets[i] = new Supermarket();

                    //set up all the old prices as deafult 0 
                    supermarkets[i].setValueToOldItemPrices(Program.HistoryItemPrices[i, Program.WeekNumber - 1]);
                    supermarkets[i].setValueToPrevFunds(Program.HistoryCurrentFunds[i, Program.WeekNumber - 1]);

                    //need to also set the newer version of the worker wages to 0 because the first time through the
                    //old variables will have no variable to be assigned too.

                    //---------------------------------------------------------------------
                    //                                                                    |
                    //supermarkets[i].itemPrices = 0;                 |
                    //supermarkets[i].workerWage = 0;                 |
                    //supermarkets[i].onlineWorkerWage = 0;           |
                    //                                                                    |
                    //---------------------------------------------------------------------

                    //call a function that sets the specific save file current funds to the appropriate current funds
                    supermarkets[i].setValueToCurrentFunds(Program.CurrentFundsForSaveFile[i]);
                    
                    if (Program.UserArea == "Rural")
                    {
                        //make the security investment invisible because there is no shoplifting in rural areas
                        labelSecurityInvestment.ForeColor = Color.WhiteSmoke;
                        textBoxSecurityInvestmentInput.BackColor = Color.WhiteSmoke;
                        textBoxSecurityInvestmentInput.BorderStyle = BorderStyle.None;
                    }

                }
            }
            else if(Program.UserLoadedFile == false)
            {
                //initialise all the supermarket objects for the right number of players
                for (int i = 0; i < Program.NumOfPlayers; i++)
                {
                    supermarkets[i] = new Supermarket();

                    //set up all the old prices as deafult 0 
                    supermarkets[i].setValueToOldItemPrices(0);
                    supermarkets[i].setValueToPrevFunds(0);
   
                
                    //check which area the user has chosen and set the appropriate current funds
                    if (Program.UserArea == "Urban")
                    {
                        supermarkets[i].setValueToCurrentFunds(132530.29);
                    }
                    if (Program.UserArea == "Suburb")
                    {
                        supermarkets[i].setValueToCurrentFunds(63452.15);
                    }
                    if (Program.UserArea == "Rural")
                    {
                        supermarkets[i].setValueToCurrentFunds(46789.87);
                        //make the security investment invisible because there is no shoplifting in rural areas
                        labelSecurityInvestment.ForeColor = Color.WhiteSmoke;
                        textBoxSecurityInvestmentInput.BackColor = Color.WhiteSmoke;
                        textBoxSecurityInvestmentInput.BorderStyle = BorderStyle.None;
                    }
                }

                //need to initialise the history variables
                Program.initHistoryVariables();
            }

            //function to set up the currentFundsForSaveFile to the right lenght
            Program.initCurrentFundsForSaveFile();

            //set up the number of weeks passed
            labelNumberOfWeeksPassedText.Text = Convert.ToString(Program.WeekNumber);

            //set up the number of weeks left
            labelNumberOfWeeksLeftText.Text = Convert.ToString(Program.calcNumOfWeeksLeft());

            //set up the current funds
            labelCurrentFundsText.Text = Convert.ToString(supermarkets[count].CurrentFunds);

            //set the last week label to be invisible first
            labelLastWeek.ForeColor = Color.WhiteSmoke;
        }

        private void mainGameScreenInput_Load(object sender, EventArgs e)
        {

        }

        private void textBoxStockAmountInput_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonSubmitChanges_Click(object sender, EventArgs e)
        {
            //this for loop is to set up all the "old" variables
            supermarkets[count].setValueToOldItemPrices(supermarkets[count].ItemPrices);
            supermarkets[count].setValueToPrevFunds(supermarkets[count].CurrentFunds); 
            //add the number of weeks passed
            labelNumberOfWeeksPassedText.Text = Convert.ToString(Program.WeekNumber);
            //add the number of weeks left 
            labelNumberOfWeeksLeftText.Text = Convert.ToString(Program.calcNumOfWeeksLeft());
            
            //reset the invalid message for current funds
            labelInvalidFunds.ForeColor = Color.WhiteSmoke;

            //set up an if statment, so that every time the submit changes is clicked the program checks whether
            //to display the graphs, or to do the next supermarket.
            //have a bool called valid which will be used to see if the user can move onto the next person or not
            if (count < Program.NumOfPlayers)
            {
                valid = true;

                //need to check if the input is a string 
                //or if the input is smaller than 1 meaning it is a minus number or 0
                //or if the input is not an integer, so is a double      
                if (Program.checkIfString(Convert.ToString(textBoxStockAmountInput.Text)) == true
                     || Program.checkIfInteger(Convert.ToString(textBoxStockAmountInput.Text)) == false
                     || Program.checkIfNegativeOrZero(Convert.ToString(textBoxStockAmountInput.Text)) == true)
                {
                    valid = false;
                    labelInvalidStockAmount.ForeColor = Color.Red;
                }
                else if(valid == true)
                {
                    valid = true;
                    stockAmount = Convert.ToInt32(textBoxStockAmountInput.Text);
                }

                //need to check if the value is a string,
                //then check if the value is 0 or smaller
                if (Program.checkIfString(textBoxItemPricesInput.Text) == true ||
                    Program.checkIfNegativeOrZero(textBoxItemPricesInput.Text) == true)
                {
                    valid = false;
                    labelInvalidItemPrices.ForeColor = Color.Red;
                }
                else if(valid == true)
                {
                    valid = true;
                    itemPrices = Convert.ToDouble(textBoxItemPricesInput.Text);
                }

                //need to check if the advertisement investment is a string,
                //then check if the value is 0 or smaller
                if (Program.checkIfString(textBoxAdvertisementInvestmentInput.Text) == true ||
                    Program.checkIfNegativeOrZero(textBoxAdvertisementInvestmentInput.Text) == true)
                {
                    valid = false;
                    labelInvalidAdvertisementInvestment.ForeColor = Color.Red;
                }
                else if(valid == true)
                {
                    valid = true;
                    advertisementInvestment = Convert.ToDouble(textBoxAdvertisementInvestmentInput.Text);
                }

                //need to check if the input is a string, then if the value is 0 or smaller
                //first need to check if it is a rural area or not,
                //if it is not a rural area does not need to go through this check because there
                //is no security variables for the rural area
                if (Program.UserArea != "Rural")
                {

                    if (Program.checkIfString(textBoxSecurityInvestmentInput.Text) == true ||
                    Program.checkIfNegativeOrZero(textBoxSecurityInvestmentInput.Text) == true)
                    {
                        valid = false;
                        labelInvalidSecurityInvestment.ForeColor = Color.Red;
                    }
                    else if (valid == true)
                    {
                        valid = true;
                        securityInvestment = Convert.ToDouble(textBoxSecurityInvestmentInput.Text);
                    }

                }
                

                

                //need to check if the input is a string, then if the input is not an integer
                //then check if the value is 0 or less
                if (Program.checkIfString(textBoxAmountOfWorkersInput.Text) == true ||
                    Program.checkIfInteger(textBoxAmountOfWorkersInput.Text) == false ||
                    Program.checkIfNegativeOrZero(textBoxAmountOfWorkersInput.Text) == true)
                {
                    valid = false;
                    labelInvalidAmountOfWorkers.ForeColor = Color.Red;
                }
                else if(valid == true)
                {
                    valid = true;
                    amountOfWorkers = Convert.ToInt32(textBoxAmountOfWorkersInput.Text);
                }

                //need to check if the input is a string, then if the input is a negative number or 0
                if (Program.checkIfString(textBoxWorkerWageInput.Text) == true ||
                    Program.checkIfNegativeOrZero(textBoxWorkerWageInput.Text) == true)
                {
                    valid = false;
                    labelInvalidWorkerWage.ForeColor = Color.Red;
                }
                else if(valid == true)
                {
                    valid = true;
                    workerWage = Convert.ToDouble(textBoxWorkerWageInput.Text);
                }

                //need to check if the input is a string, then if the input is
                //not a integer, then if the value is 0 or less
                if (Program.checkIfString(textBoxAmountOfDeliveryWorkersInput.Text) == true ||
                    Program.checkIfInteger(textBoxAmountOfDeliveryWorkersInput.Text) == false ||
                    Program.checkIfNegativeOrZero(textBoxAmountOfDeliveryWorkersInput.Text) == true)
                {
                    valid = false;
                    labelInvalidAmountOfDeliveryWorkers.ForeColor = Color.Red;
                }
                else if(valid == true)
                {
                    valid = true;
                    onlineAmountOfWorkers = Convert.ToInt32(textBoxAmountOfDeliveryWorkersInput.Text);
                }

                //need to check if the input is a string,
                //then if the input is zero or less 
                if (Program.checkIfString(textBoxDeliveryWorkerWageInput.Text) == true ||
                    Program.checkIfNegativeOrZero(textBoxDeliveryWorkerWageInput.Text) == true)
                {
                    valid = false;
                    labelInvalidDeliveryWorkerWage.ForeColor = Color.Red;
                }
                else if(valid == true)
                {
                    valid = true;
                    onlineWorkerWage = Convert.ToDouble(textBoxDeliveryWorkerWageInput.Text);
                }
               
                
                //check if user suppier is empty
                
                if (userSupplier == "Excellent" || userSupplier == "Great" || userSupplier == "Average" || userSupplier == "Bad" || userSupplier == "Poor")
                {
                    if (valid == true)
                    {
                        valid = true;
                    }  
                }
                else
                {
                    labelInvalidUserSupplier.ForeColor = Color.Red;
                    valid = false;
                }
                

                //check if the stock range is empty
                if (stockShop[0] == "Vegetables" || stockShop[1] == "Meat" || stockShop[2] == "Snack"
                || stockShop[3] == "Household")
                {
                    if (valid == true)
                    {
                        valid = true;
                    }
                }
                else
                {
                    valid = false;
                    labelInvalidStockShop.ForeColor = Color.Red;
                }
                
                


                //if passes all the checks for invalid data, e.g. erroneous and boundary
                if (valid == true)
                {
                    //this function sets all the variables in mainGameScreen to supermarket vairables
                    setVariablesToSupermarkets();
                    //this function calls all the supermarket methods used
                    callAllSupermarketMethods();

                    //check if the user has enough funds to do what they want to do
                    if (supermarkets[count].checkCurrentFundsNegative() == true)
                    {
                        //if the function returns true that means that there are not enough
                        //funds to process all the user's changes
                        valid = false;
                        //display error message to user
                        labelInvalidFunds.ForeColor = Color.Red;
                        //tell the user how much they have overspent by
                        labelOverspent.Text = "Overspent by £" + Convert.ToString(supermarkets[count].Overspent);
                        labelOverspent.ForeColor = Color.Red;
                    }
                    else
                    {
                        //only increment count if passes all the checks
                        //so only increment if valid is true
                        count++;

                        //change the player to the right player using the count index only if there are more players
                        if (count < Program.NumOfPlayers)
                        {
                            labelPlayerNum.Text = "Player " + Convert.ToString(count + 1);
                            //label for the current funds
                            labelCurrentFundsText.Text = Convert.ToString(supermarkets[count].CurrentFunds);

                        }

                        //reset the screen to the original
                        buttonReset.PerformClick();
                    }
                }
                else
                {
                    //this else means that valid is false, so the player has to input their variables again
                    //this means that count stays the same
                }

            }
            if(count == Program.NumOfPlayers)
            {
                //after the if statment process all the changes to the supermarket in this else statement

                //make a loop that will input all the supermarket multipliers into a list 
                for (int i = 0; i < supermarkets.Length; i++)
                {
                    customerMultipliers[i] = supermarkets[i].CustomerMultiplier;
                    onlineCustomerMultipliers[i] = supermarkets[i].OnlineCustomerMultiplier;
                }

                //use the same function to calculate the number of customers and then the number of customer for the online shop
                numberOfCustomers = calcNumOfCustomer(area.CustomerPopulation, customerMultipliers);
                onlineNumberOfCustomers = calcNumOfCustomer(area.OnlineCustomerPopulation, onlineCustomerMultipliers);

                //now we need to calculate the current funds for all the supermarkets
                //we can do this by using a for loop to go through all the supermarkets
                for (int i = 0; i < supermarkets.Length; i++)
                {
                    //this calulates the current funds for every supermarket
                    supermarkets[i].calcCurrentFunds(numberOfCustomers[i], onlineNumberOfCustomers[i]);
                    //set the current funds to a save file if it will be used
                    Program.setCurrentFundsForSaveFile(supermarkets[i].CurrentFunds, i);
                    //now calculate the net profit for all the supermarkets
                    supermarkets[i].calcNetProfit();
                }

                //only graph the results if the currentFunds isn't negative, or the valid is true
                // --- NOW WE NEED TO START GRAPHING THE RESULTS ---
                //first we need to get all the variables that are going to be graphed and put them into a list in Program
                //this list will contain the history of all the variables, so they can be graphed

                //using a for loop
                //i representing the index of the number the player is. For example when i is 0 it looks at the first
                //player, when i is 1 it looks at the second player etc...
                for (int i = 0; i < Program.NumOfPlayers; i++)
                {
                    Program.setHistoryVariables(Program.HistoryNetProfit, i, supermarkets[i].NetProfit);
                    Program.setHistoryVariables(Program.HistoryAmountOfWorkers, i, supermarkets[i].AmountOfWorkers);
                    Program.setHistoryVariables(Program.HistoryCurrentFunds, i, supermarkets[i].CurrentFunds);
                    Program.setHistoryVariables(Program.HistoryItemPrices, i, supermarkets[i].ItemPrices);
                    Program.setHistoryVariables(Program.HistoryNumOfCustomers, i, numberOfCustomers[i]);
                    Program.setHistoryVariables(Program.HistoryOnlineNumOfCustomers, i, onlineNumberOfCustomers[i]);
                    Program.setHistoryVariables(Program.HistoryOnlineAmountOfWorkers, i, supermarkets[i].OnlineAmountOfWorkers);
                    Program.setHistoryVariables(Program.HistoryOnlineWorkerWage, i, supermarkets[i].OnlineWorkerWage);
                    Program.setHistoryVariables(Program.HistoryWorkerWage, i, supermarkets[i].WorkerWage);
                }
                //once the turns have finished implement the number of weeks by 1
                Program.incrementWeekNumber();
                //add the right number of weeks to the label
                //set up the number of weeks passed
                labelNumberOfWeeksPassedText.Text = Convert.ToString(Program.WeekNumber);

                //set up the number of weeks left
                labelNumberOfWeeksLeftText.Text = Convert.ToString(Program.calcNumOfWeeksLeft());

                //reset count back to the first player 
                count = 0;

                //reset the label which says to the player which player it is
                labelPlayerNum.Text = "Player " + Convert.ToString(count + 1);

                //label for the current funds
                labelCurrentFundsText.Text = Convert.ToString(supermarkets[count].CurrentFunds);

                //initialise the new main game screen graph and show it
                mainGameScreenGraph mgsg = new mainGameScreenGraph();
                mgsg.Show();

                //this means it is the last week
                if (Program.calcNumOfWeeksLeft() == 1)
                {
                    //this means it is the last turn
                    labelLastWeek.ForeColor = Color.Red;
                }

                //if the number of weeks is equal to end number of weeks
                //there are no more goes left so close this forms application

                if (Program.calcNumOfWeeksLeft() == 0)
                {
                    this.Close();
                }
            }
        }

        //a function that calculates the number of customers
        public static int[] calcNumOfCustomer(int custPop, double[] custMults)
        {
            //calculate the number of customers
            //Area.customerPopulation or Area.onlineCustomerPopulation
            //customerMultipliers (double []) or onlineCustomerMultipliers (double [])
           

            //first add all the multipliers together
            double multTotal = 0;
            for (int i = 0; i < custMults.Length; i++)
            {
                multTotal = multTotal + custMults[i];
            }

            //then find the reciporacal of all the multipliers 
            double recipMulTotal = 1 / multTotal;

            //use the reciprocal of the total of all the multipliers and multipliy all the seperate multipliers by this value
            //create a new value for the new balanced multipliers
            double[] newMults = new double[custMults.Length];
            for (int i = 0; i < custMults.Length; i++)
            {
                newMults[i] = custMults[i] * recipMulTotal;
            }

            //with the new balanced multipliers use this value as a multiplier and multiply by the total customer population
            //create a new list of all the new updated number of customers
            int[] numOfCust = new int[custMults.Length];
            for (int i = 0; i < custMults.Length; i++)
            {
                //note that here when rounding the number of customers will ignore any decimal points
                //this means that adding all the user supermarkets together will not lead to an exact
                //value of the area customer population
                //however when dealing with such big number of customers (e.g over 100)
                //then this little number of customers "dissapearing" seems igsicnificant
                numOfCust[i] = Convert.ToInt32(Math.Round(newMults[i] * custPop));
            }
            return numOfCust;
        }
        
        //create a function that sets all the variables to their respective supermarket object
        public static void setVariablesToSupermarkets()
        {
            supermarkets[count].setValueToStockAmount(stockAmount);
            supermarkets[count].setValueToUserSupplier(userSupplier);
            supermarkets[count].setValueToItemPrices(itemPrices);
            supermarkets[count].setValueToAdInvest(advertisementInvestment);
            supermarkets[count].setValueToSecInvest(securityInvestment);
            supermarkets[count].setValueToAmountOfWorkers(amountOfWorkers);
            supermarkets[count].setValueToWorkerWage(workerWage);
            supermarkets[count].setValueToOnilneAmountOfWorkers(onlineAmountOfWorkers);
            supermarkets[count].setValueToOnlineWorkerWage(onlineWorkerWage);
            supermarkets[count].setValuesToStockShop(stockShop);
            supermarkets[count].checkStockAvailable(supplier.StockRange);
        }

        //create a function that calls all the supermarket methods used to get the find the supermarkets results
        public static void callAllSupermarketMethods()
        {
            supermarkets[count].calcAdvertisementMultiplier(area.AverageAreaAdvertisementInvestment);
            supermarkets[count].calcQualityMultiplier(supplier.SuppliersQuality, supplier.SuppliersQualityMultiplier);
            supermarkets[count].calcNumOfPayingCustomers(area.ShopLiftingRate, area.AverageSecurityInvestment);
            supermarkets[count].calcItemPricesMultiplier();
            supermarkets[count].calcAmountOfWorkersMultiplier(area.AverageAmountOfWorkers);
            supermarkets[count].calcOnlineAmountOfWorkersMultiplier(area.OnlineAverageAmountOfWorkers);
            supermarkets[count].calcWorkerWageMultiplier();
            supermarkets[count].calcOnlineWorkerWageMultiplier();
            supermarkets[count].calcSupplierCost(supplier.SuppliersPrices, supplier.SuppliersQuality);
            supermarkets[count].stockAvailableChangeProfit();
            supermarkets[count].calcCustomerMultiplier();
            supermarkets[count].calcOnlineCustomerMultiplier();
        }



        private void buttonExcellent_Click(object sender, EventArgs e)
        {
            userSupplier = "Excellent";
            buttonExcellent.BackColor = Color.WhiteSmoke;
            buttonGreat.BackColor = Color.FromArgb(192, 192, 255);
            buttonAverage.BackColor = Color.FromArgb(192, 192, 255);
            buttonBad.BackColor = Color.FromArgb(192, 192, 255);
            buttonPoor.BackColor = Color.FromArgb(192, 192, 255);
        }

        private void buttonGreat_Click(object sender, EventArgs e)
        {
            userSupplier = "Great";
            buttonExcellent.BackColor = Color.FromArgb(192, 192, 255);
            buttonGreat.BackColor = Color.WhiteSmoke;
            buttonAverage.BackColor = Color.FromArgb(192, 192, 255);
            buttonBad.BackColor = Color.FromArgb(192, 192, 255);
            buttonPoor.BackColor = Color.FromArgb(192, 192, 255);
        }

        private void buttonAverage_Click(object sender, EventArgs e)
        {
            userSupplier = "Average";
            buttonExcellent.BackColor = Color.FromArgb(192, 192, 255);
            buttonGreat.BackColor = Color.FromArgb(192, 192, 255);
            buttonAverage.BackColor = Color.WhiteSmoke;
            buttonBad.BackColor = Color.FromArgb(192, 192, 255);
            buttonPoor.BackColor = Color.FromArgb(192, 192, 255);
        }

        private void buttonBad_Click(object sender, EventArgs e)
        {
            userSupplier = "Bad";
            buttonExcellent.BackColor = Color.FromArgb(192, 192, 255);
            buttonGreat.BackColor = Color.FromArgb(192, 192, 255);
            buttonAverage.BackColor = Color.FromArgb(192, 192, 255);
            buttonBad.BackColor = Color.WhiteSmoke;
            buttonPoor.BackColor = Color.FromArgb(192, 192, 255);
        }

        private void buttonPoor_Click(object sender, EventArgs e)
        {
            userSupplier = "Poor";
            buttonExcellent.BackColor = Color.FromArgb(192, 192, 255);
            buttonGreat.BackColor = Color.FromArgb(192, 192, 255);
            buttonAverage.BackColor = Color.FromArgb(192, 192, 255);
            buttonBad.BackColor = Color.FromArgb(192, 192, 255);
            buttonPoor.BackColor = Color.WhiteSmoke;
        }

        private void buttonVegetables_Click(object sender, EventArgs e)
        {
            stockShop[0] = "Vegetables";
            buttonVegetables.BackColor = Color.WhiteSmoke;
        }

        private void buttonMeat_Click(object sender, EventArgs e)
        {
            stockShop[1] = "Meat";
            buttonMeat.BackColor = Color.WhiteSmoke;
        }

        private void buttonSnacks_Click(object sender, EventArgs e)
        {
            stockShop[2] = "Snack";
            buttonSnacks.BackColor = Color.WhiteSmoke;
        }

        private void buttonHousehold_Click(object sender, EventArgs e)
        {
            stockShop[3] = "Household";
            buttonHousehold.BackColor = Color.WhiteSmoke;
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            
            //set the number of weeks and num of weeks left to the right number
            //add the number of weeks passed
            labelNumberOfWeeksPassedText.Text = Convert.ToString(Program.WeekNumber);
            //add the number of weeks left 
            labelNumberOfWeeksLeftText.Text = Convert.ToString(Program.calcNumOfWeeksLeft());

            //reset the stock different stocks all to false
            for (int i = 0; i < stockShop.Length; i++)
            {
                stockShop[i] = " ";
            }
            //resetting the colors
            buttonVegetables.BackColor = Color.FromArgb(192, 192, 255);
            buttonMeat.BackColor = Color.FromArgb(192, 192, 255);
            buttonSnacks.BackColor = Color.FromArgb(192, 192, 255);
            buttonHousehold.BackColor = Color.FromArgb(192, 192, 255);

            //reset the user Supplier to nothing
            userSupplier = "";
            //reset all the buttons
            buttonExcellent.BackColor = Color.FromArgb(192, 192, 255);
            buttonGreat.BackColor = Color.FromArgb(192, 192, 255);
            buttonAverage.BackColor = Color.FromArgb(192, 192, 255);
            buttonBad.BackColor = Color.FromArgb(192, 192, 255);
            buttonPoor.BackColor = Color.FromArgb(192, 192, 255);

            //reset all the textboxes
            textBoxStockAmountInput.ResetText();
            textBoxItemPricesInput.ResetText();
            textBoxAdvertisementInvestmentInput.ResetText();
            textBoxSecurityInvestmentInput.ResetText();
            textBoxAmountOfWorkersInput.ResetText();
            textBoxWorkerWageInput.ResetText();
            textBoxAmountOfDeliveryWorkersInput.ResetText();
            textBoxDeliveryWorkerWageInput.ResetText();

            labelInvalidStockAmount.ForeColor = Color.WhiteSmoke;
            labelInvalidItemPrices.ForeColor = Color.WhiteSmoke;
            labelInvalidAdvertisementInvestment.ForeColor = Color.WhiteSmoke;
            labelInvalidSecurityInvestment.ForeColor = Color.WhiteSmoke;
            labelInvalidAmountOfWorkers.ForeColor = Color.WhiteSmoke;
            labelInvalidWorkerWage.ForeColor = Color.WhiteSmoke;
            labelInvalidAmountOfDeliveryWorkers.ForeColor = Color.WhiteSmoke;
            labelInvalidDeliveryWorkerWage.ForeColor = Color.WhiteSmoke;
            labelInvalidStockShop.ForeColor = Color.WhiteSmoke;
            labelInvalidUserSupplier.ForeColor = Color.WhiteSmoke;
            labelInvalidFunds.ForeColor = Color.WhiteSmoke;
            labelOverspent.ForeColor = Color.WhiteSmoke;

        }

        private void labelCleanlinessInvestment_Click(object sender, EventArgs e)
        {

        }
    }
}
