

/// Структура игральной карты.

namespace FinalTask.CasinoCore.Models
{

    public readonly struct Card
    {
        public CardSuit Suit { get; }
        public CardValue Value { get; }

        public Card (CardSuit suit, CardValue value)
        {
            Suit = suit;
            Value = value;
        }

        public override string ToString()
        {
            return $"{Value} of {Suit}";
        }
    }
}
