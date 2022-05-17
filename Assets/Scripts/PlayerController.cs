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
    private InputManager inputManager;
    public event Action OnPerkUse = delegate { };
    public event Action OnPerkSet = delegate { };
    public event Action OnScoreChange = delegate { };
    private GameObject explosion;

    public void Awake()
    {
        carHealth = GetComponent<HealthController>();
        carHealth.HealthChanged += OnHealthChanged;
        inputManager = GetComponentInParent<InputManager>();
        if (inputManager)
            inputManager.onUsePerk += usePerk;

        explosion = (GameObject)Resources.Load("Explosion", typeof(GameObject));
    }

    public void Start()
    {
        StartCoroutine(IncreaseScoreEveryOtherSecond());
    }

    private void OnHealthChanged()
    {
        healthBar.fillAmount = carHealth.GetHealthPercentage();

        if (carHealth.GetHealth() <= 0)
        {
            PauseMenu pauseMenu = FindObjectOfType<PauseMenu>();
            pauseMenu.ShowDeadMenu();

            GameObject explosionGameObject = Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(explosionGameObject, 2f);
            
            Destroy(gameObject);
        }
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
