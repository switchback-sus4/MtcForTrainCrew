using System;
using System.Windows.Forms;

namespace MtcForTrainCrew
{
    public partial class ButtonSettingForm : Form
    {
        public string targetButtonPb;
        public string targetButtonSelectedPb;
        private string selectedAction;
        public ButtonSettingForm(string targetButton, string targetButtonSelected)
        {
            targetButtonPb = targetButton;
            targetButtonSelectedPb = targetButtonSelected;
            InitializeComponent();

            if (string.IsNullOrEmpty(targetButtonSelected))
            {
                label1.Text = "設定中の動作：なし";
            } else
            {
                label1.Text = "設定中の動作：" + InputActionMtc.ActionLabel[targetButtonSelected];
            }

            string keys = InputActionMtc.ActionLabel.Keys.ToString();
//            listBox1.Items.Add("（設定なし）");
            foreach (string key in InputActionMtc.ActionLabel.Keys)
            {
//                listBox1.Items.Add(InputAction.ActionLabel[key]);
                listBox1.Items.Add(new listItems { Key = key, Value = InputActionMtc.ActionLabel[key].ToString() });
            }
            listBox1.DisplayMember = "Value";
            listBox1.ValueMember = "Key";
            selectedAction = targetButtonSelected;
    }

        public class listItems
        {
            public string Key { get; set; }
            public string Value { get; set; }

        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedAction = ((listItems)listBox1.SelectedItem).Key;
        }
        private void buttonOK_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default[targetButtonPb] = selectedAction;
            Properties.Settings.Default.Save();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {

        }
    }

}
