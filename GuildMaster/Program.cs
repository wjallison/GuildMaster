using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildMaster
{
    class Program
    {
        static void Main(string[] args)
        {


            List<AC> initACs = new List<AC>();
            initACs.Add(new AC("WarriorOne", AC.Job.Warrior, AC.Race.Dwarf));
            initACs.Add(new AC("WarriorTwo", AC.Job.Warrior, AC.Race.Human));
            initACs.Add(new AC("RogueOne:AStarWarsStory", AC.Job.Rogue, AC.Race.Halfling));
            Party party = new Party(initACs);




            Console.ReadKey();
        }
    }
}
