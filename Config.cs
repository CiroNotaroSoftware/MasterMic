using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterMic
{
    internal class Config
    {
        public static string SOUNDBOARD_PATH = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "MasterMic");
        public static string KEYBOUNDS_PATH = Path.Combine(SOUNDBOARD_PATH, "hotkeys.json");

        public static string PRODUCT_NAME = "Master Mic";
        public static string PRODUCT_VERSION = "0.7";
        public static string PRODUCT_DEVELOPER = "Notaro Ciro";
        public static string PRODUCT_GITHUB = "https://github.com/CiroNotaroSoftware/MasterMic";
    }
}
