using UnityEngine;

public class NitroPerk : BasePerk
{
    public override string perkIcon { get { return "Nitro"; } }

    public override void usePerk(GameObject perk, GameObject gameObject)
    {
        Debug.Log("NITROOO");
    }
}