using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace supermarketProject1
{
    public class Area
    {
        public int customerPopulation;
        public int onlineCustomerPopulation;


        public int averageAmountOfWorkers;
        public int onlineAverageAmountOfWorkers;
        public double averageAreaAdvertisementInvestment;
        public double shopliftingRate;
        public double averageSecurityInvestment;

        public Area()
        {

        }
        public virtual void updateArea()
        {
            //userArea, customerPopulation, numberOfComputerSupermarkets, onlineCustomerPopulation, averageAmountOfWorkers
            //onlineAverageAmountOfWorkers, averageAreaAdvertisementInvestment, shopliftingRate, averageSecurityInvestment
            //rent, numberOfPlayers   

            if(Program.userArea == "Urban")
            {
                //here are the values based on real data of urban areas
                customerPopulation = 10605;
                onlineCustomerPopulation = 1585;
                averageAmountOfWorkers = 15;
                onlineAverageAmountOfWorkers = 15;
                averageAreaAdvertisementInvestment = 354.58;
                shopliftingRate = 0.0145;
                averageSecurityInvestment = 1327.86;
                

                

            }
            if (Program.userArea == "Suburb")
            {
                //real values
                customerPopulation = 4972;
                onlineCustomerPopulation = 743;
                averageAmountOfWorkers = 10;
                onlineAverageAmountOfWorkers = 7;
                averageAreaAdvertisementInvestment = 290.55;
                shopliftingRate = 0.0091;
                averageSecurityInvestment = 885.12;
 
            }
            if (Program.userArea == "Rural")
            {
                //real values
                customerPopulation = 3795;
                onlineCustomerPopulation = 567;
                averageAmountOfWorkers = 5;
                onlineAverageAmountOfWorkers = 5;
                averageAreaAdvertisementInvestment = 226.08;
                shopliftingRate = 0;
                averageSecurityInvestment = 0;

            }
        }
        
    }
}
