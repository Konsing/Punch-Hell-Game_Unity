using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueBoxController : MonoBehaviour
{
    public void SetVisible(bool shown)
    {
        gameObject.SetActive(shown);
    }

    public void SetName(string name)
    {
        Text dialogueName = transform.Find("DialogueName").GetComponent<Text>();
        dialogueName.text = name;
        dialogueName.color = Color.yellow;
    }

    public void SetText(string text)
    {
        Text dialogueText = transform.Find("DialogueText").GetComponent<Text>();
        dialogueText.text = text;
        dialogueText.color = Color.white;
    }
}