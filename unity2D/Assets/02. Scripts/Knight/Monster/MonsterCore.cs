using System.IO;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;

public abstract class MonsterCore : MonoBehaviour, IDamageable
{
    public Transform target;
    public enum MonsterState { IDLE, PATROL, TRACE, ATTACK }
    public MonsterState monsterState = MonsterState.IDLE;

    public float hp;
    public float speed;
    public float attackTime;

    protected Animator animator;
    protected Rigidbody2D monsterRb;
    protected Collider2D monsterColl;

    protected float moveDir;
    protected bool isTrace;
    protected float targetDist;

    public float currHp;
    public Image hpBar;
    public float atkDamage;

    private bool isDead;

    public ItemManager itemManager;

    protected virtual void Init(float hp, float speed, float attackTime, float atkDamage)
    {
        this.hp = hp;
        this.speed = speed;
        this.attackTime = attackTime;
        this.atkDamage = atkDamage;

        target = GameObject.FindGameObjectWithTag("Player").transform;

        animator = GetComponent<Animator>();
        monsterRb = GetComponent<Rigidbody2D>();
        monsterColl = GetComponent<Collider2D>();
        itemManager = FindFirstObjectByType<ItemManager>();

        currHp = hp;
        hpBar.fillAmount = currHp / hp;
    }

    void Update()
    {
        if (isDead)
            return;

        switch (monsterState)
        {
            case MonsterState.IDLE:
                Idle();
                break;
            case MonsterState.PATROL:
                Patrol();
                break;
            case MonsterState.TRACE:
                Trace();
                break;
            case MonsterState.ATTACK:
                Attack();
                break;
        }
    }

    public abstract void Idle();
    public abstract void Patrol();
    public abstract void Trace();
    public abstract void Attack();

    public void ChangeState(MonsterState newState)
    {
        if (monsterState != newState)
            monsterState = newState;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Return"))
        {
            moveDir *= -1;
            transform.localScale = new Vector3(moveDir, 1, 1);
        }

        if (other.GetComponent<IDamageable>() != null)
        {
            other.GetComponent<IDamageable>().TakeDamage(atkDamage);
        }
    }

    public void TakeDamage(float damage)
    {
        currHp -= damage;
        hpBar.fillAmount = currHp / hp; // 현재체력 / 최대체력
        if (currHp <= 0f)
            Death();
    }

    public void Death()
    {
        isDead = true;
        animator.SetTrigger("Death");
        monsterColl.enabled = false;
        monsterRb.gravityScale = 0f;

        itemManager.DropItem(transform.position);
    }
}