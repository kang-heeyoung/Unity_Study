using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private Rigidbody2D characterRb;
    public SpriteRenderer[] renderers;

    public float moveSpeed;
    public float jumpPower = 10f;

    private float h;

    private bool isGround; 

    private void Start()
    {
        characterRb = GetComponent<Rigidbody2D>();

        renderers = GetComponentsInChildren<SpriteRenderer>();
    }
    void Update()
    {
        // Ű �Է�
        h = Input.GetAxis("Horizontal");

        Jump();
    }

    void FixedUpdate()
    {
        Move();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        isGround = true;
        renderers[2].gameObject.SetActive(false);
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        isGround = false;
        renderers[0].gameObject.SetActive(false);
        renderers[1].gameObject.SetActive(false);
        renderers[2].gameObject.SetActive(true);
    }

    // ĳ���� �����ӿ� ���� �̹����� Flip ���°� ���ϴ� ���
    private void Move()
    {

        if (h != 0) // ������ ��
        {
            if (isGround)
            {
                renderers[0].gameObject.SetActive(false); // Idle
                renderers[1].gameObject.SetActive(true); // Run
                renderers[2].gameObject.SetActive(false); // Run
                
            }

            // �������� �̵�
            characterRb.linearVelocityX = h * moveSpeed;

            // �������� �� ��
            if (h > 0)
            {
                renderers[0].flipX = false;
                renderers[1].flipX = false;
                renderers[2].flipX = false;
            }
            // ������ �� ��
            else if (h < 0)
            {
                renderers[0].flipX = true;
                renderers[1].flipX = true;
                renderers[2].flipX = true;
            }
        }
        else // �������� ���� ��
        {
            if (isGround)
            {
                renderers[0].gameObject.SetActive(true); // Idle
                renderers[1].gameObject.SetActive(false); // Run
                renderers[2].gameObject.SetActive(false); // Run

            }
            
        }
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            characterRb.AddForceY(jumpPower, ForceMode2D.Impulse);
        }
    }
}
