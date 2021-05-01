using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [Header("Self")]
    public GameObject self;

    [Header("List of Dialogues")]
    public List<Dialogue> dialogues;

    [Header("UI Labels")]
    public Text nameLabel;
    public Text dialogueLabel;

    private int index;

    private void Start()
    {
        index = -1;
        ShowNextDialogue();
    }

    public void ShowNextDialogue()
    {
        index++;
        if(index == dialogues.Count)
        {
            index = 0;
            self.SetActive(false);
            return;
        }
        nameLabel.text = dialogues[index].name;
        //dialogueLabel.text = dialogues[index].message;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(dialogues[index].message));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueLabel.text = "";
        foreach(char letter in sentence)
        {
            dialogueLabel.text += letter;
            yield return new WaitForEndOfFrame();
        }
    }
}
