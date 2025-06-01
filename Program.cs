
using System;
using System.Windows.Forms;

namespace MicEffectEcho
{
    static class Program
    {

        [STAThread]
        static void Main()
        {
            if(!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)+ "\\MasterMic"))
            {
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\MasterMic");
            }

            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }
    }
}
