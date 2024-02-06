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
    public partial class mainGameScreenGraph : Form
    {
        public mainGameScreenGraph()
        {
            InitializeComponent();

            //set the label end of the game to be invisible
            labelEndOfTheGame.ForeColor = Color.WhiteSmoke;

            //set the invalid no more graphs to look at label to be invisible
            labelNoMoreGraphs.ForeColor = Color.WhiteSmoke;

            //first i'm going to create two lists
            //one for the data on the x axis and another for the data on the y axis
            double[] dataX = new double[Program.numOfWeeks];
            double[] dataY = new double[Program.numOfWeeks];


            //create a function that takes in one of the history values and adds the x data and y data into the dataX and dataY
            addHistoryValuesToGraph(Program.historyWorkerWage,dataX, dataY);
            //plot the graph
            chartWorkerWage.Plot.AddScatter(dataX, dataY);
            //you need to refresh the graph every time it is plotted
            chartWorkerWage.Refresh();
           
            
            //repeat this for every one of the graphs

            //for the online worker wage
            addHistoryValuesToGraph(Program.historyOnlineWorkerWage, dataX, dataY);
            chartAmountOfDeliveryWorkers.Plot.AddScatter(dataX, dataY);
            chartAmountOfDeliveryWorkers.Refresh();

            //for amount of workers
            addHistoryValuesToGraph(Program.historyAmountOfWorkers, dataX, dataY);
            chartAmountOfWorkers.Plot.AddScatter(dataX, dataY);
            chartAmountOfWorkers.Refresh();

            //for the online amount of workers
            addHistoryValuesToGraph(Program.historyOnlineAmountOfWorkers, dataX, dataY);
            chartDeliveryWorkerWage.Plot.AddScatter(dataX, dataY);  
            chartDeliveryWorkerWage.Refresh();

            //for the item prices
            addHistoryValuesToGraph(Program.historyItemPrices, dataX, dataY);
            chartItemPrices.Plot.AddScatter(dataX, dataY);
            chartItemPrices.Refresh();

            //for the number of customers
            addHistoryValuesToGraph(Program.historyNumOfCustomers, dataX, dataY);
            chartNumberOfCustomers.Plot.AddScatter(dataX, dataY);
            chartNumberOfCustomers.Refresh();

            //for the online number of customers
            addHistoryValuesToGraph(Program.historyOnlineNumOfCustomers, dataX, dataY);
            chartOnlineNumOfCustomers.Plot.AddScatter(dataX, dataY);
            chartOnlineNumOfCustomers.Refresh();

            //for the net profit
            addHistoryValuesToGraph(Program.historyNetProfit, dataX, dataY);
            chartNetProfit.Plot.AddScatter(dataX, dataY);
            chartNetProfit.Refresh();

            //for the current funds
            addHistoryValuesToGraph(Program.historyCurrentFunds, dataX, dataY);
            chartCurrentFunds.Plot.AddScatter(dataX, dataY);
            chartCurrentFunds.Refresh();

            //check to see if this is the last week by checking how many weeks have gone by
            if (Program.numOfWeeks == Program.endNumOfWeeks)
            {
                //set the error message to visible red
                labelEndOfTheGame.ForeColor = Color.Red;
                //set the game to ended
                Program.gameEnded = true;
            }

            
        }

        //a function that adds the history values to the dataX and dataY so that the graphs can be updated
        //note that all the history values need to be a double for the ScottPlot to accept them
        public static void addHistoryValuesToGraph(double[,] historyValues, double[]x, double[]y)
        {
            //x and y represeneting dataX and dataY respectively
            //create a for loop which will go through the number of weeks that have passed
            for (int i = 0; i < Program.numOfWeeks; i++)
            {
                //then set up the x axis by assigning i to the dataX
                x[i] = i;

                //then get the data from the historyValues, which represents the y axis
                //then we need to get the supermarket index to check which supermarket to look into
                //the supermarket index changes everytime that a new graph is made
                y[i] = historyValues[Program.supermarketIndex, i];
            }
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
            if (Program.supermarketIndex + 1 < Program.numOfPlayers)
            {
                //if there are more graphs to show then create a new mainGameScreenGraph object
                //also need to indent the supermarket index
                Program.supermarketIndex++;
                mainGameScreenGraph mgsg = new mainGameScreenGraph();
                mgsg.Show();
            }
            else
            {
                //display error message
                labelNoMoreGraphs.ForeColor = Color.Red;
                //reset the supermarket index
                Program.supermarketIndex = 0;
            }
        }

        //button to close graph
        private void buttonContinue_Click(object sender, EventArgs e)
        {
            if (Program.gameEnded == true)
            {
                //this means that it is the end of the game and there are no more turns left
                //display error message
                Application.Exit();
            }
            else
            {
                //close the application
                this.Close();
                //reset the supermarket index
                Program.supermarketIndex = 0;
            }

        }

        private void buttonSaveQuit_Click(object sender, EventArgs e)
        {
            if (Program.gameEnded == false)
            {
                //show th save game screen
                saveGameScreen sgs = new saveGameScreen();
                sgs.Show();

            }

            else if (Program.gameEnded == true)
            {
                labelCantSaveEndedGame.ForeColor = Color.Red;   
            }

        }
    }
}
