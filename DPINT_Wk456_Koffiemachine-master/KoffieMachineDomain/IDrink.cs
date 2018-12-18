using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain
{
    public interface IDrink
    {

        double GetPrice();

        void LogDrinkMaking(ICollection<string> log);

        void HasSugar(ICollection<string> log, Amount sugarAmount);

        void HasMilk(ICollection<string> log, Amount milkAmount);

        void DrinkStrength(ICollection<string> log, Strength level);

    }
}
