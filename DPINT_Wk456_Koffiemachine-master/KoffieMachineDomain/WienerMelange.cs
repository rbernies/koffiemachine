using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain
{
    public class WienerMelange : Capuccino
    {
        public override string Name => "Wiener Melange";

        public WienerMelange()
        {
            HasSugar = false;
            DrinkStrength = Strength.Weak;
        }

        public override double GetPrice()
        {
            return BaseDrinkPrice * 2;
        }
    }
}
