using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void OnPlayButton()
    {
        SceneManager.LoadScene("SCN_Game");
    }

    public void OnQuitButton()
    {
        Debug.LogWarning("Game has been closed");
        Application.Quit();
    }
}
