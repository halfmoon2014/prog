using System;
using System.Runtime.InteropServices;

namespace Merrto.baseclass
{
    public class VideoAPI
    {
        // 视频API调用

        [DllImport("avicap32.dll")]

        public static extern IntPtr capCreateCaptureWindowA(byte[] lpszWindowName,

            int dwStyle, int x, int y, int nWidth, int nHeight,

            IntPtr hWndParent, int nID);

        [DllImport("avicap32.dll")]

        public static extern bool capGetDriverDescriptionA(short wDriver,

            byte[] lpszName, int cbName, byte[] lpszVer, int cbVer);

        [DllImport("User32.dll")]

        public static extern bool SendMessage(IntPtr hWnd, int wMsg,

            bool wParam, int lParam);

        [DllImport("User32.dll")]

        public static extern bool SendMessage(IntPtr hWnd, int wMsg,

            short wParam, int lParam);

        // 常量

        public const int WM_USER = 0x400;

        public const int WS_CHILD = 0x40000000;

        public const int WS_VISIBLE = 0x10000000;

        public const int SWP_NOMOVE = 0x2;

        public const int SWP_NOZORDER = 0x4;

        public const int WM_CAP_DRIVER_CONNECT = WM_USER + 10;

        public const int WM_CAP_DRIVER_DISCONNECT = WM_USER + 11;

        public const int WM_CAP_SET_CALLBACK_FRAME = WM_USER + 5;

        public const int WM_CAP_SET_PREVIEW = WM_USER + 50;

        public const int WM_CAP_SET_PREVIEWRATE = WM_USER + 52;

        public const int WM_CAP_SET_VIDEOFORMAT = WM_USER + 45;

        public const int WM_CAP_START = WM_USER;

        public const int WM_CAP_SAVEDIB = WM_CAP_START + 25;
    }
}
