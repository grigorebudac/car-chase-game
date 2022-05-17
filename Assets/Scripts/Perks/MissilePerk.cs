using UnityEngine;

public class MissilePerk : BasePerk
{
    public override string perkIcon { get { return "Missile"; } }

    public override void usePerk(GameObject perk, GameObject targetGameObject)
    {
        Instantiate(perk, targetGameObject.transform.position + (targetGameObject.transform.forward * 10f), targetGameObject.transform.rotation);
    }
}