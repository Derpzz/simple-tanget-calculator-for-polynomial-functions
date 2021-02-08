using System;

namespace Tangentengleichung
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                InOut io = new InOut("Tangentengleichung einer ganzrationalen Funktion");
                Funktion.getTangete();
                if (stop(false))
                    return;
                Console.Clear();
            }
        }

        private static bool stop(bool force)
        {
            if (!force)
            {
                Console.WriteLine("\nBeliebige Taste zum Beenden drücken...\nW zum wiederholen drücken...");
                if (Console.ReadKey().Key == ConsoleKey.W)
                    return false;
            }
            return true;
        }
    }
}
