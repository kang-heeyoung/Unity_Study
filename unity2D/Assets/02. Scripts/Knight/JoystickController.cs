using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickController : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    [SerializeField] private KnightController_Joystick knightController;

    [SerializeField] private GameObject backgroundUI;
    [SerializeField] private GameObject handlerUI;

    private Vector2 startPos, currPos;


    void Start()
    {
        backgroundUI.SetActive(true);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //backgroundUI.SetActive(true);
        //backgroundUI.transform.position = eventData.position; 
        startPos = eventData.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        // 조이스틱 구현
        currPos =  eventData.position;
        Vector2 dragDir = currPos - startPos;

        float maxDist = Mathf.Min(dragDir.magnitude, 75f);

        handlerUI.transform.position = startPos + dragDir.normalized * maxDist;

        // 조이스틱 값 전달
        knightController.InputJoyStick(dragDir.x, dragDir.y); 
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        knightController.InputJoyStick(0, 0);
        handlerUI.transform.localPosition = Vector2.zero; // 핸들러가 원점으로 이동
        //backgroundUI.SetActive(false);
    }
}
