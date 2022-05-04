using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasePerk : MonoBehaviour
{
    public abstract string perkIcon { get; }
    public abstract void usePerk(GameObject perk, GameObject gameObject);

}
