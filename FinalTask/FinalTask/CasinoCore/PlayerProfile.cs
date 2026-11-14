

/// Модель профиля игрока.

namespace FinalTask.CasinoCore
{
    public class PlayerProfile
    {
        public string Name { get; set; }
        public long Bank { get; set; }
        public const long MaxBank = 20_000;
    }
}
