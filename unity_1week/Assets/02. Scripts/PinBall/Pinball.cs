using System;
using UnityEngine;

public class Pinball : MonoBehaviour
{
    public PinballManager pinballManager; // À¯´ÏÆ¼ »ó¿¡¼­ ÇÒ´ç ÇÊ¿ä
    
    void OnCollisionEnter2D(Collision2D other)
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        int score = 0;
        if (other.gameObject.CompareTag("Score10"))
        {
            pinballManager.totalScore += 10;
            Debug.Log("10Á¡ È¹µæ");
        }
        else if (other.gameObject.CompareTag("Score30"))
        {
            pinballManager.totalScore += 30;
            Debug.Log("30Á¡ È¹µæ");
        }
        else if (other.gameObject.CompareTag("Score50"))
        {
            pinballManager.totalScore += 50;
            Debug.Log("50Á¡ È¹µæ");
        }

        if (other.gameObject.CompareTag("GameOver"))
        {
            Debug.Log($"°ÔÀÓ Á¾·á : ÇöÀç Á¡¼ö {pinballManager.totalScore}");
        }
    }
}