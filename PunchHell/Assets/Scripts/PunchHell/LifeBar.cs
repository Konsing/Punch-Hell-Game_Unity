using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeBar : MonoBehaviour
{
    private Transform[] hearts;
    // Start is called before the first frame update
    void Start()
    {
        hearts = transform.GetComponentsInChildren<Transform>(true);
    }

    public void SetHeartsVisible(int count)
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].gameObject.SetActive(count + 1 > i);
        }
    }
}
