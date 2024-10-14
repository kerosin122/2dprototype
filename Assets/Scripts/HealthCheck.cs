using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class HealthCheck : MonoBehaviour
{

   [SerializeField]
    private GameObject _gameOverScreen;
    public GameObject gameOverScreen
    {
        get
        {
            return _gameOverScreen;

        }
        set
        {  _gameOverScreen=value;

        }

    }
   [SerializeField]
    private GameObject _OFFui;
      public GameObject OFFui
    {
        get
        {
            return _OFFui;

        }
        set
        {  _OFFui=value;

        }

    }
    [SerializeField]
    private Health playerHealth; // Переменная для ссылки на компонент Health игрока
    [SerializeField]
    private TextMeshProUGUI healthText; // Переменная для ссылки на компонент TextMeshProUGUI
    [SerializeField]
    private Score _score1;
    
      public Score score1
    {
        get
        {
            return _score1;

        }
        set
        {  _score1=value;

        }

    }


    private void Update()
    {
        if (playerHealth != null && healthText != null)
        {
            healthText.text = "Здоровье: " + playerHealth.currentHealth.ToString();
        }
    }
}