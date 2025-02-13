using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{
    
    [SerializeField] public GameObject[] levels;

    private void Awake()
    {
        int lastCompletedLevel = PlayerPrefs.GetInt("lastCompletedLevel");
        for (int i = 0; i < levels.Length; i++)
        {
            if (i + Config.LEVEL_1_ID > lastCompletedLevel + 1)
            {
                levels[i].GetComponent<Image>().color = Color.black;
            }
        }
    }

    public void PlayGame()
    {
        int currentLevel = PlayerPrefs.GetInt("currentLevel");
        if (currentLevel != 0) {
            SceneManager.LoadScene(currentLevel);
        } else {
            SceneManager.LoadScene(Config.LEVEL_1_ID);
        }
    }

    public void PlayLevel1()
    {
        SceneManager.LoadScene(Config.LEVEL_1_ID);
    }

    public void PlayLevel2()
    {
        int lastCompletedLevel = PlayerPrefs.GetInt("lastCompletedLevel");
        if (lastCompletedLevel < 1)
        {
            return;
        }
        SceneManager.LoadScene(Config.LEVEL_2_ID);
    }

    public void PlayLevel3()
    {
        int lastCompletedLevel = PlayerPrefs.GetInt("lastCompletedLevel");
        if (lastCompletedLevel < 2)
        {
            return;
        }
        SceneManager.LoadScene(Config.LEVEL_3_ID);
    }

    public void ExitGame()
    {
        Debug.Log("Игра закрылась");
        Application.Quit();
    }
}
