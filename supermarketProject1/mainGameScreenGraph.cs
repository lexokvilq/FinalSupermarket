using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using System.Windows.Shapes;

namespace supermarketProject1
{
    public partial class MainGameScreenGraph : Form
    {        
        //this is the data that will be displayed on the x axis of a graph
        private static double[] dataX;
        //this is the data that will be displayed on the y axis of a graph
        private static double[] dataY;
        //both these lists are updated for every graph

        public MainGameScreenGraph()
        {
            InitializeComponent();

            //This shows which screen is displaying which player's graphs by displaying the player number
            labelPlayerNumber.Text = labelPlayerNumber.Text + Convert.ToString(Program.SupermarketIndex+1);

            //Assume that it is not the end of the game yet, so set the end of the game message to be invisible
            labelEndOfTheGame.ForeColor = Color.WhiteSmoke;

            //Set the error message, no more graphs left to look at, to be invisible
            labelNoMoreGraphs.ForeColor = Color.WhiteSmoke;

            //this function updates the dataX and dataY lists to contain the appropriate data from one of the history variables
            //this call of the function is setting the dataX and dataY to the values inside of HistoryWorkerWage
            addHistoryValuesToGraph(Program.HistoryWorkerWage);
            //This plots the line on the graph
            chartWorkerWage.Plot.AddScatter(dataX, dataY);
            //The graph needs to be refreshed everytime it is used
            chartWorkerWage.Refresh();
           
            //The function that adds the history variables to dataX and dataY is called again
            //HistoryOnlineWorkerWage graph
            addHistoryValuesToGraph(Program.HistoryOnlineWorkerWage);
            chartAmountOfDeliveryWorkers.Plot.AddScatter(dataX, dataY);
            chartAmountOfDeliveryWorkers.Refresh();

            //HistoryAmountOfWorkers
            addHistoryValuesToGraph(Program.HistoryAmountOfWorkers);
            chartAmountOfWorkers.Plot.AddScatter(dataX, dataY);
            chartAmountOfWorkers.Refresh();

            //HistoryOnlineAmountOfWorkers, amount of delivery workers
            addHistoryValuesToGraph(Program.HistoryOnlineAmountOfWorkers);
            chartDeliveryWorkerWage.Plot.AddScatter(dataX, dataY);  
            chartDeliveryWorkerWage.Refresh();

            //HistoryItemPrices
            addHistoryValuesToGraph(Program.HistoryItemPrices);
            chartItemPrices.Plot.AddScatter(dataX, dataY);
            chartItemPrices.Refresh();

            //HistoryPotentialNumberOfRegularCustomers
            addHistoryValuesToGraph(Program.HistoryPotentialNumberOfRegularCustomers);
            chartNumberOfCustomers.Plot.AddScatter(dataX, dataY);
            chartNumberOfCustomers.Refresh();

            //HistoryPotentialNumberOfOnlineCustomers
            addHistoryValuesToGraph(Program.HistoryPotentialNumberOfOnlineCustomers);
            chartOnlineNumOfCustomers.Plot.AddScatter(dataX, dataY);
            chartOnlineNumOfCustomers.Refresh();

            //HistoryNetProfit
            addHistoryValuesToGraph(Program.HistoryNetProfit);
            chartNetProfit.Plot.AddScatter(dataX, dataY);
            chartNetProfit.Refresh();

            //HistoryCurrentFunds
            addHistoryValuesToGraph(Program.HistoryCurrentFunds);
            chartCurrentFunds.Plot.AddScatter(dataX, dataY);
            chartCurrentFunds.Refresh();

            //HistoryActualNumberOfCustomers
            addHistoryValuesToGraph(Program.HistoryActualNumberOfCustomers);
            chartActualNumberOfCustomres.Plot.AddScatter(dataX, dataY);
            chartActualNumberOfCustomres.Refresh();

            //check to see if this is the last week by checking how many weeks have gone by
            if (Program.calcNumOfWeeksLeft() == 0)
            {
                //set the error message to visible red
                labelEndOfTheGame.ForeColor = Color.Red;
                //set the game to ended
                Program.setGameEnded(true);
            }
        }
        
        //This function updates the dataX and dataY variables to contain the values from the history variables
        //the history variables being graphed is passed in
        public static void addHistoryValuesToGraph(double[,] historyValues)
        {
            //the dataX and dataY need to be initialised and set to the right length, the num of weeks that have passed
            initDataXY();

            //create a for loop which will go through the number of weeks that have passed
            for (int i = 0; i < Program.WeekNumber; i++)
            {
                //then set up the x axis by assigning i to the dataX
                //the dataX will just go up from 0 to the number of weeks that have passed
                dataX[i] = i;

                //The data from the historyValues is graphed on the y axis
               //supermarket index is used to check which supermarekt is currently being looked at
               //the i represents the week being looked at
                dataY[i] = historyValues[Program.SupermarketIndex, i];
            }
        }

        //set the dataX and dataY to the right length
        public static void initDataXY()
        {
            //the dataX and dataY are set to the WeekNumber, representing the number of weeks that have passed
            dataX = new double[Program.WeekNumber];
            dataY = new double[Program.WeekNumber];
        }
       
        private void cartesianChart1_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }

        private void mainGameScreenGraph_Load(object sender, EventArgs e)
        {

        }

        private void buttonNextGraph_Click(object sender, EventArgs e)
        {
            //need to check if there are any more graphs to look at
            //do this by checking if the supermarket index is the same as the number of players
            //while the index is smaller than the number of players it still hasnt reached the end
            //need to check the next supermarket so that is why it is supermarketIndex + 1
            if (Program.SupermarketIndex + 1 < Program.NumOfPlayers)
            {
                //if there are more graphs to show then create a new mainGameScreenGraph object
                //also need to indent the supermarket index
                Program.incrementSupermarketIndex();
                MainGameScreenGraph mgsg = new MainGameScreenGraph();
                mgsg.Show();
            }
            else
            {
                //display error message
                labelNoMoreGraphs.ForeColor = Color.Red;
            }
        }

        //this button will close graph
        private void buttonContinue_Click(object sender, EventArgs e)
        {
            if (Program.GameEnded == true)
            {
                //this means that it is the end of the game and there are no more turns left
                //close the application
                Application.Exit();
            }
            else
            {
                //close the window
                this.Close();
                //reset the supermarket index
                Program.resetSupermarketIndex();
            }

        }

        //button if the user wants to save their progress and quit the game
        private void buttonSaveQuit_Click(object sender, EventArgs e)
        {
            //check if the game hasnt ended, can only save a game that hasnt ended
            if (Program.GameEnded == false)
            {
                //show the save game screen
                SaveGameScreen sgs = new SaveGameScreen();
                sgs.Show();
            }

            //check if the game has ended
            //if the game has ended there is no point saving the game, so not allowed to save an ended game
            else if (Program.GameEnded == true)
            {
                //display error message to the user
                labelCantSaveEndedGame.ForeColor = Color.Red;   
            }

        }
    }
}
