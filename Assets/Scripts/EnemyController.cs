using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed;
    public Rigidbody2D body;

    private void Start()
    {
        body.linearVelocity = transform.right * speed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Attack")
        {
            //Destroy self
            Destroy(this);
        }
    }
}
