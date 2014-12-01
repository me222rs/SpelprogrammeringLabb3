#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using Labb3Uppgift1.Content.Controller;
#endregion

namespace Labb3Uppgift1
{
#if WINDOWS || LINUX
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (var game = new Game1())
                game.Run();
        }
    }
#endif
}
