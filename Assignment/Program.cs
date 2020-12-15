using Assignment.Interface;
using Assignment.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            IGameService gameService = new GameService();
            gameService.Run();
            Console.ReadLine();
        }
    }
}
