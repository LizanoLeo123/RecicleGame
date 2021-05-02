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
    public GameObject finalMessage;

    [Header("UI In Minigame")]
    public GameObject miniGamePanel;

    [Header("SoundFX")]
    public AudioClip fullFX;
    private Transform soundPoint;

    [Header("Inventory Object")]
    public Text ecolones;
    public InventoryObject inventory;

    private GameManager gameManager;

    private Animator animator;
    
    int fruits;
    int papers;
    int bottles;
    int cans;

    private void Start()
    {
        inventory.money = 0;
        ecolones.text = inventory.money.ToString();
        animator = GetComponent<Animator>();
        soundPoint = GameObject.Find("SoundPoint").transform;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        fruits = 0;
        papers = 0;
        bottles = 0;
        cans = 0;

        trashMessage.SetActive(false);
        message.SetActive(false);
        trashIndicator1.text = "";
        miniGamePanel.SetActive(false);
        minigameMessage.SetActive(false);
        finalMessage.SetActive(false);
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
                AudioSource.PlayClipAtPoint(fullFX, soundPoint.position);
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
        animator.SetBool("Minigame", state);
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

    public void FastTravel()
    {
        animator.SetTrigger("Exit");
    }

    public void GainOrLoss(bool decision)
    {
        StartCoroutine(AdjustMoney(decision));
        if (decision) //Selected well
        {
            animator.SetTrigger("Gain");
        }
        else //Selected bad
        {
            animator.SetTrigger("Loss");
        }
    }

    IEnumerator AdjustMoney(bool decision)
    {
        //Wait for message before updating money balance
        yield return new WaitForSeconds(1f);
        if (decision) //Selected well
        {
            inventory.money += 50;
        }
        else //Selected bad
        {
            inventory.money -= 10;
        }
        ecolones.text = inventory.money.ToString();
        gameManager.CheckCondition();
    }

    public void ShowFinalMessage()
    {
        ActivateMinigamePanel(false);
        trashMessage.SetActive(false);
        message.SetActive(false);
        trashIndicator1.text = "";
        miniGamePanel.SetActive(false);
        minigameMessage.SetActive(false);
        finalMessage.SetActive(true);
    }

    public void FadeOut()
    {
        animator.SetTrigger("Exit");
    }
}
