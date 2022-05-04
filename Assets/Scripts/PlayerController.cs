using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Image healthBar;
    public HealthController carHealth;
    public GameObject perk;
    public event Action OnPerkUse = delegate { };
    public event Action OnPerkSet = delegate { };

    public void Awake()
    {
        carHealth = GetComponent<HealthController>();
        carHealth.HealthChanged += OnHealthChanged;
    }

    private void OnHealthChanged()
    {
        healthBar.fillAmount = carHealth.GetHealthPercentage();
    }

    public float GetHealth()
    {
        return carHealth.GetHealth();
    }

    internal void setPerk(GameObject perk)
    {
        this.perk = perk;
        OnPerkSet();
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
        if (gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                usePerk();
            }
        }
        else if (gameObject.tag == "PolicePlayer")
        {
            if (Input.GetKeyDown(KeyCode.M))
            {
                usePerk();
            }
        }
    }


}
