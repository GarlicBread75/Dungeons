using UnityEngine;
using UnityEngine.Events;

public class EnemyHealthArmour : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] int maxHp;
    [SerializeField] int currentHp;
    [SerializeField] GameObject deathEffect;
    [SerializeField] UnityEvent addKill;

    [Space]

    [Header("Armour")]
    [SerializeField] int maxArmour;
    [SerializeField] int currentArmour;
    bool shieldBroken;

    [Space]

    [Header("Sounds")]
    [SerializeField] UnityEvent[] sounds;

    void Start()
    {
        currentHp = maxHp;
        currentArmour = maxArmour;
    }

    void FixedUpdate()
    {
        if (currentArmour == 0)
        {
            shieldBroken = true;
        }
        else
        if (currentArmour > 0)
        {
            shieldBroken = false;
        }

        if (currentHp > maxHp)
        {
            currentHp = maxHp;
        }

        if (currentArmour > maxArmour)
        {
            currentArmour = maxArmour;
        }

        if (currentHp <= 0)
        {
            Die();
        }
    }

    #region HitPoints

    public void TakeDmg(int dmg)
    {
        if (shieldBroken)
        {
            currentHp -= dmg;
        }
        else
        {
            currentArmour -= dmg;
        }
    }

    public void HealHp(int heal)
    {
        currentHp += heal;
    }

    public void HealArmour(int heal)
    {
        currentArmour += heal;
    }

    public void RaiseMaxHp(int increase)
    {
        maxHp += increase;
        currentHp += increase;
    }

    public void RaiseMaxArmour(int increase)
    {
        maxArmour += increase;
        currentArmour += increase;
    }

    public void LowerMaxHp(int decrease)
    {
        maxHp -= decrease;
        currentHp -= decrease;
    }

    public void LowerMaxArmour(int decrease)
    {
        maxArmour -= decrease;
        currentArmour -= decrease;
    }

    #endregion

    public void Die()
    {
        GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 0.6f);
        addKill.Invoke();
        Destroy(gameObject);
    }
}