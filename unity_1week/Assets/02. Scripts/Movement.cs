using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed=5f;


    void Start()
    {
        
    }

    void Update()
    {
        /// Input System (Old Legacy)
        /// �Է°��� ���� ��ӵ� �ý���
        /// �̵� -> WASD, ȭ��ǥŰ����
        /// ���� -> Space
        /// �ѽ�� -> ���콺 ����
        
        // �ε巴�� �����ϴ� �� (����)
        float h = Input.GetAxis("Horizontal"); // x
        float v = Input.GetAxis("Vertical"); // z

        // �� �������� ��
        //float h = Input.GetAxisRaw("Horizontal");
        //float v = Input.GetAxisRaw("Vertical");

        
        Vector3 dir = new Vector3(h, 0, v); // x, y, z
        Vector3 normalDir = dir.normalized;

        transform.position += dir * moveSpeed * Time.deltaTime;

        transform.LookAt(transform.position + normalDir);


        //if (Input.GetKey(KeyCode.W)) // ������ ���� ���
        //{
        //    transform.position += Vector3.forward * moveSpeed * Time.deltaTime;
        //}

        //if (Input.GetKey(KeyCode.S)) // �ڷ� ���� ���
        //{
        //    transform.position += Vector3.back * moveSpeed * Time.deltaTime;
        //}

        //if (Input.GetKey(KeyCode.A)) // �������� ���� ���
        //{
        //    transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        //}

        //if (Input.GetKey(KeyCode.D)) // ���������� ���� ���
        //{
        //    transform.position += Vector3.right * moveSpeed * Time.deltaTime;
        //}
    }
}
