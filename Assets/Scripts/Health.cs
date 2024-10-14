
using UnityEngine;
using UnityEngine.Events;
public class Health : MonoBehaviour
{
    [SerializeField]
    private int _maxHealth = 100;

   public int maxHealth
    {
        get
        {
            return _maxHealth;

        }
        set
        {
            if (value >= 0)


                _maxHealth = value;
            else
            {
                _maxHealth = 0;
            }

        }

    }
    [SerializeField]
    private int _currentHealth;
    public int currentHealth
    {
        get
        {
            return _currentHealth;

        }
        set
        {
            if (value >= 0)


                _currentHealth = value;
            else
            {
                _currentHealth = 0;
            }

        }

    }
    [SerializeField]
    private float invincibilityDuration = 1f; // Продолжительность неуязвимости в секундах
    private float lastDamageTime; // Время последнего полученного урона

    [SerializeField]
    private Death death;

    public UnityEvent<float> onHealthChanged = new UnityEvent<float>();


    private void Start()
    {
        currentHealth = maxHealth;

        lastDamageTime = -invincibilityDuration;
    }

    public void TakeDamage(int damage)
    {
        if (Time.time - lastDamageTime >= invincibilityDuration)
        {
            currentHealth -= damage;
            lastDamageTime = Time.time;

            onHealthChanged.Invoke(invincibilityDuration);



        }


        if (currentHealth <= 0)
        {
            death.Die();

        }


    }
    public void PureDeath()
    {
        death.Die();

    }


}
