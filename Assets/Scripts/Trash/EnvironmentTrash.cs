using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentTrash : MonoBehaviour
{
    [Header("Type of trash 1-4")]
    public int tipo;

    public InventoryObject inventory;

    public ItemObject itemDisplay;

    public AudioClip pickup;
    private Transform soundPoint;

    private UI_Manager uiManager;

    // Start is called before the first frame update
    void Start()
    {
        soundPoint = GameObject.Find("SoundPoint").transform;
        uiManager = GameObject.Find("Canvas").GetComponent<UI_Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            uiManager.ActivateTrashMessage(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (inventory.hasSapce(1))
                {
                    inventory.addItem(itemDisplay, 1);
                    //Debug.Log("Recogiste un " + transform.tag);
                    uiManager.PickupTrash(this.tipo);
                    AudioSource.PlayClipAtPoint(pickup, soundPoint.position);
                    Destroy(gameObject);
                }
                else
                {
                    uiManager.PickupTrash(5); //Show message of full inventory
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("Player"))
            uiManager.ActivateTrashMessage(false);
    }
}
