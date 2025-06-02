using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MasterMic
{
    public partial class SoundboardSubForm : Form
    {
        public VirtualMicSoundboard soundboard;

        public SoundboardSubForm()
        {
            InitializeComponent();
            lb_dir.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\MasterMic";
            soundboard = new VirtualMicSoundboard(DashboardForm.Instance.homeSubForm.getOutputDeviceCombobox().SelectedIndex, selfListen.Checked);
        }

        private void RefreshWAVFileList()
        {
            string folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "MasterMic");

            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            string[] mp3Files = Directory.GetFiles(folder, "*.mp3", SearchOption.TopDirectoryOnly);

            soundBoardList.Items.Clear();

            foreach (string file in mp3Files)
            {
                soundBoardList.Items.Add(Path.GetFileName(file));
            }

            string[] wavFiles = Directory.GetFiles(folder, "*.wav", SearchOption.TopDirectoryOnly);

            foreach (string file in wavFiles)
            {
                soundBoardList.Items.Add(Path.GetFileName(file));
            }
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            RefreshWAVFileList();
        }

        private void btn_open_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "MasterMic"));
        }

        private void soundBoardList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = soundBoardList.IndexFromPoint(e.Location);
            if (index != ListBox.NoMatches)
            {

                string selectedItem = soundBoardList.Items[index].ToString();

                string folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "MasterMic");
                string fullPath = Path.Combine(folder, selectedItem);

                soundboard.PlaySound(fullPath);
            }
        }

        private void selfListen_CheckStateChanged(object sender, EventArgs e)
        {
            soundboard.setAutoListen(selfListen.Checked);
        }

        public bool getAutoListen() { return selfListen.Checked; }
    }
}
