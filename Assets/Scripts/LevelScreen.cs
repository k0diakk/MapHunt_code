using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelScreen : MonoBehaviour
{

    [SerializeField] private int currentLevel;
    
    
    private void Awake()
    {
        PlayerPrefs.SetInt("currentLevel", currentLevel);
    }

    public void NavigateToMainMenu()
    {
        SceneManager.LoadScene(Config.MAIN_MENU_ID);
    }
}
