using UnityEngine;

public class Factory<T> : MonoBehaviour
{
    public T prefab;

    public Factory()
    {
        Debug.Log($"Factory는 {typeof(TabbedView)} 타입 입니다.");
    }
}
