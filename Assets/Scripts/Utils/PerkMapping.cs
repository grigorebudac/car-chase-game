using System;
using System.Collections.Generic;
using UnityEngine;

public static class PerkMapping
{
    public static Dictionary<Type, Type> PerkMap = new Dictionary<Type, Type>()
    {
        { typeof(MineCollectable), typeof(MinePerk) },
        { typeof(NitroCollectable), typeof(NitroPerk) },
        { typeof(HomingMissileCollectable), typeof(HomingMissilePerk) },
        { typeof(MissleCollectable), typeof(MissilePerk) },
        { typeof(ShieldCollectable), typeof(ShieldPerk)}
    };

    public static Dictionary<Type, GameObject> PerkMapToGameObject = new Dictionary<Type, GameObject>()
    {
        { typeof(MineCollectable), Resources.Load<GameObject>("GroundMine") },
        { typeof(NitroCollectable), Resources.Load<GameObject>("Nitro") },
        { typeof(HomingMissileCollectable), Resources.Load<GameObject>("HomingMissile") },
        { typeof(MissleCollectable), Resources.Load<GameObject>("Missile") },
        { typeof(ShieldCollectable), Resources.Load<GameObject>("Shield") }
    };
}