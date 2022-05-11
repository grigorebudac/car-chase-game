using System;
using UnityEngine;

[Serializable]
public struct PrefabEntry
{
    public GameObject prefab;
    [Range(0, 100)]
    public int chanceOfSpawn;
}