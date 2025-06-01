
namespace MicEffectEcho
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private ComboBox cmbInput;
        private ComboBox cmbOutput;
        private Button btnStart;
        private Button btnStop;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            cmbInput = new ComboBox();
            cmbOutput = new ComboBox();
            btnStart = new Button();
            btnStop = new Button();
            cbox_eff_reverb = new CheckBox();
            effectsPanel = new Panel();
            cbox_eff_childvoice = new CheckBox();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            btn_open = new Button();
            lb_dir = new Label();
            btn_refresh = new Button();
            soundBoardList = new ListBox();
            effectsPanel.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            SuspendLayout();
            // 
            // cmbInput
            // 
            cmbInput.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cmbInput.FormattingEnabled = true;
            cmbInput.Location = new Point(12, 12);
            cmbInput.Name = "cmbInput";
            cmbInput.Size = new Size(625, 23);
            cmbInput.TabIndex = 0;
            // 
            // cmbOutput
            // 
            cmbOutput.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cmbOutput.FormattingEnabled = true;
            cmbOutput.Location = new Point(12, 41);
            cmbOutput.Name = "cmbOutput";
            cmbOutput.Size = new Size(625, 23);
            cmbOutput.TabIndex = 1;
            cmbOutput.SelectedIndexChanged += cmbOutput_SelectedIndexChanged;
            // 
            // btnStart
            // 
            btnStart.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnStart.Location = new Point(12, 369);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(75, 23);
            btnStart.TabIndex = 2;
            btnStart.Text = "Start";
            btnStart.Click += btnStart_Click;
            // 
            // btnStop
            // 
            btnStop.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnStop.Enabled = false;
            btnStop.Location = new Point(93, 369);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(75, 23);
            btnStop.TabIndex = 3;
            btnStop.Text = "Stop";
            btnStop.Click += btnStop_Click;
            // 
            // cbox_eff_reverb
            // 
            cbox_eff_reverb.AutoSize = true;
            cbox_eff_reverb.Location = new Point(3, 3);
            cbox_eff_reverb.Name = "cbox_eff_reverb";
            cbox_eff_reverb.Size = new Size(62, 19);
            cbox_eff_reverb.TabIndex = 5;
            cbox_eff_reverb.Text = "Reverb";
            cbox_eff_reverb.UseVisualStyleBackColor = true;
            cbox_eff_reverb.CheckStateChanged += cbox_eff_reverb_CheckStateChanged;
            // 
            // effectsPanel
            // 
            effectsPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            effectsPanel.AutoScroll = true;
            effectsPanel.BorderStyle = BorderStyle.FixedSingle;
            effectsPanel.Controls.Add(cbox_eff_childvoice);
            effectsPanel.Controls.Add(cbox_eff_reverb);
            effectsPanel.Location = new Point(3, 3);
            effectsPanel.Name = "effectsPanel";
            effectsPanel.Size = new Size(611, 259);
            effectsPanel.TabIndex = 6;
            // 
            // cbox_eff_childvoice
            // 
            cbox_eff_childvoice.AutoSize = true;
            cbox_eff_childvoice.Location = new Point(3, 28);
            cbox_eff_childvoice.Name = "cbox_eff_childvoice";
            cbox_eff_childvoice.Size = new Size(85, 19);
            cbox_eff_childvoice.TabIndex = 6;
            cbox_eff_childvoice.Text = "Child Voice";
            cbox_eff_childvoice.UseVisualStyleBackColor = true;
            cbox_eff_childvoice.CheckStateChanged += cbox_eff_childvoice_CheckStateChanged;
            // 
            // tabControl1
            // 
            tabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(12, 70);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(625, 293);
            tabControl1.TabIndex = 7;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(effectsPanel);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(617, 265);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Effects";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(btn_open);
            tabPage2.Controls.Add(lb_dir);
            tabPage2.Controls.Add(btn_refresh);
            tabPage2.Controls.Add(soundBoardList);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(617, 265);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "SoundBoard";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // btn_open
            // 
            btn_open.Location = new Point(87, 3);
            btn_open.Name = "btn_open";
            btn_open.Size = new Size(103, 23);
            btn_open.TabIndex = 3;
            btn_open.Text = "Open Folder";
            btn_open.UseVisualStyleBackColor = true;
            btn_open.Click += btn_open_Click;
            // 
            // lb_dir
            // 
            lb_dir.AutoSize = true;
            lb_dir.Location = new Point(196, 7);
            lb_dir.Name = "lb_dir";
            lb_dir.Size = new Size(22, 15);
            lb_dir.TabIndex = 2;
            lb_dir.Text = "???";
            // 
            // btn_refresh
            // 
            btn_refresh.Location = new Point(6, 3);
            btn_refresh.Name = "btn_refresh";
            btn_refresh.Size = new Size(75, 23);
            btn_refresh.TabIndex = 1;
            btn_refresh.Text = "Refresh";
            btn_refresh.UseVisualStyleBackColor = true;
            btn_refresh.Click += btn_refresh_Click;
            // 
            // soundBoardList
            // 
            soundBoardList.FormattingEnabled = true;
            soundBoardList.ItemHeight = 15;
            soundBoardList.Location = new Point(6, 30);
            soundBoardList.Name = "soundBoardList";
            soundBoardList.Size = new Size(605, 229);
            soundBoardList.TabIndex = 0;
            soundBoardList.MouseDoubleClick += soundBoardList_MouseDoubleClick;
            // 
            // MainForm
            // 
            ClientSize = new Size(649, 395);
            Controls.Add(tabControl1);
            Controls.Add(cmbInput);
            Controls.Add(cmbOutput);
            Controls.Add(btnStart);
            Controls.Add(btnStop);
            Name = "MainForm";
            Text = "MasterMic";
            effectsPanel.ResumeLayout(false);
            effectsPanel.PerformLayout();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ResumeLayout(false);
        }

        private CheckBox cbox_eff_reverb;
        private Panel effectsPanel;
        private CheckBox cbox_eff_childvoice;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Label lb_dir;
        private Button btn_refresh;
        private ListBox soundBoardList;
        private Button btn_open;
    }
}
