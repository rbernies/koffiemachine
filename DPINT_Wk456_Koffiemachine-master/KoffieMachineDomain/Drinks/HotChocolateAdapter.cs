using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeaAndChocoLibrary;

namespace KoffieMachineDomain
{
    public class HotChocolateAdapter: Drink
    {

        private HotChocolate chocolate;
        public override string Name => chocolate.GetNameOfDrink();

        public HotChocolateAdapter(bool deluxe)
        {
            chocolate = new HotChocolate();
            if (deluxe)
                chocolate.MakeDeluxe();
        }

        public override double GetPrice()
        {
            return chocolate.Cost();
        }

        public override void LogDrinkMaking(ICollection<string> log)
        {
            foreach(string s in chocolate.GetBuildSteps())
            {
                log.Add(s);
            }
        }
    }
}
