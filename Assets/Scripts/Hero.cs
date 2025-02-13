using System.Linq;
using UnityEngine;

public class Hero : MonoBehaviour
{
    [SerializeField] public float speed = 10f; // Скорость движения
    [SerializeField] private float bobFrequency = 30f; // Частота качания
    [SerializeField] private float bobAmplitude = 0.1f; // Амплитуда качания
    [SerializeField] private Map map;

    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Vector3 startPosition; // Для сохранения базовой позиции

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        startPosition = transform.position;
    }

    private void Update()
    {
        if (Input.GetButton("Horizontal"))
            Run();
        else
            ResetPosition(); // Возвращаем персонажа в базовую позицию
    }

    private void Run()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 dir = transform.right * horizontalInput; // Направление движения

        // Движение
        // rb.linearVelocity = new Vector2(dir.x * speed, rb.linearVelocity.y);

        // Анимация качания
        float bobOffset = Mathf.Sin(Time.time * bobFrequency) * bobAmplitude;
        transform.position = new Vector3(transform.position.x, startPosition.y + bobOffset, transform.position.z);
        Vector3 horizontalMove = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);
        if (IsHorizontalMoveAllowed(horizontalMove))
        {
            transform.position = horizontalMove;
        }
        // Отражение спрайта
        sprite.flipX = horizontalInput < 0.0f;
    }

    private void ResetPosition()
    {
        // Возвращаем персонажа к базовой вертикальной позиции
        transform.position = new Vector3(transform.position.x, startPosition.y, transform.position.z);

        // Останавливаем горизонтальное движение
        // rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
    }

    private bool IsHorizontalMoveAllowed(Vector3 newHorizontalPosition)
    {
        float startOfRoad = map.GetMapStartX();
        float endOfRoad = map.GetMapEndX();
        return newHorizontalPosition.x >= startOfRoad && newHorizontalPosition.x <= endOfRoad;
    }
}
