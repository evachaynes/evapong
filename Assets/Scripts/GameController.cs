using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private InputActions playerInputActions;
    private bool gameStart = false;
    public int player1Score;
    public int player2Score;

    private void Awake()
    {
        playerInputActions = new InputActions();
        player1Score = 0;
        player2Score = 0;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (playerInputActions.Game.Start.ReadValue<float>() != 0 && !gameStart)
        {
            BroadcastMessage("StartGame");
            gameStart = true;
        }
    }

    public void ResetGame()
    {
        gameStart = false;
        Debug.Log("Player1: " + player1Score + " Player2: " + player2Score);
    }

    public void Player1Point()
    {
        player1Score++;
    }

    public void Player2Point()
    {
        player2Score++;
    }

    private void OnEnable()
    {
        playerInputActions.Game.Enable();
    }

    private void OnDisable()
    {
        playerInputActions.Game.Disable();
    }
}
