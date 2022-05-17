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
    private GameObject explosion;

    public void Awake()
    {
        carHealth = GetComponent<HealthController>();
        carHealth.HealthChanged += OnHealthChanged;

        explosion = (GameObject)Resources.Load("Explosion", typeof(GameObject));
    }
    private void OnHealthChanged()
    {
        if (healthBar)
            healthBar.fillAmount = carHealth.GetHealthPercentage();

        if (carHealth.GetHealth() <= 0)
        {
            GameObject explosionGameObject = Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(explosionGameObject, 2f);

            Destroy(gameObject);
        }
    }


    public float GetHealth()
    {
        return carHealth.GetHealth();
    }
}
