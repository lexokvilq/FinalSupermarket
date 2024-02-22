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
    public partial class MainGameScreenInput : Form
    {
        //this is the supplier that the current player chose
        private static string userSupplier;

        //this is the stock that the current player has chosen, stored in a list
        private static string[] stockShop = new string[Program.LengthOfStockRange];

        //this is the amount of stock the current player chose
        private static int stockAmount;

        //this is the price of the items the current player chose
        private static double itemPrices;

        //this is the amount spent on advertisements, that the current player chose
        private static double advertisementInvestment;

        //this is the amount spent on security by the current player
        private static double securityInvestment;

        //amount of workers for the current player
        private static int amountOfWorkers;

        //wage of worker for the current player
        private static double workerWage;

        //amount of delivery workers the current player has chosen
        private static int onlineAmountOfWorkers;

        //wage of the delivery workers that the current player has chosen
        private static double onlineWorkerWage;

        //valid is used as a check to see if the user has inputed valid values
        private static bool valid;

        //this is an array of Supermarket objects, which represents every player's supermarket
        //which is why this array is set to the size of the number of players 
        private static Supermarket[] supermarkets = new Supermarket[Program.NumOfPlayers];

        //an Area object is called, area
        private static Area area = new Area(Program.UserArea);

        //a Supplier object is called, supplier
        private static Supplier supplier;

        //This is an array which contains the potential number of customers for each of the supermarkets which is why the length of the array is set
        //to the number of players in the game
        //The potential number of regular customers is the number of customers that a supermarekt could get in an area
        //if they had an infinite stock amount
        private static int[] potentialNumberOfRegularCustomers = new int[Program.NumOfPlayers];

        //this is a list contatining all the potential number of online customers for each of the supermarkets
        //this array works in the same way as the potentialNumberOfRegularCustomers, but holds the data of the online number of customers instead
        private static int[] potentialNumberOfOnlineCustomers = new int[Program.NumOfPlayers];

        //this is a list contatining all the customer multipliers for all the supermarkets, shown by the size of the list to be the number of players
        //a customer multiplier represents the percentage of customers that a supermaret will get in the customer population 
        private static double[] customerMultipliers = new double[Program.NumOfPlayers];
        
        //this list contains all the online customer multipliers for all the supemrarkets, shown by the size of the array being the number of players
        private static double[] onlineCustomerMultipliers = new double[Program.NumOfPlayers];

        //count is used as an index to see what supermarket is currently being looked at in the arrays and
        //is used in other parts of the program to check if all the supermarkets have been seen so that the program can move into the next stage
        private static int count;

        //Constructor
        public MainGameScreenInput()
        {
            InitializeComponent();

            //set count to 0, the first index
            count = 0;

            //initialise supplier
            supplier = new Supplier();

            //check if the user has loaded a file or not
            if (Program.UserLoadedFile == true)
            {
                //the user has loaded a file

                //this is a for loop that will go through all the players, seen by i < Program.NumOfPlayers
                //the for loop goes through all the supermarekts in the list
                for (int i = 0; i < Program.NumOfPlayers; i++)
                {
                    //initialise supermarket with its constructor
                    supermarkets[i] = new Supermarket();

                    //set all the supermarkets old item prices to the last value in the HistoryItemPrices
                    supermarkets[i].setValueToOldItemPrices(Program.HistoryItemPrices[i, Program.WeekNumber - 1]);
                    //set all the supermarlets  previous funds to the last value in the HistoryCurrentFunds
                    supermarkets[i].setValueToPrevFunds(Program.HistoryCurrentFunds[i, Program.WeekNumber - 1]);

                    //need to also set the newer version of the worker wages to 0 because the first time through the
                    //old variables will have no variable to be assigned too.

                    //set all the supermarkets current funds 
                    supermarkets[i].setValueToCurrentFunds(Program.CurrentFundsForSaveFile[i]);
                    
                    //if the user chose a rural area then all the security values can be blank
                    if (Program.UserArea == "Rural")
                    {
                        //make the security investment invisible because there is no shoplifting in rural areas
                        labelSecurityInvestment.ForeColor = Color.WhiteSmoke;
                        textBoxSecurityInvestmentInput.BackColor = Color.WhiteSmoke;
                        textBoxSecurityInvestmentInput.BorderStyle = BorderStyle.None;
                    }

                    //set all the textboxes to the previous values
                    textBoxItemPricesInput.Text = Convert.ToString(Program.HistoryItemPrices[count, Program.WeekNumber - 1]);
                    textBoxAmountOfWorkersInput.Text = Convert.ToString(Program.HistoryAmountOfWorkers[count, Program.WeekNumber - 1]);
                    textBoxAmountOfDeliveryWorkersInput.Text = Convert.ToString(Program.HistoryOnlineAmountOfWorkers[count, Program.WeekNumber - 1]);
                    textBoxWorkerWageInput.Text = Convert.ToString(Program.HistoryWorkerWage[count, Program.WeekNumber - 1]);
                    textBoxDeliveryWorkerWageInput.Text = Convert.ToString(Program.HistoryOnlineWorkerWage[count, Program.WeekNumber - 1]);
                    textBoxStockAmountInput.Text = Convert.ToString(Program.PreviousStockAmounts[count]);
                    //the rural area has no security values
                    if (Program.UserArea != "Rural")
                    {
                        textBoxSecurityInvestmentInput.Text = Convert.ToString(Program.PreviousSecurityInvestments[count]);

                    }
                    textBoxAdvertisementInvestmentInput.Text = Convert.ToString(Program.PreviousAdInvestment[count]);
                }
            }

            //if the user did not load a file, so is starting a new game
            else if(Program.UserLoadedFile == false)
            {
                //This for loop will go through all the player's supermarekts in the list of supermarkets
                for (int i = 0; i < Program.NumOfPlayers; i++)
                {
                    //initialise the supermarekt object
                    supermarkets[i] = new Supermarket();

                    //set up all the old prices as deafult 0 
                    supermarkets[i].setValueToOldItemPrices(0);
                    supermarkets[i].setValueToPrevFunds(0);

                   //set the current funds to the right value, depending on the area the user chose and the number of players in the game
                    supermarkets[i].setCurrentFunds(Program.NumOfPlayers, Program.UserArea);

                    //if the player chose a rural area then there are no security values
                    if (Program.UserArea == "Rural")
                    {
                        //make the security investment invisible because there is no shoplifting in rural areas
                        labelSecurityInvestment.ForeColor = Color.WhiteSmoke;
                        textBoxSecurityInvestmentInput.BackColor = Color.WhiteSmoke;
                        textBoxSecurityInvestmentInput.BorderStyle = BorderStyle.None;
                    }
                }

                //initialising all the history variables
                Program.initHistoryVariables();

                //initialise all the previous variables
                Program.initPreviousVariables();

                //Set up all the default variables
                Program.setValuesToDefaultValues();
                textBoxStockAmountInput.Text = Convert.ToString(Program.DefaultStockAmount);
                textBoxAdvertisementInvestmentInput.Text = Convert.ToString(Program.DefaultAdvertisementInvestment);
                //no security values for the rural area
                if (Program.UserArea != "Rural")
                {
                    textBoxSecurityInvestmentInput.Text = Convert.ToString(Program.DefaultSecurityInvestment);
                }
                textBoxAmountOfWorkersInput.Text = Convert.ToString(Program.DefaultAmountOfWorkers);
                //doesn't matter which supermarket is chosen from the list
                textBoxWorkerWageInput.Text = Convert.ToString(supermarkets[count].WorkerWageAverageConstant);
                //doesn't matter which supermarket is chosen from the list
                textBoxAmountOfDeliveryWorkersInput.Text = Convert.ToString(Program.DefaultAmountOfOnlineWorkers);
                textBoxDeliveryWorkerWageInput.Text = Convert.ToString(supermarkets[count].OnlineWorkerWageAverageConstant);
            }



            //set up the number of weeks passed
            labelNumberOfWeeksPassedText.Text = Convert.ToString(Program.WeekNumber);

            //set up the number of weeks left
            labelNumberOfWeeksLeftText.Text = Convert.ToString(Program.calcNumOfWeeksLeft());

            //set up the current funds
            labelCurrentFundsText.Text = "£"+Convert.ToString(supermarkets[count].CurrentFunds);

            //set the last week label to be invisible 
            labelLastWeek.ForeColor = Color.WhiteSmoke;

            //initialise the current funds for save file to the right lenght
            Program.initCurrentFundsForSaveFile();

            //Check if there is only one week left
            if (Program.calcNumOfWeeksLeft() == 1)
            {
                //If it is the last week, this will be the last turn for all the users
                labelLastWeek.ForeColor = Color.Red;
            }
        }

        private void mainGameScreenInput_Load(object sender, EventArgs e)
        {

        }

        private void textBoxStockAmountInput_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonSubmitChanges_Click(object sender, EventArgs e)
        {
            //set the old item prices and previous funds of the current supermarket to their appropriate value
            supermarkets[count].setValueToOldItemPrices(supermarkets[count].ItemPrices);
            supermarkets[count].setValueToPrevFunds(supermarkets[count].CurrentFunds); 
            
            //This label is showing how many weeks have passed
            labelNumberOfWeeksPassedText.Text = Convert.ToString(Program.WeekNumber);
            //This label shows how many weeks are left
            labelNumberOfWeeksLeftText.Text = Convert.ToString(Program.calcNumOfWeeksLeft());
            
            //Set the invalid funds label to be invisible, there is no error yet
            labelInvalidFunds.ForeColor = Color.WhiteSmoke;

            //check if there is still supermarkets to look at
            //count represents the index of the supemarket we are looking at, (count starts at 0) so if count = the number of players
            //that means that there are no more supermarkets to look at, as the players have finished inputting values
            if (count < Program.NumOfPlayers)
            {
                //assume that the input is valid first
                valid = true;

                //The stock amount needs to be a positive integer
                //First checks if the value is a string or if it a double or if it is = 0
                //if it is any of these values then the input is not valid
                //note that no check is needed to see if the value is negative because
                //if there is a negative sign then the value is counted as a string
                if (Program.checkIfString(Convert.ToString(textBoxStockAmountInput.Text)) == true
                     || Program.checkIfInteger(Convert.ToString(textBoxStockAmountInput.Text)) == false
                     || Program.checkIfZero(Convert.ToString(textBoxStockAmountInput.Text)) == true)
                {
                    //failed the checks

                    //set valid to false
                    valid = false;
                    //display an error message to the user
                    labelInvalidStockAmount.ForeColor = Color.Red;
                }

                //checks if the valid is true, if it is not and there was an error elsewhere, so the stock amount can't have a value set to it
                else
                {
                    //the input has passed all the checks

                    //the stock amount can be set to its value
                    stockAmount = Convert.ToInt32(textBoxStockAmountInput.Text);
                }

                //The item prices has to be a positive integer or double
                //Checks if the textbox holds a value that is a string, or is 0
                if (Program.checkIfString(textBoxItemPricesInput.Text) == true ||
                    Program.checkIfZero(textBoxItemPricesInput.Text) == true)
                {
                    //valid is set to false
                    valid = false;
                    //error message is displayed
                    labelInvalidItemPrices.ForeColor = Color.Red;
                }
                
                //this check in the else statement means that if the user enters an invalid value somewhere else in the code the variables don'ts
                //have values set to them
                else
                {
                    //item prices have their value set to them
                    itemPrices = Convert.ToDouble(textBoxItemPricesInput.Text);
                }

                //The advertisement investment must be a positive double
                //Check if the value is a string, then if the value is 0 
                if (Program.checkIfString(textBoxAdvertisementInvestmentInput.Text) == true ||
                    Program.checkIfZero(textBoxAdvertisementInvestmentInput.Text) == true)
                {
                    //valid is set to false
                    valid = false;

                    //error message is displayed
                    labelInvalidAdvertisementInvestment.ForeColor = Color.Red;
                }

                //the input is valid
                else 
                {
                    //the value gets set to advertisement investment
                    advertisementInvestment = Convert.ToDouble(textBoxAdvertisementInvestmentInput.Text);
                }

                //The rural area has no security variables, so before validation of the text box starts
                //the program makes sure that it is only validating the input of a suburb or urban area
                if (Program.UserArea != "Rural")
                {
                    //security investment must be a positive double
                    //check if the value is a string, then check if the value is 0
                    if (Program.checkIfString(textBoxSecurityInvestmentInput.Text) == true ||
                    Program.checkIfZero(textBoxSecurityInvestmentInput.Text) == true)
                    {
                        //set the valid to false
                        valid = false;

                        //display an error message
                        labelInvalidSecurityInvestment.ForeColor = Color.Red;
                    }
                    else
                    {
                        //the value passed the validation and can be set to a variable
                        securityInvestment = Convert.ToDouble(textBoxSecurityInvestmentInput.Text);
                    }
                }
             
                //amount of workers needs to be a positive integer
                //check if the value is a string then check if the value is a double then check if the value is 0
                if (Program.checkIfString(textBoxAmountOfWorkersInput.Text) == true ||
                    Program.checkIfInteger(textBoxAmountOfWorkersInput.Text) == false ||
                    Program.checkIfZero(textBoxAmountOfWorkersInput.Text) == true)
                {
                    //failed the validation, valid is false
                    valid = false;
                    //error message displayed
                    labelInvalidAmountOfWorkers.ForeColor = Color.Red;
                }
                
                //if the value has passed all the validation
                else 
                {
                    //the value can be set to the variable
                    amountOfWorkers = Convert.ToInt32(textBoxAmountOfWorkersInput.Text);
                }

                //worker wage needs to be a positive double
                //check if worker wage is a string, then if it is 0
                if (Program.checkIfString(textBoxWorkerWageInput.Text) == true ||
                    Program.checkIfZero(textBoxWorkerWageInput.Text) == true)
                {
                    //worker wage is an invalid value
                    valid = false;
                    //display an error message
                    labelInvalidWorkerWage.ForeColor = Color.Red;
                }
                else
                {
                    //the value has passed the validation and can be set to workerWage
                    workerWage = Convert.ToDouble(textBoxWorkerWageInput.Text);
                }

                //the amount of delivery workers needs to be a positve integer
                //check if the value is a string, then check if it is an integer, then check if the value is 0
                if (Program.checkIfString(textBoxAmountOfDeliveryWorkersInput.Text) == true ||
                    Program.checkIfInteger(textBoxAmountOfDeliveryWorkersInput.Text) == false ||
                    Program.checkIfZero(textBoxAmountOfDeliveryWorkersInput.Text) == true)
                {
                    //amount of delivery workers is an invalid value
                    valid = false;
                    //dsiplay an error message
                    labelInvalidAmountOfDeliveryWorkers.ForeColor = Color.Red;
                }
                else 
                {
                    //the amount of delivery workers value has passed all validation and can be set to its variable onlineAmountOfWorkers
                    onlineAmountOfWorkers = Convert.ToInt32(textBoxAmountOfDeliveryWorkersInput.Text);
                }

                //the delivery worker wage must be a positive double or integer
                if (Program.checkIfString(textBoxDeliveryWorkerWageInput.Text) == true ||
                    Program.checkIfZero(textBoxDeliveryWorkerWageInput.Text) == true)
                {
                    //delivery worker wage is not a valid value
                    valid = false;
                    //error message displayed
                    labelInvalidDeliveryWorkerWage.ForeColor = Color.Red;
                }
                else
                {
                    //delivery worker wage passed all the validation and can be set to its value online worker wage
                    onlineWorkerWage = Convert.ToDouble(textBoxDeliveryWorkerWageInput.Text);
                }
               
                //need to check if the user supplier is empty
                if (userSupplier == "Excellent" || userSupplier == "Great" || userSupplier == "Average" || userSupplier == "Bad" || userSupplier == "Poor")
                {
                    //userSupplier was valid
                }
                else
                {
                    //error message displayed
                    labelInvalidUserSupplier.ForeColor = Color.Red;
                    //valid is false, hasn't passed the validation
                    valid = false;
                }

                //check if the stock range is empty
                if (stockShop[0] == "Vegetables" || stockShop[1] == "Meat" || stockShop[2] == "Snack"
                || stockShop[3] == "Household")
                {
                    //stock shop was valid
                }
                else
                {
                    //did not pass validation
                    valid = false;
                    //display error message
                    labelInvalidStockShop.ForeColor = Color.Red;
                }
                
                


                //if all the user's inputs have passed the validation
                if (valid == true)
                {
                    //this function sets all the variables in MainGameScreenInput (which the user has input) to their respective
                    //supermarket vairables
                    setVariablesToSupermarkets();

                    //set all the previous values to their values
                    Program.setValuesToPreviousVariables(stockAmount, securityInvestment, advertisementInvestment, count);
                    
                    //This function calls all the methods in Supermarket needed to work out the customer multiplier
                    //for the current supermarket
                    callAllSupermarketMethods();

                    //check if the user has enough funds to do what they want to do
                    if (supermarkets[count].checkCurrentFundsNegative() == true)
                    {
                        //The user doesn't have enough funds for their changes
                        //set valid to false
                        valid = false;
                        //display error message to user
                        labelInvalidFunds.ForeColor = Color.Red;
                        //tell the user how much they have overspent by
                        string overspentOutput = Convert.ToString(Math.Round(supermarkets[count].Overspent, 2));
                        labelOverspent.Text = "Overspent by £" + overspentOutput;
                        labelOverspent.ForeColor = Color.Red;
                    }
                    //the user has enough funds
                    else
                    {
                        //Count incremented, the supermarket has passed all the checks
                        count++;

                        //Check if there are any more players to look at
                        if (count < Program.NumOfPlayers)
                        {
                            //set the label to display the number of the current player
                            labelPlayerNum.Text = "Player " + Convert.ToString(count + 1);
                            //Display the label which for the current funds of the current player's supermarket
                            labelCurrentFundsText.Text = "£"+Convert.ToString(supermarkets[count].CurrentFunds);
                        }

                        //reset all the text boxes and buttons to their original state
                        buttonReset.PerformClick();

                        //display all the previous variable (from the last week) in the text box
                        //need to check if it is not the first week (there are no previous values in the first week)
                        //also check if not all the player's supermarkets have been seen, check the count index
                        if (Program.WeekNumber > 0 & count < Program.NumOfPlayers)
                        { 
                            textBoxItemPricesInput.Text = Convert.ToString(Program.HistoryItemPrices[count, Program.WeekNumber-1]);
                            textBoxAmountOfWorkersInput.Text = Convert.ToString(Program.HistoryAmountOfWorkers[count, Program.WeekNumber - 1]);
                            textBoxAmountOfDeliveryWorkersInput.Text = Convert.ToString(Program.HistoryOnlineAmountOfWorkers[count, Program.WeekNumber - 1]);
                            textBoxWorkerWageInput.Text = Convert.ToString(Program.HistoryWorkerWage[count, Program.WeekNumber - 1]);
                            textBoxDeliveryWorkerWageInput.Text = Convert.ToString(Program.HistoryOnlineWorkerWage[count, Program.WeekNumber - 1]);
                            textBoxStockAmountInput.Text = Convert.ToString(Program.PreviousStockAmounts[count]);
                            textBoxAdvertisementInvestmentInput.Text = Convert.ToString(Program.PreviousAdInvestment[count]);
                            //the rural area has no security values, so need this check to make sure no value is added to the rural text box
                            if (Program.UserArea != "Rural")
                            {
                                textBoxSecurityInvestmentInput.Text = Convert.ToString(Program.PreviousSecurityInvestments[count]);
                            }
                        }
                        //if it the week number is 0 then the deafult values can be added to the textBoxes
                        else
                        {
                            //Set up all the default variables
                            Program.setValuesToDefaultValues();
                            textBoxStockAmountInput.Text = Convert.ToString(Program.DefaultStockAmount);
                            textBoxAdvertisementInvestmentInput.Text = Convert.ToString(Program.DefaultAdvertisementInvestment);
                            //no security values for the rural area
                            if (Program.UserArea != "Rural")
                            {
                                textBoxSecurityInvestmentInput.Text = Convert.ToString(Program.DefaultSecurityInvestment);
                            }
                            textBoxAmountOfWorkersInput.Text = Convert.ToString(Program.DefaultAmountOfWorkers);
                            //count already incremented by 1, so needs to be decremented in case of the final player
                            textBoxWorkerWageInput.Text = Convert.ToString(supermarkets[count-1].WorkerWageAverageConstant);
                            //count already incremented by 1, so needs to be decremented in case of the final player
                            textBoxAmountOfDeliveryWorkersInput.Text = Convert.ToString(Program.DefaultAmountOfOnlineWorkers);
                            textBoxDeliveryWorkerWageInput.Text = Convert.ToString(supermarkets[count-1].OnlineWorkerWageAverageConstant);
                        }
                    }
                }
            }

            //this checks if all the players have been seen
            //by checking the count index
            if(count == Program.NumOfPlayers)
            {
                //Go through all the supermarekts and add every supermarkets customer multiplier to a list of customer multipliers
                for (int i = 0; i < supermarkets.Length; i++)
                {
                    //add the customer multiplier of the current supermarekt to the list
                    customerMultipliers[i] = supermarkets[i].CustomerMultiplier;
                    //add the online customer multiplier of the current supermarket to the list
                    onlineCustomerMultipliers[i] = supermarkets[i].OnlineCustomerMultiplier;
                }

                //The potential number of customers are important to have as they show to the user how many customers they could've got
                //if they had enough stock for all their supermarket's customers
                //if the potential number of regular customers is greatere than the actual number of customers this means that the stock amount
                //is the limiting factor for the supermarket.

                //calculate the potential number of regular customers, using the list of all the customer multipliers and the customer population in the area
                potentialNumberOfRegularCustomers = Program.calcPotentialNumOfCustomers(area.CustomerPopulation, customerMultipliers);
                //calculate the potential number of online customer, using the list of all the online customer multipliers and the customer population in the area
                potentialNumberOfOnlineCustomers = Program.calcPotentialNumOfCustomers(area.OnlineCustomerPopulation, onlineCustomerMultipliers);
                
               //using a for loop to go through all the supermarekts 
                for (int i = 0; i < supermarkets.Length; i++)
                {
                    //calculate the actual number of customers that each supermarket gets
                    //this uses the potential number of regular and online customers, and sees if the supermarket has
                    //enough stock amount to supply for all these customers
                    supermarkets[i].calcActualNumOfCustomers(potentialNumberOfRegularCustomers[i], potentialNumberOfOnlineCustomers[i]);

                    //Work out the supplier cost for each of the supermarkets
                    supermarkets[i].calcSupplierCost(supplier.SuppliersPrices, supplier.SuppliersQuality);
                    
                    //after the actual number of customers has been found out, all the supermarket's current funds can be calculated
                    supermarkets[i].calcCurrentFunds();
                    
                    //set the current funds of all the supermarkets to this variable
                    //which will be used if the user saves their game
                    Program.setCurrentFundsForSaveFile(supermarkets[i].CurrentFunds, i);
                    
                    //once the currenet funds for each of the supermarkets have been calculated
                    //the net profit can be found by finding the difference between the previous and current funds
                    supermarkets[i].calcNetProfit();
                }

                //Set the current supermarket's variables to the history values for every supermarket
                for (int i = 0; i < Program.NumOfPlayers; i++)
                {
                    Program.setHistoryVariables(Program.HistoryNetProfit, i, supermarkets[i].NetProfit);
                    Program.setHistoryVariables(Program.HistoryAmountOfWorkers, i, supermarkets[i].AmountOfWorkers);
                    Program.setHistoryVariables(Program.HistoryCurrentFunds, i, supermarkets[i].CurrentFunds);
                    Program.setHistoryVariables(Program.HistoryItemPrices, i, supermarkets[i].ItemPrices);
                    Program.setHistoryVariables(Program.HistoryPotentialNumberOfRegularCustomers, i, potentialNumberOfRegularCustomers[i]);
                    Program.setHistoryVariables(Program.HistoryPotentialNumberOfOnlineCustomers, i, potentialNumberOfOnlineCustomers[i]);
                    Program.setHistoryVariables(Program.HistoryOnlineAmountOfWorkers, i, supermarkets[i].OnlineAmountOfWorkers);
                    Program.setHistoryVariables(Program.HistoryOnlineWorkerWage, i, supermarkets[i].OnlineWorkerWage);
                    Program.setHistoryVariables(Program.HistoryWorkerWage, i, supermarkets[i].WorkerWage);
                    Program.setHistoryVariables(Program.HistoryActualNumberOfCustomers, i, supermarkets[i].ActualNumberOfCustommers);
                }

                //once all the supermarket turns have finished the number of weeks is incremented by 1
                Program.incrementWeekNumber();
                
                //display the number of weeks that have passed to the user
                labelNumberOfWeeksPassedText.Text = Convert.ToString(Program.WeekNumber);

                //display the number of weeks that are left in the game
                labelNumberOfWeeksLeftText.Text = Convert.ToString(Program.calcNumOfWeeksLeft());

                //reset count back to 0, so the turn resets back to the first player 
                count = 0;

                //reset the player number label to the first player
                labelPlayerNum.Text = "Player " + Convert.ToString(count + 1);

                //display the current funds of the first player
                labelCurrentFundsText.Text = "£" + Convert.ToString(supermarkets[count].CurrentFunds);

                //display the graphing screens
                MainGameScreenGraph mgsg = new MainGameScreenGraph();
                mgsg.Show();

                //Check if there is only one week left
                if (Program.calcNumOfWeeksLeft() == 1)
                {
                    //If it is the last week, this will be the last turn for all the users
                    labelLastWeek.ForeColor = Color.Red;
                }

                //display the previous values for all the variables in all their respective text boxes
                textBoxItemPricesInput.Text = Convert.ToString(Program.HistoryItemPrices[count, Program.WeekNumber - 1]);
                textBoxAmountOfWorkersInput.Text = Convert.ToString(Program.HistoryAmountOfWorkers[count, Program.WeekNumber - 1]);
                textBoxAmountOfDeliveryWorkersInput.Text = Convert.ToString(Program.HistoryOnlineAmountOfWorkers[count, Program.WeekNumber - 1]);
                textBoxWorkerWageInput.Text = Convert.ToString(Program.HistoryWorkerWage[count, Program.WeekNumber - 1]);
                textBoxDeliveryWorkerWageInput.Text = Convert.ToString(Program.HistoryOnlineWorkerWage[count, Program.WeekNumber - 1]);
                textBoxStockAmountInput.Text = Convert.ToString(Program.PreviousStockAmounts[count]);
                textBoxAdvertisementInvestmentInput.Text = Convert.ToString(Program.PreviousAdInvestment[count]);
                //if the user area is rural, then there is no security investment textbox, so only if suburb or urban area is chosen
                //is the previous value displayed for the security investment textbox
                if (Program.UserArea != "Rural")
                {
                    textBoxSecurityInvestmentInput.Text = Convert.ToString(Program.PreviousSecurityInvestments[count]);

                }

                //check how many weeks are left, if there are no weeks left close this window
                if (Program.calcNumOfWeeksLeft() == 0)
                {
                    this.Close();
                }
            }
        }

        //This function sets all the variables that the user has inputed for their supermarket
        //to their respective supermarket variable, the count is used to check which supermarket in the list is being looked at currently
        public static void setVariablesToSupermarkets()
        {
            //Stock amount
            supermarkets[count].setValueToStockAmount(stockAmount);
            //User supplier
            supermarkets[count].setValueToUserSupplier(userSupplier);
            //Item prices
            supermarkets[count].setValueToItemPrices(itemPrices);
            //Advertisement Investment
            supermarkets[count].setValueToAdInvest(advertisementInvestment);
            //Security investment
            supermarkets[count].setValueToSecInvest(securityInvestment);
            //Amount of workers
            supermarkets[count].setValueToAmountOfWorkers(amountOfWorkers);
            //Worker wage
            supermarkets[count].setValueToWorkerWage(workerWage);
            //Online amount of workers, amount of delivery workers
            supermarkets[count].setValueToOnilneAmountOfWorkers(onlineAmountOfWorkers);
            //Online worker wage, the wage of the delivery drivers
            supermarkets[count].setValueToOnlineWorkerWage(onlineWorkerWage);
            //The stock that the shop has bought
            supermarkets[count].setValuesToStockShop(stockShop);
            //The available stock that the shop has 
            supermarkets[count].checkStockAvailable(supplier.StockRange);
        }

        //calls all the methods to work out the customer multipliers, and online customer multiplier
        public static void callAllSupermarketMethods()
        {
            supermarkets[count].calcAdvertisementMultiplier(area.AverageAreaAdvertisementInvestment);
            supermarkets[count].calcQualityMultiplier(supplier.SuppliersQuality, supplier.SuppliersQualityMultiplier);
            supermarkets[count].calcPercentageOfPayingCustomers(area.ShopLiftingRate, area.AverageSecurityInvestment);
            supermarkets[count].calcItemPricesMultiplier();
            supermarkets[count].calcAmountOfWorkersMultiplier(area.AverageAmountOfWorkers);
            supermarkets[count].calcOnlineAmountOfWorkersMultiplier(area.OnlineAverageAmountOfWorkers);
            supermarkets[count].calcWorkerWageMultiplier();
            supermarkets[count].calcOnlineWorkerWageMultiplier();
            supermarkets[count].stockAvailableChangeProfit();
            supermarkets[count].calcCustomerMultiplier();
            supermarkets[count].calcOnlineCustomerMultiplier();
            supermarkets[count].calcSupplierCost(supplier.SuppliersPrices, supplier.SuppliersQuality);
        }
        
        //The user chooses the excellent quality supplier
        private void buttonExcellent_Click(object sender, EventArgs e)
        {
            //user supplier is set to excellent
            userSupplier = "Excellent";
            //show that the excellent button is selected
            buttonExcellent.BackColor = Color.WhiteSmoke;
            //deselect all the other buttons
            buttonGreat.BackColor = Color.FromArgb(192, 192, 255);
            buttonAverage.BackColor = Color.FromArgb(192, 192, 255);
            buttonBad.BackColor = Color.FromArgb(192, 192, 255);
            buttonPoor.BackColor = Color.FromArgb(192, 192, 255);
        }

        //The user chooses the great quality supplier
        private void buttonGreat_Click(object sender, EventArgs e)
        {
            //The user supplier is set to great
            userSupplier = "Great";
            //show that the great button has been selected
            buttonGreat.BackColor = Color.WhiteSmoke;
            //un select all the other buttons
            buttonExcellent.BackColor = Color.FromArgb(192, 192, 255);
            buttonAverage.BackColor = Color.FromArgb(192, 192, 255);
            buttonBad.BackColor = Color.FromArgb(192, 192, 255);
            buttonPoor.BackColor = Color.FromArgb(192, 192, 255);
        }

        //The user has chosen the average quality supplier
        private void buttonAverage_Click(object sender, EventArgs e)
        {
            //the quality of the supplier is set to average
            userSupplier = "Average";
            buttonExcellent.BackColor = Color.FromArgb(192, 192, 255);
            buttonGreat.BackColor = Color.FromArgb(192, 192, 255);
            buttonAverage.BackColor = Color.WhiteSmoke;
            buttonBad.BackColor = Color.FromArgb(192, 192, 255);
            buttonPoor.BackColor = Color.FromArgb(192, 192, 255);
        }

        //The user has chosen the bad quality supplier
        private void buttonBad_Click(object sender, EventArgs e)
        {
            userSupplier = "Bad";
            buttonExcellent.BackColor = Color.FromArgb(192, 192, 255);
            buttonGreat.BackColor = Color.FromArgb(192, 192, 255);
            buttonAverage.BackColor = Color.FromArgb(192, 192, 255);
            buttonBad.BackColor = Color.WhiteSmoke;
            buttonPoor.BackColor = Color.FromArgb(192, 192, 255);
        }

        //The user has chosen the poor quality supplier
        private void buttonPoor_Click(object sender, EventArgs e)
        {
            userSupplier = "Poor";
            buttonExcellent.BackColor = Color.FromArgb(192, 192, 255);
            buttonGreat.BackColor = Color.FromArgb(192, 192, 255);
            buttonAverage.BackColor = Color.FromArgb(192, 192, 255);
            buttonBad.BackColor = Color.FromArgb(192, 192, 255);
            buttonPoor.BackColor = Color.WhiteSmoke;
        }

        //The user has chosen for vegetables to be included in the stock of their shop
        private void buttonVegetables_Click(object sender, EventArgs e)
        {
            //Vegetables is set to the stock shop list
            stockShop[0] = "Vegetables";
            //The vegetables button is selected
            buttonVegetables.BackColor = Color.WhiteSmoke;
        }

        //The user has chsoen for meat to be included in the stock of their shop
        private void buttonMeat_Click(object sender, EventArgs e)
        {
            //Meat is set to the stock shop list
            stockShop[1] = "Meat";
            //Meat button selected
            buttonMeat.BackColor = Color.WhiteSmoke;
        }

        //The user has chosen for snacks to be included in the stock of their shop
        private void buttonSnacks_Click(object sender, EventArgs e)
        {
            //Snacks is set to the stock shop list
            stockShop[2] = "Snack";
            //Snack button is selected
            buttonSnacks.BackColor = Color.WhiteSmoke;
        }

        //The user has chosen for household items to be included in the stock of their shop
        private void buttonHousehold_Click(object sender, EventArgs e)
        {
            //Houshold items is set to the stock shop list
            stockShop[3] = "Household";
            //The houshold button is selected
            buttonHousehold.BackColor = Color.WhiteSmoke;
        }

        //The user has pressed the reset button, all the text boxes and buttons will be reset to have no values
        private void buttonReset_Click(object sender, EventArgs e)
        {
            //Set the number of weeks that have passed to the right value
            labelNumberOfWeeksPassedText.Text = Convert.ToString(Program.WeekNumber);
            //Set the number of weeks left to the right value
            labelNumberOfWeeksLeftText.Text = Convert.ToString(Program.calcNumOfWeeksLeft());

            //reset all the different types of stock to be null values
            for (int i = 0; i < stockShop.Length; i++)
            {
                stockShop[i] = " ";
            }

            //reset the colors of all the stock shop, to be its deafult value
            buttonVegetables.BackColor = Color.FromArgb(192, 192, 255);
            buttonMeat.BackColor = Color.FromArgb(192, 192, 255);
            buttonSnacks.BackColor = Color.FromArgb(192, 192, 255);
            buttonHousehold.BackColor = Color.FromArgb(192, 192, 255);

            //reset the user Supplier to be null
            userSupplier = "";

            //reset the user supplier button to the deafult color
            buttonExcellent.BackColor = Color.FromArgb(192, 192, 255);
            buttonGreat.BackColor = Color.FromArgb(192, 192, 255);
            buttonAverage.BackColor = Color.FromArgb(192, 192, 255);
            buttonBad.BackColor = Color.FromArgb(192, 192, 255);
            buttonPoor.BackColor = Color.FromArgb(192, 192, 255);

            //All the text boxes text is reset
            textBoxStockAmountInput.ResetText();
            textBoxItemPricesInput.ResetText();
            textBoxAdvertisementInvestmentInput.ResetText();
            textBoxSecurityInvestmentInput.ResetText();
            textBoxAmountOfWorkersInput.ResetText();
            textBoxWorkerWageInput.ResetText();
            textBoxAmountOfDeliveryWorkersInput.ResetText();
            textBoxDeliveryWorkerWageInput.ResetText();

            //The invalid messages are all set to be invisible
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

        //This is never used
        private void labelCleanlinessInvestment_Click(object sender, EventArgs e)
        {
        }
    }
}
