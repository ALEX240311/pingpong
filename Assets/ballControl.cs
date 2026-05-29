using System;
using UnityEngine;

public class ballControl : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 8f;

    private float maxspeed = 10f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        launchBall();
    }
    
    public void launchBall()
    {
        float x = UnityEngine.Random.Range(-1f, 1f);
        float y = UnityEngine.Random.Range(-1f, 1f);
        Vector2 direction = new Vector2(x, y).normalized;
        rb.linearVelocity = direction * speed;
        //increase speed by 10% every time the ball is launched, up to a maximum speed
        speed = Mathf.Min(speed * 1.1f, maxspeed);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("leftGoals") || collision.CompareTag("rightGoals"))
        {
            ScoreManager scoreManager = FindFirstObjectByType<ScoreManager>();
            if (scoreManager != null)
            {
                scoreManager.ScorePoint(collision.tag);
            }
        }
    }
}
