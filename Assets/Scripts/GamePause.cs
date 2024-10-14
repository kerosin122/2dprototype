using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePause : MonoBehaviour
{
  private bool isTimeStopped = false;

    public void ToggleTimePause()
    {
        if (isTimeStopped)
        {
            Time.timeScale = 1; // Возобновление времени
            isTimeStopped = false;
        }
        else
        {
            Time.timeScale = 0; // Остановка времени
            isTimeStopped = true;
        }
    }
}
