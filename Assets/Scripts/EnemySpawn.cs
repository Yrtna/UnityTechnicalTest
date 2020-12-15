using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySpawn : MonoBehaviour
{
    public float spawnRate = 1f;
    public float minimumSpawnDistance = 10f;

    [SerializeField]
    private List<GameObject> units;

    private SpawnController spawnController;
    private float timeSinceLastSpawn;
    private Transform player;

    void Start()
    {
        // So we will at least spawn 1 enemy immediately, without doing any funny business
        timeSinceLastSpawn = spawnRate;
        spawnController = GetComponent<SpawnController>();
        player = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;
    }

    private void FixedUpdate()
    {
        if (timeSinceLastSpawn >= spawnRate)
        {
            SpawnEnemy();
            spawnRate -= 0.02f;
            if (spawnRate <= 0f)
                spawnRate = 0.05f;
        }
    }

    private void SpawnEnemy()
    {
        var validPoint = spawnController.GetValidSpawnPoint();
        while ((validPoint - player.position).magnitude < minimumSpawnDistance)
        {
            validPoint = spawnController.GetValidSpawnPoint();
        }

        var newUnit = spawnController.SpawnUnit(units[Random.Range(0, units.Count)], validPoint);
        newUnit.AddComponent<EnemyMovement>();
        
        timeSinceLastSpawn = 0f;
    }
}