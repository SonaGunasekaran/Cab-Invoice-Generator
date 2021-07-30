using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGenerator
{
    public class CabInvoice
    {
        double ratePerKm = 10;
        double minFare=5;
        double ratePerMin=1;

        public enum RideType
        {
            PREMIUM, NORMAL
        }

        public CabInvoice(RideType ridetype)
        {
            if (ridetype.Equals(RideType.NORMAL))
            {
                ratePerKm = 10;
                minFare = 5;
                ratePerMin = 1;
            }
            if (ridetype.Equals(RideType.PREMIUM))
            {
                ratePerKm = 15;
                minFare = 20;
                ratePerMin = 2;
            }
        }
        // calculate total fare
        public double CalculateTotalFare(double distance, double time)
        {
            //initialize the total fare
            double totalFare = 0;
            try
            {
                //formula for calculating total fare
                totalFare = (distance * ratePerKm ) + (time * ratePerMin);
            }
            catch (CabInvoiceException)
            {
                if (distance <= 0)
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_DISTANCE, "Invalid Distance");
                if (time <= 0)
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_TIME, "Invalid Time");
            }
            return Math.Max(minFare, totalFare);
        }
        public string CalculateAggregateFare(Rides[] rides)
        {
            double totalFare = 0;
            
            try
            {
                foreach (Rides i in rides)
                {
                    totalFare += CalculateTotalFare(i.distance, i.time);
                }
            }
            catch (CabInvoiceException)
            {
                throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_RIDE, "Invalid ride");
            }
            InvoiceSummary summary = new InvoiceSummary(rides.Length, totalFare);
            return "Number of rides = "+" "+summary.numOfRides+" "+" \n TotalFare = "+" "+summary.totalFare+" "+"\n AverageFare = "+" "+summary.avgFare;
        }

    }
}
