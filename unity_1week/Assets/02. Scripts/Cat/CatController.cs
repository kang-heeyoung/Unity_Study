using System;
using UnityEngine;
using System.Collections;
using Cat;

public class CatController : MonoBehaviour
{
    public SoundManager soundManager;
    public VideoManager videoManager;

    public GameObject gameOverUI;
    public GameObject fadeUI;

    private Rigidbody2D catRb;
    private Animator catAnim;

    public float limitPower = 20f;
    public float jumpPower = 20f;

    public int jumpCount = 0;

    void Awake() // 1번만 실행
    {
        catRb = GetComponent<Rigidbody2D>();
        catAnim = GetComponent<Animator>();
    }
    void OnEnable() // 켜질때마다 1번씩 실행
    {
        transform.localPosition = new Vector3(-8.18f,-2.24f,0); // 고양이 처음 위치

        GetComponent<CircleCollider2D>().enabled = true;
        soundManager.audioSource.Play();
    }

    void Update()
    {
        Jump();
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < 5)
        {
            catAnim.SetTrigger("Jump");
            catAnim.SetBool("isGround", false);
            jumpCount++; // 1씩 증가
            soundManager.OnjumpSound();
            catRb.AddForceY(jumpPower, ForceMode2D.Impulse);

            // 자연스러운 점프를 위한 속도 제한
            if (catRb.linearVelocityY > limitPower)
                catRb.linearVelocityY = limitPower;

        }

        // 점프 시 고양이 회전
        var catRotation = transform.eulerAngles;
        catRotation.z = catRb.linearVelocityY * 2.5f;
        transform.eulerAngles = catRotation;

    }

    // 사과와 충돌할 경우 점수가 올라가고 사과가 사라짐.
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Apple"))
        {
            other.gameObject.SetActive(false);
            other.transform.parent.GetComponent<ItemEvent>().particle.SetActive(true);

            GameManager.score++;

            if (GameManager.score == 10)
            {
                fadeUI.SetActive(true);
                fadeUI.GetComponent<FadeRoutine>().OnFade(3f, Color.white,true);
                this.GetComponent<CircleCollider2D>().enabled = false;

                StartCoroutine(EndingRoutine(true));
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Pipe"))
        {
            soundManager.OnColliderSound();

            gameOverUI.SetActive(true); // 게임 오버 켜기
            fadeUI.SetActive(true); // 페이드 켜기
            fadeUI.GetComponent<FadeRoutine>().OnFade(3f, Color.black, true); // 페이드 실행
            GetComponent<CircleCollider2D>().enabled = false;

            StartCoroutine(EndingRoutine(false));
        }

        if (other.gameObject.CompareTag("Ground"))
        {
            catAnim.SetBool("isGround", true);
            jumpCount = 0;
        }
    }

    IEnumerator EndingRoutine(bool isHappy)
    {
        yield return new WaitForSeconds(3.5f);

        videoManager.VideoPlay(isHappy); // 영상 재생 시작
        yield return new WaitForSeconds(1f);

        var newColor = isHappy ? Color.white : Color.black;
        fadeUI.GetComponent<FadeRoutine>().OnFade(3f, newColor, false); // 페이드 실행

        yield return new WaitForSeconds(3f);
        fadeUI.SetActive(false);
        gameOverUI.SetActive(false);
        soundManager.audioSource.Stop();

        transform.parent.gameObject.SetActive(false); // PLAY 오브젝트 Off
    }

}