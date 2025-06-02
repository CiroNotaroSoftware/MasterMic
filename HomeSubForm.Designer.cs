namespace MasterMic
{
    partial class HomeSubForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            comboBoxInputDevice = new ComboBox();
            comboBoxOutputDevice = new ComboBox();
            labelEffects = new Label();
            labelDevice = new Label();
            buttonPlay = new Button();
            buttonStop = new Button();
            checkBoxReverb = new CheckBox();
            checkBoxBassVoice = new CheckBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Gainsboro;
            label1.Location = new Point(24, 42);
            label1.Name = "label1";
            label1.Size = new Size(46, 20);
            label1.TabIndex = 0;
            label1.Text = "Input";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Gainsboro;
            label2.Location = new Point(12, 85);
            label2.Name = "label2";
            label2.Size = new Size(58, 20);
            label2.TabIndex = 1;
            label2.Text = "Output";
            // 
            // comboBoxInputDevice
            // 
            comboBoxInputDevice.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comboBoxInputDevice.Font = new Font("Microsoft Sans Serif", 12F);
            comboBoxInputDevice.FormattingEnabled = true;
            comboBoxInputDevice.Location = new Point(76, 39);
            comboBoxInputDevice.Name = "comboBoxInputDevice";
            comboBoxInputDevice.Size = new Size(596, 28);
            comboBoxInputDevice.TabIndex = 2;
            // 
            // comboBoxOutputDevice
            // 
            comboBoxOutputDevice.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comboBoxOutputDevice.Font = new Font("Microsoft Sans Serif", 12F);
            comboBoxOutputDevice.FormattingEnabled = true;
            comboBoxOutputDevice.Location = new Point(76, 82);
            comboBoxOutputDevice.Name = "comboBoxOutputDevice";
            comboBoxOutputDevice.Size = new Size(596, 28);
            comboBoxOutputDevice.TabIndex = 3;
            comboBoxOutputDevice.SelectedIndexChanged += comboBoxOutputDevice_SelectedIndexChanged;
            // 
            // labelEffects
            // 
            labelEffects.AutoSize = true;
            labelEffects.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelEffects.ForeColor = Color.Gainsboro;
            labelEffects.Location = new Point(2, 126);
            labelEffects.Name = "labelEffects";
            labelEffects.Size = new Size(78, 25);
            labelEffects.TabIndex = 4;
            labelEffects.Text = "Effects";
            // 
            // labelDevice
            // 
            labelDevice.AutoSize = true;
            labelDevice.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelDevice.ForeColor = Color.Gainsboro;
            labelDevice.Location = new Point(2, 9);
            labelDevice.Name = "labelDevice";
            labelDevice.Size = new Size(78, 25);
            labelDevice.TabIndex = 6;
            labelDevice.Text = "Device";
            // 
            // buttonPlay
            // 
            buttonPlay.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonPlay.BackColor = Color.FromArgb(0, 192, 0);
            buttonPlay.FlatStyle = FlatStyle.Flat;
            buttonPlay.Font = new Font("Microsoft Sans Serif", 12F);
            buttonPlay.ForeColor = Color.White;
            buttonPlay.Location = new Point(12, 522);
            buttonPlay.Name = "buttonPlay";
            buttonPlay.Size = new Size(93, 34);
            buttonPlay.TabIndex = 7;
            buttonPlay.Text = "Play";
            buttonPlay.UseVisualStyleBackColor = false;
            buttonPlay.Click += buttonPlay_Click;
            // 
            // buttonStop
            // 
            buttonStop.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonStop.BackColor = Color.Red;
            buttonStop.Enabled = false;
            buttonStop.FlatStyle = FlatStyle.Flat;
            buttonStop.Font = new Font("Microsoft Sans Serif", 12F);
            buttonStop.ForeColor = Color.White;
            buttonStop.Location = new Point(579, 522);
            buttonStop.Name = "buttonStop";
            buttonStop.Size = new Size(93, 34);
            buttonStop.TabIndex = 8;
            buttonStop.Text = "Stop";
            buttonStop.UseVisualStyleBackColor = false;
            buttonStop.Click += buttonStop_Click;
            // 
            // checkBoxReverb
            // 
            checkBoxReverb.AutoSize = true;
            checkBoxReverb.Font = new Font("Microsoft Sans Serif", 12F);
            checkBoxReverb.ForeColor = Color.Gainsboro;
            checkBoxReverb.Location = new Point(12, 154);
            checkBoxReverb.Name = "checkBoxReverb";
            checkBoxReverb.Size = new Size(79, 24);
            checkBoxReverb.TabIndex = 9;
            checkBoxReverb.Text = "Reverb";
            checkBoxReverb.UseVisualStyleBackColor = true;
            checkBoxReverb.CheckStateChanged += checkBoxReverb_CheckStateChanged;
            // 
            // checkBoxBassVoice
            // 
            checkBoxBassVoice.AutoSize = true;
            checkBoxBassVoice.Font = new Font("Microsoft Sans Serif", 12F);
            checkBoxBassVoice.ForeColor = Color.Gainsboro;
            checkBoxBassVoice.Location = new Point(12, 179);
            checkBoxBassVoice.Name = "checkBoxBassVoice";
            checkBoxBassVoice.Size = new Size(108, 24);
            checkBoxBassVoice.TabIndex = 10;
            checkBoxBassVoice.Text = "Bass Voice";
            checkBoxBassVoice.UseVisualStyleBackColor = true;
            checkBoxBassVoice.CheckStateChanged += checkBoxBassVoice_CheckStateChanged;
            // 
            // HomeSubForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(17, 14, 24);
            ClientSize = new Size(684, 561);
            Controls.Add(checkBoxBassVoice);
            Controls.Add(checkBoxReverb);
            Controls.Add(buttonStop);
            Controls.Add(buttonPlay);
            Controls.Add(labelDevice);
            Controls.Add(labelEffects);
            Controls.Add(comboBoxOutputDevice);
            Controls.Add(comboBoxInputDevice);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "HomeSubForm";
            Text = "HomeSubForm";
            FormClosing += HomeSubForm_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private ComboBox comboBoxInputDevice;
        private ComboBox comboBoxOutputDevice;
        private Label labelEffects;
        private Label labelDevice;
        private Button buttonPlay;
        private Button buttonStop;
        private CheckBox checkBoxReverb;
        private CheckBox checkBoxBassVoice;
    }
}