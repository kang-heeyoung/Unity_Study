using UnityEngine;
using DevA;

public class ProgrammerB : MonoBehaviour
{
    // ProgrammerA Ŭ���� Ÿ���� �޴� ���� pA�� public���� ����
    public ProgrammerA pA;

    private void Start()
    {
        //pA.number1 = 10;

        pA.number2 = 20; // public���� ������ ������ ����
        
        //pA.number3 = 30;
        
        //pA.number4 = 40;
        
        //pA.number5 = 50;
    }

}
