using System;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    private float health;
    private const float MAX_HEALTH = 100f;
    public event Action HealthChanged = delegate { };

    public void Awake()
    {
        this.health = MAX_HEALTH;
    }

    public float GetHealth()
    {
        return this.health;
    }

    public float GetHealthPercentage()
    {
        return this.health / MAX_HEALTH;
    }

    public void TakeDamage(float value)
    {
        this.health = Math.Max(this.health - value, 0);
        HealthChanged();
    }

    public void Heal(float value)
    {
        this.health = Math.Min(this.health + value, MAX_HEALTH);
        HealthChanged();
    }
}
