using GamePrototype.Items.EconomicItems;
using GamePrototype.Items.EquipItems;
using GamePrototype.Utils;
using System.Text;

namespace GamePrototype.Units
{
    public sealed class Player : Unit
    {
        private readonly Dictionary<EquipSlot, EquipItem> _equipment = new();

        public Player(string name, uint health, uint maxHealth, uint baseDamage) : base(name, health, maxHealth, baseDamage)
        {            
        }

        public override uint GetUnitDamage()
        {
            if (_equipment.TryGetValue(EquipSlot.Weapon, out var item) && item is Weapon weapon) 
            {
                return BaseDamage + weapon.Damage;
            }
            return BaseDamage;
        }

        public override void HandleCombatComplete()
        {
            var items = Inventory.Items;
            for (int i = 0; i < items.Count; i++) 
            {
                if (items[i] is HealthPotion economicItem) 
                {
                    UseEconomicItem(economicItem);
                    Inventory.TryRemove(items[i]);
                }
                if (items[i] is Grindstone grindstone && (_equipment.TryGetValue(EquipSlot.Weapon, out var item) && item is RangeWeapon weapon))
                {
                    weapon.Repair(grindstone.GrindstoneRestore);
                    Inventory.TryRemove(items[i]);
                }
                if (items[i] is RangeWeapon rangeWeapon)
                {
                    AddWeapon(EquipSlot.Weapon, rangeWeapon);
                    Inventory.TryRemove(items[i]);
                }
                if (items[i] is Helmet helmet)
                {
                    AddWeapon(EquipSlot.Armour, helmet);
                    Inventory.TryRemove(items[i]);
                }

            }
        }

        public override void AddItemToInventory(Item item)
        {
            if (item is EquipItem equipItem && _equipment.TryAdd(equipItem.Slot, equipItem)) 
            {
                // Item was equipped
                return;
            }
            base.AddItemToInventory(item);
        }

        // Метод для добавления/замены оружия в слот
        public void AddWeapon(EquipSlot slot, EquipItem item)
        {
            if (!_equipment.ContainsKey(slot))
            {
                _equipment.Add(slot, item);
                Console.WriteLine("Оружие добавлено в слот");
            }
            else
            {
                _equipment[slot] = item;
                Console.WriteLine("Оружие успешно заменено");
            }
        }

        // Метод для добавления/замены брони в слот
        public void AddArmour(EquipSlot slot, EquipItem item)
        {
            if (!_equipment.ContainsKey(slot))
            {
                _equipment.Add(slot, item);
                Console.WriteLine("Броня добавлена в слот");
            }
            else
            {
                _equipment[slot] = item;
                Console.WriteLine("Броня успешно заменена");
            }
        }

        private void UseEconomicItem(EconomicItem economicItem)
        {
            if (economicItem is HealthPotion healthPotion) 
            {
                Health += healthPotion.HealthRestore;
            }
        }

        protected override uint CalculateAppliedDamage(uint damage)
        {
            if (_equipment.TryGetValue(EquipSlot.Armour, out var item) && item is Armour armour) 
            {
                damage -= (uint)(damage * (armour.Defence / 100f));
            }
            return damage;
        }
        protected override void ReductionInStrength()
        {
            if (_equipment.TryGetValue(EquipSlot.Armour, out var item) && item is Armour armour)
            {
                armour.ReduceDurability(1);
            }
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine(Name);
            builder.AppendLine($"Health {Health}/{MaxHealth}");
            builder.AppendLine("Loot:");
            var items = Inventory.Items;
            for (int i = 0; i < items.Count; i++) 
            {
                builder.AppendLine($"[{items[i].Name}] : {items[i].Amount}");
            }
            return builder.ToString();
        }
    }
}
