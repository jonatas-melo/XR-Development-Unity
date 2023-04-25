using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] objectPrefabs;

    public void SpawnObjects()
    {
        var randomIndex = Random.Range(0, objectPrefabs.Length);
        var randomPrefab = objectPrefabs[randomIndex];
        Instantiate(randomPrefab, transform.position, Random.rotation);
    }
}