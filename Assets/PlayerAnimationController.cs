using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{

    public ParticleSystem dust_ps;
    public GameObject death_ps_prefab;


    Subscription<PlayerDidJump> did_jump_subscription;
    Subscription<PlayerKilledEvent> did_die_subscription;
    // Start is called before the first frame update
    void Start()
    {
        did_jump_subscription = EventBus.Subscribe<PlayerDidJump>(_OnJumpEventRecieved);
        did_die_subscription = EventBus.Subscribe<PlayerKilledEvent>(_OnPlayerDeathRecieved);
    }


    void _OnJumpEventRecieved(PlayerDidJump e)
    {
        dust_ps.Play();
    }

    void _OnPlayerDeathRecieved(PlayerKilledEvent e)
    {
        Instantiate(death_ps_prefab, e.player_pos.position, Quaternion.identity);
    }

}

