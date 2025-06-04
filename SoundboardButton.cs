using MasterMic.Utils;
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
    public partial class SoundboardButton : UserControl
    {
        private bool isPlaying = false;
        public string filepath;

        public SoundboardButton()
        {
            Init();
        }

        public SoundboardButton(string filepath)
        {
            this.filepath = filepath;
            Init();
        }

        private void Init()
        {
            if (SoundBoardImages.playImg == null)
            {
                SoundBoardImages.playImg = Image.FromFile("Res/play-button.png");
                SoundBoardImages.playImg = SoundBoardImages.ResizeImage(SoundBoardImages.playImg, 29, 29);
            }

            if (SoundBoardImages.stopImg == null)
            {
                SoundBoardImages.stopImg = Image.FromFile("Res/stop-button.png");
                SoundBoardImages.stopImg = SoundBoardImages.ResizeImage(SoundBoardImages.stopImg, 29, 29);
            }

            InitializeComponent();

            label1.Text = filepath;

            button1.Image = SoundBoardImages.playImg;
            button1.Click += (s, e) =>
            {

                SoundboardSubForm.Instance.soundBoardListStop();

                if (!isPlaying)
                {
                    SoundboardSubForm.Instance.soundboard.PlaySoundFromButton(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\MasterMic", filepath), this);
                }
            };

            button1.MouseHover += PictureBox1_MouseHover;
            button1.MouseLeave += PictureBox1_MouseLeave;
        }

        private void PictureBox1_MouseLeave(object? sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }

        private void PictureBox1_MouseHover(object? sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
        }

        public string CardTitle
        {
            get => ((Label)this.label1).Text;
            set => ((Label)this.label1).Text = value;
        }

        public bool IsPlaying
        {
            get => isPlaying;
            set
            {
                isPlaying = value;
                button1.Image = value ? SoundBoardImages.stopImg : SoundBoardImages.playImg;
            }
        }

        public string Text
        {
            get => label1.Text;
            set
            {
                label1.Text = value;
            }
        }

        public Button PlayButton
        {
            get => button1;
        }

        public void setBorderColorForFixingFocusQuad(Color color)
        {
            button1.FlatAppearance.BorderColor = color;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DashboardForm.Instance.Hide();

            new HotKeyRecorder(label1.Text, DashboardForm.Instance).Show();
        }
    }
}
