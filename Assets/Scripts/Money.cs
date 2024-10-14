using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    [SerializeField]
    private int points;
    [SerializeField]
    private Score score;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<HeroController>() != null)
        {
            // Добавляем очки
            score.score += points;
            score.ScoreChange("Счёт: "+score.score);
          
            Destroy(gameObject);
        }
    }
}
