using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeaAndChocoLibrary;

namespace KoffieMachineDomain
{
    public class TeaAdapter: Drink
    {

        private Tea _tea;
        private bool _hasSugar = false;

        public TeaAdapter(bool hasSugar, TeaBlend selectedTeaBlend)
        {
            _hasSugar = hasSugar;
            _tea = new Tea();
            _tea.Blend = selectedTeaBlend;
        }

        public override string Name => _tea.Blend.Name;

        public override double GetPrice()
        {
            if (_hasSugar)
                return Tea.Price + Drink.SugarPrice;

            return Tea.Price;
        }

        
    }
}
