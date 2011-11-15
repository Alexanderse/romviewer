    using System;
    using System.Diagnostics;
    using System.Text;
    using System.Collections;
    using System.Runtime.InteropServices;

    namespace WindowHider
    {
        /// <summary>

        /// Object used to control a Windows Form.

        /// </summary>

        public class Window
        {
            /// <summary>

            /// Win32 API Imports

            /// </summary>

            [DllImport("user32.dll")] private static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);
            [DllImport("user32.dll")] private static extern bool SetForegroundWindow(IntPtr hWnd);
            [DllImport("user32.dll")] private static extern bool IsIconic(IntPtr hWnd);
            [DllImport("user32.dll")] private static extern bool IsZoomed(IntPtr hWnd);
            [DllImport("user32.dll")] private static extern IntPtr GetForegroundWindow();
            [DllImport("user32.dll")] private static extern IntPtr GetWindowThreadProcessId(IntPtr hWnd, IntPtr ProcessId);
            [DllImport("user32.dll")] private static extern IntPtr AttachThreadInput(IntPtr idAttach, IntPtr idAttachTo, int fAttach);
            [DllImport("user32.dll", CharSet = CharSet.Auto)]
            public static extern bool PostMessage(int hhwnd, uint msg, IntPtr wparam, IntPtr lparam);
            [DllImport("user32.dll")]
            public static extern IntPtr GetWindowLong(IntPtr hWnd, int nIndex);



            /// <summary>

            /// Win32 API Constants for ShowWindowAsync()

            /// </summary>

            private const int SW_HIDE = 0;
            private const int SW_SHOWNORMAL = 1;
            private const int SW_SHOWMINIMIZED = 2;
            private const int SW_SHOWMAXIMIZED = 3;
            private const int SW_SHOWNOACTIVATE = 4;
            private const int SW_RESTORE = 9;
            private const int SW_SHOWDEFAULT = 10;
            private const int MOUSEEVENTF_LEFTDOWN = 0x02;
            private const int MOUSEEVENTF_LEFTUP = 0x04;
            private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
            private const int MOUSEEVENTF_RIGHTUP = 0x10;
            const int WM_KEYDOWN = 0x100;
            const int WM_KEYUP = 0x101;

            /// <summary>

            /// Private Fields

            /// </summary>

            private IntPtr m_hWnd;
            private string m_Title;
            private bool m_Visible = true;
            private string m_Process;
            private bool m_WasMax = false;


            public Window(IntPtr mHWnd, string mTitle, bool mVisible, string mProcess)
            {
                m_hWnd = mHWnd;
                m_Title = mTitle;
                m_Visible = mVisible;
                m_Process = mProcess;
            }

            /// <summary>

            /// Window Object's Public Properties

            /// </summary>

            public IntPtr hWnd
            {
                get { return m_hWnd; }
                set { m_hWnd = value; }
            }
            public string Title
            {
                get { return m_Title; }
            }
            public string Process
            {
                get { return m_Process; }
            }

            /// <summary>

            /// Sets this Window Object's visibility

            /// </summary>

            public bool Visible
            {
                get { return m_Visible; }
                set
                {
                    //show the window

                    if (value == true)
                    {
                        if (m_WasMax)
                        {
                            if (ShowWindowAsync(m_hWnd, SW_SHOWMAXIMIZED))
                                m_Visible = true;
                        }
                        else
                        {
                            if (ShowWindowAsync(m_hWnd, SW_SHOWNORMAL))
                                m_Visible = true;
                        }
                    }
                    //hide the window

                    if (value == false)
                    {
                        m_WasMax = IsZoomed(m_hWnd);
                        if (ShowWindowAsync(m_hWnd, SW_HIDE))
                            m_Visible = false;
                    }
                }
            }

            /// <summary>

            /// Constructs a Window Object

            /// </summary>

            /// <param name="Title">Title Caption</param>

            /// <param name="hWnd">Handle</param>

            /// <param name="Process">Owning Process</param>

            public Window(string Title, IntPtr hWnd, string Process)
            {
                m_Title = Title;
                m_hWnd = hWnd;
                m_Process = Process;
            }

            //Override ToString() 

            public override string ToString()
            {
                //return the title if it has one, if not return the process name

                if (m_Title.Length > 0)
                {
                    return m_Title;
                }
                else
                {
                    return m_Process;
                }
            }

            /// <summary>

            /// Sets focus to this Window Object

            /// </summary>

            public void Activate()
            {
                if (m_hWnd == GetForegroundWindow())
                    return;

                IntPtr ThreadID1 = GetWindowThreadProcessId(GetForegroundWindow(), IntPtr.Zero);
                IntPtr ThreadID2 = GetWindowThreadProcessId(m_hWnd, IntPtr.Zero);

                if (ThreadID1 != ThreadID2)
                {
                    AttachThreadInput(ThreadID1, ThreadID2, 1);
                    SetForegroundWindow(m_hWnd);
                    AttachThreadInput(ThreadID1, ThreadID2, 0);
                }
                else
                {
                    SetForegroundWindow(m_hWnd);
                }

                if (IsIconic(m_hWnd))
                {
                    ShowWindowAsync(m_hWnd, SW_RESTORE);
                }
                else
                {
                    ShowWindowAsync(m_hWnd, SW_SHOWNORMAL);
                }
            }

            public void KeyPress(IntPtr key, IntPtr mod)
            {
                PostMessage((int)hWnd, WM_KEYDOWN, key, mod);
                PostMessage((int)hWnd, WM_KEYUP, key, mod);
            }
        }

        /// <summary>

        /// Collection used to enumerate Window Objects

        /// </summary>

        public class Windows : IEnumerable, IEnumerator
        {
            /// <summary>

            /// Win32 API Imports

            /// </summary>

            [DllImport("user32.dll")]
            private static extern int GetWindowText(int hWnd, StringBuilder title, int size);
            [DllImport("user32.dll")]
            private static extern int GetWindowModuleFileName(int hWnd, StringBuilder title, int size);
            [DllImport("user32.dll")]
            private static extern int EnumWindows(EnumWindowsProc ewp, int lParam);
            [DllImport("user32.dll")]
            private static extern bool IsWindowVisible(int hWnd);
            [DllImport("user32.dll", SetLastError = true)]
            private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

            //delegate used for EnumWindows() callback function

            public delegate bool EnumWindowsProc(int hWnd, int lParam);

            private int m_Position = -1; // holds current index of wndArray, 

            // necessary for IEnumerable


            ArrayList wndArray = new ArrayList(); //array of windows


            //Object's private fields

            private bool m_invisible = false;
            private bool m_notitle = false;

            /// <summary>

            /// Collection Constructor with additional options

            /// </summary>

            /// <param name="Invisible">Include invisible Windows</param>

            /// <param name="Untitled">Include untitled Windows</param>

            public Windows(bool Invisible, bool Untitled)
            {
                m_invisible = Invisible;
                m_notitle = Untitled;

                //Declare a callback delegate for EnumWindows() API call

                EnumWindowsProc ewp = new EnumWindowsProc(EvalWindow);
                //Enumerate all Windows

                EnumWindows(ewp, 0);
            }
            /// <summary>

            /// Collection Constructor

            /// </summary>

            public Windows()
            {
                //Declare a callback delegate for EnumWindows() API call

                EnumWindowsProc ewp = new EnumWindowsProc(EvalWindow);
                //Enumerate all Windows

                EnumWindows(ewp, 0);
            }
            //EnumWindows CALLBACK function

            private bool EvalWindow(int hWnd, int lParam)
            {
                if (m_invisible == false && !IsWindowVisible(hWnd))
                    return (true);

                StringBuilder title = new StringBuilder(256);
                StringBuilder module = new StringBuilder(256);

                GetWindowModuleFileName(hWnd, module, 256);
                GetWindowText(hWnd, title, 256);

                if (m_notitle == false && title.Length == 0)
                    return (true);

                wndArray.Add(new Window(title.ToString(), (IntPtr)hWnd,
                                        module.ToString()));

                return (true);
            }

            //implement IEnumerable

            public IEnumerator GetEnumerator()
            {
                return (IEnumerator)this;
            }
            //implement IEnumerator

            public bool MoveNext()
            {
                m_Position++;
                if (m_Position < wndArray.Count)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public void Reset()
            {
                m_Position = -1;
            }
            public object Current
            {
                get
                {
                    return wndArray[m_Position];
                }
            }


        }

        public class ManagedProc
        {
            public int processId;
            public string processName;
            public int Interval = 10;
            public bool Visible = true;
            public WindowHider.Window Window;

            public ManagedProc(Process process, int interval)
            {
                processId = process.Id;
                processName = process.ProcessName;
                Interval = interval;
                Window = new Window(process.MainWindowTitle, process.MainWindowHandle, process.Id.ToString());
            }

            public ManagedProc(string source)
            {
                string[] tokens = source.Split('|');

                processId = Convert.ToInt32(tokens[0]);
                processName = tokens[1];
                Interval = Convert.ToInt32(tokens[2]);

                Window = new Window((IntPtr)Convert.ToInt32(tokens[4]), tokens[3], Convert.ToBoolean(tokens[5]), processId.ToString());
            }

            public override string ToString()
            {
                return string.Format("{1}{0}{2}{0}{3}{0}{4}{0}{5}{0}{6}", "|", processId, processName, Interval, Window.Title, Window.hWnd, Window.Visible);
            }
        }

    }
