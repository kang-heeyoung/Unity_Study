using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 100f;
    void Update()
    {
        transform.position += transform.forward * bulletSpeed * Time.deltaTime; // transform.forward : 나 자신의 정면
    }
}

