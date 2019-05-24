using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildMaster
{
    public class Guild
    {
        public int money;
        public string name;
        public List<Item> inventory = new List<Item>();

        public List<Party> parties = new List<Party>();
        public List<AC> spares = new List<AC>();



        public Guild()
        {
            money = 100;
        }

        public Guild(string nm, int mon = 100)
        {
            name = nm;
            money = mon;
        }
    }
}
