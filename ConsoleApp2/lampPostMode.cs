using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueOfDraven
{
    class lampPostMode
    {
        static Random rand = new Random();
        public static void stageOne()
        {
            Console.WriteLine("Round 1");
            Console.WriteLine(" " + Program.summoner.name + " vs Draven the Grand Executioner");
            Console.WriteLine("Hint: When Dravens axes are spinning they deal massive damage. Try jumping on him immediately and stunning him ");
            Console.WriteLine("The battle has begun!");
            Console.ReadKey();
            levelOne("Draven", 60, 29, 574);
        }

        public static void levelOne(string summoner, int attackDamage, int armor, int hp)
        {
            while (hp > 0 && Program.summoner.hp > 0)
            {
                Console.Clear();
                Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
                Console.WriteLine("|(Q)Hit Draven hit an empowered strike                   |");
                Console.WriteLine("|(E)Stun Draven with your counter-strike attack.         |");
                Console.WriteLine("|(I)Run it down                                          |");
                Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++++++++");

                string choice = Console.ReadLine();
                int damage = attackDamage + rand.Next(30, 40) - Program.summoner.armor1;
                int attack = Program.summoner.attackDamage1 + rand.Next(30, 40) - armor;
                int stun = Program.summoner.stunDamage1 - armor;

                if (choice.ToLower() == "q")
                {
                    Console.WriteLine("You attack Draven with an empowered attack for " + attack + " damage");
                    Console.WriteLine("Draven fights back and hits you with two spinning axes for " + damage + " and " + damage + " damage");
                    Program.summoner.hp1 -= damage + damage;
                    hp -= attack;
                    Program.summoner.addDamageDelt(0, attack);
                    Program.summoner.addDamageTaken(0, damage + damage);
                    Console.WriteLine("Draven: " + hp + " hp\t" + Program.summoner.name + " : " + Program.summoner.hp1 + " hp");
                }
                else if (choice.ToLower() == "e")
                {
                    Console.WriteLine("Draven uses his blood lust ability to run you down, he deals " + damage + " damage");
                    Console.WriteLine("You close the distance enough to land your stun dealing " + stun + " damage");
                    Console.WriteLine("While stunned you hit draven with two additional attacks " + attack + " and " + attack + " damage");
                    Program.summoner.hp1 -= attack;
                    hp -= attack + attack + stun;
                    Program.summoner.addDamageDelt(0, attack + attack + stun);
                    Program.summoner.addDamageTaken(0, damage);
                    Console.WriteLine("Draven: " + hp + " hp\t" + Program.summoner.name + " : " + Program.summoner.hp1 + " hp");
                }
                else if (choice.ToLower() == "i")
                {
                    Console.WriteLine("You give up because Draven is so powerful and cool");
                    Console.WriteLine("While running it down, Draven throws two axes an enormous distance and executes you. ");
                    int combo = 1000;
                    Program.summoner.hp1 -= combo;
                    Program.summoner.addDamageTaken(0, combo);
                    Console.WriteLine("You suck!");
                }
                Console.ReadKey();
            }

            Console.Clear();

            if (Program.summoner.hp1 <= 0)
            {
                Console.WriteLine("You have died!");
                Console.WriteLine("Draven is the winner!");
                Program.endGame();
            }
            else
            {
                Console.WriteLine("Good job, you beat Draven!");
                Console.WriteLine("Prepare for the next round.");
                Console.ReadKey();
                Program.summoner.addDefeatedEnemy(0, "Draven");
                stageTwo();
            }
            Console.ReadKey();
        }

        public static void stageTwo()
        {
            Console.WriteLine("Round 2");
            Console.WriteLine(" " + Program.summoner.name + " vs Riven the Exile");
            Console.WriteLine("Hint: Riven is highly mobile, avoid her broken wings attack at all costs");
            Console.WriteLine("The battle has begun!");
            Console.ReadKey();
            levelTwo("Riven", 64, 33, 558);
        }

        public static void levelTwo(string summoner, int attackDamage, int armor, int hp)
        {
            if (Program.summoner.hp1 < 500)
            {
                Program.summoner.hp1 = 592;
            }
            while (hp > 0 && Program.summoner.hp1 > 0)
            {
                Console.Clear();
                Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
                Console.WriteLine("|(Q)Attack Riven using an empowered strike.                       |");
                Console.WriteLine("|(W)Close the distance and stun her.                              |");
                Console.WriteLine("|(I)Turret Dive her.                                              |");
                Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
                string choice = Console.ReadLine();
                int damage = attackDamage - Program.summoner.armor1;
                int brokenWings = attackDamage + 45 - Program.summoner.armor1;
                int attack = Program.summoner.attackDamage1 + rand.Next(10, 20) - armor;
                int stun = Program.summoner.stunDamage1 - armor;
                if (choice.ToLower() == "q")
                {
                    Console.WriteLine("You attack using an empowered strike " + attack + " damage");
                    Console.WriteLine("Riven uses her broken wings ability to slash you three times dealing " + brokenWings + " damage");
                    Program.summoner.hp1 -= brokenWings;
                    hp -= attack;
                    Program.summoner.addDamageDelt(1, attack);
                    Program.summoner.addDamageTaken(1, brokenWings);
                    Console.WriteLine("Riven: " + hp + " hp\t" + Program.summoner.name + " : " + Program.summoner.hp1 + " hp");
                }
                else if (choice.ToLower() == "w")
                {
                    Console.WriteLine("You jump on Riven with you leap strike. ");
                    Console.WriteLine("You are able to stun Riven and deal and two empowered attack dealing " + stun + attack + attack + " damage.");
                    Console.WriteLine("Riven manages to attack you once dealing " + damage + " damage");
                    Program.summoner.hp1 -= damage;
                    hp -= attack + attack + stun; ;
                    Program.summoner.addDamageDelt(1, stun + attack + attack);
                    Program.summoner.addDamageTaken(1, damage);
                    Console.WriteLine("Riven: " + hp + " hp\t" + Program.summoner.name + " : " + Program.summoner.hp1 + " hp");
                }
                else if (choice.ToLower() == "i")
                {
                    Console.WriteLine("You try to dive riven under her turret");
                    Console.WriteLine("She stuns you and you take multiple turret shots. Riven then executes you");
                    int combo = 1000;
                    Program.summoner.hp1 -= combo;
                    Program.summoner.addDamageTaken(1, combo);
                    Console.WriteLine("You suck");
                }
                Console.ReadKey();
            }
            Console.Clear();

            if (Program.summoner.hp1 <= 0)
            {
                Console.WriteLine("You have died!");
                Console.WriteLine("Riven is the winner!");
                Program.endGame();
            }
            else
            {
                Program.summoner.addDefeatedEnemy(1, "Riven");
                Console.WriteLine("Good job, you beat Riven!");
                Console.WriteLine("You have won the League of Draven.");
                Program.endGame();
                Console.ReadKey();
            }
            Console.ReadKey();

        }
    }


}
