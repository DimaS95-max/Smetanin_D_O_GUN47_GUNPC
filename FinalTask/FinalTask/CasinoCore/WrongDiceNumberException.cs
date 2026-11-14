
/// Исключение, выбрасываемое при некорректном задании диапазона костей.

namespace FinalTask.CasinoCore
{

    public class WrongDiceNumberException : Exception
    {
        public WrongDiceNumberException(int number, int min, int max)
            : base($"Invalid dice number: {number}. Allowed range: {min} to {max}.")
        {
        }
    }
}