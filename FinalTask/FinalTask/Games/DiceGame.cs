using FinalTask.CasinoCore.Models;

/// Реализация игры в кости.

namespace FinalTask.Games
{

    public class DiceGame : CasinoGameBase
    {
        private readonly int _diceCount;
        private readonly int _minValue;
        private readonly int _maxValue;
        private readonly List<Dice> _dices;
        private readonly Random _random;

        public DiceGame(int diceCount, int minValue, int maxValue)
        {
            if (diceCount < 1) throw new ArgumentException("Must have at least 1 dice.");
            _diceCount = diceCount;
            _minValue = minValue;
            _maxValue = maxValue;
            _random = new Random();
            _dices = new List<Dice>();
            FactoryMethod();
        }

        protected override void FactoryMethod()
        {
            _dices.Clear();
            for (int i = 0; i < _diceCount; i++)
            {
                _dices.Add(new Dice(_minValue, _maxValue));
            }
        }

        private int RollPlayer()
        {
            int sum = 0;
            foreach (var dice in _dices)
            {
                sum += dice.Number;
            }
            return sum;
        }

        public override void PlayGame()
        {
            int playerSum = RollPlayer();

            // Пересоздаем кости для компьютера, чтобы значения были случайными
            FactoryMethod();
            int dealerSum = RollPlayer();

            Console.WriteLine("\n--- Your roll ---");
            foreach (var dice in _dices) Console.Write($"{dice.Number} ");
            Console.WriteLine($"\nTotal: {playerSum}");

            // Пересоздаем для вывода дилера
            FactoryMethod();
            Console.WriteLine("\n--- Dealer roll ---");
            foreach (var dice in _dices) Console.Write($"{dice.Number} ");
            Console.WriteLine($"\nTotal: {dealerSum}");

            if (playerSum > dealerSum) OnWinInvoke(0);
            else if (dealerSum > playerSum) OnLooseInvoke(0);
            else OnDrawInvoke();
        }
    }
}
