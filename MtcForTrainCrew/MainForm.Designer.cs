namespace MtcForTrainCrew
{
    partial class MainForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.labelConnectedCassette = new System.Windows.Forms.Label();
            this.buttonUp = new System.Windows.Forms.Button();
            this.buttonDown = new System.Windows.Forms.Button();
            this.buttonLeft = new System.Windows.Forms.Button();
            this.buttonRight = new System.Windows.Forms.Button();
            this.buttonSelect = new System.Windows.Forms.Button();
            this.labelSettingStatus = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonResetSetting = new System.Windows.Forms.Button();
            this.debugModeButton = new System.Windows.Forms.Button();
            this.roundButtonAts = new MtcForTrainCrew.RoundButton();
            this.triangleButtonStart = new MtcForTrainCrew.TriangleButton();
            this.roundButtonD = new MtcForTrainCrew.RoundButton();
            this.roundButtonC = new MtcForTrainCrew.RoundButton();
            this.roundButtonB = new MtcForTrainCrew.RoundButton();
            this.roundButtonA = new MtcForTrainCrew.RoundButton();
            this.SuspendLayout();
            // 
            // labelConnectedCassette
            // 
            this.labelConnectedCassette.AutoSize = true;
            this.labelConnectedCassette.Font = new System.Drawing.Font("游ゴシック", 11F);
            this.labelConnectedCassette.Location = new System.Drawing.Point(43, 52);
            this.labelConnectedCassette.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelConnectedCassette.Name = "labelConnectedCassette";
            this.labelConnectedCassette.Size = new System.Drawing.Size(233, 29);
            this.labelConnectedCassette.TabIndex = 0;
            this.labelConnectedCassette.Text = "接続されたカセット：";
            // 
            // buttonUp
            // 
            this.buttonUp.BackColor = System.Drawing.SystemColors.ControlText;
            this.buttonUp.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.buttonUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonUp.Location = new System.Drawing.Point(152, 242);
            this.buttonUp.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.buttonUp.Name = "buttonUp";
            this.buttonUp.Size = new System.Drawing.Size(33, 60);
            this.buttonUp.TabIndex = 2;
            this.buttonUp.UseVisualStyleBackColor = false;
            this.buttonUp.Click += new System.EventHandler(this.buttonUp_Click);
            // 
            // buttonDown
            // 
            this.buttonDown.BackColor = System.Drawing.SystemColors.ControlText;
            this.buttonDown.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.buttonDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDown.Location = new System.Drawing.Point(152, 350);
            this.buttonDown.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.buttonDown.Name = "buttonDown";
            this.buttonDown.Size = new System.Drawing.Size(33, 60);
            this.buttonDown.TabIndex = 3;
            this.buttonDown.UseVisualStyleBackColor = false;
            this.buttonDown.Click += new System.EventHandler(this.buttonDown_Click);
            // 
            // buttonLeft
            // 
            this.buttonLeft.BackColor = System.Drawing.SystemColors.ControlText;
            this.buttonLeft.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.buttonLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLeft.Location = new System.Drawing.Point(85, 310);
            this.buttonLeft.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.buttonLeft.Name = "buttonLeft";
            this.buttonLeft.Size = new System.Drawing.Size(67, 30);
            this.buttonLeft.TabIndex = 4;
            this.buttonLeft.UseVisualStyleBackColor = false;
            this.buttonLeft.Click += new System.EventHandler(this.buttonLeft_Click);
            // 
            // buttonRight
            // 
            this.buttonRight.BackColor = System.Drawing.SystemColors.ControlText;
            this.buttonRight.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.buttonRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRight.Location = new System.Drawing.Point(185, 310);
            this.buttonRight.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.buttonRight.Name = "buttonRight";
            this.buttonRight.Size = new System.Drawing.Size(67, 30);
            this.buttonRight.TabIndex = 5;
            this.buttonRight.UseVisualStyleBackColor = false;
            this.buttonRight.Click += new System.EventHandler(this.buttonRight_Click);
            // 
            // buttonSelect
            // 
            this.buttonSelect.BackColor = System.Drawing.SystemColors.ControlText;
            this.buttonSelect.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.buttonSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSelect.Location = new System.Drawing.Point(295, 310);
            this.buttonSelect.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.buttonSelect.Name = "buttonSelect";
            this.buttonSelect.Size = new System.Drawing.Size(83, 30);
            this.buttonSelect.TabIndex = 13;
            this.buttonSelect.UseVisualStyleBackColor = false;
            this.buttonSelect.Click += new System.EventHandler(this.buttonSelect_Click);
            // 
            // labelSettingStatus
            // 
            this.labelSettingStatus.AutoSize = true;
            this.labelSettingStatus.Font = new System.Drawing.Font("游ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelSettingStatus.Location = new System.Drawing.Point(590, 51);
            this.labelSettingStatus.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelSettingStatus.Name = "labelSettingStatus";
            this.labelSettingStatus.Size = new System.Drawing.Size(110, 62);
            this.labelSettingStatus.TabIndex = 16;
            this.labelSettingStatus.Text = "設定状況\r\n\r\n";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("游ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(50, 514);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 26);
            this.label2.TabIndex = 17;
            this.label2.Text = "aaaaaa";
            this.label2.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("游ゴシック", 9.75F);
            this.label1.Location = new System.Drawing.Point(405, 514);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 26);
            this.label1.TabIndex = 18;
            this.label1.Text = "label1";
            this.label1.Visible = false;
            // 
            // buttonResetSetting
            // 
            this.buttonResetSetting.Font = new System.Drawing.Font("游ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonResetSetting.Location = new System.Drawing.Point(743, 48);
            this.buttonResetSetting.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.buttonResetSetting.Name = "buttonResetSetting";
            this.buttonResetSetting.Size = new System.Drawing.Size(162, 34);
            this.buttonResetSetting.TabIndex = 19;
            this.buttonResetSetting.Text = "設定リセット";
            this.buttonResetSetting.UseVisualStyleBackColor = true;
            this.buttonResetSetting.Click += new System.EventHandler(this.buttonResetSetting_Click);
            // 
            // debugModeButton
            // 
            this.debugModeButton.Font = new System.Drawing.Font("游ゴシック", 9F);
            this.debugModeButton.Location = new System.Drawing.Point(48, 11);
            this.debugModeButton.Name = "debugModeButton";
            this.debugModeButton.Size = new System.Drawing.Size(254, 35);
            this.debugModeButton.TabIndex = 20;
            this.debugModeButton.Text = "Debugモード：OFF";
            this.debugModeButton.UseVisualStyleBackColor = true;
            this.debugModeButton.Click += new System.EventHandler(this.debugModeButton_Click);
            // 
            // roundButtonAts
            // 
            this.roundButtonAts.BackColor = System.Drawing.Color.White;
            this.roundButtonAts.FlatAppearance.BorderSize = 0;
            this.roundButtonAts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.roundButtonAts.Font = new System.Drawing.Font("游ゴシック", 10F);
            this.roundButtonAts.Location = new System.Drawing.Point(405, 426);
            this.roundButtonAts.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.roundButtonAts.Name = "roundButtonAts";
            this.roundButtonAts.Size = new System.Drawing.Size(83, 75);
            this.roundButtonAts.TabIndex = 15;
            this.roundButtonAts.Text = "ATS\r\n確認";
            this.roundButtonAts.UseVisualStyleBackColor = false;
            this.roundButtonAts.Click += new System.EventHandler(this.roundButtonAts_Click);
            // 
            // triangleButtonStart
            // 
            this.triangleButtonStart.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.triangleButtonStart.Direction = MtcForTrainCrew.TriangleButton.TriangleDirection.Right;
            this.triangleButtonStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.triangleButtonStart.Location = new System.Drawing.Point(405, 310);
            this.triangleButtonStart.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.triangleButtonStart.Name = "triangleButtonStart";
            this.triangleButtonStart.Size = new System.Drawing.Size(83, 30);
            this.triangleButtonStart.TabIndex = 14;
            this.triangleButtonStart.TriangleColor = System.Drawing.SystemColors.ControlText;
            this.triangleButtonStart.UseVisualStyleBackColor = false;
            this.triangleButtonStart.Click += new System.EventHandler(this.triangleButtonStart_Click);
            // 
            // roundButtonD
            // 
            this.roundButtonD.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.roundButtonD.FlatAppearance.BorderSize = 0;
            this.roundButtonD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.roundButtonD.Font = new System.Drawing.Font("游ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.roundButtonD.Location = new System.Drawing.Point(405, 124);
            this.roundButtonD.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.roundButtonD.Name = "roundButtonD";
            this.roundButtonD.Size = new System.Drawing.Size(83, 75);
            this.roundButtonD.TabIndex = 11;
            this.roundButtonD.Text = "D";
            this.roundButtonD.UseVisualStyleBackColor = false;
            this.roundButtonD.Click += new System.EventHandler(this.roundButtonD_Click);
            // 
            // roundButtonC
            // 
            this.roundButtonC.BackColor = System.Drawing.Color.Red;
            this.roundButtonC.FlatAppearance.BorderSize = 0;
            this.roundButtonC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.roundButtonC.Font = new System.Drawing.Font("游ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.roundButtonC.Location = new System.Drawing.Point(295, 124);
            this.roundButtonC.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.roundButtonC.Name = "roundButtonC";
            this.roundButtonC.Size = new System.Drawing.Size(83, 75);
            this.roundButtonC.TabIndex = 8;
            this.roundButtonC.Text = "C";
            this.roundButtonC.UseVisualStyleBackColor = false;
            this.roundButtonC.Click += new System.EventHandler(this.roundButtonC_Click);
            // 
            // roundButtonB
            // 
            this.roundButtonB.BackColor = System.Drawing.Color.Yellow;
            this.roundButtonB.FlatAppearance.BorderSize = 0;
            this.roundButtonB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.roundButtonB.Font = new System.Drawing.Font("游ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.roundButtonB.Location = new System.Drawing.Point(182, 124);
            this.roundButtonB.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.roundButtonB.Name = "roundButtonB";
            this.roundButtonB.Size = new System.Drawing.Size(83, 75);
            this.roundButtonB.TabIndex = 7;
            this.roundButtonB.Text = "B";
            this.roundButtonB.UseVisualStyleBackColor = false;
            this.roundButtonB.Click += new System.EventHandler(this.roundButtonB_Click);
            // 
            // roundButtonA
            // 
            this.roundButtonA.BackColor = System.Drawing.Color.GreenYellow;
            this.roundButtonA.FlatAppearance.BorderSize = 0;
            this.roundButtonA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.roundButtonA.Font = new System.Drawing.Font("游ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.roundButtonA.Location = new System.Drawing.Point(72, 124);
            this.roundButtonA.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.roundButtonA.Name = "roundButtonA";
            this.roundButtonA.Size = new System.Drawing.Size(83, 75);
            this.roundButtonA.TabIndex = 6;
            this.roundButtonA.Text = "A";
            this.roundButtonA.UseVisualStyleBackColor = false;
            this.roundButtonA.Click += new System.EventHandler(this.roundButtonA_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1333, 675);
            this.Controls.Add(this.debugModeButton);
            this.Controls.Add(this.buttonResetSetting);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelSettingStatus);
            this.Controls.Add(this.roundButtonAts);
            this.Controls.Add(this.triangleButtonStart);
            this.Controls.Add(this.buttonSelect);
            this.Controls.Add(this.roundButtonD);
            this.Controls.Add(this.roundButtonC);
            this.Controls.Add(this.roundButtonB);
            this.Controls.Add(this.roundButtonA);
            this.Controls.Add(this.buttonRight);
            this.Controls.Add(this.buttonLeft);
            this.Controls.Add(this.buttonDown);
            this.Controls.Add(this.buttonUp);
            this.Controls.Add(this.labelConnectedCassette);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "MainForm";
            this.Text = "MTC for TrainCrew";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelConnectedCassette;
        private System.Windows.Forms.Button buttonUp;
        private System.Windows.Forms.Button buttonDown;
        private System.Windows.Forms.Button buttonLeft;
        private System.Windows.Forms.Button buttonRight;
        private RoundButton roundButtonA;
        private RoundButton roundButtonB;
        private RoundButton roundButtonC;
        private RoundButton roundButtonD;
        private System.Windows.Forms.Button buttonSelect;
        private TriangleButton triangleButtonStart;
        private RoundButton roundButtonAts;
        private System.Windows.Forms.Label labelSettingStatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonResetSetting;
        private System.Windows.Forms.Button debugModeButton;
    }
}

