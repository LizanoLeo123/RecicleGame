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

    [HideInInspector]
    public bool meetLeo;
    [HideInInspector]
    public bool meetDanilo;
    [HideInInspector]
    public bool meetKevin;
    [HideInInspector]
    public bool meetRandald;

    private bool metAll;

    private void Start()
    {
        meetDanilo = false;
        meetLeo = false;
        meetKevin = false;
        meetRandald = false;
        metAll = false;
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
                player.moveSpeed = 7.5f;
                break;
        }
    }

    public void CheckCondition()
    {
        if (inventory.money >= 300) //Collect this amount of ecolones to win
            StartCoroutine(LoadNextScene());
    }

    public void MeetDeveloper(string name)
    {
        Debug.Log(name);
        switch (name)
        {
            case "Leo":
                if(!meetLeo)
                    uiManager.ShowAchievement("Leo");
                meetLeo = true;
                break;
            case "Danilo":
                if (!meetDanilo)
                    uiManager.ShowAchievement("Danilo");
                meetDanilo = true;
                break;
            case "Kevin":
                if (!meetKevin)
                    uiManager.ShowAchievement("Kevin");
                meetKevin = true;
                break;
            case "Randald":
                if(!meetRandald)
                    uiManager.ShowAchievement("Randald");
                meetRandald = true;
                break;
        }
        StartCoroutine(VerifyDevelopers());
    }

    IEnumerator VerifyDevelopers()
    {
        yield return new WaitForSeconds(4f);
        if(!metAll)
            if (meetDanilo && meetLeo && meetKevin && meetRandald) //Player has met all developers
            {
                metAll = true;
                uiManager.ShowAchievement("todos los desarrolladores.");
            }    
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
