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
        //first i'm going to create two lists
        //one for the data on the x axis and another for the data on the y axis
        private static double[] dataX;
        private static double[] dataY;
        public mainGameScreenGraph()
        {
            InitializeComponent();

            //set the label of the player number
            //this shows which graph is which player
            labelPlayerNumber.Text = labelPlayerNumber.Text + Convert.ToString(Program.SupermarketIndex+1);

            //set the label end of the game to be invisible
            labelEndOfTheGame.ForeColor = Color.WhiteSmoke;

            //set the invalid no more graphs to look at label to be invisible
            labelNoMoreGraphs.ForeColor = Color.WhiteSmoke;




            //create a function that takes in one of the history values and adds the x data and y data into the dataX and dataY
            addHistoryValuesToGraph(Program.HistoryWorkerWage);
            //plot the graph
            chartWorkerWage.Plot.AddScatter(dataX, dataY);
            //you need to refresh the graph every time it is plotted
            chartWorkerWage.Refresh();
           
            
            //repeat this for every one of the graphs

            //for the online worker wage
            addHistoryValuesToGraph(Program.HistoryOnlineWorkerWage);
            chartAmountOfDeliveryWorkers.Plot.AddScatter(dataX, dataY);
            chartAmountOfDeliveryWorkers.Refresh();

            //for amount of workers
            addHistoryValuesToGraph(Program.HistoryAmountOfWorkers);
            chartAmountOfWorkers.Plot.AddScatter(dataX, dataY);
            chartAmountOfWorkers.Refresh();

            //for the online amount of workers
            addHistoryValuesToGraph(Program.HistoryOnlineAmountOfWorkers);
            chartDeliveryWorkerWage.Plot.AddScatter(dataX, dataY);  
            chartDeliveryWorkerWage.Refresh();

            //for the item prices
            addHistoryValuesToGraph(Program.HistoryItemPrices);
            chartItemPrices.Plot.AddScatter(dataX, dataY);
            chartItemPrices.Refresh();

            //for the number of customers
            addHistoryValuesToGraph(Program.HistoryNumOfCustomers);
            chartNumberOfCustomers.Plot.AddScatter(dataX, dataY);
            chartNumberOfCustomers.Refresh();

            //for the online number of customers
            addHistoryValuesToGraph(Program.HistoryOnlineNumOfCustomers);
            chartOnlineNumOfCustomers.Plot.AddScatter(dataX, dataY);
            chartOnlineNumOfCustomers.Refresh();

            //for the net profit
            addHistoryValuesToGraph(Program.HistoryNetProfit);
            chartNetProfit.Plot.AddScatter(dataX, dataY);
            chartNetProfit.Refresh();

            //for the current funds
            addHistoryValuesToGraph(Program.HistoryCurrentFunds);
            chartCurrentFunds.Plot.AddScatter(dataX, dataY);
            chartCurrentFunds.Refresh();

            //check to see if this is the last week by checking how many weeks have gone by
            if (Program.calcNumOfWeeksLeft() == 0)
            {
                //set the error message to visible red
                labelEndOfTheGame.ForeColor = Color.Red;
                //set the game to ended
                Program.setGameEnded(true);
            }

            
        }
        
        //a function that adds the history values to the dataX and dataY so that the graphs can be updated
        //note that all the history values need to be a double for the ScottPlot to accept them
        public static void addHistoryValuesToGraph(double[,] historyValues)
        {

            initDataXY();
            //create a for loop which will go through the number of weeks that have passed
            for (int i = 0; i < Program.NumOfWeeks; i++)
            {
                //then set up the x axis by assigning i to the dataX
                dataX[i] = i;

                //then get the data from the historyValues, which represents the y axis
                //then we need to get the supermarket index to check which supermarket to look into
                //the supermarket index changes everytime that a new graph is made
                dataY[i] = historyValues[Program.SupermarketIndex, i];
            }
        }

        public static void initDataXY()
        {
            dataX = new double[Program.NumOfWeeks];
            dataY = new double[Program.NumOfWeeks];
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
                mainGameScreenGraph mgsg = new mainGameScreenGraph();
                mgsg.Show();
            }
            else
            {
                //display error message
                labelNoMoreGraphs.ForeColor = Color.Red;
                //reset the supermarket index
                Program.resetSupermarketIndex();
            }
        }

        //button to close graph
        private void buttonContinue_Click(object sender, EventArgs e)
        {
            if (Program.GameEnded == true)
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
                Program.resetSupermarketIndex();
            }

        }

        private void buttonSaveQuit_Click(object sender, EventArgs e)
        {
            if (Program.GameEnded == false)
            {
                //show the save game screen
                saveGameScreen sgs = new saveGameScreen();
                sgs.Show();

            }

            else if (Program.GameEnded == true)
            {
                labelCantSaveEndedGame.ForeColor = Color.Red;   
            }

        }
    }
}
