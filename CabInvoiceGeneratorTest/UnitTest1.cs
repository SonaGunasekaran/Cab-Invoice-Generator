using Microsoft.VisualStudio.TestTools.UnitTesting;
using CabInvoiceGenerator;

namespace CabInvoiceGeneratorTest
{
    [TestClass]
    public class UnitTest1
    {
       CabInvoice invoice;

        
       [TestMethod]
        public void TotalFare()
        {
            double distance = 20;
            double time = 10;
            invoice = new CabInvoice(CabInvoice.RideType.NORMAL);
            double actual = invoice.CalculateTotalFare(distance, time);
            double expected = 210;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TotalFareTest1()
        {
            try
            {
                double distance = 10;
                double time = 0;
                invoice = new CabInvoice(CabInvoice.RideType.NORMAL);
                var actual = invoice.CalculateTotalFare(distance, time);
            }
            catch (CabInvoiceException ex)
            {
                Assert.AreEqual(ex.Message,"Invalid Time");
            }
        }
        [TestMethod]
        public void TotalFareTest2()
        {
            try
            {
                double distance = 40;
                double time = 0;
                invoice = new CabInvoice(CabInvoice.RideType.NORMAL);
                var actual = invoice.CalculateTotalFare(distance, time);
            }
            catch (CabInvoiceException ex)
            {
                Assert.AreEqual(ex.Message,"Invalid Distance");
            }
        }
        [TestMethod]
        public void TotalFareForMultipleRides()
        {
            Rides[] rides = { new Rides(20, 10), new Rides(30, 10) };
            invoice = new CabInvoice(CabInvoice.RideType.PREMIUM);
            var actual = invoice.CalculateAggregateFare(rides);
            double expected = 520;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetInvoiceSummary()
        {
            Rides[] rides = { new Rides(20, 10), new Rides(30, 10) };
            string actual;
            invoice = new CabInvoice(CabInvoice.RideType.NORMAL);
            string expected = "Number of rides = 2\nTotalFare =520\nAverageFare = 260";
            actual = invoice.CalculateAggregateFare(rides);
            Assert.AreEqual(expected, actual);
        }
    }
}
