using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain
{
    public class Cappuccino : Drink
    {
        public override string Name => "Capuccino";
        public virtual bool HasSugar { get; set; }
        public virtual Amount SugarAmount { get; set; }
        protected virtual Strength DrinkStrength { get; set; }

        public Cappuccino()
        {
            DrinkStrength = Strength.Normal;
        }

        public override double GetPrice()
        {
            if (HasSugar)
            return BaseDrinkPrice + 0.8 + Drink.SugarPrice;

            return BaseDrinkPrice + 0.8;
        }
        public override void LogDrinkMaking(ICollection<string> log)
        {
            base.LogDrinkMaking(log);
            base.DrinkStrength(log, DrinkStrength);

            if (HasSugar)
            {
                base.HasSugar(log, SugarAmount);
            }

            base.CreamingDrink(log);
        }
    }
}
