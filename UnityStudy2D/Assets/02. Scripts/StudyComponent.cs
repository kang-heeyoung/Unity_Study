using UnityEngine;

public class StudyComponent : MonoBehaviour
{
    public GameObject obj;

    public string changeName;

    void Start()
    {
        obj = GameObject.Find("Main Camera");

        // 큐브 오브젝트의 이름을 바꾸는 기능
        obj.name = changeName;
    }   

    
    
}
