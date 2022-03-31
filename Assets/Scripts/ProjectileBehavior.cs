using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    public int   damage = 10;
    public float speed = 4.5f;

    private float projectileDirection;
    private float flightTimer = 0.0f;
    private int flightInterval = 2;

    private void Start()
    {
        projectileDirection = transform.parent.localScale.x;
    }

    private void Update()
    {
        flightTimer += Time.deltaTime;
        if (flightTimer > flightInterval)
        {
            Destroy(gameObject);
        }

        transform.position += transform.right * projectileDirection * Time.deltaTime * speed;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
