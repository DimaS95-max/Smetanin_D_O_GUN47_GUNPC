

/// Абстрактный базовый класс для всех игр казино.

namespace FinalTask.Games
{

    public abstract class CasinoGameBase
    {
        public event Action<long>? OnWin;
        public event Action<long>? OnLoose;
        public event Action? OnDraw;

        protected void OnWinInvoke(long amount) => OnWin?.Invoke(amount);
        protected void OnLooseInvoke(long amount) => OnLoose?.Invoke(amount);
        protected void OnDrawInvoke() => OnDraw?.Invoke();

        protected abstract void FactoryMethod();
        public abstract void PlayGame();
    }
}
