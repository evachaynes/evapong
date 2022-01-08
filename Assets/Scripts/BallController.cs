using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody2D rb;
    private GameObject gameController;
    public float xForce = -45.0f;
    public float yForce = -40.0f;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        Collider2D player1Wall = GameObject.Find("LeftWall").GetComponent<Collider2D>();
        Collider2D player2Wall = GameObject.Find("RightWall").GetComponent<Collider2D>();
    }

    void StartGame()
    {
        float yRandForce = Random.Range(-8.0f, 8.0f);
        Vector2 ballForce = new Vector2(xForce, yForce + yRandForce);
        rb.AddForce(ballForce);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name == "LeftWall")
        {
            transform.parent.GetComponent<GameController>().Player2Point();
        }
        if (col.name == "RightWall")
        {
            transform.parent.GetComponent<GameController>().Player1Point();
        }
        ResetBall();
        transform.parent.GetComponent<GameController>().ResetGame();
    }

    void ResetBall()
    {
        rb.velocity = new Vector2(0, 0);
        transform.position = new Vector3(0, 4, 0);
    }
}
