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
    public partial class HomeSubForm : Form
    {
        public WaveInEvent waveIn;
        public WaveOutEvent waveOut;
        public BufferedWaveProvider bufferedWaveProvider;
        public EffectsChainSampleProvider effectsChain;

        public bool noEffect = false;
        public List<String> requestedEffects = new List<String>();

        public HomeSubForm()
        {
            InitializeComponent();
            LoadDevicesList();
        }

        private void LoadDevicesList()
        {
            comboBoxInputDevice.Items.Clear();
            for (int i = 0; i < WaveIn.DeviceCount; i++)
            {
                var device = WaveIn.GetCapabilities(i);
                comboBoxInputDevice.Items.Add(i.ToString() + ": " + device.ProductName);
            }

            comboBoxOutputDevice.Items.Clear();
            for (int i = 0; i < WaveOut.DeviceCount; i++)
            {
                var device = WaveOut.GetCapabilities(i);
                comboBoxOutputDevice.Items.Add(i.ToString() + ": " + device.ProductName);
            }

            if (comboBoxInputDevice.Items.Count > 0) comboBoxInputDevice.SelectedIndex = 0;
            if (comboBoxOutputDevice.Items.Count > 0) comboBoxOutputDevice.SelectedIndex = 0;
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            if (waveIn != null)
            {
                MessageBox.Show("L'audio è già in esecuzione.");
                return;
            }

            int inputIndex = comboBoxInputDevice.SelectedIndex;
            int outputIndex = comboBoxOutputDevice.SelectedIndex;

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

            buttonPlay.Enabled = false;
            buttonStop.Enabled = true;
        }
        private void buttonStop_Click(object sender, EventArgs e)
        {
            waveIn?.StopRecording();
            waveIn?.Dispose();
            waveIn = null;

            waveOut?.Stop();
            waveOut?.Dispose();
            waveOut = null;

            buttonPlay.Enabled = true;
            buttonStop.Enabled = false;
        }

        private void checkBoxReverb_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBoxReverb.Checked)
            {
                requestedEffects.Add("Reverb");
            }
            else
            {
                requestedEffects.Remove("Reverb");
            }
        }

        private void checkBoxBassVoice_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBoxBassVoice.Checked)
            {
                requestedEffects.Add("DeepVoice");
            }
            else
            {
                requestedEffects.Remove("DeepVoice");
            }
        }

        private void HomeSubForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            buttonStop_Click(null, null);
        }

        public ComboBox getOutputDeviceCombobox() { return comboBoxOutputDevice; }

        private void comboBoxOutputDevice_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(DashboardForm.Instance.soundboardSubForm != null)
                DashboardForm.Instance.soundboardSubForm.soundboard = new VirtualMicSoundboard(comboBoxOutputDevice.SelectedIndex, DashboardForm.Instance.soundboardSubForm.getAutoListen());
        }
    }
}
