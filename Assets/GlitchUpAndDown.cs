using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlitchUpAndDown : MonoBehaviour
{
    int going_up = 1;

    int count = 0;

    int num_segments = 3;

    public float movement_distance = 0.1f;
    public float wait_time = 0.25f;

    // Update is called once per frame
    void Start()
    {
        StartCoroutine(MovementCoroutine());
    }

    IEnumerator MovementCoroutine() {
        while (true) {

            if (count == num_segments || count == -1*num_segments) {
                count = 0;
                going_up *= -1;
            }

            yield return new WaitForSeconds(wait_time);
            transform.position += new Vector3(0, going_up*movement_distance, 0);
            count += going_up;
        }
    }
}
