using UnityEngine;

public class StudyComponent : MonoBehaviour
{
    public GameObject obj;

    public string changeName;

    void Start()
    {
        obj = GameObject.Find("Main Camera"); // Main Camera 오브젝트를 찾아서 할당하는 기능

        // 큐브 오브젝트의 이름을 바꾸는 기능
        obj.name = changeName;
    }   

    
    
}
