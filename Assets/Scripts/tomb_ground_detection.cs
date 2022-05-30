using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tomb_ground_detection : MonoBehaviour
{
    [SerializeField] Transform rayshootpos;
    [SerializeField] RaycastHit hit;
    [SerializeField] LayerMask layerMask;

    [SerializeField] float distance;

    [SerializeField] float Timefordestroy;
    public bool cancount;
    public float time;

    [SerializeField] GameObject holde, statusbar;


    [SerializeField] healthbar healthbar;

    void Start()
    {

        healthbar.setMaxHealth(Timefordestroy);
        healthbar.sethealth(0);

        if ( Physics.Raycast(rayshootpos.position, Vector3.down, out hit, layerMask))
        {
             distance = rayshootpos.transform.position.y - hit.point.y;

            transform.position = new Vector3(transform.position.x, transform.position.y - distance, transform.position.z);


        }
    }

    private void Update()
    {
        Count();
        healthbar.sethealth(time);
    }

    public void Count()
    {
        if (cancount)
        {
            time += Time.deltaTime;
        }

        else
        {
            time = 0;
        }

        if (time > Timefordestroy)
        {
            Debug.Log("timereached");
            Destroy(gameObject);
        }
    }


    public void turnonHoldEanddisablestatus()
    {
        holde.SetActive(true);
        statusbar.SetActive(false);
    }

    public void turnoffHoldEandenablestatus()
    {

        holde.SetActive(false);
        statusbar.SetActive(true);
    }

    public void turnoffHoldEanddisablestatus()
    {

        holde.SetActive(false);
        statusbar.SetActive(false);
    }
}
