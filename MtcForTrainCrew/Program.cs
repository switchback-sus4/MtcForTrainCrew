using System;
using System.Text;
using System.Windows.Forms;

using LibUsbDotNet;
using LibUsbDotNet.Main;
using System.Collections;
using System.Collections.Specialized;

namespace MtcForTrainCrew
{
    public static class MtcState
    {
        public static string ConnectedCassette;
        public static string[] Reverser = new string[] { "Off", "Back", "Forward" };
        public static string[] Handle = new string[] { "EB", "B6", "B5", "B4", "B3", "B2", "B1", "Yokusoku", "N", "P1", "P2", "P3", "P4", "P5", "", "", "NULL" };
        public static int HandlePos;
        public static int HandlePosExist;
        public static int ReverserPos;
        public static int ReverserPosExist;
        public static Boolean yokusokuPos = false;
        public static int WiperState = 0;
        public static byte readColorButtonBuffer;
        public static byte readColorButtonBufferExist;
        public static byte readCtrlButtonBuffer;
        public static byte readCtrlButtonBufferExist;
    }
    public static class InputActionMtc
    {
        public static string btnAshallow;
        public static string btnAdeep;
        public static string btnB;
        public static string btnC;
        public static string btnD;
        public static string Up;
        public static string Down;
        public static string Left;
        public static string Right;
        public static string Start;
        public static string Select;
        public static string Ats;
        public static string SettingStatus;
        public static OrderedDictionary ActionLabel = new OrderedDictionary();
    }

    internal static class Program
    {
        public static UsbDeviceFinder MTCP5B7Finder = new UsbDeviceFinder(0x0AE4, 0x0101, 800);
        public static UsbDeviceFinder MTCP5B8Finder = new UsbDeviceFinder(0x0AE4, 0x0004, 0x0100);

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                if ( UsbDevice.OpenUsbDevice(MTCP5B7Finder) != null ) {
                    MtcState.ConnectedCassette = "P5B7";
                }
                else if (UsbDevice.OpenUsbDevice(MTCP5B8Finder) != null) {
                    MtcState.ConnectedCassette = "P5B8";
                }
                else
                {
                    MessageBox.Show(
                        "MTCを検出できませんでした。\r\nP5B7、もしくはP5B8のカセットが装着されたMTCを接続してから\r\nもう一度このアプリを起動してください。\r\n\r\nMTCを接続済みの場合は、デバイスマネージャなどで正常に認識されているか確認してください。\r\n",
                        "MTC for TrainCrew",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                    WaitingFormClosing();
                    // throw new Exception("Device Not Found.");
                }

            }
            catch (Exception ex)
            {
                /*
                sb.AppendLine(ec != ErrorCode.None ? ec + ":" : String.Empty + ex.Message);
                label2.Text = sb.ToString();
                 */
            }

            readConfigurations();

            Application.Run(new MainForm());

        }


