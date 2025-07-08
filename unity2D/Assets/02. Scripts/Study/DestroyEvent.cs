using UnityEngine;

public class DestroyEvent : MonoBehaviour
{
    public float destroyTime = 3f;
    void Start()
    {
        Destroy(this.gameObject, destroyTime);

    }

    // 오브젝트가 파괴될 때 1번 실행됨.
    // 파괴가 안되고 프로그램 종료시에도 1번 실행됨.
    private void OnDestroy()
    {
        Debug.Log($"{this.gameObject.name}이 파괴되었습니다.");
        
    }
}
