using UnityEngine;

public class Study_Casting : MonoBehaviour
{
    int number1 = 1;
    float number2 = 1.99f;

    private void Start()
    {
        number1 = (int)number2;
        Debug.Log(number1);

        float number4 = Mathf.Floor(number2);
        float number5 = Mathf.Ceil(number2);
        float number6 = Mathf.Round(number2);
    }
}
