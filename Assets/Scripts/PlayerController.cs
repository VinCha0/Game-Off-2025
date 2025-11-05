using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public AudioSource source;
    public AudioVolumeDetection detector;

    public float volumeSensitivity = 100;
    public float threshold = 0.1f;
    private void Update()
    {
        //transform.Translate(Vector2.down * 1.5f * Time.deltaTime);

        float volume = detector.GetVolumeFromAudioClip(source.timeSamples, source.clip) * volumeSensitivity;

        if (volume < threshold)
        {
            volume = 0;
        }
    }
}
