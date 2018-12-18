using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain
{
    public abstract class Drink
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
    }
}
