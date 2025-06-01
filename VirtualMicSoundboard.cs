using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.IO;

public class VirtualMicSoundboard
{
    private WaveOutEvent waveOut;
    private BufferedWaveProvider bufferedWaveProvider;
    private WaveFormat waveFormat = new WaveFormat(48000, 16, 2);
    BufferedWaveProvider defaultBuff;
    private WaveOutEvent defaultWaveOut;

    public VirtualMicSoundboard(int virtualMicDeviceIndex)
    {
        if (virtualMicDeviceIndex != 0)
        {
            defaultBuff = new BufferedWaveProvider(waveFormat)
            {
                DiscardOnBufferOverflow = true
            };

            defaultWaveOut = new WaveOutEvent
            {
                DeviceNumber = 0
            };
            defaultWaveOut.Init(defaultBuff);
            defaultWaveOut.Play();
        }
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
            if (defaultBuff != null)
            {
                defaultBuff.AddSamples(buffer, 0, bytesRead);
            }
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
