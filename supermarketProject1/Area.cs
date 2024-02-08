using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace supermarketProject1
{
    public class Area
    {
        private int customerPopulation;
        public int CustomerPopulation
        {
            get { return customerPopulation; }
        }

        private int onlineCustomerPopulation;
        public int OnlineCustomerPopulation
        {
            get { return onlineCustomerPopulation; }
        }

        private int averageAmountOfWorkers;
        public int AverageAmountOfWorkers
        {
            get { return averageAmountOfWorkers; }
        }
        private int onlineAverageAmountOfWorkers;
        public int OnlineAverageAmountOfWorkers
        {
            get { return onlineAverageAmountOfWorkers; }
        }

        private double averageAreaAdvertisementInvestment;
        public double AverageAreaAdvertisementInvestment
        {
            get { return averageAreaAdvertisementInvestment; }
        }

        private double shopliftingRate;
        public double ShopLiftingRate
        {
            get { return shopliftingRate; }
        }
        
        private double averageSecurityInvestment;
        public double AverageSecurityInvestment
        {
            get { return averageSecurityInvestment; }
        }
        public Area(String area)
        {
            //the parameter passed in represents the Program.getUserArea
            if (area == "Urban")
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
            if (area == "Suburb")
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
            if (area == "Rural")
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
