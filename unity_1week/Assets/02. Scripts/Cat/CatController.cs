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
        // �����̽� Ű �Է�
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < 2)
        {
            // Y�� �������� ����������(Impulse) jumpPower�� ���� ����
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
