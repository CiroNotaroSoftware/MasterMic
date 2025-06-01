using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicEffectEcho.Effects
{
    public interface IAudioEffect
    {
        /// <summary>
        /// Process a block of audio samples (float PCM).
        /// </summary>
        /// <param name="buffer">Samples</param>
        /// <param name="offset">Offset</param>
        /// <param name="count">Samples count</param>
        void Process(float[] buffer, int offset, int count);
    }
}
