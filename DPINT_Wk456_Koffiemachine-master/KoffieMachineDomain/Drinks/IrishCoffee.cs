using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain
{
    public class IrishCoffee : Drink
    {
        public override string Name => "Irish Coffee";
        
        public override double GetPrice()
        {           
            return BaseDrinkPrice + Drink.SugarPrice + Drink.WhiskyPrice + Drink.WhippedCreamPrice;           
        }

        public override void LogDrinkMaking(ICollection<string> log)
        {
            base.LogDrinkMaking(log);           
            base.HasSugar(log, Amount.Normal);
            log.Add("Adding whiskey...");
            log.Add("Gently adding whipped cream...");
        }
    }
}
