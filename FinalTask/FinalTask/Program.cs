

namespace FinalTask.Casino
{

    class Program
    {
        static void Main(string[] args)
        {
            IGame casino = new Casino();
            casino.StartGame();
        }
    }
}
