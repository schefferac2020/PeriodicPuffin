using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManagerController : MonoBehaviour
{
    Subscription<FinishedLevelEvent> finished_level_sub;
    Subscription<PlayerKilledEvent> player_death_sub;
    // Start is called before the first frame update
    void Start()
    {
        finished_level_sub = EventBus.Subscribe<FinishedLevelEvent>(_HandleFinishedLevel);
        player_death_sub = EventBus.Subscribe<PlayerKilledEvent>(_HandlePlayerDeath);
    }

    void _HandleFinishedLevel(FinishedLevelEvent e) {
        int next_index = (SceneManager.GetActiveScene().buildIndex + 1) % 9;
        SceneManager.LoadScene(next_index);
    }

    void _HandlePlayerDeath(PlayerKilledEvent e)
    {
        StartCoroutine(PlayerDeathCoroutine());
    }

    IEnumerator PlayerDeathCoroutine() {
        GameObject player = GameObject.Find("Player");
        Destroy(player);
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
