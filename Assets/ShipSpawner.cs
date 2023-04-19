using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShipSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject shipPrefab;
    public float spawnDelay = 1f;
    public float spawnDelayRandomness = 0.5f;
    public float spawnDistance = 10f;
    public float spawnDistanceRandomness = 5f;
    public float spawnSpeed = 10f;
    public float spawnSpeedRandomness = 5f;
    static int shipCount = 0;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (shipCount < 1){
            Invoke("SpawnShip", Random.Range(spawnDelay - spawnDelayRandomness, spawnDelay + spawnDelayRandomness));

    }
    }

    public void SpawnShip(){
            shipCount++;
            GameObject newShip = Instantiate(shipPrefab, transform.position, transform.rotation);
            newShip.transform.Translate(Vector3.forward * Random.Range(spawnDistance - spawnDistanceRandomness, spawnDistance + spawnDistanceRandomness));
            newShip.GetComponent<Rigidbody2D>().velocity = transform.forward * Random.Range(spawnSpeed - spawnSpeedRandomness, spawnSpeed + spawnSpeedRandomness);

}

    public void DestroyShip(){
        shipCount--;
    }
}
