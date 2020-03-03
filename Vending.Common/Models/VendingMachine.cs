using System.Collections.Generic;
using System.Linq;
using Vending.Common.Exceptions;

namespace Vending.Common.Models
{
    public class VendingMachine : IVendingMachine
    {
        public int[] CoinDenominations { get; set; }

        public VendingMachine(int[] coinDenominations)
        {
            CoinDenominations = coinDenominations;
            CoinDenominations = CoinDenominations?.ToList()?.OrderByDescending(x => x)?.ToArray();
        }
        public int[] CalculateChange(double purchaseAmount, double tenderAmount)
        {
            var purchaseAmountTemp = purchaseAmount * 100;
            var tenderAmountTemp = tenderAmount * 100;
            var result = new List<int>();
            if (purchaseAmount > 0 && CoinDenominations.Length > 0)
            {
                var balance = tenderAmountTemp - purchaseAmountTemp;
                var currentCointPos = 0;
                var currentCoin = CoinDenominations[currentCointPos];

                while (balance > 0)
                {
                    if (balance >= currentCoin)
                    {
                        result.Add(currentCoin);
                        balance -= currentCoin;
                        continue;
                    }
                    else
                    {
                        currentCointPos++;
                        if (currentCointPos < CoinDenominations.Length)
                        {
                            currentCoin = CoinDenominations[currentCointPos];
                        }
                        else
                        {
                            throw new InvalidCoinCombinationException($"Can't give exact change with this coin combination");
                        }
                    }
                }
            }
            return result?.ToArray();
        }
    }
}
