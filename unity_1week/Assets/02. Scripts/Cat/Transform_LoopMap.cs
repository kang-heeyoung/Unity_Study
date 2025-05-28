using UnityEngine;

public class Transform_LoopMap : MonoBehaviour
{
    public float moveSpeed = 3f;

    public float returnPosX = 15f;
    public float randomPosY;

    void Update()
    {
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;

        if (transform.position.x <= -returnPosX)
        {
            randomPosY = Random.Range(-6.5f, -2.9f);
            transform.position = new Vector3(returnPosX, randomPosY, 0);
        }
    }
}
