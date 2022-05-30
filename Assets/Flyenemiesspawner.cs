using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flyenemiesspawner : MonoBehaviour
{
   
    public bool haschecked;
    public bool ROUNDfinished;
    [SerializeField] bool hascloseddoor;
    [SerializeField] GameObject doornew;
    [SerializeField] GameObject doorold;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if(ROUNDfinished == false)
            {
                if (haschecked == false)
                {
                    GunRoundManager.instance.StartCoroutine(GunRoundManager.instance.spawnfirstenemies());
                    haschecked = true;
                }

                if (hascloseddoor == false)
                {
                    hascloseddoor = true;
                    doorold.SetActive(false);
                    doornew.SetActive(true);
                }
            }
            
        }
    }

}
