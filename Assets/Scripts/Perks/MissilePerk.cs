using UnityEngine;

public class MissilePerk : BasePerk
{
    public override string perkIcon { get { return "Missile"; } }

    public override void usePerk(GameObject perk, GameObject gameObject)
    {
        Instantiate(perk, gameObject.transform.position - new Vector3(10, 0, 10), gameObject.transform.rotation);
    }
}