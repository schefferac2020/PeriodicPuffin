using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteWobbles : MonoBehaviour
{
    public float freq = 1.0f;
    public float magnitude = 1.0f;

    // Update is called once per frame
    void Update()
    {
        float deg = Mathf.Sin(Time.time * freq) * magnitude;
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, deg);
    }
}
