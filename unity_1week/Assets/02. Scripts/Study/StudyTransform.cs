using UnityEngine;

public class StudyTransform : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float rotateSpeed = 70f;

    // Update is called once per frame
    void Update()
    {
        // ���� �������� �̵�
        transform.position += Vector3.forward * moveSpeed * Time.deltaTime;

        // ���� �������� �̵�
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        // ���� ������ �̵�
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime, Space.World);

        // ���� �������� ȸ��
        transform.rotation = Quaternion.Euler(0f, transform.eulerAngles.y + rotateSpeed * Time.deltaTime, 0f);

        // ���� �������� ȸ��
        transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime); // Space.Self ����

        // ���� �������� ȸ��
        transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime, Space.World);

        // Ư�� ��ġ�� �ֺ��� ȸ��
        transform.RotateAround(Vector3.zero, Vector3.up, rotateSpeed * Time.deltaTime);

        // Ư�� ��ġ�� �ٶ󺸸� ȸ��
        transform.LookAt(Vector3.zero);
    }
}
