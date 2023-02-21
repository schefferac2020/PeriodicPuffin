using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillsPlayer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            EventBus.Publish<PlayerKilledEvent>(new PlayerKilledEvent(collision.transform));
        }
    }
}
