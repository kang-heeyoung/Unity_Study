using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed=5f;

    public static int coinCount = 0;


    void Start()
    {
        
    }

    void Update()
    {
        // �ε巴�� �����ϴ� �� (����)
        float h = Input.GetAxis("Horizontal"); // x
        float v = Input.GetAxis("Vertical"); // z


        Vector3 dir = new Vector3(h, 0, v); // x, y, z
        Vector3 normalDir = dir.normalized;

        transform.position += dir * moveSpeed * Time.deltaTime;

        transform.LookAt(transform.position + normalDir);
    }
}
