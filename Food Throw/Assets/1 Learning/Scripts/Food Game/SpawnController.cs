using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnController : MonoBehaviour
{
    [SerializeField] private GameObject[] prefabs;
    [SerializeField] private GameController gameController;

    public void SpawnObject()
    {
        int randomIndex = Random.Range(0, prefabs.Length);
        GameObject instantiatedPrefab = Instantiate(prefabs[randomIndex], transform.position, Random.rotation);
        
        ThrowableController food = instantiatedPrefab.GetComponent<ThrowableController>();
        food.Initialize(gameController);
    }
}