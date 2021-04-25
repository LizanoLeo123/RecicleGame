using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentTrash : MonoBehaviour
{
    [Header("Type of trash 1-4")]
    public int tipo;

    public InventoryObject inventory;

    public ItemObject itemDisplay;

    private UI_Manager uiManager;

    // Start is called before the first frame update
    void Start()
    {
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
