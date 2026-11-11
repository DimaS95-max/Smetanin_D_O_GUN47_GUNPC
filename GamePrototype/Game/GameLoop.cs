using GamePrototype.Combat;
using GamePrototype.Dungeon;
using GamePrototype.Units;
using GamePrototype.Utils;

namespace GamePrototype.Game
{
    public sealed class GameLoop
    {
        private Unit _player;
        private DungeonRoom _dungeon;
        private Complexity _complexity;
        private readonly CombatManager _combatManager = new CombatManager();
        
        public void StartGame() 
        {
            Initialize();
            Console.WriteLine("Entering the dungeon");
            StartGameLoop();
        }

        #region Game Loop

        private void Initialize()
        {
            Console.WriteLine("Welcome, player!");
            Console.WriteLine("Enter your name");
            string? name = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(name))
            {

                Console.WriteLine("Некорректное имя. Попробуйте ещё раз.");
                name = Console.ReadLine();
            }

            Console.WriteLine($"Hello {name}");
            Console.WriteLine("Введите сложность (Easy/Hard)");

            while (true)
            {
                // Проверяем ввод с помощью TryParse и IsDefined
                if (Enum.TryParse<Complexity>(Console.ReadLine(), true, out var complexity) && Enum.IsDefined(typeof(Complexity), complexity))
                {
                    // Ввод корректен — можно использовать значение _complexity
                    _complexity=complexity;
                    break;
                }
                else
                {
                    Console.WriteLine("Неверный ввод. Пожалуйста, введите снова.");
                }
            }

            switch (_complexity)
                    {
                        case Complexity.Easy:
                            _dungeon = new DungeonBuilder().BuildDungeon();
                            _player = new UnitFactoryDemo().CreatePlayer(name);
                            break;
                        case Complexity.Hard:
                            _dungeon = new DungeonBuilder2().BuildDungeon();
                            _player = new UnitFactoryDemo2().CreatePlayer(name);
                            break;

                        default:
                            Console.WriteLine("Unknown complexity level.");
                            break;

                    }

            
        }

        private void StartGameLoop()
        {
            var currentRoom = _dungeon;
            
            while (currentRoom.IsFinal == false) 
            {
                StartRoomEncounter(currentRoom, out var success);
                if (!success) 
                {
                    Console.WriteLine("Game over!");
                    return;
                }
                DisplayRouteOptions(currentRoom);
                while (true) 
                {
                    if (Enum.TryParse<Direction>(Console.ReadLine(), out var direction) ) 
                    {
                        currentRoom = currentRoom.Rooms[direction];
                        break;
                    }
                    else 
                    {
                        Console.WriteLine("Wrong direction!");
                    }
                }
            }
            Console.WriteLine($"Congratulations, {_player.Name}");
            Console.WriteLine("Result: ");
            Console.WriteLine(_player.ToString());
        }

        private void StartRoomEncounter(DungeonRoom currentRoom, out bool success)
        {
            success = true;
            if (currentRoom.Loot != null) 
            {
                _player.AddItemToInventory(currentRoom.Loot);
            }
            if (currentRoom.Enemy != null) 
            {
                if (_combatManager.StartCombat(_player, currentRoom.Enemy) == _player)
                {
                    _player.HandleCombatComplete();
                    LootEnemy(currentRoom.Enemy);
                }
                else 
                {
                    success = false;
                }
            }

            void LootEnemy(Unit enemy)
            {
                _player.AddItemsFromUnitToInventory(enemy);
            }
        }

        private void DisplayRouteOptions(DungeonRoom currentRoom)
        {
            Console.WriteLine("Where to go?");
            foreach (var room in currentRoom.Rooms)
            {
                Console.Write($"{room.Key} - {(int) room.Key}\t");
            }
        }

        
        #endregion
    }
}
