using System;
using UnityEngine;

public class Coins : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" || collision.gameObject.CompareTag("Player"))
        {
            Debug.Log(collision.gameObject.name + " Pickup Coin. +10 credits");
            collision.transform.GetComponent<Move>().AddScore(10);
            Destroy(gameObject);
        }
    }
}
