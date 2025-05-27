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
        transform.Rotate(Vector3.forward * rotSpeed); // z�� �������� ȸ���ϴ� ���

        // ��� 1. ���콺 ���� ��ư�� ������ �� ȸ���ϴ� ���
        if (Input.GetMouseButtonDown(0))
        {
            rotSpeed = 5f;
            
        }

        // ��� 2. �����̽��ٸ� ������ �� ���ߴ� ���
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isStop = true;
        }

        if (isStop == true)
        {
            rotSpeed *= 0.98f; // ���� �ӵ����� Ư�� ����ŭ ���̴� ���
            
            if (rotSpeed < 0.01f)
            {
                rotSpeed = 0f;
                isStop = false; 
            }

        }
        
    }
}
