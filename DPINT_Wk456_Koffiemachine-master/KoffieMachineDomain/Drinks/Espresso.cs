using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain
{
    public class Espresso : Drink
    {
        public override string Name => "Espresso";
        public virtual bool HasSugar { get; set; }
        public virtual Amount SugarAmount { get; set; }
        public virtual bool HasMilk { get; set; }
        public virtual Amount MilkAmount { get; set; }

        public override double GetPrice()
        {
            if (HasMilk && HasSugar)
                return BaseDrinkPrice + 0.7 + Drink.SugarPrice + Drink.MilkPrice;

            if (HasSugar)
                return BaseDrinkPrice + 0.7 + Drink.SugarPrice;

            if (HasMilk)
                return BaseDrinkPrice + 0.7 + Drink.MilkPrice;

            return BaseDrinkPrice + 0.7;
        }

        public override void LogDrinkMaking(ICollection<string> log)
        {
            base.LogDrinkMaking(log);        
            log.Add($"Setting coffee amount to {Amount.Few}.");
            base.DrinkStrength(log, Strength.Strong);

            if (HasSugar)
            {
                base.HasSugar(log, SugarAmount);
            }

            base.CreamingDrink(log);
        }
    }
}
