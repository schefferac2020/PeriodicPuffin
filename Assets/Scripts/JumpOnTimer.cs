using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpOnTimer : MonoBehaviour
{
    public float jumping_speed = 7.0f;
    public float time_to_wait = 2.0f;

    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        StartCoroutine(JumpOnTimerCoroutine());
    }

    IEnumerator JumpOnTimerCoroutine() {
        while (true) {
            EventBus.Publish<TimerUpdatedEvent>(new TimerUpdatedEvent(4));
            yield return new WaitForSeconds(time_to_wait / 4.0f);
            EventBus.Publish<TimerUpdatedEvent>(new TimerUpdatedEvent(3));
            yield return new WaitForSeconds(time_to_wait / 4.0f);
            EventBus.Publish<TimerUpdatedEvent>(new TimerUpdatedEvent(2));
            yield return new WaitForSeconds(time_to_wait / 4.0f);
            EventBus.Publish<TimerUpdatedEvent>(new TimerUpdatedEvent(1));
            yield return new WaitForSeconds(time_to_wait / 4.0f);
            EventBus.Publish<TimerUpdatedEvent>(new TimerUpdatedEvent(0));
            Jump();
        }
    }

    public void DisableTimerJump() {
        time_to_wait = 10000000;
    }

    public void Jump() {
        rb.velocity = jumping_speed * Vector3.up;
        EventBus.Publish<PlayerDidJump>(new PlayerDidJump());
    }
}
