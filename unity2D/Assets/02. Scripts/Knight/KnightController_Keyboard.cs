using System;
using UnityEngine;
using UnityEngine.UI;

public class KnightController_Keyboard : MonoBehaviour, IDamageable
{
    private Animator animator;
    private Rigidbody2D knightRb;
    private Collider2D knightCol;

    private Vector3 inputDir;
    [SerializeField] private float moveSpeed = 8f;
    [SerializeField] private float jumpPower = 13f;

    private float atkDamage = 3f;

    private bool isGround;
    private bool isAttack;
    private bool isCombo;

    private bool isLadder;

    public float hp = 100f;
    public float currHp;

    public Image hpBar;

    void Start()
    {
        animator = GetComponent<Animator>();
        knightRb = GetComponent<Rigidbody2D>();
        knightCol = GetComponent<Collider2D>();

        currHp = hp;
        hpBar.fillAmount = currHp / hp;
    }

    void Update() // 일반적인 작업
    {
        InputKeyboard();
        Jump();
        Attack();
    }

    void FixedUpdate() // 물리적인 작업
    {
        Move();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            animator.SetBool("isGround", true);
            isGround = true;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            animator.SetBool("isGround", false);
            isGround = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Monster"))
        {
            if (other.GetComponent<IDamageable>() != null)
            {
                other.GetComponent<IDamageable>().TakeDamage(atkDamage);
                other.GetComponent<Animator>().SetTrigger("Hit");
            }
        }
        if (other.CompareTag("Ladder"))
        {
            isLadder = true;
            knightRb.gravityScale = 0f;
            knightRb.linearVelocity = Vector2.zero;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ladder"))
        {
            isLadder = false;
            knightRb.gravityScale = 2f;
            knightRb.linearVelocity = Vector2.zero;
        }
    }

    void InputKeyboard()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        inputDir = new Vector3(h, v, 0);
        animator.SetFloat("JoystickX", inputDir.x);
        animator.SetFloat("JoystickY", inputDir.y);
    }

    void Move()
    {
        if (inputDir.x != 0)
        {
            var scaleX = inputDir.x > 0 ? 1 : -1;
            transform.localScale = new Vector3(scaleX, 1, 1);

            knightRb.linearVelocityX = inputDir.x * moveSpeed;
        }

        if(isLadder && inputDir.y != 0)
        {
            knightRb.linearVelocityY = inputDir.y * moveSpeed;
        }
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            animator.SetTrigger("Jump");
            knightRb.AddForceY(jumpPower, ForceMode2D.Impulse);
        }
    }

        void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (!isAttack)
            {
                isAttack = true;
                atkDamage = 3f;
                animator.SetTrigger("Attack");
            }
            else
            {
                isCombo = true;
                Debug.Log("콤보 확인");
            }
        }
    }

    public void WaitCombo()
    {
        if (isCombo)
        {
            atkDamage = 5f;
            animator.SetBool("isCombo", true);
        }
        else
        {
            //animator.SetBool("isCombo", false);
            isAttack = false;
            isCombo = false;
        }   
    }

    public void EndCombo()
    {
        isAttack = false;
        isCombo = false;
        animator.SetBool("isCombo", false);
    }

    public void TakeDamage(float damage)
    {
        currHp -= damage;

        hpBar.fillAmount = currHp / hp;
        Debug.Log(currHp);

        if (currHp <= 0f)
            Death();
    }


    public void Death()
    {
        animator.SetTrigger("Death");
        knightCol.enabled = false;
        knightRb.gravityScale = 0f;
    }
}