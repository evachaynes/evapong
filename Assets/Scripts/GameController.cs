using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private InputActions playerInputActions;
    private bool gameStart = false;

    private void Awake()
    {
        playerInputActions = new InputActions();
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

    private void OnEnable()
    {
        playerInputActions.Game.Enable();
    }

    private void OnDisable()
    {
        playerInputActions.Game.Disable();
    }
}
