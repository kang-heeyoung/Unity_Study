using UnityEngine;

public class StudyLog1 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Start 함수 실행");
        Debug.LogWarning("경고 메세지 출력");
        Debug.LogError("에러 메세지 출력");
    }

    // Update is called once per frame
    void Update()
    {
    }
}
