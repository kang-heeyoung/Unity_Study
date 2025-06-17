using UnityEngine;

public abstract class Monster : MonoBehaviour
{
    private SpriteRenderer sRenderer;

    protected float hp = 3f;
    protected float moveSpeed = 3f;

    private int dir = 1;

    public abstract void Init(); // 보통 초기화 기능으로 많이 사용

    void Start()
    {
        sRenderer = GetComponent<SpriteRenderer>();

        Init();
    }

    void OnMouseDown()
    {
        Hit(1);
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
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

    void Hit(float damage)
    {
        hp -= damage;

        if(hp <= 0)
        {
            Debug.Log("몬스터 죽음");
            Destroy(gameObject);
        }
    }
}
