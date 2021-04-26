using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    [Header("UI In Game")]
    public GameObject inGamePanel;

    [Header("UI Labels")]
    public Text trashIndicator1;
    public GameObject trashMessage;
    public GameObject message;
    public GameObject minigameMessage;

    [Header("UI In Minigame")]
    public GameObject miniGamePanel;
    

    int fruits;
    int papers;
    int bottles;
    int cans;

    private void Start()
    {
        fruits = 0;
        papers = 0;
        bottles = 0;
        cans = 0;

        trashMessage.SetActive(false);
        message.SetActive(false);
        trashIndicator1.text = "";
        miniGamePanel.SetActive(false);
        minigameMessage.SetActive(false);
    }

    //Types of Trash
    //1 Rotten Fruit
    //2 Paper
    //3 Bottles
    //4 Cans

    public void PickupTrash(int type)
    {
        trashMessage.SetActive(false);
        message.SetActive(true);
        switch (type)
        {
            case 1:
                fruits++;
                trashIndicator1.text = "Rotten fruits: " + fruits.ToString();
                break;
            case 2:
                papers++;
                trashIndicator1.text = "Papers: " + papers.ToString();
                break;
            case 3:
                bottles++;
                trashIndicator1.text = "Glass bottles: " + bottles.ToString();
                break;
            case 4:
                cans++;
                trashIndicator1.text = "Cans and metals: " + cans.ToString();
                break;
            case 5:
                trashIndicator1.text = "¡Inventario lleno!";
                break;
        }
        StartCoroutine(HideMessage());
    }

    public void ActivateTrashMessage(bool state)
    {
        trashMessage.SetActive(state);
    }

    public void ActivateMinigamePanel(bool state)
    {
        inGamePanel.SetActive(!state);
        miniGamePanel.SetActive(state);
    }

    public void ActivateMinigameMessage(bool state)
    {
        minigameMessage.SetActive(state);
    }

    IEnumerator HideMessage()
    {
        yield return new WaitForSeconds(3f);
        trashIndicator1.text = "";
        message.SetActive(false);
    }
}
