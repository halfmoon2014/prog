using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;
using System.Diagnostics;
namespace wow
{
    public partial class Form1 : Form
    {
        // Fields
        private static int hHook;
        private HookProc KeyBoardHookProcedure;

        static Dictionary<string, Thread> dict = new Dictionary<string, Thread>();

        // Methods
        //static hook() { }
        //public hook() { }
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto)]
        public static extern int CallNextHookEx(int idHook, int nCode, IntPtr wParam, IntPtr lParam);
        [DllImport("USER32.DLL")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("kernel32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);
        public void Hook_Clear()
        {
            bool flag = true;
            if (hHook != 0)
            {
                flag = UnhookWindowsHookEx(hHook);
                hHook = 0;
            }
            if (!flag)
            {
                throw new Exception("取消hook失败!");
            }
        }
        public void Hook_Start()
        {
            if (hHook == 0)
            {
                this.KeyBoardHookProcedure = new HookProc(Form1.KeyBoardHookProc);
                hHook = SetWindowsHookEx(13, this.KeyBoardHookProcedure, GetModuleHandle(Process.GetCurrentProcess().MainModule.ModuleName), 0);
                if (hHook == 0)
                {
                    MessageBox.Show("设置Hook失败!");
                    this.Hook_Clear();
                }
            }
        }
        [DllImport("User32.dll")]
        public static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);

        public static void 战士抖杀()
        {
            while (true)
            {
                keybd_event(56, 0, 0, 0);
                Thread.Sleep(2000);
                keybd_event(56, 0, 2, 0); //释放D
                //byte num1 = (byte)Keys.E;

                //keybd_event(num1, 0, 0, 0);
                //Thread.Sleep(100);
                //keybd_event(num1, 0, 2, 0);
                //Thread.Sleep(100);
                //keybd_event(num1, 0, 0, 0);
                //Thread.Sleep(100);
                //keybd_event(num1, 0, 2, 0);
                //Thread.Sleep(100);
                //byte num2 = (byte)Keys.D4;
                //keybd_event(num2, 0, 0, 0);
                //Thread.Sleep(100);
                //keybd_event(num2, 0, 2, 0);
                //Thread.Sleep(100);
                //keybd_event(num1, 0, 0, 0);
                //Thread.Sleep(100);
                //keybd_event(num1, 0, 2, 0);
                //Thread.Sleep(100);
                //keybd_event(num1, 0, 0, 0);
                //Thread.Sleep(100);
                //keybd_event(num1, 0, 2, 0);
                //Thread.Sleep(100);
                //byte num4 = (byte)Keys.R;
                //keybd_event(num4, 0, 0, 0);
                //Thread.Sleep(100);
                //keybd_event(num4, 0, 2, 0);
                //Thread.Sleep(100);
            }
        }

        public static int KeyBoardHookProc(int nCode, IntPtr wParam, IntPtr lParam)
        {
            KeyBoardHookStruct input = (KeyBoardHookStruct)Marshal.PtrToStructure(lParam, typeof(KeyBoardHookStruct));

            if (input.vkCode == (int)Keys.F11)
            {
                IntPtr ptr = GetForegroundWindow();
                if (ptr != IntPtr.Zero)
                {
                    if (dict.Count < 1)
                    {
                        ThreadStart threadStart = new ThreadStart(战士抖杀);
                        Thread thread = new Thread(threadStart);
                        thread.Start();
                        dict.Clear();
                        dict.Add("战士抖杀", thread);
                    }
                }
                return 1;
            }
            else if (input.vkCode == (int)Keys.F12)
            {
                foreach (var th in dict)
                {
                    Thread thread = th.Value;
                    if (thread != null && thread.IsAlive)
                    {
                        if (!thread.Join(3))
                        {
                            thread.Abort();
                        }
                    }
                }
                dict.Clear();
            }
            return CallNextHookEx(hHook, nCode, wParam, lParam);
        }
        [DllImport("USER32.DLL")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);
        [DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto)]
        public static extern int SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hInstance, int threadId);
        [DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto)]
        public static extern bool UnhookWindowsHookEx(int idHook);

        // Nested Types
        public delegate int HookProc(int nCode, IntPtr wParam, IntPtr lParam);

        [StructLayout(LayoutKind.Sequential)]
        public class KeyBoardHookStruct
        {
            public int vkCode;
            public int scanCode;
            public int flags;
            public int time;
            public int dwExtraInfo;
            public KeyBoardHookStruct() { }
        }

        public Form1()
        {
             
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            Hook_Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hook_Clear();
        }
    }
}
