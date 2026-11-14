using FinalTask.CasinoCore.Models;


/// Реализация игры Блэкджек.

namespace FinalTask.Games
{

    public class BlackjackGame : CasinoGameBase
    {
        private readonly int _cardsToDeal;
        private Queue<Card> _deck;
        private readonly List<Card> _playerHand = new();
        private readonly List<Card> _dealerHand = new();
        private readonly Random _random;

        public BlackjackGame(int cardsToDeal)
        {
            if (cardsToDeal < 2) throw new ArgumentException("Must deal at least 2 cards.");
            _cardsToDeal = cardsToDeal;
            _random = new Random();
            FactoryMethod();
        }

        protected override void FactoryMethod()
        {
            _deck = new Queue<Card>();
            var suits = (CardSuit[])Enum.GetValues(typeof(CardSuit));
            var values = (CardValue[])Enum.GetValues(typeof(CardValue));

            foreach (var suit in suits)
            {
                foreach (var value in values)
                {
                    // Для упрощения используем колоду из 32 карт (6, 7, 8, 9, 10, В, Д, К, Т)
                    if ((int)value >= 6)
                    {
                        _deck.Enqueue(new Card(suit, value));
                    }
                }
            }
            Shuffle();
        }

        private void Shuffle()
        {
            var temp = new List<Card>(_deck);
            _deck.Clear();
            while (temp.Count > 0)
            {
                int index = _random.Next(temp.Count);
                _deck.Enqueue(temp[index]);
                temp.RemoveAt(index);
            }
        }

        private int CalculateScore(List<Card> hand)
        {
            int score = 0;
            int aces = 0;
            foreach (var card in hand)
            {
                score += (int)card.Value;
                if (card.Value == CardValue.Ace) aces++;
            }

            while (score > 21 && aces > 0)
            {
                score -= 10;
                aces--;
            }
            return score;
        }

        private void DealCards()
        {
            _playerHand.Clear();
            _dealerHand.Clear();
            _playerHand.Add(_deck.Dequeue());
            _playerHand.Add(_deck.Dequeue());
            _dealerHand.Add(_deck.Dequeue());
            _dealerHand.Add(_deck.Dequeue());
        }

        public override void PlayGame()
        {
            DealCards();

            int playerScore = CalculateScore(_playerHand);
            int dealerScore = CalculateScore(_dealerHand);

            Console.WriteLine("\n--- Your cards ---");
            foreach (var card in _playerHand) Console.WriteLine(card);
            Console.WriteLine($"Total: {playerScore}");

            Console.WriteLine("\n--- Dealer cards ---");
            Console.WriteLine(_dealerHand[0]);
            Console.WriteLine("Hidden card");

            // Логика по ТЗ: если ничья (<21) — добор, иначе сравнение
            while (playerScore == dealerScore && playerScore < 21)
            {
                Console.WriteLine("\nScores are equal and less than 21. Drawing one more card each...");
                _playerHand.Add(_deck.Dequeue());
                _dealerHand.Add(_deck.Dequeue());
                playerScore = CalculateScore(_playerHand);
                dealerScore = CalculateScore(_dealerHand);

                Console.WriteLine("\n--- Your cards ---");
                foreach (var card in _playerHand) Console.WriteLine(card);
                Console.WriteLine($"Total: {playerScore}");
            }

            Console.WriteLine("\n--- Final Dealer cards ---");
            foreach (var card in _dealerHand) Console.WriteLine(card);
            Console.WriteLine($"Total: {dealerScore}");

            if (playerScore > 21 && dealerScore > 21) OnDrawInvoke();
            else if (playerScore <= 21 && (dealerScore > 21 || playerScore > dealerScore)) OnWinInvoke(0);
            else if (dealerScore <= 21 && (playerScore > 21 || dealerScore > playerScore)) OnLooseInvoke(0);
            else OnDrawInvoke();
        }
    }
}
