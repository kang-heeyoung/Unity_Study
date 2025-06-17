using UnityEngine;

public class Gun : MonoBehaviour, IDropItem
{
    public GameObject bulletPrefab;
    public Transform shootPos;
    public void Grab(Transform grabPos)
    {
        transform.SetParent(grabPos);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;

        Debug.Log("ÃÑÀ» ÁÖ¿ü´Ù.");
    }

    public void Use()
    {
        GameObject bullet = Instantiate(bulletPrefab, shootPos.position, Quaternion.identity);
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();

        bulletRb.AddForce(shootPos.forward * 100f, ForceMode.Impulse);

        Debug.Log("ÃÑÀ» ÄÑ´Ù");
    }

    public void Drop()
    {
        Debug.Log("ÃÑÀ» ¹ö·È´Ù.");
    }
}
