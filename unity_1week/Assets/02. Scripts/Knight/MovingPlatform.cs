using System.Timers;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public enum MoveType { Horizontal, Vertical }
    public MoveType moveType;

    public float theta;
    public float power = 0.1f;
    public float speed = 1f;

    private Vector3 initPos;

    void Start()
    {
        initPos = transform.position;
    }

    void Update()
    {
        theta += Time.deltaTime * speed;

        if (moveType == MoveType.Horizontal)
            transform.position = new Vector3(initPos.x + power * Mathf.Sin(theta), initPos.y, initPos.z);
        else if (moveType == MoveType.Vertical)
            transform.position = new Vector3(initPos.x, initPos.y + power * Mathf.Sin(theta), initPos.z);
    }

    // 움직이는 플랫폼 위에 플레이어가 있을 경우, 플랫폼과 함께 움직임.
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.SetParent(transform);
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.SetParent(null);
        }
    }
}