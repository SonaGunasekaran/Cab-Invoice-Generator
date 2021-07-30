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
                if (time<= 0)
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_TIME, "Invalid Time");
            }
            return Math.Max(minFare, totalFare);
        }
    }
}
