using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kill_zone : MonoBehaviour
{
   
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            DIE.instance.StartCoroutine(DIE.instance.die());
            AudioManager.instance.playsound(6);
        }
    }
}
