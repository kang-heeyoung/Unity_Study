using UnityEngine;
using System;

public class CharacterControl : MonoBehaviour
{
    private IDropItem currentItem;

    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private Transform grabPos;
    

    void Update()
    {
        Move();
        Interaction();
    }

    private void Move()
    {
        float h = Input.GetAxis("Horizontal"); // x축 오른쪽/왼쪽
        float v = Input.GetAxis("Vertical"); // z축 앞쪽/뒤쪽

        Vector3 dir = new Vector3(h, 0, v).normalized;

        transform.position += dir * moveSpeed * Time.deltaTime;
    }

    private void Interaction()
    {
        if (currentItem == null)
            return;

        if (Input.GetMouseButtonDown(0))
        {
            currentItem.Use();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentItem.Drop();
            currentItem= null;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<IDropItem>() != null)
        {
            currentItem = other.GetComponent<IDropItem>();

            currentItem.Grab(grabPos);
        }
    }
}
