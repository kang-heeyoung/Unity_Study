using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public float moveSpeed = 3f;
    public Rigidbody2D carRb;

    private float h;

    void Update()
    {
        h = Input.GetAxis("Horizontal");
        // 기존방식 : Transform 이동 (순간이동 활용)
        //transform.position += Vector3.right * h * moveSpeed * Time.deltaTime;
    }

    // 지속적인 물리와 관련된 것은 대부분 FixedUpdate()에서 사용해야함.
    void FixedUpdate()
    {
        // 수정한 방식 : Rigidbody 이동 (속도 활용)
        carRb.linearVelocityX = h * moveSpeed;
    }

    //Collision
    // 충돌 시 1번 실행
    void OnCollisionEnter2D(Collision2D other)
    {
        // 충돌한 오브젝트의 이름 출력
        // Debug.Log(other.gameObject.name);

        //충돌한 오브젝트의 활성화 상태 끄기
        // other.gameObject.SetActive(false);

        Debug.Log("Collision Enter");

    }

    // 충돌 중일때 계속 실행되지만, 충돌중인 오브젝트가 물리적인 변화가 없으면 1초 정도 실행하다가 멈춤.
    void OnCollisionStay2D(Collision2D other)
    {
        Debug.Log("Collision Stay");
    }

    // 충돌이 끝났을 때 1번 실행
    void OnCollisionExit2D(Collision2D other)
    {
        Debug.Log("Collision Exit");
    }

    
    //Trigger

    void OnTriggerEnter2D(Collider2D other)
    {
        
    }

    void OnTriggerStay2D(Collider2D other)
    {
        
    }

    void OnTriggerExit2D(Collider2D other)
    {
        
    }
}
