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


        //ALL THE SET FUNCTIONS FOR THE VARIABLES ARENT WORKING 
        //CREATING OWN NEW FUNCTIONS WHEN SET NEEDS TO BE OUTSIDE THE CLASS

        //userArea 
        private static string userArea;
        public static string UserArea
        {
            get { return userArea; }
        }

        //this is the number of the week that the game is on
        private static int weekNumber;
        public static int WeekNumber
        {
            get { return weekNumber; }
        }

        //end number of weeks
        private static int endNumOfWeeks;
        public static int EndNumOfWeeks
        {
            get { return endNumOfWeeks; }
        }

        private static int numOfPlayers;
        public static int NumOfPlayers
        {
            get { return numOfPlayers; }
        }

        //add these values to the design
        //lenStockRange represents the number of different types of stock
        public const int LenStockRange = 4;
        //lenSuppliers represents the number of different types of suppliers
        public const int LenSuppliers = 5;

        //need to create a supermarket index
        //this index represents which supermarket the program is looking at when graphing - in the 2d array
        //this is called in the maingameScreenGraph.cs
        private static int supermarketIndex;
        public static int SupermarketIndex
        {
            get { return supermarketIndex; }
        }

        //create variables storing the history of the graphing variables
        private static double[,] historyWorkerWage;
        public static double[,] HistoryWorkerWage
        {
            get { return historyWorkerWage; }
        }

        private static double[,] historyOnlineWorkerWage;
        public static double[,] HistoryOnlineWorkerWage
        {
            get { return historyOnlineWorkerWage; }
        }

        private static double[,] historyAmountOfWorkers;
        public static double[,] HistoryAmountOfWorkers
        {
            get { return historyAmountOfWorkers; }
        }

        private static double[,] historyOnlineAmountOfWorkers;
        public static double[,] HistoryOnlineAmountOfWorkers
        {
            get { return historyOnlineAmountOfWorkers; }
        }

        private static double[,] historyItemPrices;
        public static double[,] HistoryItemPrices
        {
            get { return historyItemPrices; }
        }

        private static double[,] historyPotentialNumberOfRegularCustomers;
        public static double[,] HistoryPotentialNumberOfRegularCustomers
        {
            get { return historyPotentialNumberOfRegularCustomers; }
        }

        private static double[,] historyPotentialNumberOfOnlineCustomers;
        public static double[,] HistoryPotentialNumberOfOnlineCustomers
        {
            get { return historyPotentialNumberOfOnlineCustomers; }
        }

        private static double[,] historyNetProfit;
        public static double[,] HistoryNetProfit
        {
            get { return historyNetProfit; }
        }

        private static double[,] historyCurrentFunds;
        public static double[,] HistoryCurrentFunds
        {
            get { return historyCurrentFunds; }
        }

        //add to design
        private static double[,] historyActualNumberOfCustomers;
        public static double[,] HistoryActualNumberOfCustomers
        {
            get { return historyActualNumberOfCustomers; }
        }

        //this is the file for loading in a file        
        private static string userLoadingFileName;
        public static string UserLoadingFileName
        {
            get { return userLoadingFileName; }
        }

        private static double[] currentFundsForSaveFile;
        public static double[] CurrentFundsForSaveFile
        {
            get { return currentFundsForSaveFile; }
        }

        private static bool userLoadedFile;
        public static bool UserLoadedFile
        {
            get { return userLoadedFile; }
        }

        private static bool gameEnded;
        public static bool GameEnded
        {
            get { return gameEnded; }
        }

        

        [STAThread]

        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //the game has started and the players is on the first week
            weekNumber = 0;

            //set the supermarketIndex to 0
            supermarketIndex = 0;

            //set the userLoadedFile as false as deafult
            userLoadedFile = false;

            

            //set the game end to false
            gameEnded = false;
            Application.Run(new Form1());
        }

        //this program will initialise all the history variables, meaning all the variables that will be graphed
        public static void initHistoryVariables()
        {
            //first need to intialise all the arrays
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



        //add this function into the design using Regular expressions
        //this functions checks if a string is a string or a number
        public static bool checkIfString(string value)
        {
            Regex rg = new Regex("[.]");
            //count the number of decimal points in the string
            MatchCollection matchedDecimalPlaces = rg.Matches(value);

            //check if the value doesn't contain a number or a decimal place, which will mean 
            //the value is a string, or if the value is null or contains white space
            //if there is more than 1 decimal place
            //if there is a negative sign the program will return true for a string because
            //the only valid inputs are integers and decimal points
            if (!Regex.IsMatch(value, "^[0-9.]*$") 
                || string.IsNullOrWhiteSpace(value) == true
                || matchedDecimalPlaces.Count > 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool checkIfInteger(string value)
        {
            //assumes the input is not a string
            //checks if there is a decimal point if there is no decimal point
            //if there is not decimal point it is a integer
            if (!Regex.IsMatch(value, "[.]"))
            {
                return true;
            }
            else
            {
                //if the function returns false the value is a double
                return false;
            }
        }

        //check if a value is 0
        //assumes the value is not a string
        public static bool checkIfZero(string value)
        {
            if (Convert.ToDouble(value) == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
       

        public static void loadFile(string file)
        {
            //a comma is stored at the end to signify the end of the data
            Boolean commaFound = false;
            //the array where we will store the values
            //this function inside the string initialiser counts the number of commas in the string
            //add one to this value to get the number of values in the string
            string[] values = new string[file.Count(c => c == ',')];
            //this count represents the index in the while loop searching for the next comma
            int count = 0;
            //this is the lenght of the value we are trying to find
            int lengthOfValue = 0;
            //number of items that have been searched in the list
            int numOfItemsSearched = 0;

            for (int i = 0; i < file.Length; i++)
            {
                //reset the comma found 
                commaFound = false;

                while (commaFound == false)
                {
                    if (file[count] == ',')
                    {
                        //the comma was found
                        commaFound = true;
                        //work out how long the value is by taking away
                        //the count from the i
                        lengthOfValue = count - i;
                        //use an array to store the values
                        char[] dataArray = new char[lengthOfValue];
                        //this is a for loop to go through the userInput and store the values
                        //as i know the start point, i
                        //the end point, count 
                        //and the length, lenghtOfValue
                        for (int j = 0; j < lengthOfValue; j++)
                        {
                            dataArray[j] = file[i + j];
                        }
                        //need to store the values in data array to values
                        values[numOfItemsSearched] = new string(dataArray);
                        //setting count to start at the start of the next value
                        i = count;
                        //next item in values
                        numOfItemsSearched++;
                        //next char in the string being searched for
                        count++;
                    }
                    else
                    {
                        //the comma was not found
                        count++;
                    }
                }
            }

            //the order that files will be stored is
            //numOfPlayers, weekNumber, endNumOfWeeks, userArea, currentFunds,
            //historyWorkerWage, historyOnlineWorkerWage, hisotryAmountOfWorkers
            //historyOnlineAmountOfWorkers, historyItemPrices, historyNumOfCustomers, historyOnlineNumOfCustomers
            //historyNetProfit, historyCurrentFunds

            numOfPlayers = Convert.ToInt32(values[0]);
            weekNumber = Convert.ToInt32(values[1]);
            endNumOfWeeks = Convert.ToInt32(values[2]);
            userArea = values[3];

            //need a variable to store the current funds

            //this index will be used for the history values to 
            //work out what value the program is currently looking at
            int indexInValues = 4;
            //the index starts on 4 as values 0-3 will have already been seen
            //this sets the current funds for each of the supermarkets
            //set up the currentFundsForSaveFile variable to the right size
            initCurrentFundsForSaveFile();
            for (int i = 0; i < numOfPlayers; i++)
            {
                currentFundsForSaveFile[i] = Convert.ToDouble(values[4 + i]);
                indexInValues++;
            }

            //need to initialise all the history values before they can be assigned values
            initHistoryVariables();

            //for the history variables need to create a list for each variable
            //history of worker wage
            
            for (int i = 0; i < numOfPlayers; i++)
            {
                for (int j = 0; j < weekNumber; j++)
                {
                    historyWorkerWage[i, j] = Convert.ToDouble(values[indexInValues]);
                    indexInValues++;
                }
            }

            //history of onlineWorkerWage
            for (int i = 0; i < numOfPlayers; i++)
            {
                for (int j = 0; j < weekNumber; j++)
                {
                    historyOnlineWorkerWage[i, j] = Convert.ToDouble(values[indexInValues]);
                    indexInValues++;
                }
            }

            //history of amount of workers
            for (int i = 0; i < numOfPlayers; i++)
            {
                for (int j = 0; j < weekNumber; j++)
                {
                    historyAmountOfWorkers[i, j] = Convert.ToInt32(values[indexInValues]);
                    indexInValues++;
                }
            }


            //history of online amount of workers
            for (int i = 0; i < numOfPlayers; i++)
            {
                for (int j = 0; j < weekNumber; j++)
                {
                    historyOnlineAmountOfWorkers[i, j] = Convert.ToInt32(values[indexInValues]);
                    indexInValues++;
                }
            }

            //history of item prices
            for (int i = 0; i < numOfPlayers; i++)
            {
                for (int j = 0; j < weekNumber; j++)
                {
                    historyItemPrices[i, j] = Convert.ToDouble(values[indexInValues]);
                    indexInValues++;
                }
            }

            //history of the potential number of regular customers 
            for (int i = 0; i < numOfPlayers; i++)
            {
                for (int j = 0; j < weekNumber; j++)
                {
                    historyPotentialNumberOfRegularCustomers [i, j] = Convert.ToInt32(values[indexInValues]);
                    indexInValues++;
                }
            }

            //history of the potential of online customers 
            for (int i = 0; i < numOfPlayers; i++)
            {
                for (int j = 0; j < weekNumber; j++)
                {
                    historyPotentialNumberOfOnlineCustomers[i, j] = Convert.ToInt32(values[indexInValues]);
                    indexInValues++;
                }
            }

            //history of net profit
            for (int i = 0; i < numOfPlayers; i++)
            {
                for (int j = 0; j < weekNumber; j++)
                {
                    historyNetProfit[i, j] = Convert.ToDouble(values[indexInValues]);
                    indexInValues++;
                }
            }

            //history of current funds
            for (int i = 0; i < numOfPlayers; i++)
            {
                for (int j = 0; j < weekNumber; j++)
                {
                    historyCurrentFunds[i, j] = Convert.ToDouble(values[indexInValues]);
                    indexInValues++;
                }
            }

            //history of actual number of customers
            for (int i = 0; i < numOfPlayers; i++)
            {
                for (int j = 0; j < weekNumber; j++)
                {
                    historyActualNumberOfCustomers[i, j] = Convert.ToDouble(values[indexInValues]);
                    indexInValues++;
                }

            }
        }

        public static bool saveFile(string fileName)
        {
            fileName = fileName + ".txt";
            //did the file get saved?
            bool passed = true;
            //file name is passed in from the save game screen

            //first need to store 
            //numOfPlayers, weekNumber, endNumOfWeeks, userArea, currentFunds,
            //historyWorkerWage, historyOnlineWorkerWage, hisotryAmountOfWorkers
            //historyOnlineAmountOfWorkers, historyItemPrices, historyNumOfCustomers, historyOnlineNumOfCustomers
            //historyNetProfit, historyCurrentFunds

            string file;

            file = Convert.ToString(numOfPlayers);
            file = file + ",";
            file = file + Convert.ToString(weekNumber);
            file = file + ",";
            file = file + Convert.ToString(endNumOfWeeks);
            file = file + ",";
            file = file + userArea;
            file = file + ",";

            //use a for loop to store all the supermarkets' current funds
            for (int i = 0; i < numOfPlayers; i++)
            {
                file = file + Convert.ToString(currentFundsForSaveFile[i]);
                file = file + ",";
            }

            //using a nested for loop to store the history worker wage
            for (int i = 0; i < numOfPlayers; i++)
            {
                for (int j = 0; j < weekNumber; j++)
                {
                    file = file + Convert.ToString(historyWorkerWage[i, j]);
                    file = file + ",";
                }
            }
            //history of onlineWorkerWage
            for (int i = 0; i < numOfPlayers; i++)
            {
                for (int j = 0; j < weekNumber; j++)
                {
                    file = file + Convert.ToString(historyOnlineWorkerWage[i, j]);
                    file = file + ",";
                }
            }

            //history of amount of workers
            for (int i = 0; i < numOfPlayers; i++)
            {
                for (int j = 0; j < weekNumber; j++)
                {
                    file = file + Convert.ToString(historyAmountOfWorkers[i, j]);
                    file = file + ",";
                }
            }

            //history of online amount of workers
            for (int i = 0; i < numOfPlayers; i++)
            {
                for (int j = 0; j < weekNumber; j++)
                {
                    file = file + Convert.ToString(historyOnlineAmountOfWorkers[i, j]);
                    file = file + ",";
                }
            }

            //history of item prices
            for (int i = 0; i < numOfPlayers; i++)
            {
                for (int j = 0; j < weekNumber; j++)
                {
                    file = file + Convert.ToString(historyItemPrices[i, j]);
                    file = file + ",";
                }
            }

            //history of number of customers 
            for (int i = 0; i < numOfPlayers; i++)
            {
                for (int j = 0; j < weekNumber; j++)
                {
                    file = file + Convert.ToString(historyPotentialNumberOfRegularCustomers[i, j]);
                    file = file + ",";
                }
            }

            //history of online number of customers 
            for (int i = 0; i < numOfPlayers; i++)
            {
                for (int j = 0; j < weekNumber; j++)
                {
                    file = file + Convert.ToString(historyPotentialNumberOfOnlineCustomers[i, j]);
                    file = file + ",";
                }
            }

            //history of net profit
            for (int i = 0; i < numOfPlayers; i++)
            {
                for (int j = 0; j < weekNumber; j++)
                {
                    file = file + Convert.ToString(historyNetProfit[i, j]);
                    file = file + ",";
                }
            }

            for (int i = 0; i < numOfPlayers; i++)
            {
                for (int j = 0; j < weekNumber; j++)
                //history of current funds
                {
                    file = file + Convert.ToString(historyCurrentFunds[i, j]);
                    file = file + ",";
                }
            }

            for (int i = 0; i < numOfPlayers; i++)
            {
                for (int j = 0; j < weekNumber; j++)
                {
                    file = file + Convert.ToString(historyActualNumberOfCustomers[i, j]);
                    file = file + ",";
                }
            }

            try
            {
                using (StreamWriter writer = new StreamWriter(fileName))
                {
                    writer.Write(file);
                }

            }
            catch (Exception)
            {
                //the save filed so
                passed = false;
            }

            return passed;
        }

        public static void initCurrentFundsForSaveFile()
        {
            currentFundsForSaveFile = new double[numOfPlayers];
        }

        //function to increment weekNumber by 1
        public static void incrementWeekNumber()
        {
            weekNumber++;
        }

        //function to work out how many weeks are left
        public static int calcNumOfWeeksLeft()
        {
            return endNumOfWeeks - weekNumber;
        }

        public static void incrementSupermarketIndex()
        {
            supermarketIndex++;
        }

        public static void resetSupermarketIndex()
        {
            supermarketIndex = 0;
        }

        //this function will set a variable to its appropriate history variable alternative
        public static void setHistoryVariables(double [,] historyArray, int index, double value)
        {
            historyArray[index, weekNumber] = value;
        }

        //currently there is an issue with the setters not working in other classes
        //made a variable here that will set the appropriate varriable with its appropriate variable
        //set the number of players
        public static void setNumOfPlayers(int n)
        {
            numOfPlayers = n;
        }
        //set the end number of weeks
        public static void setEndNumOfWeeks(int endWeek)
        {
            endNumOfWeeks = endWeek;
        }

        //for the user loading a file need to get what the user names their file and add it to the file name
        public static void generateNameUserLoadingFile(string name)
        {
            //set the directory where user save file will be stored
            //THIS NEEDS TO CHANGE DEPENDENT ON THE DEVICE



            userLoadingFileName = "C:\\Users\\maxle\\OneDrive\\Documents\\Visual Studio 2022\\SUPERMARKET PROJECT OLD HOME REAL\\FinalSupermarket\\supermarketProject1\\bin\\Debug\\";
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
        public static void setUserLoadedFile(bool loadedFile)
        {
            if (loadedFile == true)
            {
                userLoadedFile = true;
            }
            else if( loadedFile  == false)
            {
                userLoadedFile = false;
            }
        }
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
        public static void setCurrentFundsForSaveFile(double currentFunds, int index)
        {
            currentFundsForSaveFile[index] = currentFunds;
        }


        // ADD THIS TO DESIGN
        public static int[] calcPotentialNumOfCustomers(int custPop, double[] custMults)
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
            //this is potential beause the supermarket might not have enough
            //stock for all the customers
            int[] potentialNumOfCustomers = new int[custMults.Length];
            // this is the maximum number of customers a supermarket can take
            //based on the stock amount.
            int[] maxNumOfCustomers = new int[custMults.Length];
            for (int i = 0; i < custMults.Length; i++)
            {
                //note that here when rounding the number of customers will ignore any decimal points
                //this means that adding all the user supermarkets together will not lead to an exact
                //value of the area customer population
                //however when dealing with such big number of customers (e.g over 100)
                //then this little number of customers "dissapearing" seems igsicnificant
                potentialNumOfCustomers[i] = Convert.ToInt32(Math.Round(newMults[i] * custPop));
            }
            return potentialNumOfCustomers;
        }


    }
}
