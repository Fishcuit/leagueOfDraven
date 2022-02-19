// Programmer: Keith Wilcox
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueOfDraven
{
    class Program
    {
        public static Player summoner = new Player();

        static void Main(string[] args)
        {
            titleScreen(); // Calls main menu/title screen
        }

        public static void titleScreen()
        {

            Console.WriteLine("Welcome to the League of Draven!");
            Console.WriteLine("A competition in which only the strongest champions in Runeterra battle for supremacy ");
            Console.WriteLine("Press enter your name to continue");
            summoner.name = Console.ReadLine(); // Takes player name
            Console.Clear();
            chooseWeapon(); // Takes player to weapom choice menu
        }

        public static void chooseWeapon()
        {
            string choice;
            Console.WriteLine("What kind of weapon will you be using" + summoner.name + "? "); // Mode is selected based on weapon choice
            Console.WriteLine("1. Spinning Axes"); // axeMode
            Console.WriteLine("2. Poison Darts"); // Automatically lose with this option
            Console.WriteLine("3. A Lamp Post"); // lampPostMode

            Console.Write("Choice: "); // User input choice
            choice = Console.ReadLine();
            Console.Clear(); // Clear the console
            switch (choice) // Switch menu for weapon choice
            {
                case "1": // axemode
                    Console.WriteLine("You chose spinning axes!");
                    Console.WriteLine("King Draven would be proud");
                    Console.WriteLine("Spinning Axes are known to inflict high damage and pain!");
                    Console.WriteLine("Please go forth and make Noxus proud!");
                    Console.ReadLine();
                    axeMode.stageOne();
                    break;
                case "2": // darts mode. you lose
                    Console.WriteLine("You chose poison darts...");
                    Console.WriteLine("Its apparent you are a Teemo disciple...");
                    Console.WriteLine("Im calling the noxon gaurd you souless freak, you are DISQUALIFIED");
                    Console.WriteLine("You lost the game. Make better choices and dont play Teemo");
                    endGame();
                    Console.ReadLine();
                    break;
                case "3": // lamppost mode
                    Console.WriteLine("You chose a lamp post... ");
                    Console.WriteLine("What a strange choice of weapon...");
                    Console.WriteLine("Nevertheless I have seen stranger...");
                    Console.WriteLine("Best of luck to you in the League of Draven");
                    Console.ReadLine();
                    lampPostMode.stageOne();
                    break;
            }
        }

        public static void endGame() // End game display
        {
            Console.WriteLine("BATTLE STATS");
            Console.WriteLine("==================================");
            for (int i = 0; i < summoner.battleData.GetLength(0); i++) // Collects battle data throughout all battles 
            {
                Console.WriteLine("Battle " + (i + 1));
                Console.WriteLine("--------------");
                Console.WriteLine("Total Damage Delt: " + summoner.battleData[i, 0]); // Battle 1
                Console.WriteLine("Total Damage Taken: " + summoner.battleData[i, 1] + "\n"); // Battle 2
            }

            Console.WriteLine("\n\nDEFEATED ENEMIES"); // Uses a 1D array to show enemies deafeated
            Console.WriteLine("==================================");
            for (int i = 0; i < summoner.defeatedEnemies.Length; i++)
            {
                Console.WriteLine(summoner.defeatedEnemies[i]);
            }
        }
    }
}
