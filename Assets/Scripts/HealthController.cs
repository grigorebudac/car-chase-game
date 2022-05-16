using System;
using UnityEngine;
using System.Collections;

public class HealthController : MonoBehaviour
{
    private float health;

    [SerializeField]
    private float MAX_HEALTH = 100f;
    public event Action HealthChanged = delegate { };
    private PrometeoCarController prometeoCarController;

    public void Awake()
    {
        this.health = MAX_HEALTH;
        prometeoCarController = GetComponent<PrometeoCarController>();
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
        if (prometeoCarController == null)
            StartCoroutine(EFlash());
    }

    public void Heal(float value)
    {
        this.health = Math.Min(this.health + value, MAX_HEALTH);
        HealthChanged();
    }

    IEnumerator EFlash()
    {
        MeshRenderer meshRenderer = gameObject.GetComponentInChildren<MeshRenderer>();
        Color orgColor = meshRenderer.material.color;

        meshRenderer.material.color = Color.red;
        yield return new WaitForSeconds(.15f);
        meshRenderer.material.color = orgColor;
    }
}
