namespace Vending.Common.Models
{
    public interface IVendingMachine
    {
        int[] CoinDenominations { get; set; }

        int[] CalculateChange(double purchaseAmount, double tenderAmount);
    }
}