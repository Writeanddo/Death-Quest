using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Uimanager : MonoBehaviour
{

    [SerializeField] Image pos1;
    [SerializeField] Image pos2;

    [SerializeField] GameManager GameManager;

    private void Update()
    {
        if (GameManager.Items[0]!= null)
        {
            pos1.sprite = GameManager.Items[0].GetComponent<item>().image;
        }
        
        if(GameManager.Items[1] != null)
        {
            pos2.sprite = GameManager.Items[1].GetComponent<item>().image;
        }
    }
}
