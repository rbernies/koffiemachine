using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain
{
    public abstract class Drink: IDrink
    {
        public static readonly double SugarPrice = 0.1;
        public static readonly double MilkPrice = 0.15;

        protected const double BaseDrinkPrice = 1.0;
        
        public abstract string Name { get; }
        public abstract double GetPrice();

        public virtual void LogDrinkMaking(ICollection<string> log)
        {
            log.Add($"Making {Name}...");
            log.Add($"Heating up...");
        }

        public virtual void HasSugar(ICollection<string> log, Amount sugarAmount)
        {
            log.Add($"Setting sugar amount to {sugarAmount}.");
            log.Add("Adding sugar...");
        }

        public void HasMilk(ICollection<string> log, Amount milkAmount)
        {
            log.Add($"Setting milk amount to {milkAmount}.");
            log.Add("Adding milk...");
        }

        public void DrinkStrength(ICollection<string> log, Strength strength)
        {
            log.Add($"Setting coffee strength to {strength}.");
            log.Add("Filling with coffee...");
        }

        public void CreamingDrink(ICollection<string> log)
        {
            log.Add("Creaming milk...");
            log.Add("Adding milk to coffee...");
        }

        public void FinishDrink(ICollection<string> log)
        {
            log.Add($"Finished making {Name}");
        }
    }
}
