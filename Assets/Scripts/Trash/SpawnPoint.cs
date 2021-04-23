using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{

    [Header("Trash Objects")]
    public GameObject[] trashObjects;

    [Header("Time between Object Spawn")]
    public float seconds = 15f;

    [Header("Number of Objects")]
    public int numberOfObjects = 5;

    [Header("Spawn Area Number")]
    public int number = 5;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnTrash", 5f, seconds);
    }

    public void SpawnTrash()
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            float xValue = Random.Range(-number, number);
            float zValue = Random.Range(-number, number);
            var gameObjectSelected = trashObjects[Random.Range(0, trashObjects.Length)];
            Instantiate(gameObjectSelected, transform.position + new Vector3(xValue, 0, zValue), Quaternion.identity);
        }
        
    }
}
