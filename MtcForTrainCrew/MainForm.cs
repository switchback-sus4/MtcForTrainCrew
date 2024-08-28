using LibUsbDotNet;
using LibUsbDotNet.Main;
using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using TrainCrew;

namespace MtcForTrainCrew
{
    public partial class MainForm : Form
    {
        ButtonSettingForm buttonSettingForm;
        Timer timer;
        public static UsbDevice MTC;
        public static UsbDeviceFinder MTCP5B7Finder = new UsbDeviceFinder(0x0AE4, 0x0101, 800);
        public static UsbDeviceFinder MTCP5B8Finder = new UsbDeviceFinder(0x0AE4, 0x0004, 0x0100);
        public static TrainState trainState;
        public static TrainSwitch trainSwitch;

        public MainForm()
        {
            InitializeComponent();
            FormClosing += Form1_FormClosing;

            ErrorCode ec = ErrorCode.None;

            try
            {
                if (MtcState.ConnectedCassette == "P5B7")
                {
                    MTC = UsbDevice.OpenUsbDevice(MTCP5B7Finder);
                }
                else if (MtcState.ConnectedCassette == "P5B8")
                {
                    MTC = UsbDevice.OpenUsbDevice(MTCP5B7Finder);
                }
                else if (MtcState.ConnectedCassette == "P4B7")
                {
                }

                if (MTC == null) throw new Exception("Device Not Found.");
                IUsbDevice wholeUsbDevice = MTC as IUsbDevice;
                if (!ReferenceEquals(wholeUsbDevice, null))
                {
                    wholeUsbDevice.SetConfiguration(1);
                    wholeUsbDevice.ClaimInterface(0);
                }

            }
            catch (Exception ex)
            {
            }

            TrainCrewInput.Init();

            labelConnectedCassette.Text += MtcState.ConnectedCassette;
            labelSettingStatus.Text += InputActionMtc.SettingStatus;

            label1.Text = "";

            timer = new Timer();
            timer.Tick += Timer_Tick;
            timer.Interval = 50;
            timer.Start();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            TrainCrewInput.Dispose();
            UsbDevice.Exit();
        }

        public static void InputActionRunner(string ActionName, Boolean onoff)
        {
            if (String.IsNullOrEmpty(ActionName) || (ActionName == "GradientStart" && trainState.Speed > 2 && onoff)) return;
            InputAction act;
            Enum.TryParse(ActionName, out act);
            TrainCrewInput.SetButton(act, onoff);
        }

        private void roundButtonA_Click(object sender, EventArgs e)
        {
        }

        private void roundButtonB_Click(object sender, EventArgs e)
        {
            changeButtonSetting("btnB", InputActionMtc.btnB);
        }

        private void roundButtonC_Click(object sender, EventArgs e)
        {
            changeButtonSetting("btnC", InputActionMtc.btnC);
        }

        private void roundButtonD_Click(object sender, EventArgs e)
        {
            changeButtonSetting("btnD", InputActionMtc.btnD);
        }

        private void buttonUp_Click(object sender, EventArgs e)
        {
            changeButtonSetting("btnUp", InputActionMtc.Up);
        }

        private void buttonDown_Click(object sender, EventArgs e)
        {
            changeButtonSetting("btnDown", InputActionMtc.Down);
        }

        private void buttonLeft_Click(object sender, EventArgs e)
        {
            changeButtonSetting("btnLeft", InputActionMtc.Left);
        }

        private void buttonRight_Click(object sender, EventArgs e)
        {
            changeButtonSetting("btnRight", InputActionMtc.Right);
        }

        private void triangleButtonStart_Click(object sender, EventArgs e)
        {
            changeButtonSetting("btnStart", InputActionMtc.Start);
        }

        private void buttonSelect_Click(object sender, EventArgs e)
        {
            changeButtonSetting("btnSelect", InputActionMtc.Select);
        }

