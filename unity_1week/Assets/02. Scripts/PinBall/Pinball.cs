using System;
using UnityEngine;

public class Pinball : MonoBehaviour
{
    public PinballManager pinballManager; // ����Ƽ �󿡼� �Ҵ� �ʿ�
    
    void OnCollisionEnter2D(Collision2D other)
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        int score = 0;
        if (other.gameObject.CompareTag("Score10"))
        {
            pinballManager.totalScore += 10;
            Debug.Log("10�� ȹ��");
        }
        else if (other.gameObject.CompareTag("Score30"))
        {
            pinballManager.totalScore += 30;
            Debug.Log("30�� ȹ��");
        }
        else if (other.gameObject.CompareTag("Score50"))
        {
            pinballManager.totalScore += 50;
            Debug.Log("50�� ȹ��");
        }

        if (other.gameObject.CompareTag("GameOver"))
        {
            Debug.Log($"���� ���� : ���� ���� {pinballManager.totalScore}");
        }
    }
}