using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI leftScoreText;
    public TextMeshProUGUI rightScoreText;

    private int leftScore = 0;
    private int rightScore = 0;


    public GameObject ball;

    private Vector2 ballStartPos;

    void Start()
    {

        if (ball != null)
        {
            ballStartPos = ball.transform.position;

        }
    }

    public void ScorePoint(string goalTag)
    {
        if (goalTag == "leftGoals")
        {
            rightScore++;
            rightScoreText.text = rightScore.ToString();
        }
        else if (goalTag == "rightGoals")
        {
            
            leftScore++;
            leftScoreText.text = leftScore.ToString();
        }
        ResetBall();    
    }

    private void ResetBall()
    {
        if (ball == null) return;

        ball.transform.position = ballStartPos;

        Rigidbody2D rb = ball.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero;
        }

        ballControl ballScript = ball.GetComponent<ballControl>();
        if (ballScript != null)
        {
            ballScript.CancelInvoke("launchBall");
            ballScript.Invoke("launchBall", 1f);
        }
    }
}
