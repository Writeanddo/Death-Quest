using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tomb_ground_detection : MonoBehaviour
{
    [SerializeField] Transform rayshootpos;
    [SerializeField] RaycastHit hit;
    [SerializeField] LayerMask layerMask;

    [SerializeField] float distance;

    void Start()
    {
       if( Physics.Raycast(rayshootpos.position, Vector3.down, out hit, layerMask))
        {
             distance = rayshootpos.transform.position.y - hit.point.y;

            transform.position = new Vector3(transform.position.x, transform.position.y - distance, transform.position.z);
        }
    }


}
