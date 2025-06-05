namespace MasterMic
{
    partial class SoundboardSubForm
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
            btn_refresh = new Button();
            btn_open = new Button();
            lb_dir = new Label();
            selfListen = new CheckBox();
            soundBoardListPanel = new FlowLayoutPanel();
            button1 = new Button();
            SuspendLayout();
            // 
            // btn_refresh
            // 
            btn_refresh.BackColor = Color.FromArgb(21, 17, 27);
            btn_refresh.FlatStyle = FlatStyle.Flat;
            btn_refresh.ForeColor = Color.Gainsboro;
            btn_refresh.Location = new Point(12, 12);
            btn_refresh.Name = "btn_refresh";
            btn_refresh.Size = new Size(93, 33);
            btn_refresh.TabIndex = 0;
            btn_refresh.Text = "Refresh";
            btn_refresh.UseVisualStyleBackColor = false;
            btn_refresh.Click += btn_refresh_Click;
            // 
            // btn_open
            // 
            btn_open.BackColor = Color.FromArgb(21, 17, 27);
            btn_open.FlatStyle = FlatStyle.Flat;
            btn_open.ForeColor = Color.Gainsboro;
            btn_open.Location = new Point(111, 12);
            btn_open.Name = "btn_open";
            btn_open.Size = new Size(137, 33);
            btn_open.TabIndex = 1;
            btn_open.Text = "Open Folder";
            btn_open.UseVisualStyleBackColor = false;
            btn_open.Click += btn_open_Click;
            // 
            // lb_dir
            // 
            lb_dir.AutoSize = true;
            lb_dir.ForeColor = Color.Gainsboro;
            lb_dir.Location = new Point(254, 18);
            lb_dir.Name = "lb_dir";
            lb_dir.Size = new Size(36, 20);
            lb_dir.TabIndex = 2;
            lb_dir.Text = "???";
            // 
            // selfListen
            // 
            selfListen.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            selfListen.AutoSize = true;
            selfListen.Checked = true;
            selfListen.CheckState = CheckState.Checked;
            selfListen.ForeColor = Color.Gainsboro;
            selfListen.Location = new Point(566, 17);
            selfListen.Name = "selfListen";
            selfListen.Size = new Size(103, 24);
            selfListen.TabIndex = 3;
            selfListen.Text = "Self Listen";
            selfListen.UseVisualStyleBackColor = true;
            selfListen.Click += selfListen_CheckStateChanged;
            // 
            // soundBoardListPanel
            // 
            soundBoardListPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            soundBoardListPanel.FlowDirection = FlowDirection.TopDown;
            soundBoardListPanel.Location = new Point(0, 61);
            soundBoardListPanel.Margin = new Padding(0);
            soundBoardListPanel.Name = "soundBoardListPanel";
            soundBoardListPanel.Size = new Size(684, 501);
            soundBoardListPanel.TabIndex = 4;
            soundBoardListPanel.SizeChanged += soundBoardListPanel_SizeChanged;
            // 
            // button1
            // 
            button1.Location = new Point(3, 3);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 0;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // SoundboardSubForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(17, 14, 24);
            ClientSize = new Size(684, 561);
            Controls.Add(soundBoardListPanel);
            Controls.Add(selfListen);
            Controls.Add(lb_dir);
            Controls.Add(btn_open);
            Controls.Add(btn_refresh);
            Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            Name = "SoundboardSubForm";
            Text = "SoundboardSubForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_refresh;
        private Button btn_open;
        private Label lb_dir;
        private CheckBox selfListen;
        private SoundboardButton soudboardButton1;
        private FlowLayoutPanel soundBoardListPanel;
        private Button button1;
    }

}