using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float force = -10.0f;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Vector2 ballForce = new Vector2(force, 0);
        rb.AddForce(ballForce);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
