using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
  [SerializeField]
  private int scores;
  [SerializeField]
  private HealthCheck lose;
  public void Die()
  {


    if (gameObject.GetComponent<HeroController>() != null)
    {
      Time.timeScale = 0;
      lose.gameOverScreen.SetActive(true);
      lose.OFFui.SetActive(false);


    }
    else
    {
      lose.score1.score += scores;
      gameObject.SetActive(false);
      lose.score1.textMeshPro.text = "Счёт: " + scores;
      

    }




  }

}
