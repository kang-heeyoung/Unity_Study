using System.Collections;
using UnityEngine;
using static MonsterCore;
using static UnityEngine.GraphicsBuffer;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Monster_Goblin : MonsterCore
{
    private float timer;
    private float ranDir;
    private float idleTime, patrolTime;

    private Vector3 startPos, endPos;

    // 거리의 경우 직접 체크한 후 본인의 코드 상황에 맞게 수정
    private float traceDist = 7f;
    private float attackDist = 2.7f;

    private bool isAttack;

    void Start()
    {
        Init(10f, 3f, 2f, 10f);
        StartCoroutine(FindPlayerRoutine());
    }

    protected override void Init(float hp, float speed, float attackTime, float atkDamage)
    {
        base.Init(hp, speed, attackTime, atkDamage);
        idleTime = Random.Range(1f, 5f);
    }

    IEnumerator FindPlayerRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.02f); // 50 FPS
            targetDist = Vector3.Distance(transform.position, target.position);

            if (monsterState == MonsterState.IDLE || monsterState == MonsterState.PATROL)
            {
                Vector3 monsterDir = Vector3.right * moveDir; // 몬스터가 바라보는 방향
                Vector3 playerDir = (transform.position - target.position).normalized; // 플레이어가 몬스터를 바라보는 방향
                float dotValue = Vector3.Dot(monsterDir, playerDir);
                isTrace = dotValue < -0.5f && dotValue >= -1f; // 고블린이 플레이어를 바라보고 있는 경우

                if (targetDist <= traceDist && isTrace)
                {
                    animator.SetBool("isRun", true);
                    ChangeState(MonsterState.TRACE);
                }
            }
            else if (monsterState == MonsterState.TRACE)
            {
                if (targetDist > traceDist)
                {
                    timer = 0f;
                    idleTime = Random.Range(1f, 5f);
                    animator.SetBool("isRun", false);

                    ChangeState(MonsterState.IDLE);
                }

                if (targetDist < attackDist)
                {
                    ChangeState(MonsterState.ATTACK);
                }
            }
        }
    }


    public override void Idle()
    {
        timer += Time.deltaTime;
        if (timer >= idleTime)
        {
            timer = 0f;
            moveDir = Random.Range(0, 2) == 1 ? 1 : -1;
            transform.localScale = new Vector3(moveDir, 1, 1);
            patrolTime = Random.Range(1f, 5f);

            animator.SetBool("isRun", true);

            //startPos = transform.position;
            //endPos = startPos + Vector3.right * ranDir * patrolTime;

            ChangeState(MonsterState.PATROL);
        }
    }

    public override void Patrol()
    {
        transform.position += Vector3.right * moveDir * speed * Time.deltaTime;
        timer += Time.deltaTime;
        //percent = timer / patrolTime;

        //transform.position = Vector3.Lerp(startPos, endPos, percent);

        if (timer >= patrolTime)
        {
            timer = 0f;
            idleTime = Random.Range(1f, 5f);
            animator.SetBool("isRun", false);

            ChangeState(MonsterState.IDLE);
        }
    }

    public override void Trace()
    {
        var targetDir = (target.position - transform.position).normalized;
        transform.position += Vector3.right * targetDir.x * speed * Time.deltaTime;

        var scaleX = targetDir.x > 0 ? 1 : -1;
        transform.localScale = new Vector3(scaleX, 1, 1);
    }

    public override void Attack()
    {
        if (!isAttack)
        {
            StartCoroutine(AttackRoutine());
        }
    }

    IEnumerator AttackRoutine()
    {
        isAttack = true;
        animator.SetTrigger("Attack");
        float currAnimLength = animator.GetCurrentAnimatorStateInfo(0).length;
        yield return new WaitForSeconds(currAnimLength);

        animator.SetBool("isRun", false);
        var targetDir = (target.position - transform.position).normalized;
        var scaleX = targetDir.x > 0 ? 1 : -1;
        transform.localScale = new Vector3(scaleX, 1, 1);
        hpBar.transform.localScale = new Vector3(scaleX, 1, 1);
        yield return new WaitForSeconds(attackTime - 1f);

        isAttack = false;
        animator.SetBool("isRun", true);
        ChangeState(MonsterState.TRACE);
    }
}