        private void roundButtonAts_Click(object sender, EventArgs e)
        {
            changeButtonSetting("btnAts", InputActionMtc.Ats);
        }


        private void changeButtonSetting(string targetButton, string targetButtonSelected)
        {
            buttonSettingForm = new ButtonSettingForm(targetButton, targetButtonSelected);
            if(buttonSettingForm.ShowDialog(this) == DialogResult.OK)
            {
                refreshSettingStatuslabel();
            }
            buttonSettingForm.Dispose();
        }

        private void refreshSettingStatuslabel()
        {
            Program.readConfigurations();
            labelSettingStatus.Text = "設定状況\r\n\r\n";
            labelSettingStatus.Text += InputActionMtc.SettingStatus;
        }


        private void Timer_Tick(object sender, EventArgs e)
        {
            trainState = TrainCrewInput.GetTrainState();
            trainSwitch = TrainCrewInput.trainSwitch;
            if (MTC != null)
            {
                UsbEndpointReader reader = MTC.OpenEndpointReader(ReadEndpointID.Ep01);
                byte[] readBuffer = new byte[8];
                int bytesRead;

                // 2km/h以上で勾配起動自動オフしたい
/*
                if (trainState.Speed >= 2 )
                {
                    TrainCrewInput.SetButton(InputAction.GradientStart, false);
                }
*/

                ErrorCode ec = ErrorCode.None;
                ec = reader.Read(readBuffer, 50, out bytesRead);

                // レバーサー
                if ((readBuffer[1] >> 7) == 1)
                {
                    MtcState.ReverserPos = 1;
                }
                else if ((readBuffer[1] >> 6) == 1)
                {
                    MtcState.ReverserPos = -1;
                }
                else
                {
                    MtcState.ReverserPos = 0;
                }

                //if (trainState.Reverser != MtcState.ReverserPos)
                if (MtcState.ReverserPosExist != MtcState.ReverserPos) 
                {
                    TrainCrewInput.SetReverser(MtcState.ReverserPos);
                    MtcState.ReverserPosExist = MtcState.ReverserPos;
                }

                // マスコン
                //MtcState.HandlePosExist = trainState.Pnotch - trainState.Bnotch;
                MtcState.HandlePos = (readBuffer[1] % 64) - 9;
                if (MtcState.HandlePosExist != MtcState.HandlePos)
                {
                    //label2.Text += "\r\n" + MtcState.Reverser[(readBuffer[1] / 64)] + " : " + MtcState.Handle[((readBuffer[1] % 64) - 1)];
                    TrainCrewInput.SetNotch(MtcState.HandlePos);
                    MtcState.HandlePosExist = MtcState.HandlePos;
                }

                // ボタン
                MtcState.readColorButtonBuffer = readBuffer[2];
                if (MtcState.readColorButtonBufferExist != MtcState.readColorButtonBuffer)
                {
                    // ATS確認ボタン
                    switch ((MtcState.readColorButtonBuffer >> 0) % 2)
                    {
                        case 0:
                            InputActionRunner(InputActionMtc.Ats, false);
                            break;
                        case 1:
                            InputActionRunner(InputActionMtc.Ats, true);
                            break;
                    }

                    // Dボタン
                    switch ((MtcState.readColorButtonBuffer >> 1) % 2)
                    {
                        case 0: InputActionRunner(InputActionMtc.btnD, false); break;
                        case 1: InputActionRunner(InputActionMtc.btnD, true); break;
                    }

                    // Aボタン弱押し
                    switch ((MtcState.readColorButtonBuffer >> 2) % 2)
                    {
                        case 0: TrainCrewInput.SetButton(InputAction.HornEle, false); break;
                        case 1: TrainCrewInput.SetButton(InputAction.HornEle, true); break;
                    }

                    // Aボタン強押し（半押しは継続される）
                    switch ((MtcState.readColorButtonBuffer >> 3) % 2)
                    {
                        case 0: TrainCrewInput.SetButton(InputAction.HornAir, false); break;
                        case 1: TrainCrewInput.SetButton(InputAction.HornAir, true); break;
                    }

                    // Bボタン
                    switch ((MtcState.readColorButtonBuffer >> 4) % 2)
                    {
                        case 0: InputActionRunner(InputActionMtc.btnB, false); break;
                        case 1: InputActionRunner(InputActionMtc.btnB, true); break;
                    }

                    // Cボタン
                    switch ((MtcState.readColorButtonBuffer >> 5) % 2)
                    {
                        case 0: InputActionRunner(InputActionMtc.btnC, false); break;
                        case 1: InputActionRunner(InputActionMtc.btnC, true); break;
                    }

                    MtcState.readColorButtonBufferExist = MtcState.readColorButtonBuffer;
                }

                MtcState.readCtrlButtonBuffer = readBuffer[3];
                if (MtcState.readCtrlButtonBufferExist != MtcState.readCtrlButtonBuffer)
                {
                    // 矢印ボタン
                    // START ボタン
                    switch ((MtcState.readCtrlButtonBuffer >> 0) % 2)
                    {
                        case 0: InputActionRunner(InputActionMtc.Start, false); break;
                        case 1: InputActionRunner(InputActionMtc.Start, true); break;
                    }

                    // SELECT ボタン
                    switch ((MtcState.readCtrlButtonBuffer >> 1) % 2)
                    {
                        case 0: InputActionRunner(InputActionMtc.Select, false); break;
                        case 1: InputActionRunner(InputActionMtc.Select, true); break;
                    }

                    // 上ボタン
                    switch ((MtcState.readCtrlButtonBuffer >> 2) % 2)
                    {
                        case 0: InputActionRunner(InputActionMtc.Up, false); break;
                        case 1: InputActionRunner(InputActionMtc.Up, true); break;
                    }

                    // 下ボタン
                    switch ((MtcState.readCtrlButtonBuffer >> 3) % 2)
                    {
                        case 0: InputActionRunner(InputActionMtc.Down, false); break;
                        case 1: InputActionRunner(InputActionMtc.Down, true); break;
                    }

                    // 左ボタン
                    switch ((MtcState.readCtrlButtonBuffer >> 4) % 2)
                    {
                        case 0: InputActionRunner(InputActionMtc.Left, false); break;
                        case 1: InputActionRunner(InputActionMtc.Left, true); break;
                    }

                    // 右ボタン
                    switch ((MtcState.readCtrlButtonBuffer >> 5) % 2)
                    {
                        case 0: InputActionRunner(InputActionMtc.Right, false); break;
                        case 1: InputActionRunner(InputActionMtc.Right, true); break;
                    }
                    MtcState.readCtrlButtonBufferExist = MtcState.readCtrlButtonBuffer;
                }

                label1.Text = "Handle: " + MtcState.HandlePosExist;
                label1.Text += "\r\nReverser: " + MtcState.ReverserPosExist;
                label2.Text = BitConverter.ToString(readBuffer);
                label2.Text += "\r\n" + Convert.ToString(readBuffer[1], 2);
                label2.Text += "\r\n" + Convert.ToString(readBuffer[2], 2);
                //label2.Text += "\r\n" + "HandlePos: " + MtcState.HandlePos;
                //label2.Text += "\r\n" + "Reverser: " + trainState.Reverser;
                //label2.Text = ((readBuffer[1] % 64)).ToString() + " : " + ((readBuffer[1] % 64) - 9).ToString();
            }
        }

        private void buttonResetSetting_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Reset();
            refreshSettingStatuslabel();
        }

        private void debugModeButton_Click(object sender, EventArgs e)
        {
            if(label2.Visible){
                label1.Visible = false;
                label2.Visible = false;
                debugModeButton.Text = debugModeButton.Text.Replace("ON", "OFF");
            }
            else {
                label1.Visible = true;
                label2.Visible = true;
                debugModeButton.Text = debugModeButton.Text.Replace("OFF","ON");
            }
        }
    }
}   