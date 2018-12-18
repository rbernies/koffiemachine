using KoffieMachineDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dpint_wk456_KoffieMachine
{
    public class CoffeeFactory
    {
        private bool _hasSugar = false;
        private bool _hasMilk = false;

        public CoffeeFactory()
        {
        }

        public Drink SelectCoffee(string coffee, Strength coffeeStrength, Amount sugarAmount, Amount milkAmount)
        {
            // else required to reset the bool to false if appropriate, otherwise bool would stay stuck on true for the next order
            if (coffee.Contains("Sugar"))
            {
                _hasSugar = true;
            } else {_hasSugar = false; }

            if (coffee.Contains("Milk"))
            {
                _hasMilk = true;
            }
            else { _hasMilk = false; }

            string coffeeOfChoice;
            coffeeOfChoice = coffee.Replace("Sugar", "");
            coffeeOfChoice = coffeeOfChoice.Replace("Milk", "");

            switch (coffeeOfChoice)
            {
                case "Coffee":
                    return new Coffee() { DrinkStrength = coffeeStrength, HasSugar = _hasSugar, SugarAmount = sugarAmount, HasMilk = _hasMilk, MilkAmount = milkAmount };
                case "Espresso":
                    return new Espresso() { HasSugar = _hasSugar, SugarAmount = sugarAmount, HasMilk = _hasMilk, MilkAmount = milkAmount };
                case "Cappuccino":
                    return new Cappuccino() { HasSugar = _hasSugar, SugarAmount = sugarAmount };
                case "Wiener Melange":
                    return new WienerMelange() { HasSugar = _hasSugar, SugarAmount = sugarAmount };
                default:
                    return null;
            }           
        }

        public string GetSugarMilkInfo()
        {
            if (_hasSugar && _hasMilk)
                return "with sugar and milk";

            if (_hasSugar)
                return "with sugar";

            if (_hasMilk)
                return "with milk";

            return "";
        }
    }
}
