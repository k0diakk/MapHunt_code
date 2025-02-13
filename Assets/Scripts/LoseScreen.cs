using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseScreen : MonoBehaviour
{

    public void NavigateToRestart()
    {
        int currentLevel = PlayerPrefs.GetInt("currentLevel");
        SceneManager.LoadScene(currentLevel);
    }

    public void NavigateToMainMenu()
    {
        SceneManager.LoadScene(Config.MAIN_MENU_ID);
    }
}
