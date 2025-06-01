using System;

namespace MicEffectEcho.Effects
{
    public class DeepVoice : IAudioEffect
    {
        private readonly float pitchFactor;

        public DeepVoice(float pitchFactor = 1.5f)
        {
            this.pitchFactor = pitchFactor;
        }

        public void Process(float[] buffer, int offset, int count)
        {
            float[] temp = new float[count];

            for (int i = 0; i < count; i++)
            {
                float sourceIndex = i / pitchFactor;

                int indexFloor = (int)Math.Floor(sourceIndex);
                int indexCeil = indexFloor + 1;

                float sample = 0;

                if (indexFloor >= 0 && indexCeil < count)
                {
                    float frac = sourceIndex - indexFloor;
                    float sample1 = buffer[offset + indexFloor];
                    float sample2 = buffer[offset + indexCeil];
                    sample = sample1 + frac * (sample2 - sample1);
                }
                else if (indexFloor >= 0 && indexFloor < count)
                {
                    sample = buffer[offset + indexFloor];
                }

                temp[i] = sample;
            }

            for (int i = 0; i < count; i++)
            {
                buffer[offset + i] = temp[i];
            }
        }
    }
}
