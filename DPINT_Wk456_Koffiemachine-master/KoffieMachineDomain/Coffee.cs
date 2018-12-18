using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain
{
    public class Coffee : Drink
    {
        
        public virtual bool HasSugar { get; set; }
        public virtual Amount SugarAmount { get; set; }
        public virtual bool HasMilk { get; set; }
        public virtual Amount MilkAmount { get; set; }
        public virtual Strength DrinkStrength { get; set; }

        public override string Name => "Coffee";

        public override double GetPrice()
        {          
            if (HasMilk && HasSugar)
                return BaseDrinkPrice + Drink.SugarPrice + Drink.MilkPrice;

            if (HasSugar)
                return BaseDrinkPrice + Drink.SugarPrice;

            if (HasMilk)
                return BaseDrinkPrice + Drink.MilkPrice;

            return BaseDrinkPrice;
        }

        public override void LogDrinkMaking(ICollection<string> log)
        {
            base.LogDrinkMaking(log);
            base.DrinkStrength(log, DrinkStrength);

            if (HasSugar)
            {
                base.HasSugar(log, SugarAmount);
            }

            if (HasMilk)
            {
                base.HasMilk(log, MilkAmount);
            }
        }
    }
}
