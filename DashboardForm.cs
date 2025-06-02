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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MasterMic
{
    public partial class DashboardForm : Form
    {
        public static DashboardForm? Instance;

        // Form Switching System -- DATA //
        private Form activeForm;
        public HomeSubForm homeSubForm;
        public SoundboardSubForm soundboardSubForm;

        public DashboardForm()
        {
            Instance = this;
            InitializeComponent();
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
            if(activeForm != null)
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
    }
}
