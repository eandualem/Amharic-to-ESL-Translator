using UnityEngine;
using System;
using System.IO;

public class AudioRecorder : MonoBehaviour
{
    private bool micConnected = false;
    private int minFreq;
    private int maxFreq;
    const int HEADER_SIZE = 44;

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
               audioSource.clip = Microphone.Start(Microphone.devices[0], true, 20, maxFreq);
                return true;
            }
            else //Recording is in progress  
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
        return bytesData;
    }
}
