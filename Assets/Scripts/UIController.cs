using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    Subscription<TimerUpdatedEvent> timer_update_subscription;

    public TextMeshProUGUI flap_counter;

    // Start is called before the first frame update
    void Start()
    {
        timer_update_subscription = EventBus.Subscribe<TimerUpdatedEvent>(_OnTimerUpdateRecieved);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void _OnTimerUpdateRecieved(TimerUpdatedEvent e) {
        flap_counter.text = "FLAP COUNTDOWN: " + e.new_timer_val.ToString();
    }

    private void OnDestroy()
    {
        EventBus.Unsubscribe(timer_update_subscription);
    }
}
