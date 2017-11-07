using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Windows.Forms;
using System.Threading;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace HM_07
{
    public partial class MainWindow : Form
    {
        delegate void sendstr(string str);
        sendstr println;
        private Controller controller;

        public MainWindow(Controller cont)
        {
            controller = cont;
            InitializeComponent();
            println = new sendstr(printline);
        }


        public void input(String str)
        {
            if(str!=null && str.Length>0 && controller.state==MachineState.Running)
            {
                 printline("输入：" + str);
                 controller.setInput(str);
                 //printline(controller.printMessages());
            }
        }
        public void printline(string str)
        {
            if (str.Length < 1) return;
            MessageBox.Text = MessageBox.Text + str + "\r\n";
            MessageBox.Select(MessageBox.TextLength, 0);
            MessageBox.ScrollToCaret();
        }
        public void printtimes(int times)
        {
            label_times.Text = "输入次数：" + times.ToString();
        }
        public void writelog(string[] infos)
        {
            label_info.Text = "系统信息：\r\n";
            label_info.Text+="总单元数："+infos[0]+"  总字符数："+infos[1]+"\r\n";
            for(int i=2;i<infos.Length;i++)
            {
                if (i < infos.Length - 1) 
                {
                    label_info.Text += infos[i];
                    if(infos[i]!=null && infos[i].Length>0)
                    for(int ii=0;ii<(30-infos[i].Length);ii++)
                    {
                        label_info.Text += " ";
                    }
                    label_info.Text+=infos[++i] + "\r\n";
                }
                else label_info.Text += infos[i];
            }
        }
        private void loadfile(string fname)
        {
            FileStream file = new FileStream(fname,FileMode.Open, FileAccess.Read);
            StreamReader read = new StreamReader(file,Encoding.Default);
            while (!read.EndOfStream)
            {
                string str = read.ReadToEnd();
                controller.setMessageByString(str);
            }
            printline("完成。");
            read.Close();
            file.Close();
            printline(controller.getMessageToSave());
        }
        private void readinput(string fname)
        {
            FileStream file = new FileStream(fname, FileMode.Open, FileAccess.Read);
            StreamReader read = new StreamReader(file, Encoding.Default);
            while (!read.EndOfStream)
            {
                string str = read.ReadToEnd();
                input(str);
            }
            read.Close();
            file.Close();
            printline(controller.getMessageToSave());
            printline("数据读取完毕。");
        }
        private void saveres()
        {
            string filename = "machineinfo.txt";
            if (filename.Length > 0)
            {
                FileStream file = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter fw = new StreamWriter(file,Encoding.Default);
                fw.WriteLine(controller.getMessageToShow());
                fw.Close();
                file.Close();
            }
            printline("导出完毕，路径: " + filename);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string str = InputBox.Text;
            InputBox.Text = "";
            input(str);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            printline("已提供快感。");
            controller.setHappy(1);
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            printline("存储"+controller.name+"的信息。");
            saveres();
        }


        private void InputBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyValue==13)
            {
                string str = InputBox.Text;
                InputBox.Text = "";
                input(str);
            }
        }

        private void InputBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                InputBox.Text = "";
            }
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            loadfile(openFileDialog1.FileName);
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            controller.Init();
            writelog(controller.getMessageToShowWithSort());
            printline("清空完毕。");
           printtimes(0);
        }

        private void InputfileButton_Click(object sender, EventArgs e)
        {
            openFileDialog2.ShowDialog();
        }

        private void openFileDialog2_FileOk(object sender, CancelEventArgs e)
        {
            readinput(openFileDialog2.FileName);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            printline(controller.getMessageToSave());
        }
    }
}
