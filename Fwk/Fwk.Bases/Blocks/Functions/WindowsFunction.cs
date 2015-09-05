using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Fwk.HelperFunctions
{

    /// <summary>
    /// Funciones de ayuda para visualisacion de formularios
    /// </summary>
    public class Win32Function
    {
        /// <summary>
        /// Inicia  un flash o parpadeo del formulario 
        /// </summary>
        /// <param name="form"></param>
        public static void FlashWindow_Start(System.Windows.Forms.Form form)
        {
            WindowDllImport.Start(form);
        }
        /// <summary>
        /// Detiene el parpadeo o flash en el formulario espesificado
        /// </summary>
        /// <param name="form"></param>
        public static void FlashWindow_Stop(System.Windows.Forms.Form form)
        {
            WindowDllImport.Stop(form);
        }

        /// <summary>
        /// Produce un parpadeo o flash en el formulario hasta q recive foco
        /// </summary>
        /// <param name="form"></param>
        public static void FlashWindow_Flash(System.Windows.Forms.Form form)
        {
            WindowDllImport.Flash(form);
        }
        /// <summary>
        /// Produce un parpadeo o flash en el formulario hasta q recive foco por un cierto periodo de tiempo
        /// </summary>
        /// <param name="form"></param>
        /// <param name="count"></param>
        public static void FlashWindow_Flash(System.Windows.Forms.Form form, uint count)
        {
            WindowDllImport.Flash(form, count);
        }

        /// <summary>
        /// Redondea un objeto que hereda de Control
        /// _BoarderRaduis can be adjusted to your needs, try 15 to start.
        /// </summary>
        /// <param name="pControl"></param>
        public static void Round(Control pControl)
        {
            System.IntPtr ptr = WindowDllImport.CreateRoundRectRgn(0, 0, pControl.Width, pControl.Height, 50, 50);
            pControl.Region = System.Drawing.Region.FromHrgn(ptr);
            WindowDllImport.DeleteObject(ptr);

        }



        /// <summary>
        /// 
        /// función privada usada para mover el formulario actual
        /// Se usa en evento MouseMove del control
        /// </summary>
        /// <param name="frm"></param>
        public static void MoveForm(Form frm)
        {
            WindowDllImport.ReleaseCapture();
            WindowDllImport.SendMessage(frm.Handle, WindowDllImport.WM_SYSCOMMAND, WindowDllImport.MOUSE_MOVE, 0);
        }



        /// <summary>
        /// Remueve la barra de titulo de un formulario
        /// </summary>
        /// <param name="hwnd">Manejador de ventana </param>
        /// <param name="remove">True = remueve</param>
        public static void RemoveTittleBar(IntPtr hwnd, bool remove)
        { WindowDllImport.RemoveTittleBar(hwnd, remove); }
    }

   internal static class WindowDllImport
    {

        #region redondear un control
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        internal static extern IntPtr CreateRoundRectRgn
        (
        int nLeftRect, // x-coordinate of upper-left corner
        int nTopRect, // y-coordinate of upper-left corner
        int nRightRect, // x-coordinate of lower-right corner
        int nBottomRect, // y-coordinate of lower-right corner
        int nWidthEllipse, // height of ellipse
        int nHeightEllipse // width of ellipse
        );

        [DllImport("gdi32.dll", EntryPoint = "DeleteObject")]
        internal static extern bool DeleteObject(System.IntPtr hObject);

       
        #endregion

        #region Mover formulario sin barra de titulo

        /// <summary>
        /// Declaraciones del API de Windows (y constantes usadas para mover el form)
        /// </summary>
        internal const int WM_SYSCOMMAND = 0x112;
        /// <summary>
        /// Declaraciones del API de Windows (y constantes usadas para mover el form)
        /// </summary>
        internal const int MOUSE_MOVE = 0xF012;
        //
        // Declaraciones del API
        [System.Runtime.InteropServices.DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        internal extern static void ReleaseCapture();
        //
        [System.Runtime.InteropServices.DllImport("user32.DLL", EntryPoint = "SendMessage")]
        internal extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);



        #endregion

        #region FlashWindowEx

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool FlashWindowEx(ref FLASHWINFO pwfi);


        /// <summary>
        ///  Ejemplo
        /// One this to note with this example usage code, is the "this" keyword is referring to
        /// the current System.Windows.Forms.Form.
        /// Flash window until it recieves focus
        ///     FlashWindow.Flash(this);
        /// Flash window 5 times
        ///     FlashWindow.Flash(this, 5);
        /// Start Flashing "Indefinately"
        ///     FlashWindow.Start(this);
        /// Stop the "Indefinate" Flashing
        ///     FlashWindow.Stop(this);
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        internal struct FLASHWINFO
        {
            /// <summary>
            /// The size of the structure in bytes.
            /// </summary>
            public uint cbSize;
            /// <summary>
            /// A Handle to the Window to be Flashed. The window can be either opened or minimized.
            /// </summary>
            public IntPtr hwnd;
            /// <summary>
            /// The Flash Status.
            /// </summary>
            public uint dwFlags;
            /// <summary>
            /// The number of times to Flash the window.
            /// </summary>
            public uint uCount;
            /// <summary>
            /// The rate at which the Window is to be flashed, in milliseconds. If Zero, the function uses the default cursor blink rate.
            /// </summary>
            public uint dwTimeout;
        }

        /// <summary>
        /// Stop flashing. The system restores the window to its original stae.
        /// </summary>
        public const uint FLASHW_STOP = 0;

        /// <summary>
        /// Flash the window caption.
        /// </summary>
        public const uint FLASHW_CAPTION = 1;

        /// <summary>
        /// Flash the taskbar button.
        /// </summary>
        public const uint FLASHW_TRAY = 2;

        /// <summary>
        /// Flash both the window caption and taskbar button.
        /// This is equivalent to setting the FLASHW_CAPTION | FLASHW_TRAY flags.
        /// </summary>
        public const uint FLASHW_ALL = 3;

        /// <summary>
        /// Flash continuously, until the FLASHW_STOP flag is set.
        /// </summary>
        public const uint FLASHW_TIMER = 4;

        /// <summary>
        /// Flash continuously until the window comes to the foreground.
        /// </summary>
        public const uint FLASHW_TIMERNOFG = 12;


        /// <summary>
        /// Flash the spacified Window (Form) until it recieves focus.
        /// </summary>
        /// <param name="form">The Form (Window) to Flash.</param>
        /// <returns></returns>
        internal static bool Flash(System.Windows.Forms.Form form)
        {
            // Make sure we're running under Windows 2000 or later
            if (Win2000OrLater)
            {
                FLASHWINFO fi = Create_FLASHWINFO(form.Handle, FLASHW_ALL | FLASHW_TIMERNOFG, uint.MaxValue, 0);
                return FlashWindowEx(ref fi);
            }
            return false;
        }

        private static FLASHWINFO Create_FLASHWINFO(IntPtr handle, uint flags, uint count, uint timeout)
        {
            FLASHWINFO fi = new FLASHWINFO();
            fi.cbSize = Convert.ToUInt32(Marshal.SizeOf(fi));
            fi.hwnd = handle;
            fi.dwFlags = flags;
            fi.uCount = count;
            fi.dwTimeout = timeout;
            return fi;
        }

        /// <summary>
        /// Flash the specified Window (form) for the specified number of times
        /// </summary>
        /// <param name="form">The Form (Window) to Flash.</param>
        /// <param name="count">The number of times to Flash.</param>
        /// <returns></returns>
        internal static bool Flash(System.Windows.Forms.Form form, uint count)
        {
            if (Win2000OrLater)
            {
                FLASHWINFO fi = Create_FLASHWINFO(form.Handle, FLASHW_ALL, count, 0);
                return FlashWindowEx(ref fi);
            }
            return false;
        }

        /// <summary>
        /// Start Flashing the specified Window (form)
        /// </summary>
        /// <param name="form">The Form (Window) to Flash.</param>
        /// <returns></returns>
        internal static bool Start(System.Windows.Forms.Form form)
        {
            if (Win2000OrLater)
            {
                FLASHWINFO fi = Create_FLASHWINFO(form.Handle, FLASHW_ALL, uint.MaxValue, 0);
                return FlashWindowEx(ref fi);
            }
            return false;
        }

        /// <summary>
        /// Stop Flashing the specified Window (form)
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        internal static bool Stop(System.Windows.Forms.Form form)
        {
            if (Win2000OrLater)
            {
                FLASHWINFO fi = Create_FLASHWINFO(form.Handle, FLASHW_STOP, uint.MaxValue, 0);
                return FlashWindowEx(ref fi);
            }
            return false;
        }

        /// <summary>
        /// A boolean value indicating whether the application is running on Windows 2000 or later.
        /// </summary>
        private static bool Win2000OrLater
        {
            get { return System.Environment.OSVersion.Version.Major >= 5; }
        }
        #endregion

        #region quitar barra de titulo


        [DllImport("user32.DLL", EntryPoint = "SetWindowLong")]
        static extern int SetWindowLong(
            IntPtr hWnd,       // handle to window
            int nIndex,     // offset of value to set
            int dwNewLong   // new value
        );
        [DllImport("user32.DLL", EntryPoint = "SetWindowPos")]
        static extern bool SetWindowPos(
            IntPtr hWnd,               // handle to window
            int hWndInsertAfter,    // placement-order handle
            int X,                  // horizontal position
            int Y,                  // vertical position
            int cx,                 // width
            int cy,                 // height
            uint uFlags             // window-positioning options
        );
        //' Declaraciones del API para 32 bits
        [DllImport("user32.DLL", EntryPoint = "GetWindowLong")]
        static extern int GetWindowLong(
            IntPtr hWnd,   // handle to window
            int nIndex  // offset of value to retrieve
        );
        //'
        //' Constantes para usar con el API
        const int GWL_STYLE = (-16);
        /// <summary>
        /// Constante Tipo de estilo, en este caso para quitar la barra 
        /// </summary>
        const int WS_CAPTION = 0x00C00000;
        ///Constantes para SetWindowPos  
        const int SWP_FRAMECHANGED = 0x0020;
        const int SWP_NOMOVE = 0x2;
        const int SWP_NOSIZE = 0x1;
        const int SWP_NOZORDER = 0x4;


        /// <summary>
        /// Remueve la barra de titulo de un formulario
        /// </summary>
        /// <param name="hwnd">Manejador de ventana </param>
        /// <param name="remove">True = remueve</param>
        internal static void RemoveTittleBar(IntPtr hwnd, bool remove)
        {
            //Almacena en la variable el estilo actual   
            int style = GetWindowLong(hwnd, GWL_STYLE);

            if (remove)
                style = style ^ WS_CAPTION;// ^ = Xor .----> Si ya lo tiene, lo quita
            else
              style = style | WS_CAPTION;//| = Or  ---> | = Or


            ///Aplica el estilo  
            SetWindowLong(hwnd, GWL_STYLE, style);

            SetWindowPos(hwnd, 0, 0, 0, 0, 0,
                              SWP_FRAMECHANGED |
                              SWP_NOMOVE |
                              SWP_NOSIZE |
                              SWP_NOZORDER);

        }


        #endregion
    }
}
