using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void OnPlayButton()
    {
        SceneManager.LoadScene("Main");
        Time.timeScale = 1f;
    }

    public void OnQuitButton()
    {
        Application.Quit();
    }
}
