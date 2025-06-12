using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public float moveSpeed = 3f;
    public Rigidbody2D carRb;

    private float h;

    void Update()
    {
        h = Input.GetAxis("Horizontal");
        // ������� : Transform �̵� (�����̵� Ȱ��)
        //transform.position += Vector3.right * h * moveSpeed * Time.deltaTime;
    }

    // �������� ������ ���õ� ���� ��κ� FixedUpdate()���� ����ؾ���.
    void FixedUpdate()
    {
        // ������ ��� : Rigidbody �̵� (�ӵ� Ȱ��)
        carRb.linearVelocityX = h * moveSpeed;
    }

    //Collision
    // �浹 �� 1�� ����
    void OnCollisionEnter2D(Collision2D other)
    {
        // �浹�� ������Ʈ�� �̸� ���
        // Debug.Log(other.gameObject.name);

        //�浹�� ������Ʈ�� Ȱ��ȭ ���� ����
        // other.gameObject.SetActive(false);

        Debug.Log("Collision Enter");

    }

    // �浹 ���϶� ��� ���������, �浹���� ������Ʈ�� �������� ��ȭ�� ������ 1�� ���� �����ϴٰ� ����.
    void OnCollisionStay2D(Collision2D other)
    {
        Debug.Log("Collision Stay");
    }

    // �浹�� ������ �� 1�� ����
    void OnCollisionExit2D(Collision2D other)
    {
        Debug.Log("Collision Exit");
    }

    
    //Trigger

    void OnTriggerEnter2D(Collider2D other)
    {
        
    }

    void OnTriggerStay2D(Collider2D other)
    {
        
    }

    void OnTriggerExit2D(Collider2D other)
    {
        
    }
}
