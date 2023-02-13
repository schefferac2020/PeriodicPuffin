using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float jump_speed = 7.0f;
    public float running_speed = 7.0f;
    private Rigidbody2D rb;
    private BoxCollider2D coll;


    private enum MovementState { idle, walking, flapping, gliding }
    private MovementState anim_state;
    private Animator anim;

    Subscription<PlayerDidJump> did_jump_subscription;

    private SpriteRenderer sprite_renderer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();

        anim = GetComponent<Animator>();
        sprite_renderer = GetComponent<SpriteRenderer>();

        did_jump_subscription = EventBus.Subscribe<PlayerDidJump>(_OnJumpEventRecieved);
    }

    void Update()
    {
        float dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(running_speed * dirX, rb.velocity.y);


        UpdateAnimator(dirX);
    }

    void UpdateAnimator(float dirX)
    {
        //Default is idle
        anim_state = MovementState.idle;

        if (IsGrounded())
        {
            if (dirX > 0.0f)
            {
                anim_state = MovementState.walking;
                sprite_renderer.flipX = false;
            }
            else if (dirX < 0.0f)
            {
                anim_state = MovementState.walking;
                sprite_renderer.flipX = true;
            }
        }
        else
        {
            if (dirX > 0.0f)
            {
                anim_state = MovementState.gliding;
                sprite_renderer.flipX = false;
            }
            else if (dirX < 0.0f)
            {
                anim_state = MovementState.gliding;
                sprite_renderer.flipX = true;
            }

            ////Set speed to zero if they are not holding the button
            //if (Input.GetKeyDown(KeyCode.Space))
            //{
            //    anim.speed = 1.0f;
            //}
            //else {
            //    anim.speed = 0.0f;
            //}
        }
        

        anim.SetInteger("state", (int)anim_state);
    }

    //Performs a jump
    void _OnJumpEventRecieved(PlayerDidJump e) {
        anim_state = MovementState.flapping;
        anim.SetInteger("state", (int)anim_state);
    }

    private bool IsGrounded() {
        LayerMask ground_layer = LayerMask.GetMask("Ground");
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, 0.1f, ground_layer);
    }
}
