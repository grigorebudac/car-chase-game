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
    private GameObject variableForPrefab;

    public void Awake()
    {
        carHealth = GetComponent<HealthController>();
        if(carHealth)
            carHealth.HealthChanged += OnHealthChanged;
        variableForPrefab = (GameObject)Resources.Load("prefabs/Explosion", typeof(GameObject));
    }

    public void Start()
    {
        StartCoroutine(IncreaseScoreEveryOtherSecond());
    }

    private void OnHealthChanged()
    {
        float health = carHealth.GetHealthPercentage();
        
        healthBar.fillAmount = health;
    }

    public void addToScore(int amount)
    {
        this.score += amount;
        OnScoreChange();
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
