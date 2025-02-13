using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    
    private void Awake()
    {
        int currentLevel = PlayerPrefs.GetInt("currentLevel");
        int lastCompletedLevel = PlayerPrefs.GetInt("lastCompletedLevel");
        if (currentLevel > lastCompletedLevel)
        {
            PlayerPrefs.SetInt("lastCompletedLevel", currentLevel);
        }
        PlayerPrefs.SetInt("currentLevel", currentLevel + 1);
    }
    public void NavigateToNextLevel()
    {
        int currentLevel = PlayerPrefs.GetInt("currentLevel");
        int nextLevel = currentLevel; // currentLevel уже стал следующим, как только открылся этот экран.
        SceneManager.LoadScene(nextLevel);
    }

    public void NavigateToMainMenu()
    {
        SceneManager.LoadScene(Config.MAIN_MENU_ID);
    }
}
