using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medicine : MonoBehaviour
{
    [SerializeField]
    private int heal;
    [SerializeField]
    Health Heal;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<HeroController>() != null)
        {
            Heal.maxHealth = Heal.maxHealth + heal;
            Heal.currentHealth = Heal.currentHealth + heal;
            Destroy(gameObject);
        }
    }
}
