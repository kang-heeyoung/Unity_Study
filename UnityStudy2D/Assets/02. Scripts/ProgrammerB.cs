using UnityEngine;
using DevA;

public class ProgrammerB : MonoBehaviour
{
    // ProgrammerA 클래스 타입을 받는 변수 pA를 public으로 선언
    public ProgrammerA pA;

    private void Start()
    {
        //pA.number1 = 10;

        pA.number2 = 20; // public으로 설정한 변수만 가능
        
        //pA.number3 = 30;
        
        //pA.number4 = 40;
        
        //pA.number5 = 50;
    }

}
