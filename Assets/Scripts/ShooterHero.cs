using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterHero : MonoBehaviour
{    [SerializeField]
    private int maxShots = 5; // Максимальное количество выстрелов
    [SerializeField]
    private float shotDelay = 0.5f; // Задержка перед следующим выстрелом
private int shotsRemaining; // Текущее количество оставшихся выстрелов
    private float shotTimer;
    [SerializeField]
    public HeroController Shots;
    
    void Start()
    {shotsRemaining = maxShots;
        StartCoroutine(RechargeShot());
        UpdateShotsText();
        
    }

    // Update is called once per frame
    void Update()
    {   shotTimer += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.R) && shotsRemaining > 0 && shotTimer >= shotDelay)
        {
            // Вызываем метод Shoot из DamageSystem
            GetComponent<DamageSystem>().Shoot();
            shotTimer = 0f;
            shotsRemaining--;
            UpdateShotsText();
        }
        
    }
       private IEnumerator RechargeShot()
    {
        while (true)
        {
            yield return new WaitForSeconds(5f); // Ждем 5 секунд
            if (shotsRemaining < maxShots)
            {
                shotsRemaining++; // Увеличиваем количество доступных выстрелов
                UpdateShotsText();
            }
        }
    }
    private void UpdateShotsText()
    {
        if (Shots.shotsText != null)
        {
            Shots.shotsText.text = "Выстрелы: " + shotsRemaining.ToString();
        }
    }
}
