using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private InputActions playerInputActions;
    private InputAction inputAction;
    private float moveDirection;
    private Vector3 moveVector;
    [SerializeField] public int player;
    [SerializeField] public float moveSpeed = 5.0f;

    private void Awake()
    {
        playerInputActions = new InputActions();
        if (player == 1)
        {
            inputAction = playerInputActions.Paddle1.Move;
        }
        if (player == 2)
        {
            inputAction = playerInputActions.Paddle2.Move;
        }
    }

    void LateUpdate()
    {

        moveDirection = inputAction.ReadValue<float>();
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
        if (player == 1)
        {
            playerInputActions.Paddle1.Enable();
        }
        if (player == 2)
        {
            playerInputActions.Paddle2.Enable();
        }
    }

    private void OnDisable()
    {
        if(player == 1)
        {
            playerInputActions.Paddle1.Disable();
        }
        if (player == 2)
        {
            playerInputActions.Paddle2.Disable();
        }
    }
}
