using FinalTask.CasinoCore;
using FinalTask.Games;
using FinalTask.Services;

/// Основной класс казино, управляющий профилем и выбором игр.

namespace FinalTask.Casino
{

    public class Casino : IGame
    {
        private readonly string _savePath = "Saves";
        private readonly ISaveLoadService <PlayerProfile> _profileService;
        private PlayerProfile _player;
        private readonly BlackjackGame _blackjack;
        private readonly DiceGame _diceGame;
        private const long MinBet = 100;

        public Casino()
        {
            _profileService = new FileSystemSaveLoadService<PlayerProfile>(_savePath);
            _blackjack = new BlackjackGame(2);
            _diceGame = new DiceGame(2, 1, 6);
        }

        public void StartGame()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("Welcome to Final Task Casino!");
            LoadOrCreateProfile();

            if (_player.Bank < MinBet)
            {
                Console.WriteLine("No money? Kicked!");
                SaveProfile();
                return;
            }

            if (_player.Bank > PlayerProfile.MaxBank)
            {
                _player.Bank /= 2;
                Console.WriteLine("You wasted half of your bank money in casino's bar");
            }

            ChooseGame();
            SaveProfile();
            Console.WriteLine("Session ended. Goodbye!");
        }

        private void LoadOrCreateProfile()
        {
            _player = _profileService.LoadData("player_profile");
            if (_player == null!)
            {
                Console.Write("Enter your name: ");
                string name = Console.ReadLine() ?? "Player";
                _player = new PlayerProfile { Name = name, Bank = 10000 };
                Console.WriteLine($"Welcome, {_player.Name}! Your starting bank is {_player.Bank}.");
            }
            else
            {
                Console.WriteLine($"Welcome back, {_player.Name}! Your current bank is {_player.Bank}.");
            }
        }

        private void SaveProfile()
        {
            _profileService.SaveData(_player, "player_profile");
        }

        private void ChooseGame()
        {
            Console.WriteLine("\nChoose your game:");
            Console.WriteLine("1. Blackjack");
            Console.WriteLine("2. Dice");
            Console.Write("Enter number: ");

            if (!int.TryParse(Console.ReadLine(), out int choice) || (choice != 1 && choice != 2))
            {
                Console.WriteLine("Invalid choice.");
                return;
            }

            Console.Write($"Enter your bet (Min {MinBet}, Max {_player.Bank}): ");
            if (!long.TryParse(Console.ReadLine(), out long bet) || bet < MinBet || bet > _player.Bank)
            {
                Console.WriteLine("Invalid bet.");
                return;
            }

            long stake = bet;

            CasinoGameBase game = choice == 1 ? _blackjack : _diceGame;

            game.OnWin += amount =>
            {
                _player.Bank += stake;
                Console.WriteLine($"You won! + {stake}");
            };
            game.OnLoose += amount =>
            {
                _player.Bank -= stake;
                Console.WriteLine($"You lost. - {stake}");
            };
            game.OnDraw += () =>
            {
                Console.WriteLine("It's a draw. Bet returned.");
            };

            game.PlayGame();

            HandleBankLimits();
        }

        private void HandleBankLimits()
        {
            if (_player.Bank <= 0)
            {
                Console.WriteLine("No money? Kicked!");
                _player.Bank = 0;
            }
            else if (_player.Bank > PlayerProfile.MaxBank)
            {
                long overflow = _player.Bank - PlayerProfile.MaxBank;
                _player.Bank = PlayerProfile.MaxBank;
                Console.WriteLine($"You ruined the casino by {overflow}; a new one will be built in your place.");
                Console.WriteLine("You wasted half of your bank money in casino’s bar");
            }
        }
    }
}
