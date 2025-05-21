using UnityEngine;

public class StudyArray : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public int[] arrayNumber = new int[5] {1, 2, 3, 4, 5};
    void Start()
    {
        Debug.Log($"Array의 첫번째 값 :{arrayNumber[0]}");
        Debug.Log($"Array의 세번째 값 :{arrayNumber[2]}");
    }

    
}
