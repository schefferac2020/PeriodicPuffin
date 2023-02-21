using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingMovement : MonoBehaviour
{
    Rigidbody2D rb;

    public float speed = 1.0f;
    public Transform ground_detection;
    public float seek_distance = 0.05f;

    private bool moving_right = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(ground_detection.position, Vector2.down, seek_distance);
        if (groundInfo.collider == false) {
            if (moving_right == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                moving_right = false;
            }
            else {
                transform.eulerAngles = new Vector3(0, 0, 0);
                moving_right = true;
            }
        }
    }

    //private void FixedUpdate()
    //{
    //    rb.velocity = new Vector2(3.0f, 0f);
    //}
}
