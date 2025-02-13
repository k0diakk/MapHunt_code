using UnityEngine;

public class Map : MonoBehaviour
{
    
    public float GetMapStartX()
    {
        Renderer renderer = transform.GetComponent<Renderer>();
        if (renderer == null)
        {
            Debug.LogError("Container должен иметь Renderer!");
            return transform.position.x;
        }
        float leftBoundary = transform.position.x - renderer.bounds.extents.x; // Левая граница
        return leftBoundary;
    }

    public float GetMapEndX()
    {
        Renderer renderer = transform.GetComponent<Renderer>();
        if (renderer == null)
        {
            Debug.LogError("Container должен иметь Renderer!");
            return transform.position.x;
        }
        float rightBoundary = transform.position.x + renderer.bounds.extents.x; // Правая граница
        return rightBoundary;
    }
}
