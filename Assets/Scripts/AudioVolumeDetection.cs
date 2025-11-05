using UnityEngine;

public class AudioVolumeDetection : MonoBehaviour
{
    public int sampleWindow = 64;

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