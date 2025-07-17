using UnityEngine;

public class PoolItem : MonoBehaviour
{
    private PoolManager poolManager;

    void Awake()
    {
        poolManager = GameObject.FindFirstObjectByType<PoolManager>();
    }

    void Start()
    {
        Invoke("ReturnObject", 3f);
    }

    void ReturnObject()
    {
        //PoolManager.Instance.pool.Release(gameObject);
        poolManager.pool.Release(gameObject);
    }
}
