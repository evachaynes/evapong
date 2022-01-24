using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBall : MonoBehaviour
{
    private Rigidbody2D rb;
    public float xForce = -50.0f;
    public float yForce = -45.0f;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        float yRandForce = Random.Range(-9.0f, 9.0f);
        Vector2 ballForce = new Vector2(xForce, yForce + yRandForce);
        rb.AddForce(ballForce);
    }
}
