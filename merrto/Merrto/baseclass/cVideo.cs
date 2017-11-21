using System;
using System.Runtime.InteropServices;

namespace Merrto.baseclass
{
    public class cVideo
    {
         private IntPtr lwndC;       //保存无符号句柄

        private IntPtr mControlPtr; //保存管理指示器

        private int mWidth;

        private int mHeight;

        public cVideo(IntPtr handle, int width, int height)

        {

            mControlPtr = handle; //显示视频控件的句柄

            mWidth = width;      //视频宽度

            mHeight = height;    //视频高度

        }

        /// <summary>

        /// 打开视频设备

        /// </summary>

        public void StartWebCam()

        {

            byte[] lpszName = new byte[100];

            byte[] lpszVer = new byte[100];

            VideoAPI.capGetDriverDescriptionA(0, lpszName, 100, lpszVer, 100);

            this.lwndC = VideoAPI.capCreateCaptureWindowA(lpszName,

                VideoAPI.WS_CHILD | VideoAPI.WS_VISIBLE, 0, 0,

                mWidth, mHeight, mControlPtr, 0);

            if (VideoAPI.SendMessage(lwndC, VideoAPI.WM_CAP_DRIVER_CONNECT, 0, 0))

            {

                VideoAPI.SendMessage(lwndC, VideoAPI.WM_CAP_SET_PREVIEWRATE, 100, 0);

                VideoAPI.SendMessage(lwndC, VideoAPI.WM_CAP_SET_PREVIEW, true, 0);

            }

        }

        /// <summary>

        /// 关闭视频设备

        /// </summary>

        public void CloseWebcam()

        {

            VideoAPI.SendMessage(lwndC, VideoAPI.WM_CAP_DRIVER_DISCONNECT, 0, 0);

        }

        ///   <summary>  

        ///   拍照

        ///   </summary>  

        ///   <param   name="path">要保存bmp文件的路径</param>  

        public void GrabImage(IntPtr hWndC, string path)

        {

            IntPtr hBmp = Marshal.StringToHGlobalAnsi(path);

            VideoAPI.SendMessage(lwndC, VideoAPI.WM_CAP_SAVEDIB, 0, hBmp.ToInt32());

        }

    
    }
}
