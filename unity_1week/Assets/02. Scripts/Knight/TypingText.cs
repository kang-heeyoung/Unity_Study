using System.Collections;
using TMPro;
using UnityEngine;

public class TypingText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textUI;

    private string currTextt;
    [SerializeField] private float typingSpeed = 0.1f;

    void Awake()
    {
        currTextt = textUI.text;
    }

    void OnEnable()
    {
        textUI.text = string.Empty;

        StartCoroutine(TypingRoutine());
    }

    IEnumerator TypingRoutine()
    {
        int textCount = currTextt.Length;
        for(int i=0; i<textCount; i++)
        {
            textUI.text += currTextt[i];
            yield return new WaitForSeconds(typingSpeed);
        }
    }
}
