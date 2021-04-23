using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpanner : MonoBehaviour
{
    [SerializeField] GameObject[] spawnees;
    [SerializeField] Transform spawnPos;

    int randomInt;

    // Start is called before the first frame update
    void Start()
    {
        if(Input.GetMouseButtonDown(0)){
            SpawnRandom();
        }
    }

    void SpawnRandom(){
        randomInt = Random.Range(0, spawnees.Length);
        Instantiate(spawnees[randomInt], spawnPos.position, spawnPos.rotation);
    }
}
