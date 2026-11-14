

/// Структура игральной кости.

namespace FinalTask.CasinoCore.Models
{

    public readonly struct Dice
    {
        private readonly int _min;
        private readonly int _max;
        private readonly Random _random;

        public int Number { get; }

        public Dice (int min, int max)
        {
            if (min < 1 || max > int.MaxValue || min > max)
            {
                throw new WrongDiceNumberException(min, 1, int.MaxValue);
            }

            _min = min;
            _max = max;
            _random = new Random();
            Number = _random.Next(_min, _max + 1);
        }
    }
}
