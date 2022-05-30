using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camholder : MonoBehaviour
{
    [SerializeField] Transform campos;
    void Update()
    {
        transform.position = campos.position;
    }
}
