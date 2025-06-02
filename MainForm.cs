using System;
using System.Numerics;
using System.Windows.Forms;
using MicEffectEcho.Effects;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;

namespace MicEffectEcho
{
    public partial class MainForm : Form
    {
        private WaveInEvent waveIn;
        private WaveOutEvent waveOut;
        private BufferedWaveProvider bufferedWaveProvider;
        private EffectsChainSampleProvider effectsChain;
        private VirtualMicSoundboard soundboard;

        bool noEffect = false;
        List<String> requestedEffects = new List<String>();

        public MainForm()
        {
            InitializeComponent();
            LoadDevices();
            RefreshWAVFileList();

            lb_dir.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\MasterMic";
            soundboard = new VirtualMicSoundboard(cmbOutput.SelectedIndex, selfListen.Checked);
        }

        private void LoadDevices()
        {
            cmbInput.Items.Clear();
            for (int i = 0; i < WaveIn.DeviceCount; i++)
            {
                var device = WaveIn.GetCapabilities(i);
                cmbInput.Items.Add(i.ToString() + ": " + device.ProductName);
            }

            cmbOutput.Items.Clear();
            for (int i = 0; i < WaveOut.DeviceCount; i++)
            {
                var device = WaveOut.GetCapabilities(i);
                cmbOutput.Items.Add(i.ToString() + ": " + device.ProductName);
            }

            if (cmbInput.Items.Count > 0) cmbInput.SelectedIndex = 0;
            if (cmbOutput.Items.Count > 0) cmbOutput.SelectedIndex = 0;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (waveIn != null)
            {
                MessageBox.Show("L'audio è già in esecuzione.");
                return;
            }

            int inputIndex = cmbInput.SelectedIndex;
            int outputIndex = cmbOutput.SelectedIndex;

            waveIn = new WaveInEvent
            {
                DeviceNumber = inputIndex,
                WaveFormat = new WaveFormat(44100, 1)
            };

            bufferedWaveProvider = new BufferedWaveProvider(waveIn.WaveFormat)
            {
                DiscardOnBufferOverflow = true
            };

            waveIn.DataAvailable += (s, a) =>
            {
                bufferedWaveProvider.AddSamples(a.Buffer, 0, a.BytesRecorded);
            };

            var sampleProvider = bufferedWaveProvider.ToSampleProvider();

            effectsChain = new EffectsChainSampleProvider(sampleProvider);

            if (!noEffect)
            {
                foreach (String effect in requestedEffects)
                {
                    switch (effect)
                    {
                        case "Reverb":
                            effectsChain.AddEffect(new EchoEffect(44100, 0.3f));
                            break;
                        case "DeepVoice":
                            effectsChain.AddEffect(new DeepVoice());
                            break;
                        default:
                            throw new Exception("Invalid state!");
                    }
                }
            }

            waveOut = new WaveOutEvent { DeviceNumber = outputIndex };
            waveOut.Init(new SampleToWaveProvider(effectsChain));

            waveIn.StartRecording();
            waveOut.Play();

            btnStart.Enabled = false;
            btnStop.Enabled = true;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            waveIn?.StopRecording();
            waveIn?.Dispose();
            waveIn = null;

            waveOut?.Stop();
            waveOut?.Dispose();
            waveOut = null;

            btnStart.Enabled = true;
            btnStop.Enabled = false;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            btnStop_Click(null, null);
        }

        private void cbox_eff_reverb_CheckStateChanged(object sender, EventArgs e)
        {
            if (cbox_eff_reverb.Checked)
            {
                requestedEffects.Add("Reverb");
            }
            else
            {
                requestedEffects.Remove("Reverb");
            }
        }

        private void cbox_eff_childvoice_CheckStateChanged(object sender, EventArgs e)
        {
            if (cbox_eff_deepvoice.Checked)
            {
                requestedEffects.Add("DeepVoice");
            }
            else
            {
                requestedEffects.Remove("DeepVoice");
            }
        }

        private void cmbOutput_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (soundboard != null) soundboard.Stop();

            soundboard = new VirtualMicSoundboard(cmbOutput.SelectedIndex, selfListen.Checked);
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

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckStateChanged(object sender, EventArgs e)
        {
            soundboard.setAutoListen(selfListen.Checked);
        }
    }
}
