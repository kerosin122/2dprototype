using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSystem : MonoBehaviour
{
    [SerializeField]
    private GameObject projectilePrefab; // Префаб снаряда
    [SerializeField]
    private float projectileSpeed = 10f;
    
    




    public void Shoot()
    {
        // Создаем копию снаряда
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

        // Направление выстрела зависит от ориентации игрока
        Vector2 shootingDirection = new Vector2(transform.localScale.x, 0).normalized;

        // Добавляем скорость снаряду в направлении взгляда игрока
        Rigidbody2D projectileRigidbody = projectile.GetComponent<Rigidbody2D>();
        projectileRigidbody.velocity = shootingDirection * projectileSpeed;
        Destroy(projectile, 1.5f);

    }


}

