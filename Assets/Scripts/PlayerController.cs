using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Audio
    public AudioSource source;
    public AudioVolumeDetection detector;

    public float volumeSensitivity;
    public float threshold = 0.1f;
    //Gameplay
    public Rigidbody2D body;
    public GameObject AttackObject;

    private void Start()
    {
        volumeSensitivity = 18;
    }
    private void FixedUpdate()
    {
        float volume = detector.GetVolumeFromMicrophone() * volumeSensitivity;

        if (volume < threshold)
        {
            volume = 0;
            if(body.gravityScale < 0)
            {
                //Ascend
                body.gravityScale = 0.1f;

                AttackObject.SetActive(false);
            }
        }
        else
        {
            //Descend
            body.gravityScale = -0.1f;
            AttackObject.SetActive(true);
        }
    }
}