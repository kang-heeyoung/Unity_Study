using UnityEngine;

public class StudyUnityEvent : MonoBehaviour
{
    private void Awake()
    {
        Debug.Log("Awake");
    }
    void Start()
    {
        Debug.Log("Start");
    }

    private void OnEnable() // 켜질때 마다 실행
    {
        Debug.Log("OnEnable");   
    }

    private void OnDisable() // 꺼질때 마다 실행
    {
        Debug.Log("OnDisable");
    }

    // Update is called once per frame
    void Update()
    {
    }
}
