using UnityEngine;

public class ColiderEvent : MonoBehaviour
{
    /// <summary>
    /// ��ȣ�ۿ� �ϴ� �� �� isTrigger = false �� ��� ȣ��
    /// </summary>
    void OnCollisionEnter(Collision other)
    {
        Debug.Log("Collision Enter");
    }

    /// <summary>
    /// ��ȣ�ۿ��ϴ� �� �� �ϳ��� isTrigger = true�� ��� ȣ��
    /// </summary>
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger Enter");
    }
}
