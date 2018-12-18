using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dpint_wk456_KoffieMachine
{
    public class Pay
    {
        public double Balance { get; set; }
        public double Price { get; set; }

        public Pay(double balance, double price)
        {
            Balance = balance;
            Price = price;
        }

       public string PayByCard(double cardBalance, double remainingPriceToPay)
        {
            double remainingBalance = cardBalance;
            if (Price <= Balance)
            {
                Balance = cardBalance - Price;
                Price = 0;
            }
            else // Pay what you can, fill up with coins later.
            {
                Balance = 0;

                Price -= Balance;
            }
            return $"Inserted {cardBalance.ToString("C", CultureInfo.CurrentCulture)}, Remaining: {Price.ToString("C", CultureInfo.CurrentCulture)}.";
      }

        public string PayWithCoins()
        {
            Price = Math.Max(Math.Round(Price - Balance, 2), 0);
            return $"Inserted {Balance.ToString("C", CultureInfo.CurrentCulture)}, Remaining: {Price.ToString("C", CultureInfo.CurrentCulture)}.";
        }
    }
    }

