using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Next Scene")]
    public string nextScene;

    [Header("Inventory")]
    public InventoryObject inventory;

    [Header("Number of the day")]
    public int day;

    [Header("Player Gameobject")]
    public PlayerController player;

    private UI_Manager uiManager;

    private void Start()
    {
        inventory.money = 0;
        uiManager = GameObject.Find("Canvas").GetComponent<UI_Manager>();
        inventory.money = 0;

        switch (day)
        {
            //Upgrade inventory on day 2
            case 2:
                inventory.capcaity = 40;
                break;
            case 3:
                player.moveSpeed = 7f;
                break;
        }
    }

    public void CheckCondition()
    {
        if (inventory.money >= 300) //2700
            StartCoroutine(LoadNextScene());
    }

    IEnumerator LoadNextScene()
    {
        //foreach (InventorySlot inventoryS in inventory.Container)
        //{
        //    inventory.removeItem(inventoryS.item);
        //}
        int size = inventory.Container.Count;
        while(size > 0)
        {
            inventory.removeItem(inventory.Container[0].item);
            size--;
        }
        inventory.totalAmount = 0;
        uiManager.ShowFinalMessage();
        yield return new WaitForSeconds(3.5f);
        uiManager.FadeOut();
        yield return new WaitForSeconds(0.9f);
        SceneManager.LoadScene(nextScene);   
    }
}
