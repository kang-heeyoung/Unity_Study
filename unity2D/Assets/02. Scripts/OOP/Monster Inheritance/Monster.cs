using System.Collections;
using UnityEngine;

public abstract class Monster : MonoBehaviour
{
    public SpawnManager spawner;

    private SpriteRenderer sRenderer;
    private Animator animator;

    protected float hp = 3f;
    protected float moveSpeed = 3f;

    private int dir = 1;
    private bool isMove = true;
    private bool isHit = false;

    public abstract void Init(); // 보통 초기화 기능으로 많이 사용

    void Start()
    {
        spawner = FindFirstObjectByType<SpawnManager>();

        sRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        Init();
    }

    void OnMouseDown()
    {
        //Hit(1);
        StartCoroutine(Hit(1));
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        if (!isMove)
            return;

        transform.position += Vector3.right * dir * moveSpeed * Time.deltaTime;

        if (transform.position.x > 8f)
        {

            dir = -1;
            sRenderer.flipX = true;
        }
        else if (transform.position.x <= -8f)
        {
            dir = 1;
            sRenderer.flipX = false;
        }
    }

    IEnumerator Hit(float damage)
    {
        Debug.Log("g");
        if (isHit) 
            yield break; // 종료
        Debug.Log("g1");

        isHit = true;
        isMove = false; // 움직임 x
        animator.SetTrigger("Hit");
        Debug.Log("g2");
        hp -= damage;

        if (hp <= 0)
        {
            animator.SetTrigger("Death");

            spawner.DropCoin(transform.position); // 코인 생성

            yield return new WaitForSeconds(3f);
            Destroy(gameObject);

            yield break;
        }

        // 잠깐 멈추거나, Delay 시키는 기능
        yield return new WaitForSeconds(0.65f);

        isHit = false;
        isMove = true; // 움직임 o
    }
}
