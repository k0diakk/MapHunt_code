using UnityEngine;
using UnityEngine.Rendering.Universal; // Для использования Light2D

public class FlashlightController : MonoBehaviour
{
    // [SerializeField] private Transform player; // Персонаж
    [SerializeField] private Transform flashlight; // Light2D фонарика
    [SerializeField] private GameObject lightOfFlashlight; // Light2D фонарика
    [SerializeField] private Timer batteryCharge; // Light2D фонарика
    [SerializeField] private float radius = 1f; // Радиус вращения фонарика
    [SerializeField] private float angleOffset = 0f; // Коррекция угла в градусах

    private void Update()
    {
        // Получаем позицию мыши в мире
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0; // Убираем Z-координату (для 2D)

        // Вычисляем направление от персонажа к мышке
        Vector2 direction = (mousePosition - transform.position).normalized;

        // Устанавливаем позицию фонарика на окружности
        flashlight.transform.position = transform.position + (Vector3)direction * radius;

        // Поворачиваем фонарик в сторону мышки с учётом корректировки угла
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + angleOffset;
        flashlight.transform.rotation = Quaternion.Euler(0, 0, angle);

        lightOfFlashlight.SetActive(!batteryCharge.isTimeOut);
    }
}
