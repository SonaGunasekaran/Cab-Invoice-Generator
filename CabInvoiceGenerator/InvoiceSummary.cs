using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGenerator
{
    class InvoiceSummary
    {
        public int numOfRides;
        public double totalFare, avgFare;

        public InvoiceSummary(int rides, double fare)
        {
            numOfRides = rides;
            totalFare = fare;
            avgFare = totalFare / numOfRides;
        }
    }
}
