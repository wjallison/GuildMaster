using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildMaster
{
    public class Dungeon
    {
        public List<Room> rooms = new List<Room>();
        public int level;
        public string name;
        public int reward;

        public Dungeon(int lvl)
        {
            level = lvl;
        }
    }

    public class Room
    {
        public List<Item> loot = new List<Item>();
        public List<NPC> enemies = new List<NPC>();
        public int encounterLevels;
    }
}
