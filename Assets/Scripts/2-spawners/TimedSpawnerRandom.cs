﻿using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

/**
 * This component instantiates a given prefab at random time intervals and random bias from its object position.
 */
public class TimedSpawnerRandom: MonoBehaviour {
    [SerializeField] Mover[] prefabToSpawn;
    [SerializeField] Vector3 velocityOfSpawnedObject;
    [Tooltip("Minimum time between consecutive spawns, in seconds")] [SerializeField] float minTimeBetweenSpawns = 1f;
    [Tooltip("Maximum time between consecutive spawns, in seconds")] [SerializeField] float maxTimeBetweenSpawns = 3f;
    [Tooltip("Maximum distance in X between spawner and spawned objects, in meters")] [SerializeField] float maxXDistance = 0.5f;
    [Tooltip("Maximum distance in Y between spawner and spawned objects, in meters")] [SerializeField] float maxYDistance = 0.5f;


    void Start() {
         this.StartCoroutine(SpawnRoutine());    // co-routines
        // _ = SpawnRoutine();                   // async-await
    }

    IEnumerator SpawnRoutine() {    // co-routines
    // async Task SpawnRoutine() {  // async-await
        while (true) {
            float timeBetweenSpawnsInSeconds = Random.Range(minTimeBetweenSpawns, maxTimeBetweenSpawns);
            yield return new WaitForSeconds(timeBetweenSpawnsInSeconds);       // co-routines
            // await Task.Delay((int)(timeBetweenSpawnsInSeconds*1000));       // async-await
            Vector3 positionOfSpawnedObject = new Vector3(
                transform.position.x + Random.Range(-maxXDistance, +maxXDistance),
                transform.position.y + Random.Range(-maxYDistance, +maxYDistance),
                transform.position.z);
            int i = Random.Range(0, prefabToSpawn.Length) > 0.8 ? 1 : 0;
            GameObject newObject = Instantiate(prefabToSpawn[i].gameObject, positionOfSpawnedObject, Quaternion.identity);
            // if new object tag is Shield then set velocity to zero
            if (newObject.tag == "Shield"){
                newObject.GetComponent<Mover>().SetVelocity(Vector3.zero);
            }
            if (newObject.tag == "UndestroyableShip"){
                newObject.GetComponent<Mover>().SetVelocity(velocityOfSpawnedObject * 0.75f);
            }

            else {
                newObject.GetComponent<Mover>().SetVelocity(velocityOfSpawnedObject);
            }
        }
    }
}
