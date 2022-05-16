using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoliceCar : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private float spawnDelay = 3;

    Transform playerTarget;
    private float nextSpawnTime;

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
        float x = playerTarget.position.x - Random.Range(10, 30);
        float y = 0.5f;
        float z = playerTarget.position.z - Random.Range(10, 30);

        Vector3 spawnPosition = new Vector3(x, y, z);
        Instantiate(prefab, spawnPosition, Quaternion.identity);

        nextSpawnTime = Time.time + spawnDelay;
    }

    private bool ShouldSpawn()
    {
        return Time.time >= nextSpawnTime;
    }
}
