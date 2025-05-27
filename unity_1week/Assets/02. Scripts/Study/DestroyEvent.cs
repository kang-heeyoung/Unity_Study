using UnityEngine;

public class DestroyEvent : MonoBehaviour
{
    public float destroyTime = 3f;
    void Start()
    {
        Destroy(this.gameObject, destroyTime);

    }

    // ������Ʈ�� �ı��� �� 1�� �����.
    // �ı��� �ȵǰ� ���α׷� ����ÿ��� 1�� �����.
    private void OnDestroy()
    {
        Debug.Log($"{this.gameObject.name}�� �ı��Ǿ����ϴ�.");
        
    }
}
