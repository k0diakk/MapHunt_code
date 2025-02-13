using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float timeInSeconds = 60f; // Начальное время в секундах
    [SerializeField] private bool countDown = true; // Обратный отсчёт (true) или обычный (false)
    [SerializeField] private Color defaultColor = Color.white; // Цвет текста по умолчанию
    [SerializeField] private Color alertColor = Color.red; // Цвет текста, когда время заканчивается

    private float currentTime;
    private TMP_Text timerText;
    public bool isTimeOut = false; // Флаг, чтобы не менять цвет многократно

    private void Start()
    {
        timerText = GetComponent<TMP_Text>();
        currentTime = timeInSeconds;
        timerText.color = defaultColor; // Устанавливаем начальный цвет
        UpdateTimerDisplay();
    }

    private void Update()
    {
        // Обновляем время
        currentTime += (countDown ? -1 : 1) * Time.deltaTime;
        currentTime = Mathf.Max(currentTime, 0); // Ограничиваем минимальное значение времени нулём

        UpdateTimerDisplay();

        // Меняем цвет текста, когда время заканчивается
        if (currentTime <= 0 && !isTimeOut)
        {
            timerText.color = alertColor;
            isTimeOut = true; // Устанавливаем флаг, чтобы изменить цвет только один раз
        }
    }

    private void UpdateTimerDisplay()
    {
        // Форматируем время в "минуты:секунды"
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);
        timerText.text = $"{minutes:D2} : {seconds:D2}";
    }

    public void ResetTimer()
    {
        // Сброс таймера
        currentTime = timeInSeconds;
        timerText.color = defaultColor; // Возвращаем цвет текста к исходному
        isTimeOut = false; // Сбрасываем флаг
        UpdateTimerDisplay();
    }
}
