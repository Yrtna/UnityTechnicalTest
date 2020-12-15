using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class SpawnController : MonoBehaviour
{
    [SerializeField]
    private float spawnRadius = 50;

    public Vector3 GetValidSpawnPoint()
    {
        var randomPoint = Random.insideUnitSphere * spawnRadius;
        var position = transform.position;
        NavMesh.SamplePosition(new Vector3(randomPoint.x, position.y, randomPoint.z) + position, out var nmHit, spawnRadius, 1 << NavMesh.GetAreaFromName("Walkable"));
        return new Vector3(nmHit.position.x, gameObject.transform.position.y, nmHit.position.z);
    }

    public GameObject SpawnUnit(GameObject unit, Vector3 spawnPosition)
    {
        return Instantiate(unit, spawnPosition, gameObject.transform.rotation);
    }
}