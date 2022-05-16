using UnityEngine;

public class MissilePerk : BasePerk
{
    public override string perkIcon { get { return "Missile"; } }

    public override void usePerk(GameObject perk, GameObject gameObject)
    {
        Instantiate(perk, gameObject.transform.position + (gameObject.transform.forward * 5f), gameObject.transform.rotation);
    }
}