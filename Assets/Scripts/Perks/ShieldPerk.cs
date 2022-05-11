using UnityEngine;

public class ShieldPerk : BasePerk
{
    public override string perkIcon { get { return "Shield"; } }
    [SerializeField]
    private GameObject target;
    public float timeLeft = 5.5f;

    public override void usePerk(GameObject perk, GameObject gameObject)
    {
        PlayerController playerController = gameObject.GetComponent<PlayerController>();
        target = gameObject;
        playerController.isUsingShield = true;
        Instantiate(perk, gameObject.transform.position, gameObject.transform.rotation);
    }

    void Update()
    {
        if (target != null)
        {
            transform.position = target.transform.position;

            timeLeft -= Time.deltaTime;
            if (timeLeft < 0 || target.GetComponent<PlayerController>().isUsingShield == false)
            {
                Destroy(gameObject);
                target.GetComponent<PlayerController>().isUsingShield = false;
            }
        }
    }
}