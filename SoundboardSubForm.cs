using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MasterMic
{
    public partial class SoundboardSubForm : Form
    {
        public static SoundboardSubForm Instance;

        public VirtualMicSoundboard soundboard;

        public List<SoundboardButton> buttons;

        public SoundboardSubForm()
        {
            if (Instance == null)
                Instance = this;
            else
                return;

            InitializeComponent();

            soundBoardListPanel.FlowDirection = FlowDirection.TopDown;
            soundBoardListPanel.WrapContents = false;
            soundBoardListPanel.HorizontalScroll.Enabled = false;
            soundBoardListPanel.HorizontalScroll.Visible = false;
            soundBoardListPanel.AutoScroll = true;

            buttons = new List<SoundboardButton>();
            lb_dir.Text = Config.SOUNDBOARD_PATH;
            if (DashboardForm.Instance.homeSubForm == null)
                soundboard = new VirtualMicSoundboard(0, selfListen.Checked);
            else
                soundboard = new VirtualMicSoundboard(DashboardForm.Instance.homeSubForm.getOutputDeviceCombobox().SelectedIndex, selfListen.Checked);

            RefreshWAVFileList();
        }

        private void RefreshWAVFileList()
        {
            if (!Directory.Exists(Config.SOUNDBOARD_PATH))
            {
                Directory.CreateDirectory(Config.SOUNDBOARD_PATH);
            }

            string[] mp3Files = Directory.GetFiles(Config.SOUNDBOARD_PATH, "*.mp3", SearchOption.TopDirectoryOnly);

            soundboard.Stop();
            buttons.Clear();
            soundBoardListPanel.Controls.Clear();

            foreach (string file in mp3Files)
            {
                buttons.Add(new SoundboardButton(Path.GetFileName(file)));
            }

            string[] wavFiles = Directory.GetFiles(Config.SOUNDBOARD_PATH, "*.wav", SearchOption.TopDirectoryOnly);

            foreach (string file in wavFiles)
            {
                buttons.Add(new SoundboardButton(Path.GetFileName(file)));
            }

            for (int i = 0; i < buttons.Count; i++)
            {

                buttons[i].Location = new Point(10, (i * 32) + 5);
                buttons[i].Width = soundBoardListPanel.ClientSize.Width - 10;
                buttons[i].setBorderColorForFixingFocusQuad(soundBoardListPanel.BackColor);
                soundBoardListPanel.Controls.Add(buttons[i]);
            }
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            RefreshWAVFileList();
        }

        private void btn_open_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", Config.SOUNDBOARD_PATH);
        }

        public void soundBoardListStop()
        {
            soundboard.Stop();
        }

        private void selfListen_CheckStateChanged(object sender, EventArgs e)
        {
            soundboard.setAutoListen(selfListen.Checked);
        }

        public bool getAutoListen() { return selfListen.Checked; }

        private void soundBoardListPanel_SizeChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < soundBoardListPanel.Controls.Count; i++)
            {
                soundBoardListPanel.Controls[i].Width = soundBoardListPanel.ClientSize.Width - 10;
            }
        }
    }
}
