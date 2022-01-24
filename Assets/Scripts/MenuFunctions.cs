using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuFunctions : MonoBehaviour
{
    public void loadNextScene(string sceneName)
    {
        if (sceneName == "EvaPongTitle")
        {
            Time.timeScale = 1;
        }
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ToggleCredits()
    {
        TextMeshProUGUI creditsTextUI;
        creditsTextUI = GameObject.Find("Credits").GetComponent<TextMeshProUGUI>();
        if (creditsTextUI.enabled == false)
        {
            creditsTextUI.enabled = true;
        }
        else
        {
            creditsTextUI.enabled = false;
        }
    
    }

    public void ToggleHelp()
    {
        TextMeshProUGUI helpTextUI;
        helpTextUI = GameObject.Find("HelpText").GetComponent<TextMeshProUGUI>();
        if (helpTextUI.enabled == false)
        {
            helpTextUI.enabled = true;
        }
        else
        {
            helpTextUI.enabled = false;
        }

    }
}
