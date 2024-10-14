using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class TrapsAndAtacks : MonoBehaviour
{
    [SerializeField]
    private int damage = 20;
  
    [SerializeField]
    private bool attack;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.GetComponent<Health>())
        {
            // Получаем скрипт HealthSystem и наносим урон
            Health healthSystem = collision.gameObject.GetComponent<Health>();
            if (healthSystem != null)
            {
                healthSystem.TakeDamage(damage);
            }
            if (attack == true)
            {
                Destroy(gameObject); // Уничтожаем снаряд после попадания

            }
           
            

        }
    }
  
}
