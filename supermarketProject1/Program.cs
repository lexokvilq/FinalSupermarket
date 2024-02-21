using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace supermarketProject1
{
    static internal class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 

        //This is the area that the user chooses 
        private static string userArea;
        public static string UserArea
        {
            get { return userArea; }
        }

        //This is the number of the week that the game is currently on
        private static int weekNumber;
        public static int WeekNumber
        {
            get { return weekNumber; }
        }

        //This is the number of the last week in the game
        private static int endNumOfWeeks;

        //This is the number of players for the game
        private static int numOfPlayers;
        public static int NumOfPlayers
        {
            get { return numOfPlayers; }
        }

        //This is the length of the stock range, the number of different types of stock that the user can buy
        //this value will remain constant throughout the whole program
        private const int LenStockRange = 4;
        public static int LengthOfStockRange
        {
            get { return LenStockRange; }
        }

        //This index represents which player's supermarket is currently being looked at,
        //when the supermarkets variables are being graphed
        private static int supermarketIndex;
        public static int SupermarketIndex
        {
            get { return supermarketIndex; }
        }

        //This 2d array stores the history of the worker wage variable
        //In the first part of the array the player number and the second part of the array stores the value
        private static double[,] historyWorkerWage;
        public static double[,] HistoryWorkerWage
        {
            get { return historyWorkerWage; }
        }

        //This 2d array stores the history of the online worker wage variable
        //The first part of the array stores player number, second part stores value
        private static double[,] historyOnlineWorkerWage;
        public static double[,] HistoryOnlineWorkerWage
        {
            get { return historyOnlineWorkerWage; }
        }

        //This 2d array stores the history of the amount of workers, for all the players
        private static double[,] historyAmountOfWorkers;
        public static double[,] HistoryAmountOfWorkers
        {
            get { return historyAmountOfWorkers; }
        }

        //This 2d array stores the history of the online amount of workers, the amount of delivery workers, for all the players
        private static double[,] historyOnlineAmountOfWorkers;
        public static double[,] HistoryOnlineAmountOfWorkers
        {
            get { return historyOnlineAmountOfWorkers; }
        }

        //This 2d array stores the history of the item prices for all the players
        private static double[,] historyItemPrices;
        public static double[,] HistoryItemPrices
        {
            get { return historyItemPrices; }
        }

        //This 2d array stores the history of the potential number of customers for all the players
        private static double[,] historyPotentialNumberOfRegularCustomers;
        public static double[,] HistoryPotentialNumberOfRegularCustomers
        {
            get { return historyPotentialNumberOfRegularCustomers; }
        }

        //This 2d array stores the history of the potential number of online customers for all the players
        private static double[,] historyPotentialNumberOfOnlineCustomers;
        public static double[,] HistoryPotentialNumberOfOnlineCustomers
        {
            get { return historyPotentialNumberOfOnlineCustomers; }
        }

        //This 2d array stores the history of the net profit for all the players
        private static double[,] historyNetProfit;
        public static double[,] HistoryNetProfit
        {
            get { return historyNetProfit; }
        }

        //This 2d array stores the history of all the current funds for all the players
        private static double[,] historyCurrentFunds;
        public static double[,] HistoryCurrentFunds
        {
            get { return historyCurrentFunds; }
        }

        //This 2d array stores the actual number of customers for all the players 
        private static double[,] historyActualNumberOfCustomers;
        public static double[,] HistoryActualNumberOfCustomers
        {
            get { return historyActualNumberOfCustomers; }
        }

        //This variable has the name of the file that the user is loading into the game
        private static string userLoadingFileName;
        public static string UserLoadingFileName
        {
            get { return userLoadingFileName; }
        }

        //This array has the current funds for all the supermarkets
        //Which will be used to set the current funds for supermarkets when a game is loaded
        private static double[] currentFundsForSaveFile;
        public static double[] CurrentFundsForSaveFile
        {
            get { return currentFundsForSaveFile; }
        }

        //This is a check to see whether the user has loaded a file or not
        private static bool userLoadedFile;
        public static bool UserLoadedFile
        {
            get { return userLoadedFile; }
        }

        //This is a check to see whether the game has ended or not
        private static bool gameEnded;
        public static bool GameEnded
        {
            get { return gameEnded; }
        }

        //ADD ALL THE PREVIOUS VALUES TO THE DESIGN

        //This array has the previous stock amounts for all the supermarkets 
        private static int[] previousStockAmounts;
        public static int[] PreviousStockAmounts
        {
            get { return previousStockAmounts; }
        }

        //This array has the previous security investments for all the supermarkets
        private static double[] previousSecurityInvestments;
        public static double[] PreviousSecurityInvestments
        {
            get { return previousSecurityInvestments; }
        }

        //This array has the previous advertisement investments for all the supermarkets
        private static double[] previousAdInvestment;
        public static double[] PreviousAdInvestment
        {
            get { return previousAdInvestment; }
        }


        [STAThread]

        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //the game has started, it is the first week so weekNumber is 0
            weekNumber = 0;

            //reset the supermarket index to its deafult value, 0
            supermarketIndex = 0;

            //Set the user loading file to false as deafult
            userLoadedFile = false;

            //Set the game ended to false as deafult
            gameEnded = false;

            Application.Run(new IntroductionScreen());
        }

        //This function initialises all the history variables, by setting them all to the right length
        public static void initHistoryVariables()
        {
            historyAmountOfWorkers = new double[numOfPlayers, endNumOfWeeks];
            historyItemPrices = new double[numOfPlayers, endNumOfWeeks];
            historyNetProfit = new double[numOfPlayers, endNumOfWeeks];
            historyPotentialNumberOfRegularCustomers = new double[numOfPlayers, endNumOfWeeks];
            historyPotentialNumberOfOnlineCustomers = new double[numOfPlayers, endNumOfWeeks];
            historyOnlineAmountOfWorkers = new double[numOfPlayers, endNumOfWeeks];
            historyWorkerWage = new double[numOfPlayers, endNumOfWeeks];
            historyOnlineWorkerWage = new double[numOfPlayers, endNumOfWeeks];
            historyCurrentFunds = new double[numOfPlayers, endNumOfWeeks];
            historyActualNumberOfCustomers = new double[numOfPlayers, endNumOfWeeks];
        }

        //This function checks if a value is a string
        public static bool checkIfString(string value)
        {
            //Regex is set to count for decimal places
            Regex rg = new Regex("[.]");

            //count the number of decimal points in the value, if there is more than 1 decimal point, 
            //then the value is a string
            MatchCollection matchedDecimalPlaces = rg.Matches(value);

            //The value is a string if it contains letters or multiple decimal places or symbols
            //Regular expressions checks if the value contains anything other than digits 0-9 or a decimal place
            //and check if there are white space or multiple decimal places
            //Note that any negative integer is accepted as a string, because no negative values will be valid inputs in this program
            if (!Regex.IsMatch(value, "^[0-9.]*$")
                || string.IsNullOrWhiteSpace(value) == true
                || matchedDecimalPlaces.Count > 1)
            {
                //The value is a string
                return true;
            }
            else
            {
                //The value is an integer or a double
                return false;
            }
        }

        //This function checks if a value is an integer
        //Assumes that the input is not a string, so must be an integer or double
        //If the function returns true the value is an integer, if it returns false the value is a double
        public static bool checkIfInteger(string value)
        {
            //Check if the value doesn't contains a decimal place or not
            if (!Regex.IsMatch(value, "[.]"))
            {
                //The value is an integer
                return true;
            }
            //the value must contain a decimal place
            else
            {
                //The value is a double
                return false;
            }
        }

        //Check if the value is 0
        //It is assumed that the input is not a string, so is a double or integer
        public static bool checkIfZero(string value)
        {
            if (Convert.ToDouble(value) == 0)
            {
                //the value is 0
                return true;
            }
            else
            {
                //value is not 0
                return false;
            }
        }

        //This is the function used to load a file
        public static void loadFile(string file)
        {
            //A comma is stored at the end of every data item
            Boolean commaFound = false;

            //The array values contains will contain all the data items in the save file
            //The file.count counts the number of ',' in the file. A ',' is stored at the end of the file
            //this means that the number of commas in the file is equal to the number of data items in the file
            string[] values = new string[file.Count(c => c == ',')];

            //this count represents the index of the character in the file that is currently being looked at
            int count = 0;

            //This is the length of the data item 
            int lengthOfValue = 0;

            //This is the number of items in the list that have been searched and added to the values array
            int numOfItemsSearched = 0;

            //This for loop goes through the length of the entire save file
            for (int i = 0; i < file.Length; i++)
            {
                //reset the comma found to deafult value at the start of the loop
                commaFound = false;

                //While the comma has not been found
                while (commaFound == false)
                {
                    //check if the current value is a comma
                    if (file[count] == ',')
                    {
                        //the comma was found
                        commaFound = true;

                        //work out the length of the array by working out the differenece between the two indexex
                        //count representing the current comma and the i representing the start of the data item
                        lengthOfValue = count - i;

                        //Using an array of chars to store the data item as individual characters
                        char[] dataArray = new char[lengthOfValue];

                        //this for loop adds all the previous characters to the character array 
                        for (int j = 0; j < lengthOfValue; j++)
                        {
                            dataArray[j] = file[i + j];
                        }

                        //The data array is stored in the values list as a string
                        //The numOfItemsSearched shows the index in the array where the data item should be stored
                        values[numOfItemsSearched] = new string(dataArray);

                        //increment numOfItemsSearched, showing that the next data item is being searched
                        //and will be stored in the next location in the values array 
                        numOfItemsSearched++;

                        //setting i to bet the start of the next character
                        i = count;

                        //count is set to be one value after the start of the next character
                        count++;
                    }
                    else
                    {
                        //the comma was not found, so look at the next character in the file
                        count++;
                    }
                }
            }

            //the order that files will be stored is
            //numOfPlayers, weekNumber, endNumOfWeeks, userArea, currentFunds,
            //historyWorkerWage, historyOnlineWorkerWage, hisotryAmountOfWorkers
            //historyOnlineAmountOfWorkers, historyItemPrices, historyPotentialNumOfCustomers, historyPotentialOnlineNumOfCustomers
            //historyNetProfit, historyCurrentFunds, historyActualNumOfCustomers, previousAdInvest, previousStockAmount, previousSecurityInvestment

            //the number of players is the first value stored
            numOfPlayers = Convert.ToInt32(values[0]);
            //week number is the second value stored
            weekNumber = Convert.ToInt32(values[1]);
            //end number of weeks is the 3rd value stored
            endNumOfWeeks = Convert.ToInt32(values[2]);
            //The user area is the fourth value stored
            userArea = values[3];

            //This index is used to see what value in values that is being currently looked at
            //the index starts on 4 as values 0-3 will have already been seen
            int indexInValues = 4;

            //set the current funds for save file to the right length
            initCurrentFundsForSaveFile();

            //Storing the values for current funds
            //For loop goes while i < numOfPlayers, numOfPlayers is know already
            //because it was already set before
            for (int i = 0; i < numOfPlayers; i++)
            {
                //Storing the value
                currentFundsForSaveFile[i] = Convert.ToDouble(values[4 + i]);
                //incrementing the index
                indexInValues++;
            }

            //need to initialise all the history values so that they can be assigned values
            initHistoryVariables();

            //History variables are a 2d array, so need a nested for loop
            //first for loop cycles through the players
            for (int i = 0; i < numOfPlayers; i++)
            {
                //second for loop goes through all the weeks that have passed
                for (int j = 0; j < weekNumber; j++)
                {
                    //set the current indexed value to the history of worker wage
                    historyWorkerWage[i, j] = Convert.ToDouble(values[indexInValues]);
                    //Increment the index by 1
                    indexInValues++;
                }
            }

            //This nested for loop stores the history online worker wage from values
            for (int i = 0; i < numOfPlayers; i++)
            {
                for (int j = 0; j < weekNumber; j++)
                {
                    historyOnlineWorkerWage[i, j] = Convert.ToDouble(values[indexInValues]);
                    indexInValues++;
                }
            }

            //This nested for loop stores the history of amount of workers
            for (int i = 0; i < numOfPlayers; i++)
            {
                for (int j = 0; j < weekNumber; j++)
                {
                    historyAmountOfWorkers[i, j] = Convert.ToInt32(values[indexInValues]);
                    indexInValues++;
                }
            }

            //This nested for loop stores the history of online amount of workers
            for (int i = 0; i < numOfPlayers; i++)
            {
                for (int j = 0; j < weekNumber; j++)
                {
                    historyOnlineAmountOfWorkers[i, j] = Convert.ToInt32(values[indexInValues]);
                    indexInValues++;
                }
            }

            //This nested for loop stores the history of item prices
            for (int i = 0; i < numOfPlayers; i++)
            {
                for (int j = 0; j < weekNumber; j++)
                {
                    historyItemPrices[i, j] = Convert.ToDouble(values[indexInValues]);
                    indexInValues++;
                }
            }

            //This for loop stores the history of the potential number of regular customers 
            for (int i = 0; i < numOfPlayers; i++)
            {
                for (int j = 0; j < weekNumber; j++)
                {
                    historyPotentialNumberOfRegularCustomers[i, j] = Convert.ToInt32(values[indexInValues]);
                    indexInValues++;
                }
            }

            //This for looop stores the history of the potential of online customers 
            for (int i = 0; i < numOfPlayers; i++)
            {
                for (int j = 0; j < weekNumber; j++)
                {
                    historyPotentialNumberOfOnlineCustomers[i, j] = Convert.ToInt32(values[indexInValues]);
                    indexInValues++;
                }
            }

            //This for loop stores the history of net profit
            for (int i = 0; i < numOfPlayers; i++)
            {
                for (int j = 0; j < weekNumber; j++)
                {
                    historyNetProfit[i, j] = Convert.ToDouble(values[indexInValues]);
                    indexInValues++;
                }
            }

            //This for loop stores the history of current funds
            for (int i = 0; i < numOfPlayers; i++)
            {
                for (int j = 0; j < weekNumber; j++)
                {
                    historyCurrentFunds[i, j] = Convert.ToDouble(values[indexInValues]);
                    indexInValues++;
                }
            }

            //This for loop stores the history of actual number of customers
            for (int i = 0; i < numOfPlayers; i++)
            {
                for (int j = 0; j < weekNumber; j++)
                {
                    historyActualNumberOfCustomers[i, j] = Convert.ToDouble(values[indexInValues]);
                    indexInValues++;
                }
            }

            //The previous variables (previousAd, previousStockAmount, previousSecInvest) need to all be set to the right
            //size before values can start to be assigned to them
            initPreviousVariables();

            //This for loop stores the previous advertisement investment from values
            for (int i = 0; i < numOfPlayers; i++)
            {
                previousAdInvestment[i] = Convert.ToDouble(values[indexInValues]);
                indexInValues++;
            }

            //This for loop stores the previous stock amounts from values
            for (int i = 0; i < numOfPlayers; i++)
            {
                previousStockAmounts[i] = Convert.ToInt32(values[indexInValues]);
                indexInValues++;
            }

            //This for loop stores the previous security investment from values
            for (int i = 0; i < numOfPlayers; i++)
            {
                previousSecurityInvestments[i] = Convert.ToDouble(values[indexInValues]);
                indexInValues++;
            }
        }

        //This is the function that is uesd to save a file
        public static bool saveFile(string fileName)
        {
            //get the file name (from SaveGameScreen) and add .txt to the end of it
            fileName = fileName + ".txt";

            //This is a check used to see if the save file has been saved successfully
            bool passed = true;

            //first need to store 
            //numOfPlayers, weekNumber, endNumOfWeeks, userArea, currentFunds,
            //historyWorkerWage, historyOnlineWorkerWage, hisotryAmountOfWorkers
            //historyOnlineAmountOfWorkers, historyItemPrices, historyPotentialNumOfCustomers, historyPotentialOnlineNumOfCustomers
            //historyActualNumberOfCustomers, historyNetProfit, historyCurrentFunds, previousAdInvestment, previousStockInvestment, previousSecurityInvestment

            //this string represents the save file
            string file;

            //first add the number of players to the save file
            file = Convert.ToString(numOfPlayers);
            //store a comma between every data item
            file = file + ",";
            //store the week number
            file = file + Convert.ToString(weekNumber);
            file = file + ",";
            //store the end number of weeks
            file = file + Convert.ToString(endNumOfWeeks);
            file = file + ",";
            //store the user area
            file = file + userArea;
            file = file + ",";

            //This for loop goes through all the players to store all their current funds
            for (int i = 0; i < numOfPlayers; i++)
            {
                //add the players current funds to the save file
                file = file + Convert.ToString(currentFundsForSaveFile[i]);
                //add a comma between every data item
                file = file + ",";
            }

            //This uses a nested for loop to store the history of the worker wage
            for (int i = 0; i < numOfPlayers; i++)
            {
                for (int j = 0; j < weekNumber; j++)
                {
                    file = file + Convert.ToString(historyWorkerWage[i, j]);
                    file = file + ",";
                }
            }
            //This uses a nested for loop to store the history of online worker wage
            for (int i = 0; i < numOfPlayers; i++)
            {
                for (int j = 0; j < weekNumber; j++)
                {
                    file = file + Convert.ToString(historyOnlineWorkerWage[i, j]);
                    file = file + ",";
                }
            }

            //This uses a nested for loop to store the history of amount of workers
            for (int i = 0; i < numOfPlayers; i++)
            {
                for (int j = 0; j < weekNumber; j++)
                {
                    file = file + Convert.ToString(historyAmountOfWorkers[i, j]);
                    file = file + ",";
                }
            }

            //This uses a nested for loop to store the history of online amount of workers
            for (int i = 0; i < numOfPlayers; i++)
            {
                for (int j = 0; j < weekNumber; j++)
                {
                    file = file + Convert.ToString(historyOnlineAmountOfWorkers[i, j]);
                    file = file + ",";
                }
            }

            //This uses a nested for loop to store the history of item prices
            for (int i = 0; i < numOfPlayers; i++)
            {
                for (int j = 0; j < weekNumber; j++)
                {
                    file = file + Convert.ToString(historyItemPrices[i, j]);
                    file = file + ",";
                }
            }

            //This uses a nested for loop to store the history of number of customers 
            for (int i = 0; i < numOfPlayers; i++)
            {
                for (int j = 0; j < weekNumber; j++)
                {
                    file = file + Convert.ToString(historyPotentialNumberOfRegularCustomers[i, j]);
                    file = file + ",";
                }
            }

            //This uses a nested for loop to store the history of online number of customers 
            for (int i = 0; i < numOfPlayers; i++)
            {
                for (int j = 0; j < weekNumber; j++)
                {
                    file = file + Convert.ToString(historyPotentialNumberOfOnlineCustomers[i, j]);
                    file = file + ",";
                }
            }

            //This uses a nested for loop to store the history of net profit
            for (int i = 0; i < numOfPlayers; i++)
            {
                for (int j = 0; j < weekNumber; j++)
                {
                    file = file + Convert.ToString(historyNetProfit[i, j]);
                    file = file + ",";
                }
            }

            //This uses a nested for loop to store the history of the current funds
            for (int i = 0; i < numOfPlayers; i++)
            {
                for (int j = 0; j < weekNumber; j++)
                {
                    file = file + Convert.ToString(historyCurrentFunds[i, j]);
                    file = file + ",";
                }
            }

            //This uses a nested for loop to store the history of the actual number of customers
            for (int i = 0; i < numOfPlayers; i++)
            {
                for (int j = 0; j < weekNumber; j++)
                {
                    file = file + Convert.ToString(historyActualNumberOfCustomers[i, j]);
                    file = file + ",";
                }
            }

            //This uses a for loop to go through all the players and store the previous ad investment
            for (int i = 0; i < numOfPlayers; i++)
            {
                file = file + Convert.ToString(previousAdInvestment[i]);
                file = file + ",";
            }

            //This uses a for loop to go through all the players and store the previous stock amount
            for (int i = 0; i < numOfPlayers; i++)
            {
                file = file + Convert.ToString(previousStockAmounts[i]);
                file = file + ",";
            }

            //This uses a for loop to go through all the players and store the previous security invesmtents
            for (int i = 0; i < numOfPlayers; i++)
            {
                file = file + Convert.ToString(previousSecurityInvestments[i]);
                file = file + ",";
            }

            //Then save the save file to the computer's storage
            try
            {
                //using StreamWriter the name of the file is passed in
                //The name of the file also hold the directory where the file will be stored
                using (StreamWriter writer = new StreamWriter(fileName))
                {
                    //The file name gets the data from file added to it, and is stored in the directory in fileName also
                    writer.Write(file);
                }
            }
            //if there was an error
            catch (Exception)
            {
                //the file was not saved succesfully, the directory could not be accessed
                passed = false;
            }

            //return whether the file has been save correctly or not
            return passed;
        }

        //This function increments the weekNumber by 1
        //shows that the turn has moved onto the next week
        public static void incrementWeekNumber()
        {
            weekNumber++;
        }

        //This function works out how many weeks are left
        public static int calcNumOfWeeksLeft()
        {
            //finds the difference between the weekNumber and the end number of weeks
            return endNumOfWeeks - weekNumber;
        }

        //This function incremenets the supemarket index by 1
        //Which shows that the graphs of the next supermarket are being looked at
        public static void incrementSupermarketIndex()
        {
            supermarketIndex++;
        }

        //Reset the supermarekt index back to its first value, 0
        //This is used when the graphs are all closed, to get ready for the next time the graphs are loaded
        //so that the graphs are displayed from the first graph
        public static void resetSupermarketIndex()
        {
            supermarketIndex = 0;
        }

        //This function sets a value to a history array by passing in the history array that will be used
        //and passing the index and week number
        //The index representing the number of the player being looked at
        public static void setHistoryVariables(double[,] historyArray, int index, double value)
        {
            historyArray[index, weekNumber] = value;
        }

        //Set the number of players to the value passed in
        public static void setNumOfPlayers(int n)
        {
            numOfPlayers = n;
        }

        //Set the end number of weeks to the value that is passed in
        public static void setEndNumOfWeeks(int endWeek)
        {
            endNumOfWeeks = endWeek;
        }

        //This function generates the name of the user's save file
        //The value passed in is the name of the save file
        public static void generateNameUserLoadingFile(string name)
        {
            //This is the directory where the save file will be stored, and will need to chhange on different devices
            userLoadingFileName = "C:\\Users\\maxle\\OneDrive\\Documents\\Visual Studio 2022\\SUPERMARKET PROJECT OLD HOME REAL\\FinalSupermarket\\supermarketProject1\\bin\\Debug\\";
            //the save file name (that the user chose) is added and .txt is added to the end
            userLoadingFileName = userLoadingFileName + name + ".txt";
        }

        //set the userArea to the appropriate value based on the input the user gives
        public static void setUserArea(string areaName)
        {
            if (areaName == "Urban")
            {
                userArea = "Urban";
            }
            if (areaName == "Suburb")
            {
                userArea = "Suburb";
            }
            if (areaName == "Rural")
            {
                userArea = "Rural";
            }
        }

        //Set the userLoadedFile to the appropriate value based on the boolean passed in
        public static void setUserLoadedFile(bool loadedFile)
        {
            if (loadedFile == true)
            {
                userLoadedFile = true;
            }
            else if (loadedFile == false)
            {
                userLoadedFile = false;
            }
        }

        //Set the game ended variable to the bool that is passed in
        public static void setGameEnded(bool ended)
        {
            if (ended == true)
            {
                gameEnded = true;
            }
            else if (ended == false)
            {
                gameEnded = false;
            }
        }

        //Set a value to the current funds for save file array
        //The value is passed in and the index in the array is also passed in 
        //The index representing the player number
        public static void setCurrentFundsForSaveFile(double currentFunds, int index)
        {
            //set the value to the array
            currentFundsForSaveFile[index] = currentFunds;
        }

        //This function initialises the current funds for save file to the right length
        public static void initCurrentFundsForSaveFile()
        {
            currentFundsForSaveFile = new double[numOfPlayers];
        }
    
        //This function calculates the potential number of customers
        //The customer popualtion of the area and all the customer multipliers are passed in#
        //This function works for both regular and online supermarket shops
        public static int[] calcPotentialNumOfCustomers(int custPop, double[] custMults)
        {
            double multTotal = 0;

            //The total of all the multipliers needs to be caluclated
            for (int i = 0; i < custMults.Length; i++)
            {
                multTotal = multTotal + custMults[i];
            }

            //then find the reciporacal of the total of all the multipliers 
            double recipMulTotal = 1 / multTotal;

            //use the reciprocal of the total of all the multipliers and multipliy all the different supermarket multipliers by this value
            //create a new value for the new multipliers, which are balanced and will all add up to 1.
            double[] newMults = new double[custMults.Length];

            //with the new balanced multipliers use these multipliers and multiply them seperately by the total customer population
            //store all the supermarekts customers in this list
            int[] potentialNumOfCustomers = new int[custMults.Length];

            //using a for loop to go through all the player's supermarkets
            for (int i = 0; i < custMults.Length; i++)
            {
                //multiply the customer multiplier by the recipirocal of the total of customer multipliers
                //to work out new balanced multipliers
                newMults[i] = custMults[i] * recipMulTotal;

                //note that the number of customers are all rounded
                //this means that adding all the users supermarket customers together might not lead to an exact
                //value of the area customer population
                //however when dealing with a big number of customers, missing 1 or 2 customers is insignificant and can be ignored
                potentialNumOfCustomers[i] = Convert.ToInt32(Math.Round(newMults[i] * custPop));
            }
            //return the list of all the potential number of custmers
            return potentialNumOfCustomers;
        }

        //this function initialises all the previous variables to the right length
        public static void initPreviousVariables()
        {
            previousAdInvestment = new double[numOfPlayers];
            previousStockAmounts = new int[numOfPlayers];
            previousSecurityInvestments = new double[numOfPlayers];
        }

        //this function sets values to all the previous variables based on the inputs
        public static void setValuesToPreviousVariables(int stAm, double secInv, double adInv, int index)
        {
            previousStockAmounts[index] = stAm;
            previousSecurityInvestments[index] = secInv;
            previousAdInvestment[index] = adInv;
        }
    }
}
