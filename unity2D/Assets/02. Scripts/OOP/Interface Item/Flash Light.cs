using UnityEngine;

public class FlashLight : MonoBehaviour, IDropItem
{
    public GameObject lightObj;

    public void Grab(Transform grabPos)
    {
        // grabPos의 자식 오브젝트로 들어가면서, 지금 오브젝트의 위치를 grabPos의 위치와 회전으로 초기화한다.
        transform.SetParent(grabPos);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;

        Debug.Log("손전등을 주웠다.");
    }

    public void Use()
    {
        // lightObj의 상태를 Use 함수가 실행될 때 마다 On <-> OFf 로 바꾼다.
        lightObj.SetActive(!lightObj.activeSelf);
        Debug.Log("손전등을 켜다");
    }

    public void Drop()
    {
        // 손전등의 부모를 null로 설정한다. (현재 있는 계층구조를 빠져 나온다.)
        transform.SetParent(null);
        transform.position = Vector3.zero;

        Debug.Log("손전등을 버렸다.");
        
    }
}
