using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    private InputActions playerInputActions;
    private bool gameStart = false;
    public int player1Score;
    public int player2Score;
    public TextMeshProUGUI player1ScoreUI;
    public TextMeshProUGUI player2ScoreUI;
    public TextMeshProUGUI startMessageUI;
    public TextMeshProUGUI winMessageUI;
    private AudioSource newRoundAudio;

    private void Awake()
    {
        playerInputActions = new InputActions();
        player1Score = 0;
        player2Score = 0;
        player1ScoreUI = GameObject.Find("Player1Score").GetComponent<TextMeshProUGUI>();
        player2ScoreUI = GameObject.Find("Player2Score").GetComponent<TextMeshProUGUI>();
        winMessageUI = GameObject.Find("WinMessage").GetComponent<TextMeshProUGUI>();
        newRoundAudio = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // start game, reset scores, play start sound
        if (playerInputActions.Game.Start.ReadValue<float>() != 0 && !gameStart)
        {
            if (player1Score == 10 | player2Score == 10)
            {
                player1ScoreUI.text = "0";
                player1Score = 0;
                player2ScoreUI.text = "0";
                player2Score = 0;
                winMessageUI.text = "";
            }
            newRoundAudio.Play();
            BroadcastMessage("StartGame");
            gameStart = true;
        }
    }

    // from BallController to unlock space bar
    public void ResetGame()
    {
        gameStart = false;
    }

    // increment player 1 score
    public void Player1Point()
    {
        player1Score++;
        player1ScoreUI.text = player1Score.ToString();
        // show win screen when player reaches 10
        if (player1Score == 10)
        {
            winMessageUI.text = "Player 1 Wins!";
            gameStart = false;
        }
    }

    // increment player 2 score
    public void Player2Point()
    {
        player2Score++;
        player2ScoreUI.text = player2Score.ToString();
        // show win screen when player reaches 10
        if (player2Score == 10)
        {
            winMessageUI.text = "Player 2 Wins!";
            gameStart = false;
        }
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
