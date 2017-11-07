using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM_07
{
    class MUnit
    {
        public int id;
        public int part1;
        public int part2;
        public int strength;
        public int tempstrength;
        public MUnit(int i)
        {
            id = i;
            part1 = part2 = -1;
            strength = 0;
            tempstrength = 0;
        }
        public MUnit(int id, int p1,int p2)
        {
            this.id = id;
            part1 = p1;
            part2 = p2;
            strength = 0;
            tempstrength = 0;
        }
        public void addStrength()
        {
            strength++;
        }
        public void setTempStrength(int num)
        {
            tempstrength += num;
        }
    }
}
