using UnityEngine;
using UnityEngine.SceneManagement;

public class afrodanger : MonoBehaviour
{
    [SerializeField] public float speed = 10f; // Скорость движения
    [SerializeField] private Timer batteryCharge; // Light2D фонарика
    [SerializeField] private Transform player; // Light2D фонарика

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 horizontalMove = Vector3.MoveTowards(transform.position, transform.position + transform.right, speed * Time.deltaTime);
        if (batteryCharge.isTimeOut)
        {
            transform.position = horizontalMove;
        }

        if (transform.position.x > player.position.x) {
            SceneManager.LoadScene(Config.LOSE_SCREEN_ID);
        }
    }
}
