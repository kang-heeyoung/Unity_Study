using UnityEngine;

public class Monster
{
    public float hp;
    public float moveSpeed;
    public void Attack()
    {
        Debug.Log("Monster 공격");
    }

    public void Move()
    {
        Debug.Log("Monster 이동");
    }
}
