using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpOnHeads : MonoBehaviour
{
    public float head_bouncing_speed = 20.0f;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Head") {
            rb.velocity = head_bouncing_speed * Vector3.up;
        }
    }
}
