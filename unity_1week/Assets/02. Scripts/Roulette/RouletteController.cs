using UnityEngine;

public class RouletteController : MonoBehaviour
{
    public float rotSpeed = 5f;

    public bool isStop; // false

    private void Start()
    {
        rotSpeed = 0;
    }

    void Update()
    {
        transform.Rotate(Vector3.forward * rotSpeed); // z축 기준으로 회전하는 기능

        // 기능 1. 마우스 왼쪽 버튼을 눌렀을 때 회전하는 기능
        if (Input.GetMouseButtonDown(0))
        {
            rotSpeed = 5f;
            
        }

        // 기능 2. 스페이스바를 눌렀을 때 멈추는 기능
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isStop = true;
        }

        if (isStop == true)
        {
            rotSpeed *= 0.98f; // 현재 속도에서 특정 값만큼 줄이는 기능
            
            if (rotSpeed < 0.01f)
            {
                rotSpeed = 0f;
                isStop = false; 
            }

        }
        
    }
}
