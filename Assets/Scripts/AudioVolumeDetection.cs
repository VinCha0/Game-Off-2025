using UnityEngine;

public class AudioVolumeDetection : MonoBehaviour
{
    public int sampleWindow = 64;
    private AudioClip microphoneClip;

    private void Start()
    {
        MicrophoneToAudioClip();
    }
    public void MicrophoneToAudioClip()
    {
        string microphoneName = Microphone.devices[0];
        microphoneClip = Microphone.Start(microphoneName,true,20,AudioSettings.outputSampleRate); //Number 20 is length of clip - may need to be increased later on
    }

    public float GetVolumeFromMicrophone()
    {
        return GetVolumeFromAudioClip(Microphone.GetPosition(Microphone.devices[0]), microphoneClip);
    }

    public float GetVolumeFromAudioClip(int clipPosition,AudioClip clip)
    {
        int startPosition = clipPosition - sampleWindow;

        if(startPosition < 0 )
        {
            return 0;
        }

        float[] waveData = new float[sampleWindow];
        clip.GetData(waveData, startPosition);

        //Compute Volume
        float totalVolume = 0;

        for (int i = 0; i < sampleWindow; i++)
        {
            totalVolume += Mathf.Abs(waveData[i]);
        }

        return totalVolume / sampleWindow;
    }
}