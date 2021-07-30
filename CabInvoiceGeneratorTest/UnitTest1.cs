using Microsoft.VisualStudio.TestTools.UnitTesting;
using CabInvoiceGenerator;

namespace CabInvoiceGeneratorTest
{
    [TestClass]
    public class UnitTest1
    {
       CabInvoice invoice;

        [TestInitialize]
        public void Setup()
        {
            invoice = new CabInvoice();
        }
       [TestMethod]
        public void TotalFare()
        {
            double distance = 20;
            double time = 10;
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
                var actual = invoice.CalculateTotalFare(distance, time);
            }
            catch (CabInvoiceException ex)
            {
                Assert.AreEqual(ex.Message,"Invalid Distance");
            }
        }
    }
}
