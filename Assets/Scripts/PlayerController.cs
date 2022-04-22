using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Image healthBar;

    [HideInInspector]
    public HealthController carHealth = new HealthController();


    public void TakeDamage(float value) {
        carHealth.TakeDamage(value);
        healthBar.fillAmount = carHealth.GetHealthPercentage();
    }

    public void Heal(float value)
    {
        carHealth.Heal(value);
        healthBar.fillAmount = carHealth.GetHealthPercentage();
    }
}
