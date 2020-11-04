using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tamagotchi_v1
{
    class Program
    {
        static void Main(string[] args)
        {
            var timer = new Timer(_ => Console.WriteLine("Every 2 seconds..", 2000, 40000));

            Console.WriteLine("hola");
            StartGame();
        }
        public static void CreateTamagotchi()
        {
            string name;
            string gender;
            Console.WriteLine("Name your tamagotchi now:");
            name = Console.ReadLine();
            Console.WriteLine("Choose sex: Male/Female:");
            gender = Console.ReadLine();

            Tamagotchi player = new Tamagotchi(name, gender);
            player.RunIntervals();
            player.ChooseAction();
        }
        public static void StartGame()
        {
            CreateTamagotchi();
        }
    }
}