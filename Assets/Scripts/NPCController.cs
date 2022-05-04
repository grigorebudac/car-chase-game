using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCController : MonoBehaviour
{
    [SerializeField]
    private Image healthBar;
    [HideInInspector]
    public HealthController carHealth;

    public void Awake()
    {
        carHealth = GetComponent<HealthController>();
        carHealth.HealthChanged += OnHealthChanged;
    }
    private void OnHealthChanged()
    {
        if (healthBar)
            healthBar.fillAmount = carHealth.GetHealthPercentage();
    }


    public float GetHealth()
    {
        return carHealth.GetHealth();
    }
}
