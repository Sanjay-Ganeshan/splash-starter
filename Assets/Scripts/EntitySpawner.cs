using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntitySpawner : MonoBehaviour {

    public float timeSinceLastSpawn = 0;

    public SpawnerEntry[] whatToSpawn;

    Dictionary<EntityType, GameObject> spawnLookup;

	// Use this for initialization
	void Start () {
        spawnLookup = new Dictionary<EntityType, GameObject>();
		foreach(SpawnerEntry entry in whatToSpawn)
        {
            spawnLookup.Add(entry.spawnType, entry.whatToSpawn);
        }
	}
	
	// Update is called once per frame
	void Update () {
        this.timeSinceLastSpawn += Time.deltaTime;
        if(timeSinceLastSpawn > GameValues.waveSpawnTime)
        {
            this.timeSinceLastSpawn = 0;
            Spawn();
        }
	}

    void Spawn()
    {
        Instantiate(spawnLookup[GameValues.NextSpawn()]);
    }
}
