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
        transform.Find("DialogueName").GetComponent<Text>().text = name;
    }

    public void SetText(string text)
    {
        transform.Find("DialogueText").GetComponent<Text>().text = text;
    }
}
