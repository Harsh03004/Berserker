
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject spawnPoint;
    [SerializeField] List<GameObject> prefabsToSpawn;
    public bool shouldspawns = true;
    private void OnTriggerEnter(Collider other)
    {
        if (shouldspawns)
        {
            if (other.gameObject.tag == "Obstacle")
            {
                Destroy(other.gameObject);

                int index = Random.Range(0, prefabsToSpawn.Count);
                GameObject spawn = prefabsToSpawn[index];
                Instantiate(spawn, spawnPoint.transform.position, Quaternion.identity);
            }
        }
    }
    public void stopspawn()
    {
        shouldspawns = false;
    }
}