using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spiderspawner : MonoBehaviour
{
    public bool haschecked;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if(haschecked == false)
            {
                Spiderroundmanager.instance.spawnenemy();
                haschecked = true;
            }
           
        }
    }
}
