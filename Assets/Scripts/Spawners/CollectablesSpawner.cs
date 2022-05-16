using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectablesSpawner : MonoBehaviour
{
    [SerializeField]
    private int minRange = 3;
    [SerializeField]
    private int maxRange = 5;
    [SerializeField]
    private float nextSpawnTime;
    Transform playerTarget;

    public PrefabEntry[] collectables;
    float _totalSpawnWeight;

    // Update the total weight when the user modifies Inspector properties,
    // and on initialization at runtime.
    void OnValidate()
    {
        _totalSpawnWeight = 0f;
        foreach (var spawnable in collectables)
            _totalSpawnWeight += spawnable.chanceOfSpawn;
    }

    void Awake()
    {
        OnValidate();
    }


    private void Start()
    {
        playerTarget = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (ShouldSpawn() && playerTarget)
        {
            Spawn();
        }
    }

    public void Spawn()
    {
        // Pick a random position within the spawn radius.
        float x = Random.Range(playerTarget.position.x - 45, playerTarget.position.x + 45);
        float z = Random.Range(playerTarget.position.z - 30, playerTarget.position.z + 50);
        int spawnDelay = Random.Range(minRange, maxRange);


        // Generate a random position in the list.
        float pick = Random.value * _totalSpawnWeight;
        int chosenIndex = 0;
        float cumulativeWeight = collectables[0].chanceOfSpawn;

        // Step through the list until we've accumulated more weight than this.
        // The length check is for safety in case rounding errors accumulate.
        while (pick > cumulativeWeight && chosenIndex < collectables.Length - 1)
        {
            chosenIndex++;
            cumulativeWeight += collectables[chosenIndex].chanceOfSpawn;
        }

        // Spawn the chosen item.
        Vector3 spawnPosition = new Vector3(x, 0.5f, z);
        GameObject collectable = Instantiate(collectables[chosenIndex].prefab, spawnPosition, Quaternion.identity);

        collectable.AddComponent<PickUpAnimation>();

        nextSpawnTime = Time.time + spawnDelay;
    }

    private bool ShouldSpawn()
    {
        return Time.time >= nextSpawnTime;
    }
}
