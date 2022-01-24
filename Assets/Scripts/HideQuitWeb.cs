using UnityEngine;
using TMPro;

public class HideQuitWeb : MonoBehaviour
{
    GameObject textquitButton;

    void Start()
    {
        textquitButton = GameObject.Find("QuitGameBtn");
        if (Application.platform == RuntimePlatform.WebGLPlayer)
        {
            textquitButton.SetActive(false);
        }
    }
}
