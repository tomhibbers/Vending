using Vending.Common.Models;

namespace Vending.App
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] coinDenominations = { 1, 5, 10, 25 }; // coin denominations – US Dollar
            var machine = new VendingMachine(coinDenominations);
            var purchaseAmount = 1.35; // amount the item cost
            var tenderAmount = 2.00; // amount the user input for the purchase
            var change = machine.CalculateChange(purchaseAmount, tenderAmount); // expect 65 cents
        }
    }
}
