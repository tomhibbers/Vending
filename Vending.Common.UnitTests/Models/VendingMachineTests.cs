using NUnit.Framework;
using Vending.Common.Exceptions;
using Vending.Common.Models;

namespace Vending.Common.UnitTests.Models
{
    [TestFixture]
    public class VendingMachineTests
    {

        [Test]
        public void CalculateChange_TestUSD()
        {
            int[] coinDenominations = { 1, 5, 10, 25 }; // coin denominations – US Dollar
            var machine = new VendingMachine(coinDenominations);
            var actualChange = machine.CalculateChange(1.35, 2.00); // expect 65 cents
            int[] expectedChange = { 25, 25, 10, 5 };
            CollectionAssert.AreEqual(expectedChange, actualChange);
        }
        [Test]
        public void CalculateChange_TestGBP()
        {
            int[] coinDenominations = { 1, 2, 5, 10, 20, 50 }; // coin denominations – US Dollar
            var machine = new VendingMachine(coinDenominations);
            var actualChange = machine.CalculateChange(1.35, 2.00); // expect 65 cents
            int[] expectedChange = { 50, 10, 5};
            CollectionAssert.AreEqual(expectedChange, actualChange);
        }
        [Test]
        public void CalculateChange_ErrorIfNoValidCoinCombinationFound()
        {
            int[] coinDenominations = { 5, 10, 25 }; // coin denominations – missing 1 cent needed for diff
            var machine = new VendingMachine(coinDenominations);
            Assert.Throws<InvalidCoinCombinationException>(() => machine.CalculateChange(1.99, 2.00));
        }
    }
}
