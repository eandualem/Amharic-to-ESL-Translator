using UnityEngine;
using System;
using System.IO;

public class AudioRecorder : MonoBehaviour
{
    private bool micConnected = false;
    private int minFreq;
    private int maxFreq;

    AudioSource audioSource;

    void Start()
    {
        if (Microphone.devices.Length <= 0)
        {
            Debug.LogWarning("Microphone not connected!");
        }
        else
        {
            micConnected = true;
            Microphone.GetDeviceCaps(null, out minFreq, out maxFreq);

            if (minFreq == 0 && maxFreq == 0)
            {
                maxFreq = 44100;
            }
        }
    }

    public bool Record(AudioSource audioSource)
    {

        this.audioSource = audioSource;
        if (micConnected)
        {
            if (!Microphone.IsRecording(Microphone.devices[0]))
            {
                // Record for 20 seconds and continue recording if lengthSec is reached, and wrap around
                audioSource.clip = Microphone.Start(Microphone.devices[0], false, 20, maxFreq);
                return true;
            }
            else 
            {
                Debug.Log("Already Recording!");
                return false;
            }
        }
        else // No microphone  
        {
            Debug.Log( "Microphone not connected!");
            return false;
        }
 
    }

    public byte[] StopRecording()
    {
        if (micConnected)
        {
            if (Microphone.IsRecording(Microphone.devices[0]))
            {
                Microphone.End(null);
                //audioSource.Play();
                return ConvertAudio(audioSource.clip);
            }
        }
        return null;
    }

    byte[] ConvertAudio(AudioClip clip)
    {
        var samples = new float[clip.samples];

        clip.GetData(samples, 0);

        Int16[] intData = new Int16[samples.Length];
        Byte[] bytesData = new Byte[samples.Length * 2];

        int rescaleFactor = 32767; //to convert float to Int16

        for (int i = 0; i < samples.Length; i++)
        {
            intData[i] = (short)(samples[i] * rescaleFactor);
            Byte[] byteArr = new Byte[2];
            byteArr = BitConverter.GetBytes(intData[i]);
            byteArr.CopyTo(bytesData, i * 2);
        }
        Debug.Log(bytesData);
        return AddHeader(bytesData, clip);
    }

    static byte[] AddHeader(byte[] bytesData, AudioClip clip)
    {
        UInt16 one        = 1;
        UInt16 two        = 2;
        UInt16 bps        = 16;
        var hz            = clip.frequency;
        var channels      = clip.channels;
        var samples       = clip.samples;
        UInt16 blockAlign = (ushort)(channels * 2);
        byte[] new_data;

        using (MemoryStream ms = new MemoryStream())
        {
            ms.Write(System.Text.Encoding.UTF8.GetBytes("RIFF"), 0, 4);
            ms.Write(BitConverter.GetBytes(3840036), 0, 4);
            ms.Write(System.Text.Encoding.UTF8.GetBytes("WAVE"), 0, 4);
            ms.Write(System.Text.Encoding.UTF8.GetBytes("fmt "), 0, 4);
            ms.Write(BitConverter.GetBytes(16), 0, 4);
            ms.Write(BitConverter.GetBytes(one), 0, 2);
            ms.Write(BitConverter.GetBytes(channels), 0, 2);
            ms.Write(BitConverter.GetBytes(hz), 0, 4);
            ms.Write(BitConverter.GetBytes(hz * channels * 2), 0, 4);
            ms.Write(BitConverter.GetBytes(blockAlign), 0, 2);
            ms.Write(BitConverter.GetBytes(bps), 0, 2);
            ms.Write(System.Text.Encoding.UTF8.GetBytes("data"), 0, 4);
            ms.Write(BitConverter.GetBytes(samples * channels * 2), 0, 4);
            ms.Write(bytesData, 0, bytesData.Length);
            new_data = ms.ToArray();
        }

        return new_data;
    }
}
