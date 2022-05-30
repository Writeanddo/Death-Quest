using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portaldoor : MonoBehaviour
{
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            DIE.instance.StartCoroutine(DIE.instance.respawn());
        }
       
    }


}
