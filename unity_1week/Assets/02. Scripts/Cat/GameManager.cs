using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI playTimeUI;
    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        playTimeUI.text = $"�÷��� �ð� : {timer:F0}��";
        // playTimeUI.text = string.Format("�÷��� �ð� : {0:F1}��", timer);
    }
}
