using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour

{
    public int value = 10;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Coin Collision");
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Destroying Coin");
            Destroy(gameObject);
        }
    }
}