using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicEffectEcho.Effects
{
    public class NoEffect : IAudioEffect
    {

        public NoEffect()
        {
            
        }

        public void Process(float[] buffer, int offset, int count)
        {
            
        }
    }
}
