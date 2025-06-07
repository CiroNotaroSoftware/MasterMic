using MasterMic;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System;
using System.Windows.Forms;

namespace MicEffectEcho
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            if (!Directory.Exists(Config.SOUNDBOARD_PATH))
            {
                Directory.CreateDirectory(Config.SOUNDBOARD_PATH);
            }

            ApplicationConfiguration.Initialize();
            Application.Run(new DashboardForm());
        }
    }
}
