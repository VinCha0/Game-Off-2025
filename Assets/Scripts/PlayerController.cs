using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Audio
    public AudioSource source;
    public AudioVolumeDetection detector;

    public float volumeSensitivity = 10;
    public float threshold = 0.1f;
    //Physics
    public Rigidbody2D body;

    private void Update()
    {
        float volume = detector.GetVolumeFromMicrophone() * volumeSensitivity;

        if (volume < threshold)
        {
            volume = 0;
            if(body.gravityScale < 0)
            {
                body.gravityScale = 0.1f;
            }
        }
        else
        {
            body.gravityScale = -0.1f;
        }

        //Ascending Controls
        //body.linearVelocity = new Vector2(body.linearVelocity.x, body.linearVelocity.y * volume * -0.05f);

    }
}
