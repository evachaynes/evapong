using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    private InputActions playerInputActions;
    private bool gameStart = false;
    private bool gamePaused = false;
    public int player1Score;
    public int player2Score;
    public TextMeshProUGUI player1ScoreUI;
    public TextMeshProUGUI player2ScoreUI;
    public TextMeshProUGUI startMessageUI;
    private GameObject winMenuUI;
    public TextMeshProUGUI winMessageUI;
    private GameObject pauseMenuUI;
    private AudioSource newRoundAudio;
    private BallController ballController;

    private void Awake()
    {
        playerInputActions = new InputActions();
        player1Score = 0;
        player2Score = 0;
        player1ScoreUI = GameObject.Find("Player1Score").GetComponent<TextMeshProUGUI>();
        player2ScoreUI = GameObject.Find("Player2Score").GetComponent<TextMeshProUGUI>();
        winMessageUI = GameObject.Find("WinMessage").GetComponent<TextMeshProUGUI>();
        winMenuUI = GameObject.Find("WinMenu");
        pauseMenuUI = GameObject.Find("PauseMenu");
        newRoundAudio = GetComponent<AudioSource>();
        ballController = GameObject.Find("Ball").GetComponent<BallController>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // start ball movement and play start sound
        if (playerInputActions.Game.Start.ReadValue<float>() != 0 && !gameStart)
        {
            newRoundAudio.Play();
            BroadcastMessage("StartGame");
            gameStart = true;
        }

        // show/hide menu
        if (playerInputActions.Game.Menu.WasPressedThisFrame() == true && !gamePaused)
        {
            pauseMenuUI.transform.localScale = new Vector3(1,1,1);
            Time.timeScale = 0;
            playerInputActions.Game.Start.Disable();
            gamePaused = true;
            Debug.Log("Game Paused");
        }
        else if (playerInputActions.Game.Menu.WasPressedThisFrame() == true && gamePaused)
        {
            pauseMenuUI.transform.localScale = new Vector3(0,0,0);
            Time.timeScale = 1;
            playerInputActions.Game.Start.Enable();
            gamePaused = false;
            Debug.Log("Game Unpaused");
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
        ballController.ballDirection = -1;
        player1Score++;
        player1ScoreUI.text = player1Score.ToString();
        // show win screen when player reaches 10
        if (player1Score >= 10)
        {
            Time.timeScale = 0;
            playerInputActions.Game.Start.Disable();
            winMessageUI.text = "Player 1 Wins!";
            winMenuUI.transform.localScale = new Vector3(1, 1, 1);
            gameStart = false;
        }
    }

    // increment player 2 score
    public void Player2Point()
    {
        ballController.ballDirection = 1;
        player2Score++;
        player2ScoreUI.text = player2Score.ToString();
        // show win screen when player reaches 10
        if (player2Score >= 10)
        {
            Time.timeScale = 0;
            playerInputActions.Game.Start.Disable();
            winMessageUI.text = "Player 2 Wins!";
            winMenuUI.transform.localScale = new Vector3(1, 1, 1);
            gameStart = false;
        }
    }

    // reset game after a player wins
    public void NewGame()
    {
        winMenuUI.transform.localScale = new Vector3(0, 0, 0);
        player1ScoreUI.text = "0";
        player1Score = 0;
        player2ScoreUI.text = "0";
        player2Score = 0;
        winMessageUI.text = "";
        Time.timeScale = 1;
        playerInputActions.Game.Start.Enable();
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
