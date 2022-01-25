using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float xForce = 50.0f;
    public float yForce = -45.0f;
    public float ballDirection = 1;
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
        float yRandForce = Random.Range(-6.0f, 9.0f);
        Vector2 ballForce = new Vector2(xForce * ballDirection, yForce + yRandForce);
        rb.AddForce(ballForce);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name == "LeftWall")
        {
            wallHitAudio.Play();
            transform.parent.GetComponent<GameController>().Player2Point();
            transform.parent.GetComponent<GameController>().ResetGame();
            ResetBall();
        }
        if (col.name == "RightWall")
        {
            wallHitAudio.Play();
            transform.parent.GetComponent<GameController>().Player1Point();
            transform.parent.GetComponent<GameController>().ResetGame();
            ResetBall();
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
