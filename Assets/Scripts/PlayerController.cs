using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Image healthBar;

    [HideInInspector]
    public HealthController carHealth = new HealthController();

    public GameObject perk;

    public event Action OnPerkUse = delegate { };

    public void TakeDamage(float value)
    {
        carHealth.TakeDamage(value);
        healthBar.fillAmount = carHealth.GetHealthPercentage();
    }

    public void Heal(float value)
    {
        carHealth.Heal(value);
        healthBar.fillAmount = carHealth.GetHealthPercentage();
    }

    public void usePerk()
    {
        if (perk != null)
        {
            perk.GetComponent<BasePerk>().usePerk(perk, gameObject);
            OnPerkUse();
            perk = null;
        }
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            usePerk();
        }
    }
}
