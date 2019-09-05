using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [SerializeField] float levelTime = 10;
    bool triggeredLevelFinish = false;

    // Update is called once per frame
    void Update()
    {
        if (triggeredLevelFinish)
        {
            return;
        }
        GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelTime;
        bool timerFinished = (Time.timeSinceLevelLoad >= levelTime);
        if (timerFinished)
        {
            FindObjectOfType<LevelController>().LevelTimerFinished();
            triggeredLevelFinish = true;
        }
    }
}
