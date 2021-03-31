using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashSpawnBehavior : MonoBehaviour
{
    public Transform spawnPoint;

    public GameObject[] trashPrefabs;

    public GameObject cam1;
    public GameObject cam2;

    private int trashIndex;

    // Start is called before the first frame update
    void Start()
    {
        //trashIndex = 0;
        //Instantiate(trashPrefabs[trashIndex], spawnPoint.position, Quaternion.identity);
        SpawnNextTrash();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            cam2.SetActive(true);
            cam1.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            cam1.SetActive(true);
            cam2.SetActive(false);
        }
    }

    public void SpawnNextTrash()
    {
        //trashIndex++;
        //if (trashIndex == trashPrefabs.Length)
        //    trashIndex = 0;
        trashIndex = Random.Range(0, trashPrefabs.Length);
        //if (trashIndex == 0)
        //{
        //    Instantiate(trashPrefabs[trashIndex], spawnPoint.position, Quaternion.Euler(-90f,0f,20f));
        //}
        //else if (trashIndex == 1) //Bottles
        //{
        //    Instantiate(trashPrefabs[trashIndex], spawnPoint.position, Quaternion.Euler(-60f, -70f, 90f));
        //}
        //else
        //    Instantiate(trashPrefabs[trashIndex], spawnPoint.position, Quaternion.identity);
        if(trashIndex >= 0 && trashIndex <= 3) //Rotten fruit / Normal trash / No reciclable trash
        {
            Instantiate(trashPrefabs[trashIndex], spawnPoint.position, Quaternion.Euler(-30f, -80f, 0f));
        }
        else if(trashIndex >= 4 && trashIndex <= 7) // Paper ball
        {
            Instantiate(trashPrefabs[trashIndex], spawnPoint.position, Quaternion.identity);
        }
        else if (trashIndex >= 8 && trashIndex <= 11) //Bottles
        {
            Instantiate(trashPrefabs[trashIndex], spawnPoint.position, Quaternion.Euler(-60f, -70f, 90f)); ;
        }
        else if (trashIndex >= 12 && trashIndex <= 15) //Cans
        {
            Instantiate(trashPrefabs[trashIndex], spawnPoint.position, Quaternion.Euler(-90f, 0f, 20f));
        }

    }
}
