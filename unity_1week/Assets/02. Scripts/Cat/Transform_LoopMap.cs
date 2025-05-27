using UnityEngine;

public class Transform_LoopMap : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float height = 1.5f;

    public Vector3 returnPos;

    void Start()
    {
        // 배경 이미지의 길이가 30이기 때문에 x = 30f 
        returnPos = new Vector3(30f, height, 0f);

    }
    // Update is called once per frame
    void Update()
    {
        // 배경 왼쪽으로 이동하는 기능
        // transform.position += Vector3.left * moveSpeed * Time.deltaTime; 유동적인 deltaTime(컴퓨터 성능에 따라서 달라지는 값) 대신

        transform.position += Vector3.left * moveSpeed * Time.fixedDeltaTime; // 고정적인 델타타임을 위해 fixedDeltaTime 사용
        Debug.Log($"{Time.fixedDeltaTime}");

        if (transform.position.x <= -30f) // 이미지의 x축 값이 -30을 넘는 순간
        {
            transform.position = returnPos; // 다시 사용하기 위해서 오른쪽 x= 30 으로 초기화
        }
    }
}
