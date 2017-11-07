using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM_07
{
    class Machine
    {
        public static int MAXUNITNUM = 50000;
        public static int UNITCLEARWAITTIME = 200;
        public const int WILDCARD = 0;
        public const int PLEASURE = 1;
        public const int END = 2;

        public bool[] unitidlist;
        public MUnit[] unit;

        public List<int> happened;
        //public List<int> happening;
        //public List<int> predict;

        public int clearnum = 0;

        public Machine()
        {
            unitidlist = new bool[MAXUNITNUM];
            unitidlist[WILDCARD] = true;
            unitidlist[PLEASURE] = true;
            unitidlist[END] = true;
            unit = new MUnit[MAXUNITNUM];
            for (int i = 0; i < unit.Length;i++ )unit[i] = new MUnit(i);
            happened = new List<int>();
            //happening = new List<int>();
            //predict = new List<int>();
            clearnum = 0;
        }
        public void addInput(int id)
        {
            List<int> temp = new List<int>();
            unit[id].addStrength();
            foreach(int uid in happened)
            {
                addUnit(uid, id);
            }
            happened.Add(id);
        }
        //主要处理方法
        /*
        public void addInput(int id)
        {
            List<int> temp=new List<int>();
            unit[id].addStrength();
            //处理预测值
            for(int i=0;i<predict.Count;i++)
            {
                MUnit u = unit[predict[i]];
                if(u.part2==id)
                {
                    temp.Add(predict[i]);
                    u.addStrength();
                }
            }
            if(temp.Count>=1)
            {
                happening = temp;
                happening.Add(id);
                //happening.Add(WILDCARD);
            }
            else
            {
                List<int> temp2 = new List<int>();
                for(int i=0;i<happening.Count;i++)
                {
                    for(int j=0;j<happened.Count;j++)
                    {
                        temp2.Add(addLink(happened[j], happening[i]));
                    }
                }
                for (int i = 0; i < happening.Count; i++)
                {
                    temp2.Add(happening[i]);
                }
                happened = new List<int>();
                int num = Math.Min(temp2.Count, 20);
                for (int i = temp2.Count-num; i < num;i++ )
                {
                    happened.Add(temp2[i]);
                }
                happening = new List<int>();
                happening.Add(id);
                //happening.Add(WILDCARD);
            }
            predict = new List<int>();
            //根据现在值写入预测信息
            for (int i = 0; i < happening.Count; i++)
            {
                for (int j = 0; j < unit.Length && unitidlist[j] ; j++)
                {
                    if (happening[i] == unit[j].part1)
                    {
                        predict.Add(unit[j].id);
                    }
                }
            }
        }
        */
        //结束一次输入。这里暂时处理为插入一个结束标志
        public void closeInput()
        {
            addInput(END);
            deleteOldUnits();
            /*
            
            happened.Clear();
            happening.Clear();
            predict.Clear();
             */
        }
        //添加新的基本单元
        public int addSingleUnit()
        {
            MUnit newunit;
            for(int i=0;i<MAXUNITNUM;i++)
            {
                if(unitidlist[i]==false)
                {
                    unitidlist[i] = true;
                    newunit=new MUnit(i);
                    unit[i] = newunit;
                    return i;
                }
            }
            int id= deleteOldUnits();
            if (id < 0) return -1;
            newunit = new MUnit(id);
            unit[id] = newunit;
            return id;
        }
        //添加新的非基本单元
        public int addUnit(int id1,int id2)
        {
            MUnit newunit;
            for (int i = 0; i < MAXUNITNUM; i++)
            {
                if (unitidlist[i] == false)
                {
                    unitidlist[i] = true;
                    newunit = new MUnit(i,id1,id2);
                    unit[i] = newunit;
                    return i;
                }
            }
            int id = deleteOldUnits();
            if( id < 0 )return -1;
            newunit = new MUnit(id,id1,id2);
            unit[id] = newunit;
            return id;
        }
        //添加一个新的联系
        
        private int addLink(int id1,int id2)
        {
            foreach(MUnit u in unit)
            {
                if(u.part1==id1 && u.part2==id2)
                {
                    u.addStrength();
                    return u.id;
                }
            }
            int id = addUnit(id1,id2);
            if (id < 0) { System.Diagnostics.Debug.WriteLine("Unit full!"); return -1; }
            foreach(MUnit u in unit)
            {
                if(u.id==id)
                {
                    u.addStrength();
                    return u.id;
                }
            }
            return -1;
        }
         
        //获取使用了的单元总数
        public int getUnitCount()
        {
            int num=0;
            for(int i=0;i<MAXUNITNUM;i++)
            {
                if (unitidlist[i]) num++;
            }
            return num;
        }
        //获取单元最大编号
        public int getUnitMaxNum()
        {
            int num = 0;
            for(int i=MAXUNITNUM-1;i>=0;i--)
            {
                if (unitidlist[i]==true)
                {
                    num = i;
                    break;
                }
            }
            return num;
        }
        //清除系统中旧的单元。返回最左的一个空白单元id
        private int deleteOldUnits()
        {
            if (clearnum < UNITCLEARWAITTIME) { clearnum++; return -1; }
            System.Diagnostics.Debug.WriteLine("Clear old Unit!");
            clearnum = 0;
            int id = -1;
            int min = getMinStrength(); System.Diagnostics.Debug.WriteLine(".."+min);
            for (int i = 3; i < unit.Length;i++ )
            {
                if (!unitidlist[i]) continue;
                else if (unit[i].part1 == -1 && unit[i].part2 == -1) continue;
                if (unit[i].strength <= min)
                {
                    deleteUnitById(i);
                    id = i;
                    //break;
                }
            }
            return id;
        }
        //按id清除一个单元（及以其为基础的那些单元）
        private void deleteUnitById(int id)
        {
            if(!unitidlist[id]) return;
            //System.Diagnostics.Debug.WriteLine("delete:"+id);
            unitidlist[id] = false;
            unit[id] = new MUnit(id);
            foreach (int i in happened) if (i == id) {happened.Remove(i); break;}

            for (int s = 3; s < unit.Length; s++)
            {
                if (!unitidlist[s]) continue;
                MUnit u = unit[s];
                if(u.part1==id || u.part2==id)
                {
                    deleteUnitById(u.id);
                    break;
                }
            }
            
        }
        //获取系统最小权值（用于清理这些单元）
        private int getMinStrength()
        {
            return 2;
            int i = int.MaxValue;
            for (int s = 3; s < getUnitMaxNum(); s++)
            {
                if (!unitidlist[s]) continue;
                else if (unit[s].part1 == -1 && unit[s].part2 == -1) continue;
                MUnit u = unit[s];
                if (u.strength < i) i = u.strength;
            }
            System.Diagnostics.Debug.WriteLine("min:"+i);
            return i;
        }
    }
}
