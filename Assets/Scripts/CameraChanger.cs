using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraChanger : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera[] virtualCameras;
    [SerializeField] private Transform[] screens; // Позиции экранов
    [SerializeField] private Transform player; // Ссылка на персонажа
    private int currentCameraIndex;
    void Start()
    {
        
    }
    void Update()
    {
        for (int i = 0; i < virtualCameras.Length; i++)
        {
            if (IsWithinHorizontalBounds(player, screens[i]) && currentCameraIndex != i)
            {
                SwitchCameraToPosition(i);
            }
        }
    }

    private void SwitchCameraToPosition(int position)
    {
        virtualCameras[currentCameraIndex].Priority = 0;

        if (position < virtualCameras.Length && position >= 0) {
            currentCameraIndex = position;
        }
        
        virtualCameras[currentCameraIndex].Priority = 1;
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
