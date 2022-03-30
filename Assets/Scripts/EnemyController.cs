using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float force = 10.0f;
    public float maxSpeed = 20.0f;
    private Rigidbody2D rb;
    private float direction = 1.0f;
    // Start is called before the first frame update
    public void takeDamage()
    {
        GameObject.Destroy(gameObject);
        Debug.Log("Attadagewfadf");
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {

        rb.AddForce(Vector2.right*force*direction);
        if(Mathf.Abs(rb.velocity.x)> maxSpeed)
        {
            rb.velocity = new Vector2(maxSpeed * Mathf.Sign(rb.velocity.x), rb.velocity.y);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Checkpoint"))
        {
            direction = -1.0f * direction;
            Debug.Log("Changing Directin" + direction.ToString());
            rb.velocity = new Vector2(force*direction*Time.fixedDeltaTime, rb.velocity.y);
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }
    }
}
