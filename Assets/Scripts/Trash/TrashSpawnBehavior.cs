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

    [Header("Audio Effects")]
    public AudioClip goodSelection;
    public AudioClip badSelection;

    [Header("Inventory")]
    public InventoryObject inventory;
    private int inventoryIndex;
    private List<InventorySlot> Container;
    private int containerAmount;

    private bool playing;

    private int trashIndex;

    private UI_Manager uiManager;

    // Start is called before the first frame update
    void Start()
    {
        inventoryIndex = 0;
        containerAmount = 0;
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

    public void ReduceAmount()
    {
        containerAmount--;
        ItemObject item = Container[inventoryIndex].item;
        Container[inventoryIndex].updateSlot(item, containerAmount);
        inventory.totalAmount -= 1;
    }

    public void SpawnNextTrash()
    {
        int limit = inventory.Container.Count;
        inventoryIndex = Random.Range(0, limit);
        //Get item information
        containerAmount = Container[inventoryIndex].amount;
        ItemObject item = Container[inventoryIndex].item;
                
        if(containerAmount == 0)
        {
            inventory.removeItem(item);

            if(inventory.totalAmount != 0)
                SpawnNextTrash();
            return;
        }

        if(containerAmount != 0)
        {
            int trashIndex = 0;

            Debug.Log(item.name);
            switch (item.name)
            {
                //Rotten fruit
                case "RottenApple":
                    trashIndex = 0;
                    break;
                case "RottenBanana":
                    trashIndex = 1;
                    break;
                case "RottenOrange":
                    trashIndex = 2;
                    break;
                case "RottenPear":
                    trashIndex = 3;
                    break;
                //PaperBall
                case "PaperBall":
                    trashIndex = 4;
                    break;
                //Bottles
                case "ChampagneBottle":
                    trashIndex = 8;
                    break;
                case "HennessyBottle":
                    trashIndex = 9;
                    break;
                case "WhiskeyBottle":
                    trashIndex = 10;
                    break;
                case "WineBottle":
                    trashIndex = 11;
                    break;
                //Cans
                case "Can1":
                    trashIndex = 12;
                    break;
                case "Can2":
                    trashIndex = 13;
                    break;
                case "Can3":
                    trashIndex = 14;
                    break;
                case "Can4":
                    trashIndex = 15;
                    break;
            }

            //Instantiate the trash prefab.
            if (trashIndex >= 0 && trashIndex <= 3) //Rotten fruit / Normal trash / No reciclable trash
            {
                Instantiate(trashPrefabs[trashIndex], spawnPoint.position, Quaternion.Euler(-30f, -80f, 0f));
            }
            else if (trashIndex >= 4 && trashIndex <= 7) // Paper ball
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

    public void PlaySoundEffect(bool select)
    {
        if (select) //Good selection
            AudioSource.PlayClipAtPoint(goodSelection, transform.position);
        else
            AudioSource.PlayClipAtPoint(badSelection, transform.position);
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
            Container = inventory.Container;
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
