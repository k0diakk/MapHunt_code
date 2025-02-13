using System;
using System.Collections;
using UnityEngine;

public class Portal : MonoBehaviour
{
    
    [SerializeField] private float rotationAngle = 180f; // Угол поворота
    [SerializeField] private float interval = 1f; // Интервал в секундах
    [SerializeField] public Transform portalName; // Название города
    [SerializeField] public Transform bounds; // Границы портала
    [SerializeField] public Transform image; // Картинка портала

    [SerializeField] private float jumpHeight = 0.5f; // Высота "подпрыгивания"
    [SerializeField] private float scaleMultiplier = 1.2f; // Увеличение размера
    [SerializeField] private float animationDuration = 0.05f; // Длительность анимации
    
    private bool isSelected = false;  // Выбран ли этот портал в текущий момент

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(RotatePeriodically());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator RotatePeriodically()
    {
        while (true)
        {
            RotateObject();
            yield return new WaitForSeconds(interval);
        }
    }

    private void RotateObject()
    {
        image.transform.Rotate(rotationAngle, 0f, 0f);
    }

    public void SetPortalSelectedState(bool selected)
    {
        if (selected != isSelected)
        {
            StartCoroutine(AnimateObject(portalName, selected));
        }
        isSelected = selected;
    }

    
    private IEnumerator AnimateObject(Transform target, bool isJumping)
    {
        Vector3 startPosition = target.position;
        Vector3 startScale = target.localScale;

        Vector3 targetPosition = isJumping 
            ? startPosition + Vector3.up * jumpHeight 
            : startPosition - Vector3.up * jumpHeight;
        Vector3 targetScale = isJumping 
            ? startScale * scaleMultiplier 
            : startScale / scaleMultiplier;

        float elapsedTime = 0f;

        while (elapsedTime < animationDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / animationDuration;

            target.position = Vector3.Lerp(startPosition, targetPosition, t);
            target.localScale = Vector3.Lerp(startScale, targetScale, t);

            yield return null;
        }

        target.position = targetPosition;
        target.localScale = targetScale;
    }
}
