using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DOOR : MonoBehaviour
{
    [SerializeField] float Timefordoor;
    public bool cancount;
    public float time;

    [SerializeField] GameObject holde, statusbar;

    [SerializeField] Animator anim;
    [SerializeField] healthbar healthbar;
    [SerializeField] Spiderroundmanager Spiderroundmanager;

    private void Start()
    {
        healthbar.setMaxHealth(Timefordoor);
        healthbar.sethealth(0);
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

        if(time > Timefordoor)
        {
            if(Spiderroundmanager != null)
            {

                Spiderroundmanager.destoryenemy();
            }
            anim.SetTrigger("open");
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
