using UnityEngine;

public class ShieldPerk : BasePerk
{
    public override string perkIcon { get { return "Shield"; } }

    public override void usePerk(GameObject perk, GameObject gameObject)
    {
        Debug.Log("SHEILD");
    }
}
