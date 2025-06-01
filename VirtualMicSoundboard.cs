using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.IO;

public class VirtualMicSoundboard
{
    private WaveOutEvent waveOut;
    private BufferedWaveProvider bufferedWaveProvider;
    private WaveFormat waveFormat = new WaveFormat(48000, 16, 2);

    public VirtualMicSoundboard(int virtualMicDeviceIndex)
    {
        bufferedWaveProvider = new BufferedWaveProvider(waveFormat)
        {
            DiscardOnBufferOverflow = true
        };

        waveOut = new WaveOutEvent
        {
            DeviceNumber = virtualMicDeviceIndex
        };
        waveOut.Init(bufferedWaveProvider);
        waveOut.Play();
    }

    public void PlaySound(string filePath)
    {
        var reader = new AudioFileReader(filePath);
        var resampler = new MediaFoundationResampler(reader, waveFormat);
        resampler.ResamplerQuality = 60;

        byte[] buffer = new byte[waveFormat.AverageBytesPerSecond / 4];
        int bytesRead;

        while ((bytesRead = resampler.Read(buffer, 0, buffer.Length)) > 0)
        {
            bufferedWaveProvider.AddSamples(buffer, 0, bytesRead);
        }

        resampler.Dispose();
        reader.Dispose();
    }

    public void Stop()
    {
        waveOut.Stop();

        bufferedWaveProvider = new BufferedWaveProvider(waveFormat)
        {
            DiscardOnBufferOverflow = true
        };

        waveOut.Init(bufferedWaveProvider);
        waveOut.Play();
    }

    public static Dictionary<int, string> ListOutputDevices()
    {
        var devices = new Dictionary<int, string>();
        for (int i = 0; i < WaveOut.DeviceCount; i++)
        {
            var caps = WaveOut.GetCapabilities(i);
            devices[i] = caps.ProductName;
        }
        return devices;
    }
}
