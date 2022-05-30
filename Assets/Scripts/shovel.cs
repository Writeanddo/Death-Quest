using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shovel : MonoBehaviour
{

    [SerializeField] float Firerate_secs;
    [SerializeField] float nexttimetofire;

    [SerializeField] GameObject camera;

    [SerializeField] Animator anim;
    private RaycastHit Hit;

    [SerializeField] float range;

    [SerializeField] GameObject hitobject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {

        dig();
    }

    void dig()
    {
        //start the the dig anim

        //DONt use a collider to detect if the shovel hit as player could not be aiming at molehill
        //just use animation trigger

        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out Hit, range))
        {
           
            if (Hit.transform.gameObject.tag == "MoleHill")
            {
                hitobject = Hit.transform.gameObject;
                 
                hitobject.GetComponent<molehill>().canvas.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E) && Time.time >= nexttimetofire)
                {
                   


                    anim.SetTrigger("dig");
                    hitobject.GetComponent<molehill>().canvas.SetActive(false);
                    nexttimetofire = Time.time + Firerate_secs;

                }

            
                
            }
            else
            {

                if (hitobject != null)
                {
                    hitobject.GetComponent<molehill>().canvas.SetActive(false);
                }
            }

            

        }

        else
        {
            if(hitobject != null)
            {
                hitobject.GetComponent<molehill>().canvas.SetActive(false);
            }
           
        }

        if(Time.time < nexttimetofire)
        {
            if (hitobject != null)
            {
                hitobject.GetComponent<molehill>().canvas.SetActive(false);
            }
        }
    }

    private void OnDisable()
    {
        if (hitobject != null)
        {
            hitobject.GetComponent<molehill>().canvas.SetActive(false);
        }
    }

    public void digevent()
    {
        if(hitobject != null)
        {
            hitobject.GetComponent<molehill>().destroyhill();
        }
     
    }
}
 
