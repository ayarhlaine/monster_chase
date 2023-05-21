using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameoverUIController : MonoBehaviour
{
    public void OnHomeButtonClick()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void OnRestartButtonClick() {
        SceneManager.LoadScene("Gameplay");
    }
}
