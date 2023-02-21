using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class FlipWhenReachesGoal : MonoBehaviour
{
    public float waiting_for_flip_time = 1.0f;
    public float flip_duration = 2.0f;

    //// Update is called once per frame
    //void Update()
    //{
    //    if (Input.GetKey(KeyCode.Space)) {
    //        GetComponent<PlayerMovement>().DisablePlayerMovement();
    //        GetComponent<JumpOnTimer>().DisableTimerJump();
    //        StartCoroutine(DoFlip());

            
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Goal") {
            GetComponent<PlayerMovement>().DisablePlayerMovement();
            GetComponent<JumpOnTimer>().DisableTimerJump();
            StartCoroutine(DoFlip());
        }
    }

    IEnumerator DoFlip() {
        yield return new WaitForSeconds(waiting_for_flip_time);
        GetComponent<JumpOnTimer>().Jump();


        float currentTime = 0f;
        float flip_duration = 1f;


        Quaternion sourceOrientation = transform.rotation;
        float sourceAngle = 0;
        float targetAngle = (Random.value - 0.5f) * 3600f + sourceAngle; // Source +/- 1800


        while (currentTime < flip_duration)
        {
            currentTime += Time.deltaTime;
            float progress = currentTime / flip_duration;

            float currentAngle = Mathf.Lerp(sourceAngle, targetAngle, progress);
            transform.rotation = Quaternion.Euler(0, 0, currentAngle);

            yield return null;
        }

        transform.rotation = Quaternion.Euler(0, 0, 0);

        EventBus.Publish<FinishedLevelEvent>(new FinishedLevelEvent());
    }
}


