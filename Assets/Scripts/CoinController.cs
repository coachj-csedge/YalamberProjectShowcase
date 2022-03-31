using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour

{
    public int value = 10;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Coin Trigger Enter");
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

}