﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Text.RegularExpressions;

namespace GuildMaster
{
    class Program
    {
        static void Main(string[] args)
        {
            System.IO.TextReader tr = new System.IO.StreamReader(@"MonsterTable.txt");

            List<NPC> npcList = new List<NPC>();
            string line;
            while ((line = tr.ReadLine()) != null)
            {
                /*extract:
                 * name
                 * hit die (a of adb + c)
                 * hit die number (b of adb + c)
                 * hit die bonus (c of adb + c)
                 * AC
                 * Attack name
                 * Attack to-hit mod
                 * Attack number of die
                 * Attack die number
                 * Attack bonus
                 * 
                 * 
                 * 
                 */
                
                if (line != "")
                {
                    NumberFormatInfo nfi = NumberFormatInfo.CurrentInfo;
                    string name = line.Split(':')[0];
                    string pattern = @"\d*[d]\d*(\s*["
                                        + Regex.Escape(nfi.PositiveSign + nfi.NegativeSign)
                                        + @"]\s*\d*)*";
                    Regex rx = new Regex(pattern);
                    MatchCollection matches = rx.Matches(line);
                    int hd = Convert.ToInt16(matches[0].ToString().Split('d')[0]);
                    int numHD = Convert.ToInt16(matches[0].ToString().Split('d')[1]);
                    int bonusHD = Convert.ToInt32(matches[0].ToString().Split('+')[1]);


                    int atkNum = Convert.ToInt16(matches[1].ToString().Split('d')[0]);
                    int atkDice = Convert.ToInt16(matches[1].ToString().Split('d')[1]);
                    int atkBonus = Convert.ToInt32(matches[1].ToString().Split('+')[1]);

                    string pattern2 = @"[AC]\s*\d*";
                    Regex rx2 = new Regex(pattern2);
                    int ac = Convert.ToInt32(rx2.Match(line).ToString().Split(' ')[1]);

                    string pattern3 = @"\w*\s+["
                                        + Regex.Escape(nfi.PositiveSign + nfi.NegativeSign)
                                        + @"]\d*";
                    Regex rx3 = new Regex(pattern3);
                    string atkName = rx3.Match(line).ToString().Split(' ')[0];
                    int atkToHitBonus = Convert.ToInt32(rx3.Match(line).ToString().Split('+')[1]);

                    npcList.Add(new NPC(name, hd, numHD, bonusHD, ac, atkToHitBonus, atkName, atkNum, atkDice, atkBonus));
                }
            }






                List<AC> initACs = new List<AC>();
            initACs.Add(new AC("WarriorOne", AC.Job.Warrior, AC.Race.Dwarf));
            initACs.Add(new AC("WarriorTwo", AC.Job.Warrior, AC.Race.Human));
            initACs.Add(new AC("RogueOne:AStarWarsStory", AC.Job.Rogue, AC.Race.Halfling));
            Party party = new Party(initACs);




            Console.ReadKey();
        }
    }
}
