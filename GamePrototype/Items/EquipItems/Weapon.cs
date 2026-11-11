using GamePrototype.Utils;

namespace GamePrototype.Items.EquipItems
{
    public abstract class Weapon : EquipItem
    {
        public Weapon(uint damage, uint durability, string name) : base(durability, name) => Damage = damage;

        public uint Damage { get; }

        public override EquipSlot Slot => EquipSlot.Weapon;
    }
}
