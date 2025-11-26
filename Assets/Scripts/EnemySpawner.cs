using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //Variables
    public float fireRate = 4;
    private float time;
    private float cooldown = 2.5f;
    //Objects
    public GameObject shark;
    // Update is called once per frame
    void Update()
    {
        //Time
        time += Time.deltaTime;

        fireRate = fireRate - time / 20000000;

        if (fireRate <= 0.35f)
        {
            fireRate = 0.35f;
        }
        //Firing
        if (cooldown == 0)
        {
            Fire();
            cooldown = fireRate;
        }

        if (cooldown != 0)
        {
            cooldown -= Time.deltaTime;
        }

        if (cooldown < 0)
        {
            cooldown = 0;
        }
    }
    void Fire()
    {
        Instantiate(shark);
    }
}
