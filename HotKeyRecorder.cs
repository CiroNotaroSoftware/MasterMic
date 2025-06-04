using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterMic
{
    public class HotKeyRecorder : Form
    {
        private Keys modifierKeys = Keys.None;
        private Keys mainKey = Keys.None;

        string key;

        Control ParentForm; 

        public HotKeyRecorder(string key, Control parent)
        {
            InitializeComponent();
            this.key = key;
            ParentForm = parent;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            txtHotkey.ReadOnly = true;
        }

        private void txtHotkey_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;

            modifierKeys = Keys.None;
            if (e.Control) modifierKeys |= Keys.Control;
            if (e.Shift) modifierKeys |= Keys.Shift;
            if (e.Alt) modifierKeys |= Keys.Alt;

            mainKey = e.KeyCode;

            if (mainKey == Keys.ControlKey || mainKey == Keys.ShiftKey || mainKey == Keys.Menu)
                return;

            txtHotkey.Text = FormatHotkey(modifierKeys, mainKey);
        }

        private string FormatHotkey(Keys modifiers, Keys key)
        {
            StringBuilder sb = new StringBuilder();
            if (modifiers.HasFlag(Keys.Control)) sb.Append("Ctrl + ");
            if (modifiers.HasFlag(Keys.Shift)) sb.Append("Shift + ");
            if (modifiers.HasFlag(Keys.Alt)) sb.Append("Alt + ");
            sb.Append(key.ToString());
            return sb.ToString();
        }

        public (Keys Modifiers, Keys Key) GetRecordedHotkey()
        {
            return (modifierKeys, mainKey);
        }

        public static int GetModifierInt(Keys modifiers)
        {
            int mod = 0;
            if (modifiers.HasFlag(Keys.Control)) mod |= 0x2; // MOD_CONTROL
            if (modifiers.HasFlag(Keys.Alt)) mod |= 0x1;     // MOD_ALT
            if (modifiers.HasFlag(Keys.Shift)) mod |= 0x4;   // MOD_SHIFT
            return mod;
        }

        void InitializeComponent()
        {
            this.txtHotkey = new System.Windows.Forms.TextBox();
            this.confirmbtn = new System.Windows.Forms.Button();
            this.deletebtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtHotkey
            // 
            this.txtHotkey.Location = new System.Drawing.Point(30, 30);
            this.txtHotkey.Name = "txtHotkey";
            this.txtHotkey.Size = new System.Drawing.Size(200, 23);
            this.txtHotkey.TabIndex = 0;
            this.txtHotkey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtHotkey_KeyDown);
            // 
            // Confirm
            // 
            this.confirmbtn.Location = new System.Drawing.Point(30, 70);
            this.confirmbtn.Name = "confirmbtn";
            this.confirmbtn.Size = new System.Drawing.Size(200, 23);
            this.confirmbtn.TabIndex = 1;
            this.confirmbtn.Text = "Confirm";
            this.confirmbtn.Click += (sender, e) =>
            {
                int modifierInt = GetModifierInt(GetRecordedHotkey().Modifiers);
                int keyInt = (int)GetRecordedHotkey().Key;

                bool success = false;

                success = txtHotkey.Text.Length > 0;

                if (success)
                {
                    success = DashboardForm.RegisterHotKey(
                        DashboardForm.Instance.Handle,
                        DashboardForm.GenerateHotkeyId(key),
                        modifierInt,
                        keyInt
                    );
                }
                
                if(success)
                {
                    KeyBindData data = new KeyBindData();
                    data.key = GetRecordedHotkey().Key;
                    data.modifiers = GetRecordedHotkey().Modifiers;
                    DashboardForm.hotkeys.Add(key, data);
                }

                MessageBox.Show(success ? "Key recording: OK" : "Key recording: FAILED");
                this.Close();
            };
            // 
            // Delete this
            // 
            this.deletebtn.Location = new System.Drawing.Point(30, 90);
            this.deletebtn.Name = "deletethid";
            this.deletebtn.Size = new System.Drawing.Size(200, 23);
            this.deletebtn.TabIndex = 1;
            this.deletebtn.Text = "Delete binding";
            this.deletebtn.Click += (sender, e) =>
            {
                KeyBindData data = new KeyBindData();
                data.key = GetRecordedHotkey().Key;
                data.modifiers = GetRecordedHotkey().Modifiers;

                if (!DashboardForm.hotkeys.ContainsKey(key))
                {
                    MessageBox.Show("No binding for "+key);
                    return;
                }

                DashboardForm.hotkeys.Remove(key);
                DashboardForm.UnregisterHotKey(DashboardForm.Instance.Handle, DashboardForm.GenerateHotkeyId(key));

                MessageBox.Show("Success!");
                this.Close();
            };
            // 
            // This
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 130);
            this.Controls.Add(this.txtHotkey);
            this.Controls.Add(this.confirmbtn);
            this.Controls.Add(this.deletebtn);
            this.Name = "HotKeyRecorderForm";
            this.Text = "Record Hotkey";
            this.FormClosing += (sender, e) =>
            {
                if (ParentForm != null)
                    ParentForm.Show();
            };
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ControlBox = true;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.ShowInTaskbar = false;
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        TextBox txtHotkey;
        Button confirmbtn;
        Button deletebtn;

    }
}
