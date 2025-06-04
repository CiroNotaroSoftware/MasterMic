using MasterMic;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.IO;

public class VirtualMicSoundboard : IDisposable
{
    private WaveOutEvent mainOutput;
    private WaveOutEvent defaultOutput;
    private AudioFileReader mainReader;
    private AudioFileReader defaultReader;
    private bool autoListen;

    private int mainDeviceIndex;

    public VirtualMicSoundboard(int mainDeviceIndex, bool autoListen)
    {
        this.mainDeviceIndex = mainDeviceIndex;
        this.autoListen = autoListen;
    }

    public void PlaySound(string filePath)
    {
        DisposeOutputsAndReaders();

        mainOutput = new WaveOutEvent { DeviceNumber = mainDeviceIndex };
        mainOutput.PlaybackStopped += OnPlaybackStopped;
        if (mainDeviceIndex != 0 && autoListen)
        {
            defaultOutput = new WaveOutEvent { DeviceNumber = 0 };
            defaultOutput.PlaybackStopped += OnPlaybackStopped;
        }
        mainReader = new AudioFileReader(filePath);
        defaultReader = new AudioFileReader(filePath);

        mainOutput.Init(mainReader);
        
        if (mainDeviceIndex != 0 && autoListen)
            defaultOutput.Init(defaultReader);

        mainOutput.Play();

        if (mainDeviceIndex != 0 && autoListen)
            defaultOutput.Play();
    }

    public void PlaySoundFromButton(string filePath, SoundboardButton btn)
    {
        // TODO: Wait for resources cleanup
        DisposeOutputsAndReaders();

        mainOutput = new WaveOutEvent { DeviceNumber = mainDeviceIndex };
        mainOutput.PlaybackStopped += (sender, e) =>
        {
            btn.IsPlaying = false;
            DisposeOutputsAndReaders();
        };

        if (mainDeviceIndex != 0 && autoListen)
        {
            defaultOutput = new WaveOutEvent { DeviceNumber = 0 };
            defaultOutput.PlaybackStopped += (sender, e) =>
            {
                btn.IsPlaying = false;
                DisposeOutputsAndReaders();
            };
        }
        mainReader = new AudioFileReader(filePath);
        defaultReader = new AudioFileReader(filePath);

        mainOutput.Init(mainReader);

        if (mainDeviceIndex != 0 && autoListen)
            defaultOutput.Init(defaultReader);

        btn.IsPlaying = true;
        mainOutput.Play();

        if (mainDeviceIndex != 0 && autoListen)
            defaultOutput.Play();
    }

    private void DisposeOutputsAndReaders()
    {
        mainOutput?.Stop();
        defaultOutput?.Stop();

        mainReader?.Dispose();
        defaultReader?.Dispose();
        mainReader = null;
        defaultReader = null;

        mainOutput?.Dispose();
        defaultOutput?.Dispose();
        mainOutput = null;
        defaultOutput = null;
    }

    void OnPlaybackStopped(object sender, StoppedEventArgs e)
    {
        DisposeOutputsAndReaders();
    }

    public void Stop()
    {
        mainOutput?.Stop();
        defaultOutput?.Stop();
    }

    public void Dispose()
    {
        DisposeOutputsAndReaders();
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

    public void setAutoListen(bool autoListen)
    {
        this.autoListen = autoListen;
    }
}
