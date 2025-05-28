using UnityEngine;

public class CatController : MonoBehaviour
{

    private Rigidbody2D catRb;
    public float jumpPower = 10f;

    private bool isGround = false;

    public int jumpCount = 0;

    void Start()
    {
        catRb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        // 스페이스 키 입력
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < 2)
        {
            // Y축 방향으로 순간적으로(Impulse) jumpPower의 힘을 가함
            catRb.AddForceY(jumpPower, ForceMode2D.Impulse);
            jumpCount++;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            //isGround = true;
            jumpCount = 0;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGround = false;
        }
    }
}
