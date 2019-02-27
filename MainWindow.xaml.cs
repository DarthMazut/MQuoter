using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using WinInterop = System.Windows.Interop;
using System.Runtime.InteropServices;
using System.IO;
using System.Speech.Synthesis;
using System.ComponentModel;

namespace MQuoter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        #region Avoid hiding task bar upon maximalisation

        private static System.IntPtr WindowProc(
              System.IntPtr hwnd,
              int msg,
              System.IntPtr wParam,
              System.IntPtr lParam,
              ref bool handled)
        {
            switch (msg)
            {
                case 0x0024:
                    WmGetMinMaxInfo(hwnd, lParam);
                    handled = true;
                    break;
            }

            return (System.IntPtr)0;
        }

        void win_SourceInitialized(object sender, EventArgs e)
        {
            System.IntPtr handle = (new WinInterop.WindowInteropHelper(this)).Handle;
            WinInterop.HwndSource.FromHwnd(handle).AddHook(new WinInterop.HwndSourceHook(WindowProc));
        }

        private static void WmGetMinMaxInfo(System.IntPtr hwnd, System.IntPtr lParam)
        {

            MINMAXINFO mmi = (MINMAXINFO)Marshal.PtrToStructure(lParam, typeof(MINMAXINFO));

            // Adjust the maximized size and position to fit the work area of the correct monitor
            int MONITOR_DEFAULTTONEAREST = 0x00000002;
            System.IntPtr monitor = MonitorFromWindow(hwnd, MONITOR_DEFAULTTONEAREST);

            if (monitor != System.IntPtr.Zero)
            {

                MONITORINFO monitorInfo = new MONITORINFO();
                GetMonitorInfo(monitor, monitorInfo);
                RECT rcWorkArea = monitorInfo.rcWork;
                RECT rcMonitorArea = monitorInfo.rcMonitor;
                mmi.ptMaxPosition.x = Math.Abs(rcWorkArea.left - rcMonitorArea.left);
                mmi.ptMaxPosition.y = Math.Abs(rcWorkArea.top - rcMonitorArea.top);
                mmi.ptMaxSize.x = Math.Abs(rcWorkArea.right - rcWorkArea.left);
                mmi.ptMaxSize.y = Math.Abs(rcWorkArea.bottom - rcWorkArea.top);
            }

            Marshal.StructureToPtr(mmi, lParam, true);
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            /// <summary>
            /// x coordinate of point.
            /// </summary>
            public int x;
            /// <summary>
            /// y coordinate of point.
            /// </summary>
            public int y;

            /// <summary>
            /// Construct a point of coordinates (x,y).
            /// </summary>
            public POINT(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MINMAXINFO
        {
            public POINT ptReserved;
            public POINT ptMaxSize;
            public POINT ptMaxPosition;
            public POINT ptMinTrackSize;
            public POINT ptMaxTrackSize;
        };

        void win_Loaded(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Maximized;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public class MONITORINFO
        {
            /// <summary>
            /// </summary>            
            public int cbSize = Marshal.SizeOf(typeof(MONITORINFO));

            /// <summary>
            /// </summary>            
            public RECT rcMonitor = new RECT();

            /// <summary>
            /// </summary>            
            public RECT rcWork = new RECT();

            /// <summary>
            /// </summary>            
            public int dwFlags = 0;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 0)]
        public struct RECT
        {
            /// <summary> Win32 </summary>
            public int left;
            /// <summary> Win32 </summary>
            public int top;
            /// <summary> Win32 </summary>
            public int right;
            /// <summary> Win32 </summary>
            public int bottom;

            /// <summary> Win32 </summary>
            public static readonly RECT Empty = new RECT();

            /// <summary> Win32 </summary>
            public int Width
            {
                get { return Math.Abs(right - left); }  // Abs needed for BIDI OS
            }
            /// <summary> Win32 </summary>
            public int Height
            {
                get { return bottom - top; }
            }

            /// <summary> Win32 </summary>
            public RECT(int left, int top, int right, int bottom)
            {
                this.left = left;
                this.top = top;
                this.right = right;
                this.bottom = bottom;
            }


            /// <summary> Win32 </summary>
            public RECT(RECT rcSrc)
            {
                this.left = rcSrc.left;
                this.top = rcSrc.top;
                this.right = rcSrc.right;
                this.bottom = rcSrc.bottom;
            }

            /// <summary> Win32 </summary>
            public bool IsEmpty
            {
                get
                {
                    // BUGBUG : On Bidi OS (hebrew arabic) left > right
                    return left >= right || top >= bottom;
                }
            }
            /// <summary> Return a user friendly representation of this struct </summary>
            public override string ToString()
            {
                if (this == RECT.Empty) { return "RECT {Empty}"; }
                return "RECT { left : " + left + " / top : " + top + " / right : " + right + " / bottom : " + bottom + " }";
            }

            /// <summary> Determine if 2 RECT are equal (deep compare) </summary>
            public override bool Equals(object obj)
            {
                if (!(obj is Rect)) { return false; }
                return (this == (RECT)obj);
            }

            /// <summary>Return the HashCode for this struct (not garanteed to be unique)</summary>
            public override int GetHashCode()
            {
                return left.GetHashCode() + top.GetHashCode() + right.GetHashCode() + bottom.GetHashCode();
            }


            /// <summary> Determine if 2 RECT are equal (deep compare)</summary>
            public static bool operator ==(RECT rect1, RECT rect2)
            {
                return (rect1.left == rect2.left && rect1.top == rect2.top && rect1.right == rect2.right && rect1.bottom == rect2.bottom);
            }

            /// <summary> Determine if 2 RECT are different(deep compare)</summary>
            public static bool operator !=(RECT rect1, RECT rect2)
            {
                return !(rect1 == rect2);
            }


        }

        [DllImport("user32")]
        internal static extern bool GetMonitorInfo(IntPtr hMonitor, MONITORINFO lpmi);

        [DllImport("user32.dll")]
        static extern bool GetCursorPos(ref Point lpPoint);

        [DllImport("User32")]
        internal static extern IntPtr MonitorFromWindow(IntPtr handle, int flags);

        #endregion

        #region ======================================= VARIABLES =========================================================

        //List<string> MisQuotesList = new List<string>();
        //List<string> MyshQuotesList = new List<string>();

        List<Quote> MisQuotesList = new List<Quote>();
        List<Quote> MyshQuotesList = new List<Quote>();

        Random kostka;

        SpeechSynthesizer speechSynthesizer;

        #endregion

        #region ======================================= PROPERTIES ========================================================

        #endregion

        #region ================================== DEPENDENCY PROPERTIES ==================================================

        #endregion

        #region ==================================== EVENTS & DELEGATES ===================================================

        #endregion

        #region ================================ CONSTRUCTOR / DESTRUCTOR =================================================

        public MainWindow()
        {
            kostka = new Random();

            if (!LoadQuotes())
            {
                MessageBox.Show("Nie odnaleziono pliku [data.dat] lub plik jest niewłaściwy.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);

                Application.Current.Shutdown();
            }
            InitializeComponent();

            SetProperCursor();

            speechSynthesizer = new SpeechSynthesizer();

            Properties.Settings.Default.AppRunCounter++;
            Properties.Settings.Default.Save();

            try
            {
                BitmapImage image = new BitmapImage();

                image.BeginInit();
                image.CreateOptions = BitmapCreateOptions.IgnoreImageCache;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = new Uri("img/bg.jpg", UriKind.Relative);
                image.EndInit();

                ImageBrush imbr = new ImageBrush();
                imbr.ImageSource = image;
                imbr.Stretch = Stretch.UniformToFill;

                xe_MainGrid.Background = imbr;
            }
            catch (Exception){}

            //MAXIMIZING WITH TASKBAR
            SourceInitialized += new EventHandler(win_SourceInitialized);
        }

        #endregion

        #region ====================================== PUBLIC METHODS =====================================================

        #endregion

        #region ====================================== PRIVATE METHODS ====================================================

        bool LoadQuotes()
        {
            string path = "data.dat";
            string[] lines;
            string msg = "";

            bool isMis = true;
            bool isClosed = true;
            SolidColorBrush col = null;

            if(File.Exists(path))
            {
                lines = File.ReadAllLines(path);

                try
                {
                    if (lines[0] == "#MQUOTER PROPER FILE#")
                    {
                        for (int i = 1; i < lines.Length; i++)
                        {
                            string line = lines[i];

                            if (isClosed)
                            {
                                if (line.StartsWith("@Mis"))
                                {
                                    isMis = true;

                                    if (line.Contains("*"))
                                    {
                                        string n = line.Substring(line.IndexOf("*")+1);
                                        n = n.Replace(" ", string.Empty);

                                        if(n == "RND")
                                        {
                                            col = new SolidColorBrush(new Color()
                                            {
                                                R = (byte)kostka.Next(256),
                                                G = (byte)kostka.Next(256),
                                                B = (byte)kostka.Next(256),
                                                A = 255
                                            });
                                        }
                                        else
                                            col = (SolidColorBrush)new BrushConverter().ConvertFromString(n);
                                    }
                                }
                                else if (line.StartsWith("@Mysh"))
                                {
                                    isMis = false;

                                    if (line.Contains("*"))
                                    {
                                        string n = line.Substring(line.IndexOf("*")+1);
                                        n = n.Replace(" ", string.Empty);

                                        if (n == "RND")
                                        {
                                            col = new SolidColorBrush(new Color()
                                            {
                                                R = (byte)kostka.Next(256),
                                                G = (byte)kostka.Next(256),
                                                B = (byte)kostka.Next(256),
                                                A = 255
                                            });
                                        }
                                        else
                                            col = (SolidColorBrush)new BrushConverter().ConvertFromString(n);
                                    }
                                }   
                                else if (line.StartsWith("["))
                                {
                                    if (line.Contains("]"))
                                    {
                                        if (line.Length > 1)
                                        {
                                            msg += line.Substring(1, line.IndexOf("]") - 1);
                                        }
                                        isClosed = true;
                                    }
                                    else
                                    {
                                        msg += line.Substring(1);
                                        isClosed = false;
                                    }

                                }

                            }
                            else
                            {
                                if (line.Contains("]"))
                                {
                                    if (line.Length > 1)
                                    {
                                        msg += "\n";
                                        msg += line.Substring(0, line.IndexOf("]") - 1);
                                    }
                                    isClosed = true;
                                }
                                else
                                {
                                    msg += "\n";
                                    msg += line;
                                }
                            }


                            if (msg != "" && isClosed)
                            {
                                if (isMis)
                                    MisQuotesList.Add(new Quote(msg, col));
                                else
                                    MyshQuotesList.Add(new Quote(msg, col));

                                msg = "";
                                col = null;
                            }

                        }

                        return true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Nieprawidłowy plik [data.dat].\n\n{ex.ToString()}","Błąd",MessageBoxButton.OK,MessageBoxImage.Error);
                    throw;
                }
 
            }
            return false;
        }

        void SetProperCursor()
        {
            if(Properties.Settings.Default.IsStandardCursor)
            {
                Mouse.OverrideCursor = Cursors.Arrow;
            }
            else
            {
                var info = Application.GetResourceStream(new Uri("pack://application:,,,/img/ted.cur"));
                Mouse.OverrideCursor = new Cursor(info.Stream);
            }
        }

        #endregion

        #region ======================================= EVENT METHODS =====================================================

        private void em_TitleBar_OnClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DragMove();
            }
            catch (Exception) { }
        }

        private void em_Close_OnClick(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void em_Maximize_OnClick(object sender, MouseButtonEventArgs e)
        {
            if (WindowState == WindowState.Maximized)
            {
                WindowState = WindowState.Normal;
                xe_MinMaxButton.Style = (Style)FindResource("TitleBarMaximize");
            }
            else if (WindowState == WindowState.Normal)
            {
                WindowState = WindowState.Maximized;
                xe_MinMaxButton.Style = (Style)FindResource("TitleBarRestore");
            }

        }

        private void em_Help_OnClick(object sender, MouseButtonEventArgs e)
        {
            About about = new About();
            about.Owner = this;
            about.ShowDialog();
        }

        private void em_Minimize_OnClick(object sender, MouseButtonEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void em_OnCopyClick(object sender, MouseButtonEventArgs e)
        {
            Clipboard.SetText(xe_TextBox_Quote.Text);
        }

        private void em_Clear_OnClick(object sender, MouseButtonEventArgs e)
        {
            xe_TextBox_Quote.Text = FindResource("ClearText") as string;
            xe_TextBox_Quote.Foreground = (SolidColorBrush)FindResource("QuoteDefaultColor");
        }

        private void em_OnMyshClick(object sender, MouseButtonEventArgs e)
        {
            int number = kostka.Next(MyshQuotesList.Count);


            if (MyshQuotesList.Count > 0)
            {
                xe_TextBox_Quote.Text = MyshQuotesList[number].QuoteText;
                if (MyshQuotesList[number].Color != null)
                {
                    xe_TextBox_Quote.Foreground = MyshQuotesList[number].Color;
                }
                else xe_TextBox_Quote.Foreground = (SolidColorBrush)FindResource("QuoteDefaultColor"); 
            }
            else
            {
                xe_TextBox_Quote.Text = FindResource("NoQuotesMysh") as string;
                xe_TextBox_Quote.Foreground = Brushes.Red;
            }
        }

        private void em_OnMisClick(object sender, MouseButtonEventArgs e)
        {
            int number = kostka.Next(MisQuotesList.Count);


            if (MisQuotesList.Count > 0)
            {
                xe_TextBox_Quote.Text = MisQuotesList[number].QuoteText;
                if (MisQuotesList[number].Color != null)
                {
                    xe_TextBox_Quote.Foreground = MisQuotesList[number].Color;
                }
                else xe_TextBox_Quote.Foreground = (SolidColorBrush)FindResource("QuoteDefaultColor"); 
            }
            else
            {
                xe_TextBox_Quote.Text = FindResource("NoQuotesMis") as string;
                xe_TextBox_Quote.Foreground = Brushes.Red;
            }

        }

        private void em_Settings_OnClick(object sender, MouseButtonEventArgs e)
        {

            Settings settings = new Settings(Properties.Settings.Default.BorderColor);
            settings.Owner = this;
            settings.ShowDialog();
            //if (settings.ShowDialog() == true)
                //ZAPISANO USTAWIENIA
        }

        private void em_OnCurClick(object sender, MouseButtonEventArgs e)
        {
            if (Properties.Settings.Default.IsStandardCursor)
            {
                Properties.Settings.Default.IsStandardCursor = false;
                Properties.Settings.Default.Save();

                SetProperCursor();
            }
            else
            {
                Properties.Settings.Default.IsStandardCursor = true;
                Properties.Settings.Default.Save();

                SetProperCursor();
            }
        }

        private void em_OnSoundClick(object sender, MouseButtonEventArgs e)
        {
            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += ReadQuote;
            bw.RunWorkerAsync(xe_TextBox_Quote.Text);
        }

        private void em_OnStatsClick(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show($"{FindResource("NrQuotesMis") as string} {MisQuotesList.Count}\n{FindResource("NrQuotesMysh") as string} {MyshQuotesList.Count}\n\n{FindResource("NrAppStartsTime") as string} {Properties.Settings.Default.AppRunCounter} razy.", "Statystyki", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        #endregion

        #region ========================================= COMMANDS ========================================================

        #endregion


        private void ReadQuote(object sender, DoWorkEventArgs e)
        {
            speechSynthesizer.Speak(e.Argument as string);
        }

       
    }

}
