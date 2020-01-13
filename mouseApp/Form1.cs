//以下坐标均以影之诗解析度（分辨率）1360X768为标准所写
//y坐标写入时均比实际增加了31

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace mouseApp
{
    public partial class Form1 : Form
    {
        private bool canStart = false;
        BackgroundWorker sv_work1;
        bool sv_NeedRun = false;
        public int Cishu;

        public Form1()
        {
            InitializeComponent();
            sv_work1 = new BackgroundWorker();
            sv_work1.DoWork += new DoWorkEventHandler(sv_work1_DoWork);
        }

        void sv_work1_DoWork(object sender, DoWorkEventArgs e)
        {
            while (sv_NeedRun == true && Cishu < Convert.ToInt32(textBox1.Text)) // 后台开始
            {
                IntPtr awin = MouseHookHelper.FindWindow("UnityWndClass",
                "Shadowverse");

                MouseHookHelper.RECT rc = new MouseHookHelper.RECT();

                MouseHookHelper.GetWindowRect(awin, ref rc);

                int width = rc.Right - rc.Left;  //窗口的宽度
                int height = rc.Bottom - rc.Top; //窗口的高度
                int x = rc.Left;
                int y = rc.Top;



                MouseHookHelper.SetForegroundWindow(awin);  // 设置当前窗口置前
                MouseHookHelper.ShowWindow(awin, MouseHookHelper.SW_SHOWNOACTIVATE);//4、5

                System.Threading.Thread.Sleep(2000);
                if (sv_NeedRun == false) break; //真不会了，只能这样判断是否暂停（下面的if都是判断）
                LeftMouseClick(new MouseHookHelper.POINT()  //点击换牌决定
                {
                    X = x + 1227,
                    Y = y + 415,
                });

                System.Threading.Thread.Sleep(8000);
                if (sv_NeedRun == false) break; 
                LeftMouseClick(new MouseHookHelper.POINT()  //如为先攻点击回合结束
                {
                    X = x + 1227,
                    Y = y + 415,
                });
                if (sv_NeedRun == false) break;
                Cishu = Cishu + 1;   //次数+1后判断是不是继续循环
                System.Threading.Thread.Sleep(68000);
                if (sv_NeedRun == false || Cishu >= Convert.ToInt32(textBox1.Text)) break; 
                LeftMouseClick(new MouseHookHelper.POINT()  //点击再次挑战
                {
                    X = x + 700,
                    Y = y + 725,
                });

                System.Threading.Thread.Sleep(5000);
                if (sv_NeedRun == false) break; 
                LeftMouseClick(new MouseHookHelper.POINT()  //默认第一卡组
                {
                    X = x + 347,
                    Y = y + 260,
                });

                System.Threading.Thread.Sleep(1000);
                if (sv_NeedRun == false) break; 
                LeftMouseClick(new MouseHookHelper.POINT()  //OK
                {
                    X = x + 816,
                    Y = y + 584,
                });
                if (sv_NeedRun == false) break; 
                System.Threading.Thread.Sleep(21500);
                if (sv_NeedRun == false) break;
            }
        }

        private static void LeftMouseClick(MouseHookHelper.POINT pointInfo)
        {

            //先移动鼠标到指定位置
            MouseHookHelper.SetCursorPos(pointInfo.X, pointInfo.Y);

            //按下鼠标左键
            MouseHookHelper.mouse_event(MouseHookHelper.MOUSEEVENTF_LEFTDOWN,
                        pointInfo.X,
                        pointInfo.Y, 0, 0);

            //松开鼠标左键
            MouseHookHelper.mouse_event(MouseHookHelper.MOUSEEVENTF_LEFTUP,
                        pointInfo.X ,
                        pointInfo.Y , 0, 0);

        }

        //实时打印鼠标的相对（x，y）位置
        private static void PrintMousePoint(int x,int y)
        {
            int x1 = x;
            int y1 = y;
            while (true)
            {

                Point p = new Point(1, 1);//定义存放获取坐标的point变量   
                MouseHookHelper.GetCursorPos(ref p);

                if (x1 != p.X && y1 != p.Y)
                {
                    System.Console.WriteLine("相对于父类窗口 dx:");
                    System.Console.WriteLine(p.X - x);
                    System.Console.WriteLine("相对于父类窗口 dy:");
                    System.Console.WriteLine(p.Y - y);
                    x1 = p.X;
                    y1 = p.Y;
                }


            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IntPtr awin = MouseHookHelper.FindWindow("UnityWndClass",
                "Shadowverse");
            if (awin == IntPtr.Zero)
            {
                MessageBox.Show("没有找到窗体");


                return;
            }
            else
            {
            canStart = true;
            MessageBox.Show("已寻找到窗体，请进行后续操作");

               
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (canStart == true)
            {
                if (textBox1.Text == "" || textBox1.Text == null || System.Text.RegularExpressions.Regex.IsMatch(textBox1.Text.ToString(), @"[\u4e00-\u9fa5]") || System.Text.RegularExpressions.Regex.IsMatch(textBox1.Text.ToString(), @"[a-zA-Z]"))
                {
                    MessageBox.Show("请输入正确的循环次数！");
                    return;
                }
                if (!sv_work1.IsBusy)
                {
                    int Cishu = 0;
                    sv_NeedRun = true;
                    sv_work1.RunWorkerAsync();
                }
                else
                    MessageBox.Show("不能同时运行2次！");
            }
            else
            {
                MessageBox.Show("请先寻找窗体！");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (sv_NeedRun == true)
            {
                int Cishu = 0;
                sv_NeedRun = false;
            }
            else
            {
                if (!sv_work1.IsBusy)
                {
                    MessageBox.Show("您还未开始");
                }
                else
                {
                    MessageBox.Show("如没停止则是未到下一个检查点");
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void 说明ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1.本程序以影之诗解析度（分辨率）1360X768为标准所写\r\n2.请先检测窗体再执行（循环次数默认为2）\r\n3.请在决定是否留卡的界面开启执行\r\n4.请配合修改过的unity文件一起使用\r\n5.暂停快捷键是ALT+S");
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("作者：①②③④⑤⑥\r\n个人博客：hd80606b.com\r\n版本：1.0.1");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Form4 f4 = new Form4();
            //f4.Show();
            //this.linkLabel1.LinkVisited = true;
            this.linkLabel1.LinkVisited = true;//改变连接后的字体颜色
            System.Diagnostics.Process.Start("https://github.com/hd80606b/shadowverse-auto-quest");
        }
    }
}
