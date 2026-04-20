using UnityEngine;

public class HoldPoint : MonoBehaviour
{
    [Header("Точка удержания предметов")]
    public Transform holdPoint;

    void Start()
    {
        // Автоматически создаем точку удержания если не назначена
        if (holdPoint == null)
        {
            CreateDefaultHoldPoint();
        }
    }

    void CreateDefaultHoldPoint()
    {
        GameObject holdPointObj = new GameObject("HoldPoint");
        holdPointObj.transform.SetParent(transform);
        holdPointObj.transform.localPosition = new Vector3(0f, 1f, 0.5f); // Перед персонажем
        holdPoint = holdPointObj.transform;
    }
}