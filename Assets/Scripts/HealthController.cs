using System;

public class HealthController
{
    private float health;
    private const float MAX_HEALTH = 100f;

    public HealthController()
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
    }

    public void Heal(float value)
    {
        this.health = Math.Min(this.health + value, MAX_HEALTH);
    }
}
