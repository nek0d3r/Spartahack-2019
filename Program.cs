using System;

namespace Spartahack_2019
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new Main())
                game.Run();
        }
    }
}
