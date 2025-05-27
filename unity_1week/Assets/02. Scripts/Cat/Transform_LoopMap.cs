using UnityEngine;

public class Transform_LoopMap : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float height = 1.5f;

    public Vector3 returnPos;

    void Start()
    {
        // ��� �̹����� ���̰� 30�̱� ������ x = 30f 
        returnPos = new Vector3(30f, height, 0f);

    }
    // Update is called once per frame
    void Update()
    {
        // ��� �������� �̵��ϴ� ���
        // transform.position += Vector3.left * moveSpeed * Time.deltaTime; �������� deltaTime(��ǻ�� ���ɿ� ���� �޶����� ��) ���

        transform.position += Vector3.left * moveSpeed * Time.fixedDeltaTime; // �������� ��ŸŸ���� ���� fixedDeltaTime ���
        Debug.Log($"{Time.fixedDeltaTime}");

        if (transform.position.x <= -30f) // �̹����� x�� ���� -30�� �Ѵ� ����
        {
            transform.position = returnPos; // �ٽ� ����ϱ� ���ؼ� ������ x= 30 ���� �ʱ�ȭ
        }
    }
}
