using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectablesSpawner : MonoBehaviour
{
    [SerializeField] private GameObject prefab;


    Transform playerTarget;
    private float nextSpawnTime;

    private void Start()
    {
        playerTarget = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (ShouldSpawn())
        {
            Spawn();
        }
    }

    public void Spawn()
    {
        float x = Random.Range(playerTarget.position.x - 100, playerTarget.position.x + 100);
        float z = Random.Range(playerTarget.position.z - 100, playerTarget.position.z + 100);
        int spawnDelay = Random.Range(5, 15);

        Vector3 spawnPosition = new Vector3(x, 1, z);
        Instantiate(prefab, spawnPosition, Quaternion.identity);

        nextSpawnTime = Time.time + spawnDelay;
    }

    private bool ShouldSpawn()
    {
        return Time.time >= nextSpawnTime;
    }
}
