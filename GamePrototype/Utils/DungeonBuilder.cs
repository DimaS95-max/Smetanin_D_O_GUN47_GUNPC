using GamePrototype.Dungeon;
using GamePrototype.Items.EconomicItems;
using GamePrototype.Items.EquipItems;

namespace GamePrototype.Utils
{
    public sealed class DungeonBuilder:Dungeons
    {
        public override DungeonRoom BuildDungeon()
        {
            var enter = new DungeonRoom("Enter");
            var monsterRoom = new DungeonRoom("Monster", new UnitFactoryDemo().CreateGoblinEnemy());
            var emptyRoom = new DungeonRoom("Empty");
            var lootRoom = new DungeonRoom("Loot1", new Gold());
            var lootStoneRoom = new DungeonRoom("Loot1", new Grindstone("Stone"));
            var helmet = new DungeonRoom("Loot1", new Helmet (20,15,"Helmet"));
            var rangeWeapon = new DungeonRoom("Loot1", new RangeWeapon (20, 15, "Helmet"));
            var finalRoom = new DungeonRoom("Final", new Grindstone("Stone1"));

            enter.TrySetDirection(Direction.Right, monsterRoom);
            enter.TrySetDirection(Direction.Left, emptyRoom);

            monsterRoom.TrySetDirection(Direction.Forward, lootRoom);
            monsterRoom.TrySetDirection(Direction.Left, emptyRoom);
            monsterRoom.TrySetDirection(Direction.Right, helmet);

            emptyRoom.TrySetDirection(Direction.Forward, lootStoneRoom);
            emptyRoom.TrySetDirection(Direction.Right, rangeWeapon);

            lootRoom.TrySetDirection(Direction.Forward, finalRoom);
            lootStoneRoom.TrySetDirection(Direction.Forward, finalRoom);

            return enter;
        }
    }
}
