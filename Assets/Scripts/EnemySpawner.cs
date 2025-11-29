using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //Variables
    public float fireRate;
    private float time;
    private float cooldown = 2.5f;
    //Objects
    public GameObject shark;
    public Transform enemySpawner1;
    public Transform enemySpawner2;
    public Transform enemySpawner3;
    public Transform enemySpawner4;
    // Update is called once per frame
    void Update()
    {
        //Time
        time += Time.deltaTime;

        fireRate = fireRate - time / 2000000;

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
        //Randomly pick asteroid or fireball to spawn at a random firepoint
        int spawn = Random.Range(1, 4);
        if (spawn == 1)
        {
            Instantiate(shark, enemySpawner1.position, enemySpawner1.rotation);
        }
        else if (spawn == 2)
        {
            Instantiate(shark, enemySpawner2.position, enemySpawner2.rotation);
        }
        else if (spawn == 3)
        {
            Instantiate(shark, enemySpawner3.position, enemySpawner3.rotation);
        }
        else if (spawn == 4)
        {
            Instantiate(shark, enemySpawner4.position, enemySpawner4.rotation);
        }
    }
}