using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{

    [Header("Trash Objects")]
    public GameObject[] trashObjects;

    [Header("Time Interval between Object Spawn")]
    public float minValue = 3f;
    public float maxValue = 7f;

    [Header("Number of Objects")]
    public int numberOfObjects = 2;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnTrashWave());
    }

    IEnumerator spawnTrashWave()
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            yield return new WaitForSeconds(Random.Range(minValue, maxValue));

            float xValue = Random.Range(-3, 3);
            float zValue = Random.Range(-3, 3);            
            var gameObjectSelected = trashObjects[Random.Range(0, trashObjects.Length)];           
            Instantiate(gameObjectSelected,transform.position + new Vector3(xValue, 0, zValue), Quaternion.identity);
        }
    }
}
