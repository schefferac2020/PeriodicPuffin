using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerUpdatedEvent
{
    public int new_timer_val = 0;
    public TimerUpdatedEvent(int _new_timer_val) { new_timer_val = _new_timer_val; }

    public override string ToString()
    {
        return "New timer value: " + new_timer_val;
    }
}
