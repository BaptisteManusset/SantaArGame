using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField] List<Transform> freeLocations;
    [SerializeField] List<Transform> usedLocations;
    [SerializeField] List<GameObject> presents;
    [SerializeField] int presentsToSpawn = 10;
    [SerializeField] int presentsCount = 0;


    void Start()
    {
        Spawn();

    }

    private void Spawn()
    {
        if (freeLocations.Count < presentsToSpawn)
        {
            Debug.LogError("Nombre de spawnpoints trop petit");
            return;
        }

        while (presentsToSpawn > presentsCount)
        {
            int presentId = Random.Range(0, presents.Count);
            int locationId = Random.Range(0, freeLocations.Count);

            Instantiate(
                    presents[presentId],
                    freeLocations[locationId].position,
                    Quaternion.identity
                    );
            usedLocations.Add(freeLocations[locationId]);
            freeLocations.RemoveAt(locationId);
            presentsCount++;
        }
    }

    [ContextMenu("Test")]
    void Reset()
    {

        freeLocations.Clear();
        usedLocations.Clear();

        Spawn();

    }

    void OnDrawGizmos()
    {
        foreach (var item in usedLocations)
        {
            Gizmos.DrawSphere(item.position, 0.1f);

        }
    }
}