        public static void readConfigurations()
        {
            InputActionMtc.btnAshallow = Properties.Settings.Default.btnAshallow;
            InputActionMtc.btnAdeep = Properties.Settings.Default.btnAdeep;
            InputActionMtc.btnB = Properties.Settings.Default.btnB;
            InputActionMtc.btnC = Properties.Settings.Default.btnC;
            InputActionMtc.btnD = Properties.Settings.Default.btnD;
            InputActionMtc.Up = Properties.Settings.Default.btnUp;
            InputActionMtc.Down = Properties.Settings.Default.btnDown;
            InputActionMtc.Left = Properties.Settings.Default.btnLeft;
            InputActionMtc.Right = Properties.Settings.Default.btnRight;
            InputActionMtc.Start = Properties.Settings.Default.btnStart;
            InputActionMtc.Select = Properties.Settings.Default.btnSelect;
            InputActionMtc.Ats = Properties.Settings.Default.btnAts;

            InputActionMtc.ActionLabel.Clear();
            InputActionMtc.ActionLabel.Add("NotchUp", "力行側へ1段");
            InputActionMtc.ActionLabel.Add("NotchDw", "制動側へ1段");
            InputActionMtc.ActionLabel.Add("NotchN", "ノッチをNにする");
            InputActionMtc.ActionLabel.Add("NotchToN", "ノッチをN側へ1段");
            InputActionMtc.ActionLabel.Add("NotchEB", "EBノッチ");
            InputActionMtc.ActionLabel.Add("NotchB1", "B1ノッチ");
            InputActionMtc.ActionLabel.Add("GradientStart", "勾配起動スイッチ");
            InputActionMtc.ActionLabel.Add("Buzzer", "連絡ブザー");
            InputActionMtc.ActionLabel.Add("HornAir", "空笛");
            InputActionMtc.ActionLabel.Add("HornEle", "電笛");
            InputActionMtc.ActionLabel.Add("ViewChange", "外部視点との切り替え");
            InputActionMtc.ActionLabel.Add("PauseMenu", "ポーズメニュー");
            InputActionMtc.ActionLabel.Add("ViewDiagram", "スタフの表示ON/OFF");
            InputActionMtc.ActionLabel.Add("ViewUserInterface", "画面表示ON/OFF");
            InputActionMtc.ActionLabel.Add("ViewHome", "視点の回転をリセット");
            InputActionMtc.ActionLabel.Add("EBReset", "EBリセット");
            InputActionMtc.ActionLabel.Add("DriverViewR", "右側へ視点移動");
            InputActionMtc.ActionLabel.Add("DriverViewL", "左側へ視点移動");
            InputActionMtc.ActionLabel.Add("DriverViewC", "運転席へ視点移動");
            InputActionMtc.ActionLabel.Add("LightLow", "前灯減光");
            InputActionMtc.ActionLabel.Add("DoorOpn", "ドア開扉");
            InputActionMtc.ActionLabel.Add("DoorCls", "ドア閉扉");
            InputActionMtc.ActionLabel.Add("ReOpenSW", "再開閉SW");
            InputActionMtc.ActionLabel.Add("JoukouSokusin", "乗降促進SW");
            InputActionMtc.ActionLabel.Add("DoorKey", "ドアスイッチ鍵操作");
            InputActionMtc.ActionLabel.Add("Housou", "車内放送再生");
            InputActionMtc.ActionLabel.Add("ConductorViewB", "後方確認");

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Aボタン（浅押し）：{0}", InputActionMtc.ActionLabel[InputActionMtc.btnAshallow]).AppendLine();
            sb.AppendFormat("Aボタン（深押し）：{0}", InputActionMtc.ActionLabel[InputActionMtc.btnAdeep]).AppendLine();
            sb.AppendFormat("Bボタン：{0}", InputActionMtc.ActionLabel[InputActionMtc.btnB]).AppendLine();
            sb.AppendFormat("Cボタン：{0}", InputActionMtc.ActionLabel[InputActionMtc.btnC]).AppendLine();
            sb.AppendFormat("Dボタン：{0}", InputActionMtc.ActionLabel[InputActionMtc.btnD]).AppendLine();
            sb.AppendFormat("上ボタン：{0}", InputActionMtc.ActionLabel[InputActionMtc.Up]).AppendLine();
            sb.AppendFormat("下ボタン：{0}", InputActionMtc.ActionLabel[InputActionMtc.Down]).AppendLine();
            sb.AppendFormat("左ボタン：{0}", InputActionMtc.ActionLabel[InputActionMtc.Left]).AppendLine();
            sb.AppendFormat("右ボタン：{0}", InputActionMtc.ActionLabel[InputActionMtc.Right]).AppendLine();
            sb.AppendFormat("スタート：{0}", InputActionMtc.ActionLabel[InputActionMtc.Start]).AppendLine();
            sb.AppendFormat("セレクト：{0}", InputActionMtc.ActionLabel[InputActionMtc.Select]).AppendLine();
            sb.AppendFormat("ATS確認：{0}", InputActionMtc.ActionLabel[InputActionMtc.Ats]).AppendLine();

            InputActionMtc.SettingStatus = sb.ToString();
        }



        public static void MainFormClosing()
        {
        }
        public static void WaitingFormClosing()
        {
            UsbDevice.Exit();
            Application.Exit();
        }

    }
}
