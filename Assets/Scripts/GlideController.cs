using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlideController : MonoBehaviour
{
    private BoxCollider2D coll;
    private Rigidbody2D rb;
    public GameObject glide_bar;

    private BarController glide_bar_controller;

    private float glide_val = 100.0f;
    private float max_glid_val = 100.0f;

    public float depletion_K = 2.0f;
    public float replenishment_K = 1.0f;

    public float max_downward_speed = 5.0f;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        glide_bar_controller = glide_bar.GetComponent<BarController>();
    }

    // Update is called once per frame
    void Update()
    {
        bool is_gliding = IsGliding();

        if (is_gliding)
        {
            glide_bar.SetActive(true);
            glide_val = Mathf.Max(0.0f, glide_val - depletion_K*Time.deltaTime);

            //limit downward velocity
            if (rb.velocity.y < max_downward_speed) {
                rb.velocity = new Vector2(rb.velocity.x, -max_downward_speed);
            }
            
        }
        else {
            if (glide_val == max_glid_val)
            {
                glide_bar.SetActive(false);
            }

            //Recharge if it is on the ground
            if (IsGrounded()) {
                glide_val = Mathf.Min(max_glid_val, glide_val + replenishment_K * Time.deltaTime);
            }
        }

        glide_bar_controller.UpdateBarValue(glide_val);

    }

    private bool IsGliding() {
        return !IsGrounded() && glide_val > 0.0f && Input.GetKey(KeyCode.UpArrow);
    }

    private bool IsGrounded()
    {
        LayerMask ground_layer = LayerMask.GetMask("Ground");
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, 0.1f, ground_layer);
    }
}
