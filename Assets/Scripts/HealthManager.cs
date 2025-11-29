using UnityEngine;
using UnityEngine.SceneManagement;
public class HealthManager : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            //If hit by enemy
            Die();
        }
    }

    private void Die()
    {
        //Load death screen
        SceneManager.LoadScene("DeathScreen");
    }
}