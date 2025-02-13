using UnityEngine;
using UnityEngine.SceneManagement;

public class GameCompleted : MonoBehaviour
{
    
    private void Awake()
    {
        PlayerPrefs.SetInt("lastCompletedLevel", 0);
        PlayerPrefs.SetInt("currentLevel", Config.LEVEL_1_ID);
    }

    public void NavigateToNewGame()
    {
        SceneManager.LoadScene(Config.LEVEL_1_ID);
    }

    public void NavigateToMainMenu()
    {
        SceneManager.LoadScene(Config.MAIN_MENU_ID);
    }
}
