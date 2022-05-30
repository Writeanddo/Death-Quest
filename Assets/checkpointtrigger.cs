using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpointtrigger : MonoBehaviour
{
    [SerializeField] bool hashit;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if (hashit == false)
            {
                checkpoint.instance.sectioncompleted();

                hashit = true;
            }
        }

    }
}
