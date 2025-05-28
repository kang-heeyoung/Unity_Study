using UnityEngine;

public class ColiderEvent : MonoBehaviour
{
    /// <summary>
    /// 상호작용 하는 둘 다 isTrigger = false 일 경우 호출
    /// </summary>
    void OnCollisionEnter(Collision other)
    {
        Debug.Log("Collision Enter");
    }

    /// <summary>
    /// 상호작용하는 둘 중 하나라도 isTrigger = true일 경우 호출
    /// </summary>
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger Enter");
    }
}
