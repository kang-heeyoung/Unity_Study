using UnityEngine;

public class Player : MonoBehaviour
{
    public float hp;
    public float moveSpeed;

    public void Attack()
    {
        Debug.Log("Player의 공격");
    }

    public void Move()
    {
        Debug.Log("Player 이동");
    }
}
