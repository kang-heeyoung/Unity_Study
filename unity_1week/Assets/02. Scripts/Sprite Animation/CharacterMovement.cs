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
        // 키 입력
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

    // 캐릭터 움직임에 따라 이미지의 Flip 상태가 변하는 기능
    private void Move()
    {

        if (h != 0) // 움직일 때
        {
            if (isGround)
            {
                renderers[0].gameObject.SetActive(false); // Idle
                renderers[1].gameObject.SetActive(true); // Run
                renderers[2].gameObject.SetActive(false); // Run
                
            }

            // 물리적인 이동
            characterRb.linearVelocityX = h * moveSpeed;

            // 오른쪽을 볼 때
            if (h > 0)
            {
                renderers[0].flipX = false;
                renderers[1].flipX = false;
                renderers[2].flipX = false;
            }
            // 왼쪽을 볼 때
            else if (h < 0)
            {
                renderers[0].flipX = true;
                renderers[1].flipX = true;
                renderers[2].flipX = true;
            }
        }
        else // 움직이지 않을 때
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
