using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace supermarketProject1
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 


        public static string userArea;

        //this is the number of the week that the game is on
        public static int numOfWeeks;
        //end number of weeks
        public static int endNumOfWeeks;

        public static int numOfPlayers;

        //add these values to the design
        //lenStockRange represents the number of different types of stock
        public const int LenStockRange = 4;
        //lenSuppliers represents the number of different types of suppliers
        public const int LenSuppliers = 5;

        //need to create a supermarket index
        //this index represents which supermarket the program is looking at when graphing - in the 2d array
        //this is called in the maingameScreenGraph.cs
        public static int supermarketIndex;

        //create variables storing the history of the graphing variables
        public static double[,] historyWorkerWage;
        public static double[,] historyOnlineWorkerWage;
        public static double[,] historyAmountOfWorkers;
        public static double[,] historyOnlineAmountOfWorkers;
        public static double[,] historyItemPrices;
        public static double[,] historyNumOfCustomers;
        public static double[,] historyOnlineNumOfCustomers;
        public static double[,] historyNetProfit;
        public static double[,] historyCurrentFunds;

        //add this to design
        public static string userSaveFile;
        public static double[] currentFundsForSaveFile;
        public static bool userLoadedFile;
        public static bool gameEnded;

        [STAThread]

        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //the game has started and the players is on the first week
            numOfWeeks = 0;

            //set the supermarketIndex to 0
            supermarketIndex = 0;

            //set the userLoadedFile as false as deafult
            userLoadedFile = false;

            //set the directory where user save file will be stored
            //THIS NEEDS TO CHANGE DEPENDENT ON THE DEVICE


            userSaveFile = "C:\\Users\\maxle\\OneDrive\\Documents\\Visual Studio 2022\\SUPERMARKET PROJECT OLD HOME REAL\\supermarketProject1\\supermarketProject1\\bin\\Debug\\";

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
            historyNumOfCustomers = new double[numOfPlayers, endNumOfWeeks];
            historyOnlineNumOfCustomers = new double[numOfPlayers, endNumOfWeeks];
            historyOnlineAmountOfWorkers = new double[numOfPlayers, endNumOfWeeks];
            historyWorkerWage = new double[numOfPlayers, endNumOfWeeks];
            historyOnlineWorkerWage = new double[numOfPlayers, endNumOfWeeks];
            historyCurrentFunds = new double[numOfPlayers, endNumOfWeeks];

            //first you need to get the number of players
            for (int i = 0; i < numOfPlayers; i++)
            {
                for (int j = 0; j < endNumOfWeeks; j++)
                {
                    historyAmountOfWorkers[i, j] = 0;
                    historyItemPrices[i, j] = 0;
                    historyNetProfit[i, j] = 0;
                    historyNumOfCustomers[i, j] = 0;
                    historyOnlineNumOfCustomers[i, j] = 0;
                    historyOnlineAmountOfWorkers[i, j] = 0;
                    historyWorkerWage[i, j] = 0;
                    historyOnlineWorkerWage[i, j] = 0;
                    historyCurrentFunds[i, j] = 0;
                }
            }
        }



        //add this function into the design
        //this functions checks if a string is a string or a number
        public static bool checkIfString(string input)
        {
            decimal number1 = 0;
            if (decimal.TryParse(input, out number1) == false)
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
            //numOfPlayers, numOfWeeks, endNumOfWeeks, userArea, currentFunds,
            //historyWorkerWage, historyOnlineWorkerWage, hisotryAmountOfWorkers
            //historyOnlineAmountOfWorkers, historyItemPrices, historyNumOfCustomers, historyOnlineNumOfCustomers
            //historyNetProfit, historyCurrentFunds

            numOfPlayers = Convert.ToInt32(values[0]);
            numOfWeeks = Convert.ToInt32(values[1]);
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
                for (int j = 0; j < numOfWeeks; j++)
                {
                    historyWorkerWage[i, j] = Convert.ToDouble(values[indexInValues]);
                    indexInValues++;
                }
            }

            //history of onlineWorkerWage
            for (int i = 0; i < numOfPlayers; i++)
            {
                for (int j = 0; j < numOfWeeks; j++)
                {
                    historyOnlineWorkerWage[i, j] = Convert.ToDouble(values[indexInValues]);
                    indexInValues++;
                }
            }

            //history of amount of workers
            for (int i = 0; i < numOfPlayers; i++)
            {
                for (int j = 0; j < numOfWeeks; j++)
                {
                    historyAmountOfWorkers[i, j] = Convert.ToInt32(values[indexInValues]);
                    indexInValues++;
                }
            }


            //history of online amount of workers
            for (int i = 0; i < numOfPlayers; i++)
            {
                for (int j = 0; j < numOfWeeks; j++)
                {
                    historyOnlineAmountOfWorkers[i, j] = Convert.ToInt32(values[indexInValues]);
                    indexInValues++;
                }
            }

            //history of item prices
            for (int i = 0; i < numOfPlayers; i++)
            {
                for (int j = 0; j < numOfWeeks; j++)
                {
                    historyItemPrices[i, j] = Convert.ToDouble(values[indexInValues]);
                    indexInValues++;
                }
            }

            //history of number of customers 
            for (int i = 0; i < numOfPlayers; i++)
            {
                for (int j = 0; j < numOfWeeks; j++)
                {
                    historyNumOfCustomers[i, j] = Convert.ToInt32(values[indexInValues]);
                    indexInValues++;
                }
            }

            //history of online number of customers 
            for (int i = 0; i < numOfPlayers; i++)
            {
                for (int j = 0; j < numOfWeeks; j++)
                {
                    historyOnlineNumOfCustomers[i, j] = Convert.ToInt32(values[indexInValues]);
                    indexInValues++;
                }
            }

            //history of net profit
            for (int i = 0; i < numOfPlayers; i++)
            {
                for (int j = 0; j < numOfWeeks; j++)
                {
                    historyNetProfit[i, j] = Convert.ToDouble(values[indexInValues]);
                    indexInValues++;
                }
            }

            //history of current funds
            for (int i = 0; i < numOfPlayers; i++)
            {
                for (int j = 0; j < numOfWeeks; j++)
                {
                    historyCurrentFunds[i, j] = Convert.ToDouble(values[indexInValues]);
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
            //numOfPlayers, numOfWeeks, endNumOfWeeks, userArea, currentFunds,
            //historyWorkerWage, historyOnlineWorkerWage, hisotryAmountOfWorkers
            //historyOnlineAmountOfWorkers, historyItemPrices, historyNumOfCustomers, historyOnlineNumOfCustomers
            //historyNetProfit, historyCurrentFunds

            string file;

            file = Convert.ToString(numOfPlayers);
            file = file + ",";
            file = file + Convert.ToString(numOfWeeks);
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
                for (int j = 0; j < numOfWeeks; j++)
                {
                    file = file + Convert.ToString(historyWorkerWage[i, j]);
                    file = file + ",";
                }
            }
            //history of onlineWorkerWage
            for (int i = 0; i < numOfPlayers; i++)
            {
                for (int j = 0; j < numOfWeeks; j++)
                {
                    file = file + Convert.ToString(historyOnlineWorkerWage[i, j]);
                    file = file + ",";
                }
            }

            //history of amount of workers
            for (int i = 0; i < numOfPlayers; i++)
            {
                for (int j = 0; j < numOfWeeks; j++)
                {
                    file = file + Convert.ToString(historyAmountOfWorkers[i, j]);
                    file = file + ",";
                }
            }

            //history of online amount of workers
            for (int i = 0; i < numOfPlayers; i++)
            {
                for (int j = 0; j < numOfWeeks; j++)
                {
                    file = file + Convert.ToString(historyOnlineAmountOfWorkers[i, j]);
                    file = file + ",";
                }
            }

            //history of item prices
            for (int i = 0; i < numOfPlayers; i++)
            {
                for (int j = 0; j < numOfWeeks; j++)
                {
                    file = file + Convert.ToString(historyItemPrices[i, j]);
                    file = file + ",";
                }
            }

            //history of number of customers 
            for (int i = 0; i < numOfPlayers; i++)
            {
                for (int j = 0; j < numOfWeeks; j++)
                {
                    file = file + Convert.ToString(historyNumOfCustomers[i,j]);
                    file = file + ",";
                }
            }

            //history of online number of customers 
            for (int i = 0; i < numOfPlayers; i++)
            {
                for (int j = 0; j < numOfWeeks; j++)
                {
                    file = file + Convert.ToString(historyOnlineNumOfCustomers[i, j]);
                    file = file + ",";
                }
            }

            //history of net profit
            for (int i = 0; i < numOfPlayers; i++)
            {
                for (int j = 0; j < numOfWeeks; j++)
                {
                    file = file + Convert.ToString(historyNetProfit[i, j]);
                    file = file + ",";
                }
            }

            for (int i = 0; i < numOfPlayers; i++)
            {
                for (int j = 0; j < numOfWeeks; j++)
            //history of current funds
                {
                    file = file + Convert.ToString(historyCurrentFunds[i, j]);
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
    }
}
