using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float xForce = -45.0f;
    public float yForce = -40.0f;
    private AudioSource[] sfxComponents;
    private AudioSource paddleHitAudio;
    private AudioSource wallHitAudio;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sfxComponents = GetComponents<AudioSource>();
        paddleHitAudio = sfxComponents[0];
        wallHitAudio = sfxComponents[1];
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
            wallHitAudio.Play();
            transform.parent.GetComponent<GameController>().Player2Point();
            ResetBall();
            transform.parent.GetComponent<GameController>().ResetGame();
        }
        if (col.name == "RightWall")
        {
            wallHitAudio.Play();
            transform.parent.GetComponent<GameController>().Player1Point();
            ResetBall();
            transform.parent.GetComponent<GameController>().ResetGame();
        }
        if (col.name == "PlayerPaddle1" | col.name == "PlayerPaddle2")
        {
            paddleHitAudio.Play();
        }
    }

    void ResetBall()
    {
        rb.velocity = new Vector2(0, 0);
        transform.position = new Vector3(0, 4, 0);
    }
}
