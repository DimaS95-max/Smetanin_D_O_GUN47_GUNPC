using GamePrototype.Items.EconomicItems;
using GamePrototype.Items.EquipItems;
using GamePrototype.Units;

namespace GamePrototype.Utils
{
    public class UnitFactoryDemo2 : UnitFactory
    {
        public override Unit CreatePlayer(string name)
        {
            var player = new Player(name, 25, 25, 4);
            player.AddItemToInventory(new RangeWeapon (5, 15, "RangeWeapon"));
            player.AddItemToInventory(new Helmet (5, 15, "Helmet"));
            player.AddItemToInventory(new HealthPotion("Potion"));
            return player;
        }

        public override Unit CreateGoblinEnemy() => new Goblin(GameConstants.Goblin, 20, 20, 4);
    }
}
