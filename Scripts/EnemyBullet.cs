using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 5f;
    public float changeDirectionInterval = 1f;
    public GameObject exploding;
    private Rigidbody2D rb;
    private Vector2 movementDirection;
    private float elapsedTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // Set an initial random movement direction
        movementDirection = Random.insideUnitCircle.normalized;
    }

    // Update is called once per frame
    void Update()
    {
         elapsedTime += Time.deltaTime;

        // Change direction at regular intervals
        if (elapsedTime >= changeDirectionInterval)
        {
            elapsedTime = 0f;
            // Generate a new random movement direction
            movementDirection = Random.insideUnitCircle.normalized;
        }

        // Move the bullet
        rb.velocity = movementDirection * speed;
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "fighter"){
            Destroy(other.gameObject);
            Vector3 position = new Vector3(transform.position.x, transform.position.y,0);
            Destroy(gameObject);
            Instantiate(exploding, position, transform.rotation);
        }
    }
}
