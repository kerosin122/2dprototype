using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiEnemyCombat : MonoBehaviour
{
    [SerializeField]
    private float meleeAttackCooldown;
    [SerializeField]
    private float meleeAttackTimer = 0.5f; // Кулдаун для атаки ближнего боя
  [SerializeField]
    private float _attackRadius;
    
    public float attackRadius
    {
        get
        {
            return _attackRadius;

        }
        set
        {
            if (value >= 0)

                _attackRadius = value;
          

        }
    }

    

    [SerializeField]
    private float meleeAttackDistance = 0.5f;
    [SerializeField]
    public bool isRangedAttacker; // Определяет тип атаки: дальняя или ближняя
    [SerializeField]
    private AiEnemyMove enemyMove;
    [SerializeField]
    private DamageSystem damageSystem;
    [SerializeField]
    public Transform player;
    [SerializeField]
    private float rangeAttackTimer = 1.5f; // Таймер для дистанционной атаки
    [SerializeField]
    private float rangeAttackCooldown;

    private void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player").transform;
        damageSystem = GetComponent<DamageSystem>();
    }

    private void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer <= attackRadius)
        {
            if (isRangedAttacker)
            {

                if (rangeAttackCooldown <= 0f)
                {
                    RangeAttack();
                    rangeAttackCooldown = rangeAttackTimer; // Сброс таймера
                }
                else
                {
                    rangeAttackCooldown -= Time.deltaTime; // Обратный отсчет таймера
                }
            }

            else
            {

                if (meleeAttackCooldown <= 0f && distanceToPlayer <= meleeAttackDistance)
                {
                    MeleeAttack();
                    meleeAttackCooldown = meleeAttackTimer; // Сброс кулдауна
                }
                else
                {
                    meleeAttackCooldown -= Time.deltaTime;
                }
            }

        }
    }

    private void MeleeAttack()
    {

        damageSystem.Shoot();
        damageSystem.Shoot();
    }

    private void RangeAttack()
    {

        damageSystem.Shoot();
    }



}