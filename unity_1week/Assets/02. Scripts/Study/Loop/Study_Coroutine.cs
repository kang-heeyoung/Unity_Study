using System.Collections;
using UnityEngine;

public class Study_Coroutine : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(RoutineA());

        StopCoroutine(RoutineA());
    }

    IEnumerator RoutineA() // ��⸦ �� �� �ִ� ���
    {
        yield return new WaitForSeconds(2f);
        Debug.Log("�ȳ��ϼ���.");

        yield return new WaitForSeconds(2f);
        Debug.Log("Hello Unity");

        yield return new WaitForSeconds(2f);
        Debug.Log("Coroutine");
    }

}