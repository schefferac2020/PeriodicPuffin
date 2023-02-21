using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanBeJumpedOn : MonoBehaviour
{
    Rigidbody2D rb;
    public float bounce_force_magnification = 5.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") {
            //Make the player bounce off...
            collision.GetComponent<Rigidbody2D>().velocity = new Vector2(collision.GetComponent<Rigidbody2D>().velocity.x, -bounce_force_magnification * collision.GetComponent<Rigidbody2D>().velocity.y);

            Destroy(transform.parent.gameObject);
        }
    }
}
