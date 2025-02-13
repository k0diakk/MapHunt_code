using UnityEngine;
using UnityEngine.SceneManagement;

public class GuessAnswer : MonoBehaviour
{

    [SerializeField] private Portal[] portals; // Порталы
    [SerializeField] public GameObject retry;
    [SerializeField] private Transform player; // Ссылка на персонажа
    [SerializeField] private int rightAnswerNumber; // Номер правильного ответа 1-3


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        for (int i = 0; i < portals.Length; i++)
        {
            bool isPlayerOnPortal = IsWithinHorizontalBounds(player, portals[i].bounds);
            if (isPlayerOnPortal)
            {
                if (Input.GetButtonDown("Jump"))
                {
                    if (i == rightAnswerNumber - 1)
                    {                        
                        int currentLevel = PlayerPrefs.GetInt("currentLevel");
                        int lastLevel = Config.ALL_LEVELS_IDS[Config.ALL_LEVELS_IDS.Length - 1];
                        if (currentLevel == lastLevel)
                        {
                            SceneManager.LoadScene(Config.GAME_COMLETED_ID);
                        }
                        else
                        {
                            SceneManager.LoadScene(Config.WIN_SCREEN_ID);
                        }
                        Debug.Log("RIGHT ANSWER!");
                    } else {
                        Debug.Log("WRONG ANSWER!");
                        SceneManager.LoadScene(Config.LOSE_SCREEN_ID);
                    }
                }
            }
            portals[i].SetPortalSelectedState(isPlayerOnPortal);
        }
    }

    private bool IsWithinHorizontalBounds(Transform player, Transform container)
    {
        // Получаем размеры через Renderer
        Renderer renderer = container.GetComponent<Renderer>();
        if (renderer == null)
        {
            Debug.LogError("Container должен иметь Renderer!");
            return false;
        }

        // Вычисляем границы по X
        float leftBoundary = container.position.x - renderer.bounds.extents.x; // Левая граница
        float rightBoundary = container.position.x + renderer.bounds.extents.x; // Правая граница

        // Проверяем, находится ли player в пределах границ
        return GetCenterX(player) >= leftBoundary && player.position.x <= rightBoundary;
    }

    private float GetCenterX(Transform target)
    {
        // Получаем размеры через Renderer
        Renderer renderer = target.GetComponent<Renderer>();
        if (renderer == null)
        {
            Debug.LogError("Container должен иметь Renderer!");
            return target.position.x;
        }

        // Вычисляем границы по X
        float leftBoundary = target.position.x - renderer.bounds.extents.x; // Левая граница
        float rightBoundary = target.position.x + renderer.bounds.extents.x; // Правая граница

        return (leftBoundary + rightBoundary) / 2; 
    }
}
