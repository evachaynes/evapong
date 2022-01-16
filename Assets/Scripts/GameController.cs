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
    private AudioSource newRoundAudio;

    private void Awake()
    {
        playerInputActions = new InputActions();
        player1Score = 0;
        player2Score = 0;
        player1ScoreUI = GameObject.Find("Player1Score").GetComponent<TextMeshProUGUI>();
        player2ScoreUI = GameObject.Find("Player2Score").GetComponent<TextMeshProUGUI>();
        newRoundAudio = GetComponent<AudioSource>();
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
            newRoundAudio.Play();
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
        if (player1Score == 10)
        {

        }
    }

    public void Player2Point()
    {
        player2Score++;
        player2ScoreUI.text = player2Score.ToString();
        if (player2Score == 10)
        {

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
