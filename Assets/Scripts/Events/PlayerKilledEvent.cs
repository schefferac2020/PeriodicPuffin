using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKilledEvent

{
    public Transform player_pos;
    public PlayerKilledEvent(Transform _player_pos) {
        player_pos = _player_pos;
    }

    public override string ToString()
    {
        return "The player was killed!";
    }
}
