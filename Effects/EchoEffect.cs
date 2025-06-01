using MicEffectEcho.Effects;

public class EchoEffect : IAudioEffect
{
    private float[] delayBuffer;
    private int delaySamples;
    private int writeIndex;
    private float feedback;
    private float wetLevel;
    private float dryLevel;

    public EchoEffect(int sampleRate, float delaySeconds = 0.5f, float feedback = 0.5f, float wetLevel = 0.5f, float dryLevel = 1.0f)
    {
        delaySamples = (int)(sampleRate * delaySeconds);
        delayBuffer = new float[delaySamples];
        writeIndex = 0;

        this.feedback = feedback;
        this.wetLevel = wetLevel;
        this.dryLevel = dryLevel;
    }

    public void Process(float[] buffer, int offset, int count)
    {
        for (int n = 0; n < count; n++)
        {
            float inputSample = buffer[offset + n];
            float delayedSample = delayBuffer[writeIndex];

            float output = inputSample * dryLevel + delayedSample * wetLevel;
            delayBuffer[writeIndex] = inputSample + delayedSample * feedback;

            buffer[offset + n] = output;

            writeIndex = (writeIndex + 1) % delaySamples;
        }
    }
}
