using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeaAndChocoLibrary;

namespace KoffieMachineDomain.Drinks
{
    public class CoffeeChoc : Drink
    {

        private HotChocolate _chocolate;
        public override string Name => "CoffeeChoc";

        public CoffeeChoc()
        {
            _chocolate = new HotChocolate();
        }

        public override double GetPrice()
        {
            return BaseDrinkPrice + _chocolate.Cost();
        }

        public override void LogDrinkMaking(ICollection<string> log)
        {
            string[] chocLog = _chocolate.GetBuildSteps().Cast<string>().ToArray();
            log.Add("Filling with coffee...");
            for (int i = 0; i < 2; i++)
            {
                log.Add(chocLog[i]);
            }         
        }
    }
}
