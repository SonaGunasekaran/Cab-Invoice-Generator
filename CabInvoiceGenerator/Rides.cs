using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGenerator
{
   public class Rides
   {
        public double distance;
        public int time;
        public Rides(double distance, int time)
        {
            this.distance = distance;
            this.time = time;
        }
   }
}
