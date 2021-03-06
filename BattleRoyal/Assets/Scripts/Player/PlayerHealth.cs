﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Destructable {

    [SerializeField] SpawnPoint[] spawnPoints;

    void SpawnAtNewSpawnpoint()
    {
        int spawnIndex = Random.Range(0, spawnPoints.Length);
        transform.position = spawnPoints[spawnIndex].transform.position;
        transform.rotation = spawnPoints[spawnIndex].transform.rotation;
    }

    public override void Die()
    {
        base.Die();
        SpawnAtNewSpawnpoint();
    }

    [ContextMenu("TEST DIE")]
    void TestDie()
    {
        Die();
    }
}
