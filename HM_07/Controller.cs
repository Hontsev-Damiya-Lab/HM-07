using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HM_07
{
    public enum MachineState
    {
        Null,Running,Dead
    }
    public class Controller
    {
        public static string machinename = "HM_07";
        public string name;
        public MachineState state;

        private Machine m;
        private string output;
        private List<Character> clist;
        private MainWindow mainwindow;
        private int inputnum;

        public Controller(string tname)
        {
            name=tname;
            state = MachineState.Null;
            Init();
            mainwindow = new MainWindow(this);
            Application.Run(mainwindow);
        }
        public void Init()
        {
            inputnum = 0;
            output = "";
            clist = new List<Character>();
            m = new Machine();
            state = MachineState.Running;
        }
        public void setInput(string input)
        {
            if (input.Length < 1) return; 
            
            for(int i=0;i<input.Length;i++)
            {
                if (  input[i] == '，'
                   || input[i] == '。'
                   || input[i] == '：'
                   || input[i] == '？'
                   || input[i] == '！'
                   || input[i] == '\n'
                   || input[i] == '\r'
                   || input[i] == ','
                   || input[i] == '.'
                   || input[i] == '!'
                   || input[i] == '?'
                   || input[i] == ';'
                   || input[i] == ' ') 
                {
                    m.closeInput();
                    continue; 
                }
                int cid=getCId(input[i].ToString());
                if(cid<0)
                {
                    cid=m.addSingleUnit();
                    clist.Add(new Character(input[i].ToString(),cid));
                }
                m.addInput(cid);
                inputnum++;
                mainwindow.printtimes(inputnum);
                Application.DoEvents();
                /*
                System.Diagnostics.Debug.WriteLine("happened:");
                for (int q = 0; q < m.happened.Count;q++ )
                    System.Diagnostics.Debug.Write(" " + getCh(m.happened[q]));
                System.Diagnostics.Debug.WriteLine("\nhappening:");
                for (int q = 0; q < m.happening.Count; q++)
                    System.Diagnostics.Debug.Write(" " + getCh(m.happening[q]));
                System.Diagnostics.Debug.WriteLine("\npredict:");
                for (int q = 0; q < m.predict.Count; q++)
                    System.Diagnostics.Debug.Write(" " + getCh(m.predict[q]));
                System.Diagnostics.Debug.WriteLine("\n_________\n");
                 */
            }
            m.closeInput();
            mainwindow.writelog(getMessageToShowWithSort());
            Application.DoEvents();
        }
        //根据字符获取其单元id
        private int getCId(string ch)
        {
            for(int i=0;i<clist.Count;i++)
            {
                if(clist[i].character==ch)
                {
                    return clist[i].id;
                }
            }
            return -1;
        }
        //根据id获取其单元字符
        private string getCh(int cid)
        {
            if (cid <= 0) return "*";
            else if (cid == 1) return "!";
            else if (cid == 2) return "。";
            for(int i=0;i<clist.Count;i++)
            {
                if(clist[i].id==cid)
                {
                    return clist[i].character.ToString();
                }
            }
            string res = "";
            for(int i=0;i<m.unit.Length;i++)
            {
                if(m.unit[i].id==cid)
                {
                    res +='('+ getCh(m.unit[i].part1);
                    res +=getCh(m.unit[i].part2)+')';
                    break;
                }
            }
            //if (res.Length < 1) res = "*";
            //else if (res == "**") res = "*";
            return res;
        }
        //获取系统输出
        public string getOutput()
        {
            return output;
        }
        //获取总体单元信息（带有单元的实际字符）
        public string getMessageToShow()
        {
            string mes = "name:" + name + "\r\n";
            mes += "chars:" + clist.Count + "\r\n";
            for(int i=0;i<clist.Count;i++)
            {
                mes = mes + clist[i].id + "，" + clist[i].character + "\r\n";
            }
            mes += "\r\n";
            mes += "units:" + m.getUnitMaxNum() + "\r\n";
            for (int i = 0; i < m.getUnitMaxNum(); i++)
            {
                mes = mes + m.unit[i].id + "，" + m.unit[i].part1 + "，" + m.unit[i].part2 + "，" + m.unit[i].strength;
                mes += "\r\n";
            }
            return mes;
        }
        //获取总体单元信息（标准输出到文件存储）
        public string getMessageToSave()
        {
            string mes = "name:" + name + "\r\n";
            mes += "\r\n";
            mes += "units:" + m.getUnitCount() + "\r\n";
            for (int i = 0; i < m.getUnitCount(); i++)
            {
                //if (getCh(m.unit[i].part1).Length>1)
                mes = mes + m.unit[i].id +"["+m.unit[i].strength+ "]:" + m.unit[i].part1 + "(" + getCh(m.unit[i].part1) + ")," + m.unit[i].part2 + "(" + getCh(m.unit[i].part2) + ")\r\n";
            }
            return mes;
        }
        //获取系统标准信息（带有单元的实际字符，并已经排序，用于显示系统状态）
        public string[] getMessageToShowWithSort()
        {
            string[] info = new string[42];
            info[0] = m.getUnitCount().ToString();
            info[1] = clist.Count.ToString();
            List<MUnit> units;
            List<MUnit> tempunit = m.unit.ToList<MUnit>();
            units = tempunit.OrderByDescending(s => s.strength).ToList<MUnit>();
            int i = 0, j = 0;
            while (true)
            {
                if (j >= 40||i>=units.Count) break;
                if(getCh(units[i].id).Length>1)
                {
                    info[j + 2] = units[i].id + "(" + units[i].strength + ")" + getCh(units[i].id);
                    i++;
                    j++;
                }
                else
                {
                    i++;
                }
            }
            return info;
        }
        //设定系统总体信息（从标准输入信息中）
        public void setMessageByString(string mes)
        {
            clist.Clear();
            m = new Machine();
            string[] str = mes.Trim('\r').Split('\n');
            for(int i=0;i<str.Length;i++)
            {
                if (str[i].Length < 5) continue;
                else if (str[i].Substring(0, 5) == "name:")
                {
                    name = str[i].Substring(5);
                }
                else if (str[i].Substring(0, 5) == "chars")
                {
                    int charnum = Int32.Parse(str[i].Substring(6));
                    for (int s = 1; s <= charnum; s++)
                    {
                        string[] temps = str[i + s].Split('，');
                        if (temps.Length >= 2)
                            clist.Add(new Character(temps[1], Int32.Parse(temps[0])));
                    }
                    i += charnum;
                }
                else if (str[i].Substring(0, 5) == "units")
                {
                    int unitnum = Int32.Parse(str[i].Substring(6));
                    for (int s = 1; s <= unitnum; s++)
                    {
                        if (s > Machine.MAXUNITNUM) break;
                        string[] temps = str[i + s].Split('，');
                        MUnit newu = new MUnit(Int32.Parse(temps[0]), Int32.Parse(temps[1]), Int32.Parse(temps[2]));
                        newu.strength = Int32.Parse(temps[3]);
                        m.unit[newu.id]=newu;
                        m.unitidlist[newu.id] = true;
                    }
                    i += unitnum;
                }
            }
        }
        //设定系统快乐值
        public void setHappy(int num)
        {
            m.addInput(1);
            inputnum++;
            mainwindow.printtimes(inputnum);
            Application.DoEvents();
        }
    }
    class Character
    {
        public string character;
        public int id;
        public Character(string ch,int cid)
        {
            id = cid;
            character = ch;
        }
    }
}
