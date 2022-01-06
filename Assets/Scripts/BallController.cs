using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody2D rb;
    private GameObject gameController;
    public float force = -15.0f;

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
        Vector2 ballForce = new Vector2(force, 0);
        rb.AddForce(ballForce);
    }
}
