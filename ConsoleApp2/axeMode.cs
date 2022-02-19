using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueOfDraven
{
    class axeMode
    {
        static Random rand = new Random(); // Random number generator
        public static void stageOne()
        {
            Console.WriteLine("Round 1");
            Console.WriteLine(" " + Program.summoner.name + " vs Jax the Grandmaster at Arms");
            Console.WriteLine("Hint: Dont allow Jax to get to close, keep him at a distance using stuns and slows. ");
            Console.WriteLine("The battle has begun!");
            Console.ReadKey();
            levelOne("Jax", 68, 36, 592); // opponent name, attack damage, armor, hp
        }

        public static void levelOne(string summoner, int attackDamage, int armor, int hp)
        {
            while (hp > 0 && Program.summoner.hp > 0) // this loop keeps running till the player or enemy dies
            {
                Console.Clear();
                //Battle Menu
                Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
                Console.WriteLine("|(Q)Attack Jax using your spinning axes.                |");
                Console.WriteLine("|(E)Stun Jax by throwing two axes simultaneously.       |");
                Console.WriteLine("|(I)Intimidate Jax with spinning axe tricks.            |");
                Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++++++++");

                string choice = Console.ReadLine();
                int damage = attackDamage - Program.summoner.armor; // damage enemy deals
                int empoweredStrike = attackDamage + 40 - Program.summoner.armor; // special attack by enemy
                int attack = Program.summoner.attackDamage + rand.Next(10, 20) - armor; // damage player deals
                int stun = Program.summoner.stunDamage - armor; // stun attack by player

                if (choice.ToLower() == "q")
                {
                    Console.WriteLine("You attack using your spinning axes and deal " + attack + " damage");
                    Console.WriteLine("Jax uses his counter-strike to bash you in the face dealing " + damage + " damage");
                    Program.summoner.hp -= damage; // Subtracts damage taken from player
                    hp -= attack; // Subtracts damage taken from enemy
                    Program.summoner.addDamageDelt(0, attack); // sends data to be displayed at end of game
                    Program.summoner.addDamageTaken(0, damage); // same ^^^
                    // Display player hp and enemy hp at end of every fight
                    Console.WriteLine("Jax: " + hp + " hp\t" + Program.summoner.name + " : " + Program.summoner.hp + " hp");
                }
                else if (choice.ToLower() == "e") // More of the same from above. 
                {
                    Console.WriteLine("Jax attacks using an empowered strike dealing " + empoweredStrike + "damage");
                    Console.WriteLine("You throw out both axes in a manner that disorients and confuses Jax dealing " + stun + "damage");
                    Console.WriteLine("While Jax is disoriented you are able to attack two additional times dealing " + attack + " and " + attack + " damage");
                    Program.summoner.hp -= empoweredStrike;
                    hp -= attack + attack + stun;
                    Program.summoner.addDamageDelt(0, attack + attack + stun);
                    Program.summoner.addDamageTaken(0, empoweredStrike);
                    Console.WriteLine("Jax: " + hp + " hp\t" + Program.summoner.name + " : " + Program.summoner.hp + " hp");
                }
                else if (choice.ToLower() == "i") // End game option. You will lose if you choose this.
                {
                    Console.WriteLine("You attempt to intimidate Jax with Axe tricks, however, Jax is a master duelist and is not intimidated");
                    Console.WriteLine("Jax activates Grandmasters Might ability and uses his leap strike to jump at you");
                    int combo = 1000;
                    Program.summoner.hp -= combo;
                    Program.summoner.addDamageTaken(0, combo);
                    Console.WriteLine("Due to your cocky attitude, Jax executes his full combo on you and you die");
                }
                Console.ReadKey();
            }

            Console.Clear();

            if (Program.summoner.hp <= 0) // if player dies 
            {
                Console.WriteLine("You have died!");
                Console.WriteLine("Jax is the winner!");
                Program.endGame();
            }
            else // if players wins
            {
                Console.WriteLine("Good job, you beat Jax!");
                Console.WriteLine("Prepare for the next round.");
                Console.ReadKey();
                Program.summoner.addDefeatedEnemy(0, "Jax"); // adds jax to list of defeated enemies.
                stageTwo(); // move on to stage 2
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
        // The next level is basically the same idea as above so Im not gonna comment everything =)
        public static void levelTwo(string summoner, int attackDamage, int armor, int hp)
        {
            if (Program.summoner.hp < 200) // used this to reset player hp to full. Not sure if there is a better way I coulda done this
            {
                Program.summoner.hp = 574;
            }
            while (hp > 0 && Program.summoner.hp > 0)
            {
                Console.Clear();
                Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
                Console.WriteLine("|(Q)Attack Riven using your spinning axes.                        |");
                Console.WriteLine("|(W)Activate blood rush ability to gain movement and attack speed.|");
                Console.WriteLine("|(I)ntimidate Riven with spinning axe tricks.                     |");
                Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
                string choice = Console.ReadLine();
                int damage = attackDamage - Program.summoner.armor;
                int brokenWings = attackDamage + 45 - Program.summoner.armor;
                int attack = Program.summoner.attackDamage + rand.Next(10, 20) - armor;
                int stun = Program.summoner.stunDamage - armor;
                if (choice.ToLower() == "q")
                {
                    Console.WriteLine("You attack using your spinning axes and deal " + attack + " damage");
                    Console.WriteLine("Riven uses her broken wings ability to slash you three times dealing " + brokenWings + " damage");
                    Program.summoner.hp -= brokenWings;
                    hp -= attack;
                    Program.summoner.addDamageDelt(1, attack);
                    Program.summoner.addDamageTaken(1, brokenWings);
                    Console.WriteLine("Riven: " + hp + " hp\t" + Program.summoner.name + " : " + Program.summoner.hp + " hp");
                }
                else if (choice.ToLower() == "w")
                {
                    Console.WriteLine("Rivens attempts to close the distance ");
                    Console.WriteLine("Your blood lust ability grants movement speed and attack speed allowing you to evade her attacks");
                    Console.WriteLine("While Riven is retreating you are able to attack twice dealing " + attack + " and " + attack + " damage");
                    Console.WriteLine("During the trade Riven manages to get an attack off dealing " + damage + " damage");
                    Program.summoner.hp -= damage;
                    hp -= attack + attack + stun; ;
                    Program.summoner.addDamageDelt(1, attack + attack);
                    Program.summoner.addDamageTaken(1, damage);
                    Console.WriteLine("Riven: " + hp + " hp\t" + Program.summoner.name + " : " + Program.summoner.hp + " hp");
                }
                else if (choice.ToLower() == "i")
                {
                    Console.WriteLine("Rivens appear to be intimidated by your axe tricks and begins to retreat");
                    Console.WriteLine("In a split second Rivens broken blade is instantly whole again, she turns on you and executes a full combo");
                    int combo = 1000;
                    Program.summoner.hp -= combo;
                    Program.summoner.addDamageTaken(1, combo);
                    Console.WriteLine("Due to your cocky attitude, Riven executes her full combo on you and you die");
                }
                Console.ReadKey();
            }
            Console.Clear();

            if (Program.summoner.hp <= 0)
            {
                Console.WriteLine("You have died!");
                Console.WriteLine("Riven is the winner!");
                Program.endGame();
            }
            else
            {
                Program.summoner.addDefeatedEnemy(1, "Riven"); // Add riven to deafeated enemies
                Console.WriteLine("Good job, you beat Riven!");
                Console.WriteLine("You have won the League of Draven."); //You WON
                Program.endGame();
                Console.ReadKey();
            }
            Console.ReadKey();

        }
    }


}
