using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashSpawnBehavior : MonoBehaviour
{
    [Header("Trash Spawn Point")]
    public Transform spawnPoint;

    public GameObject[] trashPrefabs;

    [Header("Main Cam and Minigame cam")]
    public GameObject cam1;
    public GameObject cam2;

    [Header("Player Object")]
    public GameObject player;

    private bool playing;

    private int trashIndex;

    private UI_Manager uiManager;

    // Start is called before the first frame update
    void Start()
    {
        playing = false;
        uiManager = GameObject.Find("Canvas").GetComponent<UI_Manager>();
    }

    private void Update()
    {
        if (playing)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                playing = false;
                uiManager.ActivateMinigamePanel(false);
                cam1.SetActive(true);
                cam2.SetActive(false);
                player.SetActive(true);
            }
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

    private void OnTriggerStay(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            uiManager.ActivateMinigameMessage(true);
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            playing = true;
            uiManager.ActivateMinigamePanel(true);
            cam2.SetActive(true);
            cam1.SetActive(false);
            player.SetActive(false);
            SpawnNextTrash();
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            uiManager.ActivateMinigameMessage(false);
        }
    }
}
