using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Image healthBar;
    public HealthController carHealth;
    public GameObject perk;
    public int score;
    public Boolean isUsingShield = false;
    public event Action OnPerkUse = delegate { };
    public event Action OnPerkSet = delegate { };
    public event Action OnScoreChange = delegate { };

    public void Awake()
    {
        carHealth = GetComponent<HealthController>();
        carHealth.HealthChanged += OnHealthChanged;
    }

    public void Start()
    {
        StartCoroutine(IncreaseScoreEveryOtherSecond());
    }

    private void OnHealthChanged()
    {
        healthBar.fillAmount = carHealth.GetHealthPercentage();
    }

    public void addToScore(int amount)
    {
        this.score += amount;
        OnScoreChange();
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

    IEnumerator IncreaseScoreEveryOtherSecond()
    {
        while (true)
        {
            score += 1;
            OnScoreChange();
            yield return new WaitForSeconds(2f);
        }
    }

}
