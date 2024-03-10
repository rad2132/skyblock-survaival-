using UnityEngine;

public class SafeArea : MonoBehaviour
{
    void Start()
    {
        RectTransform rectTransform = GetComponent<RectTransform>();

        Vector2 anchorMin = Screen.safeArea.position;
        Vector2 anchorMax = Screen.safeArea.size + anchorMin;

        anchorMin.x /= Screen.width;
        anchorMin.y /= Screen.height;
        anchorMax.x /= Screen.width;
        anchorMax.y /= Screen.height;
        rectTransform.anchorMin = anchorMin;
        rectTransform.anchorMax = anchorMax;
    }
}
