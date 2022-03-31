using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float force = 10.0f;
    public float maxSpeed = 20.0f;
    public Transform attackCheck;
    public Transform player;
    public ProjectileBehavior projectilePrefab;
    public Transform launchOffset;

    private Rigidbody2D rb;
    private float direction = 1.0f;
    private Animator animator;
    private bool isAttacking = false;
    private float attackTimer = 0.0f;
    private int attackInterval = 2;

    // Start is called before the first frame update
    public void takeDamage()
    {
        GameObject.Destroy(gameObject);
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        DetectPlayer();
    }
    private void FixedUpdate()
    {
        if (!isAttacking)
        {
            rb.AddForce(Vector2.right * force * direction);
            if (Mathf.Abs(rb.velocity.x) > maxSpeed)
            {
                rb.velocity = new Vector2(maxSpeed * Mathf.Sign(rb.velocity.x), rb.velocity.y);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Checkpoint"))
        {
            Debug.Log("Collision object: " + gameObject.name);
            direction = -1.0f * direction;
            Debug.Log("Changing Direction" + direction.ToString());
            rb.velocity = new Vector2(force*direction*Time.fixedDeltaTime, rb.velocity.y);
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }
    }

    // Deciding to use position of attackCheck instead of a collider due to
    // issues with other colliders attached ot this object.
    private void DetectPlayer()
    {
        if ((direction > 0 &&
                (player.position.x < attackCheck.position.x) &&
                (player.position.x > transform.position.x)) ||
            (direction < 0 &&
                (player.position.x > attackCheck.position.x) &&
                (player.position.x < transform.position.x)))
        {
            if (Mathf.Abs(player.position.y - attackCheck.position.y) < 0.5)
            {
                attackTimer += Time.deltaTime;
                if (attackTimer > attackInterval || !isAttacking)
                {
                    animator.SetBool("IsAttacking", true);
                    isAttacking = true;
                    LaunchProjectile();
                    attackTimer = 0;
                }
            }
        }
        else if (isAttacking)
        {
            animator.SetBool("IsAttacking", false);
            isAttacking = false;
        }
    }

    private void LaunchProjectile()
    {
        Instantiate(projectilePrefab, launchOffset.position, projectilePrefab.transform.rotation, transform);
    }
}
