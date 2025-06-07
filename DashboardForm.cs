using MicEffectEcho;
using MicEffectEcho.Effects;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MasterMic
{
    public partial class DashboardForm : Form
    {
        public const int HOTKEY_ID = 9000;
        private const int WM_HOTKEY = 0x0312;

        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);

        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        private const int MOD_ALT = 0x1;
        private const int MOD_CONTROL = 0x2;
        private const int MOD_SHIFT = 0x4;
        private const int MOD_WIN = 0x8;

        public static Dictionary<string, KeyBindData> hotkeys = new Dictionary<string, KeyBindData>();

        public static DashboardForm? Instance;

        // Form Switching System -- DATA //
        private Form activeForm;
        public HomeSubForm homeSubForm;
        public SoundboardSubForm soundboardSubForm;
        public DashboardForm()
        {
            Instance = this;
            InitializeComponent();

            if (File.Exists(Config.KEYBOUNDS_PATH))
            {
                string content = File.ReadAllText(Config.KEYBOUNDS_PATH);
                hotkeys = JsonSerializer.Deserialize<Dictionary<string, KeyBindData>>(content);

                foreach ((string key, KeyBindData value) in hotkeys)
                {
                    int modifierInt = HotKeyRecorder.GetModifierInt(value.modifiers);
                    int keyInt = (int)value.key;

                    DashboardForm.RegisterHotKey(
                       DashboardForm.Instance.Handle,
                       DashboardForm.GenerateHotkeyId(key),
                       modifierInt,
                       keyInt
                   );
                }
            }
        }

        // Listeners //
        private void buttonHome_Click(object sender, EventArgs e)
        {
            if (homeSubForm == null)
                homeSubForm = new HomeSubForm();
            openChildForm(homeSubForm);
        }

        private void buttonSoundboard_Click(object sender, EventArgs e)
        {
            if (soundboardSubForm == null)
                soundboardSubForm = new SoundboardSubForm();
            openChildForm(soundboardSubForm);
        }

        // Form Switching System -- Functions //
        void openChildForm(Form form)
        {
            if (activeForm != null)
                activeForm.Hide();

            activeForm = form;
            activeForm.TopLevel = false;
            activeForm.FormBorderStyle = FormBorderStyle.None;
            activeForm.Dock = DockStyle.Fill;
            panelContent.Controls.Add(activeForm);
            panelContent.Tag = activeForm;
            activeForm.BringToFront();
            activeForm.Show();
        }

        public static int GenerateHotkeyId(string key)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] hash = md5.ComputeHash(Encoding.UTF8.GetBytes(key));
                return BitConverter.ToInt32(hash, 0);
            }
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == WM_HOTKEY)
            {
                foreach ((string key, KeyBindData value) in hotkeys)
                {
                    if (m.WParam.ToInt32() == GenerateHotkeyId(key))
                    {
                        if (SoundboardSubForm.Instance == null)
                        {
                            MessageBox.Show("Open the dashboard first!");
                            return;
                        }

                        foreach (SoundboardButton btn in SoundboardSubForm.Instance.buttons)
                        {
                            if (btn.Text.Equals(key))
                            {
                                btn.PlayButton.PerformClick();
                                return;
                            }
                        }

                        hotkeys.Remove(key);
                    }
                }
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            File.WriteAllText(Config.KEYBOUNDS_PATH, JsonSerializer.Serialize(hotkeys));

            foreach ((string key, KeyBindData value) in hotkeys)
            {
                UnregisterHotKey(this.Handle, GenerateHotkeyId(key));
            }
            base.OnFormClosed(e);
        }

        private void buttonCredits_Click(object sender, EventArgs e)
        {
            CreditsForm c = new CreditsForm();
            c.ShowDialog();
        }
    }
}
