using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kill_zone : MonoBehaviour
{
    [SerializeField] DIE DIE;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            DIE.StartCoroutine(DIE.die());
        }
    }
}
