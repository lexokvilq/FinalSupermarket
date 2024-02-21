using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace supermarketProject1
{
    public class Area
    {
        //this is the population of customers, which changes in different areas
        private int customerPopulation;
        public int CustomerPopulation
        {
            //the get is used when the customer population is accessed outside of area
            get { return customerPopulation; }
        }

        //this is the population of online customers, which changes in different areas
        private int onlineCustomerPopulation;
        public int OnlineCustomerPopulation
        {
            //used outside of area
            get { return onlineCustomerPopulation; }
        }

        //this is the average amount of wokers in an area (changes in different areas)
        private int averageAmountOfWorkers;
        public int AverageAmountOfWorkers
        {
            //used outside of area
            get { return averageAmountOfWorkers; }
        }

        //this is the average amount of online workers (delivery workers) which changes in different areas
        private int onlineAverageAmountOfWorkers;
        public int OnlineAverageAmountOfWorkers
        {
            //used outside of area
            get { return onlineAverageAmountOfWorkers; }
        }

        //this is average amount spent in advertisements, changes dependent on the area
        private double averageAreaAdvertisementInvestment;
        public double AverageAreaAdvertisementInvestment
        {
            //used outside of area
            get { return averageAreaAdvertisementInvestment; }
        }

        //this is the shoplifting rate, which changes in different areas
        private double shopliftingRate;
        public double ShopLiftingRate
        {
            //shoplifting rate is accessed outside of area
            get { return shopliftingRate; }
        }
        
        //this is the average security investments, changes in different areas
        private double averageSecurityInvestment;
        public double AverageSecurityInvestment
        {
            //accessed outside of area
            get { return averageSecurityInvestment; }
        }
       
        //Area constructor
        public Area(String area)
        {
            //the parameter passed in represents the Program.userArea
            //which is the area the user chose
            
            //if the user chose an urban area
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

            //if the user chose a suburb area
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

            //if the user chose a rural area
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
