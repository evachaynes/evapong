using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private InputActions playerInputActions;
    private float moveDirection;
    private Vector3 moveVector;

    [SerializeField] public float moveSpeed = 5.0f;

    private void Awake()
    {
        playerInputActions = new InputActions();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    void FixedUpdate()
    {
        moveDirection = playerInputActions.Paddle.Move.ReadValue<float>();
        if (moveDirection != 0)
        {
            Debug.Log(moveDirection);
        }
        moveVector = new Vector3(0, moveDirection * moveSpeed, 0);
        transform.position += moveVector * Time.deltaTime;

        if (transform.position.y > 4.0f)
        {
            transform.position = new Vector3(transform.position.x, 4.0f, transform.position.z);
        }
        if (transform.position.y < -4.0f)
        {
            transform.position = new Vector3(transform.position.x, -4.0f, transform.position.z);
        }
    }

    private void OnEnable()
    {
        playerInputActions.Paddle.Enable();
    }

    private void OnDisable()
    {
        playerInputActions.Paddle.Disable();
    }
}
