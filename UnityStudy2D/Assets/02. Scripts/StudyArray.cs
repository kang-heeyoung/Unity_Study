using UnityEngine;

public class StudyArray : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public int[] arrayNumber = new int[5] {1, 2, 3, 4, 5};
    void Start()
    {
        Debug.Log($"Array�� ù��° �� :{arrayNumber[0]}");
        Debug.Log($"Array�� ����° �� :{arrayNumber[2]}");
    }

    
}
