using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePrototype.Items.EquipItems
{
    public sealed class RangeWeapon: Weapon
    {
        public RangeWeapon (uint damage, uint durability, string name) : base(damage, durability, name) { }
    }
}
