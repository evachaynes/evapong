using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody2D rb;
    private GameObject gameController;
    public float xForce = -25.0f;
    public float yForce = -20.0f;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void StartGame()
    {
        float yRandForce = Random.Range(-8.0f, 8.0f);
        Vector2 ballForce = new Vector2(xForce, yForce + yRandForce);
        rb.AddForce(ballForce);
    }
}
