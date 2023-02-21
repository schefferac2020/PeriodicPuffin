using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChecksIfPlayerFell : MonoBehaviour
{
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null) {
            return;
        }

        if (player.transform.position.y < transform.position.y) {
            EventBus.Publish<PlayerKilledEvent>(new PlayerKilledEvent(player.transform));
        }
    }
}
