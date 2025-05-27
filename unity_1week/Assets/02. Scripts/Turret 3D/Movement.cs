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
        /// 입력값에 대한 약속된 시스템
        /// 이동 -> WASD, 화살표키보드
        /// 점프 -> Space
        /// 총쏘기 -> 마우스 왼쪽
        
        // 부드럽게 증감하는 값 (관성)
        float h = Input.GetAxis("Horizontal"); // x
        float v = Input.GetAxis("Vertical"); // z

        // 딱 떨어지는 값
        //float h = Input.GetAxisRaw("Horizontal");
        //float v = Input.GetAxisRaw("Vertical");

        
        Vector3 dir = new Vector3(h, 0, v); // x, y, z
        Vector3 normalDir = dir.normalized;

        transform.position += dir * moveSpeed * Time.deltaTime;

        transform.LookAt(transform.position + normalDir);


        //if (Input.GetKey(KeyCode.W)) // 앞으로 가는 기능
        //{
        //    transform.position += Vector3.forward * moveSpeed * Time.deltaTime;
        //}

        //if (Input.GetKey(KeyCode.S)) // 뒤로 가는 기능
        //{
        //    transform.position += Vector3.back * moveSpeed * Time.deltaTime;
        //}

        //if (Input.GetKey(KeyCode.A)) // 왼쪽으로 가는 기능
        //{
        //    transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        //}

        //if (Input.GetKey(KeyCode.D)) // 오른쪽으로 가는 기능
        //{
        //    transform.position += Vector3.right * moveSpeed * Time.deltaTime;
        //}
    }
}
