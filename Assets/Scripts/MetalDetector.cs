using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalDetector : MonoBehaviour
{

    public GameObject Key;
    public float distance;


    [SerializeField] RaycastHit Hit;
    [SerializeField] float range;
    [SerializeField] public Transform rayshootpos;
    [SerializeField] LayerMask layerMask;

    [SerializeField] float clampedypos;


    [SerializeField] float timetobeepcounter,timetobeattime;


    [SerializeField] float  thirdrange, secondrange, firstrange;


    [SerializeField] float beattime4, beattime3, beattime2, beattime1;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Key != null)
        {

            distance = Vector3.Distance(transform.position, Key.transform.position);

            timetobeepcounter -= Time.deltaTime;

            if (timetobeepcounter <= 0)
            {
                AudioManager.instance.playsound(8);
                timetobeepcounter = timetobeattime;
            }

            if (distance > thirdrange)
            {
                timetobeattime = beattime4;
            }

            else if (distance <= thirdrange && distance > secondrange)
            {
                timetobeattime = beattime3;
            }

            else if (distance <= secondrange && distance > firstrange)
            {
                timetobeattime = beattime2;
            }

            else if (distance <= firstrange)
            {
                timetobeattime = beattime1;
            }
        }
      
    }
}

