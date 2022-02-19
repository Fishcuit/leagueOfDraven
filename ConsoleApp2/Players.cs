using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueOfDraven
{
    class Player
    {
        public string name;
        // Axe stats
        public int attackDamage = 60;
        public int stunDamage = 75;
        public int armor = 29;
        public int hp = 574;

        public string[] defeatedEnemies;
        public int[,] battleData; //first is battle number, second is damage delt and damage taken
        //lamp post stats
        public int attackDamage1 = 68;
        public int armor1 = 36;
        public int hp1 = 592;
        public int stunDamage1 = 55;


        public Player()
        {
            defeatedEnemies = new string[2];
            defeatedEnemies[0] = "NOT ENCOUNTERED OR DEFEATED";
            defeatedEnemies[1] = "NOT ENCOUNTERED OR DEFEATED";
            battleData = new int[2, 2];
        }

        public void addDamageDelt(int battleNum, int amount) // collects damage dealt 
        {
            battleData[battleNum, 0] += amount;
        }

        public void addDamageTaken(int battleNum, int amount) // collects damage taken
        {
            battleData[battleNum, 1] += amount;
        }

        public void addDefeatedEnemy(int index, string name) // collects deafeated enemies
        {
            defeatedEnemies[index] = name;
        }
    }
}
