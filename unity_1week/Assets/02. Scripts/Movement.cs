using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed;


    void Start()
    {
        
    }

    void Update()
    {
        //  옛날에 쓰던 방식
        if (Input.GetKeyDown(KeyCode.W))
        {
            this.transform.position += Vector3.forward * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            this.transform.position += Vector3.back * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            this.transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            this.transform.position += Vector3.right * moveSpeed * Time.deltaTime;
        }
    }
}
