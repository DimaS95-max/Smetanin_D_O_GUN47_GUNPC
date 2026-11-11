using GamePrototype.Items.EconomicItems;
using GamePrototype.Items.EquipItems;
using GamePrototype.Units;

namespace GamePrototype.Utils
{
    public class UnitFactoryDemo: UnitFactory
    {
        public override Unit CreatePlayer (string name)
        {
            var player = new Player(name, 30, 30, 6);
            player.AddItemToInventory(new RangeWeapon (10, 15, "RangeWeapon"));
            player.AddItemToInventory(new Helmet (10, 15, "Helmet"));
            player.AddItemToInventory(new HealthPotion("Potion"));
            return player;
        }

        public override Unit CreateGoblinEnemy() => new Goblin(GameConstants.Goblin, 18, 18, 2);
    }
}
