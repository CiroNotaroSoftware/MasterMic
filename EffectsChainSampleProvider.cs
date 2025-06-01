using MicEffectEcho.Effects;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicEffectEcho
{
    public class EffectsChainSampleProvider : ISampleProvider
    {
        private readonly ISampleProvider source;
        private readonly List<IAudioEffect> effects = new List<IAudioEffect>();

        public EffectsChainSampleProvider(ISampleProvider source)
        {
            this.source = source;
            WaveFormat = source.WaveFormat;
        }

        public WaveFormat WaveFormat { get; }

        public void AddEffect(IAudioEffect effect)
        {
            effects.Add(effect);
        }

        public void RemoveEffect(IAudioEffect effect)
        {
            effects.Remove(effect);
        }

        public int Read(float[] buffer, int offset, int count)
        {
            int samplesRead = source.Read(buffer, offset, count);

            foreach (var effect in effects)
            {
                effect.Process(buffer, offset, samplesRead);
            }

            return samplesRead;
        }
    }
}
