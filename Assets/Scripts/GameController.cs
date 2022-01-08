using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.UI;

public class GameController : MonoBehaviour
{
    private InputActions playerInputActions;
    private bool gameStart = false;
    public int player1Score;
    public int player2Score;
    public TextMeshProUGUI player1ScoreUI;
    public TextMeshProUGUI player2ScoreUI;
    public TextMeshProUGUI startMessageUI;

    private void Awake()
    {
        playerInputActions = new InputActions();
        player1Score = 0;
        player2Score = 0;
        player1ScoreUI = GameObject.Find("Player1Score").GetComponent<TextMeshProUGUI>();
        player2ScoreUI = GameObject.Find("Player2Score").GetComponent<TextMeshProUGUI>();
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
        player1ScoreUI.text = player1Score.ToString();
    }

    public void Player2Point()
    {
        player2Score++;
        player2ScoreUI.text = player2Score.ToString();
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
