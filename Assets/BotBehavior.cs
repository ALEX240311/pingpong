using UnityEngine;

public class BotBehavior : MonoBehaviour
{
    public float speed = 4.5f;       
    private Transform ball;         
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        
        GameObject ballGo = GameObject.Find("ball");
        if (ballGo != null)
        {
            ball = ballGo.transform;
        }
    }

    void FixedUpdate()
    {
        if (ball == null) return;


        if (ball.position.y > transform.position.y + 0.2f)
        {
            rb.linearVelocity = new Vector2(0, speed);
        }
   
        else if (ball.position.y < transform.position.y - 0.2f)
        {
            rb.linearVelocity = new Vector2(0, -speed);
        }
       
        else
        {
            rb.linearVelocity = Vector2.zero;
        }
    }
}
