using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePrototype.Items.EquipItems
{
    public sealed class Helmet : Armour
    {
        public Helmet(uint defence, uint durability, string name) : base(defence, durability, name) {}
    }
}
