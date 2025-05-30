using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Movement.coinCount++;

            Debug.Log($"������� {Movement.coinCount}");

            Destroy(this.gameObject);
        }
    }
}
