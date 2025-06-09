using System;
using UnityEngine;
using Cat;

public class CatController : MonoBehaviour
{
    public SoundManager soundManager;
    private Rigidbody2D catRb;
    private Animator catAnim;

    public float limitPower = 20f;
    public float jumpPower = 10f;

    public bool isGround = false;

    public int jumpCount = 0;

    void Start()
    {
        catRb = GetComponent<Rigidbody2D>();
        catAnim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < 2)
        {
            catAnim.SetTrigger("Jump");
            catAnim.SetBool("isGround", false);
            jumpCount++; // 1씩 증가
            soundManager.OnjumpSound();
            catRb.AddForceY(jumpPower, ForceMode2D.Impulse);

            if (catRb.linearVelocityY > limitPower)
                catRb.linearVelocityY = limitPower;
            
        }

        // 점프 시 고양이 회전
        var catRotation = transform.eulerAngles;
        catRotation.z = catRb.linearVelocityY * 2.5f;
        transform.eulerAngles = catRotation;

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            catAnim.SetBool("isGround", true);
            jumpCount = 0;
            isGround = true;
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