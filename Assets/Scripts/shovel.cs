using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shovel : MonoBehaviour
{

    [SerializeField] float Firerate_secs;
    [SerializeField] float nexttimetofire;

    [SerializeField] GameObject camera;

    private RaycastHit Hit;

    [SerializeField] float range;

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
                Debug.Log("detecting");
                if (Input.GetKeyDown(KeyCode.E) && Time.time >= nexttimetofire)
                {
                    Hit.transform.gameObject.GetComponent<molehill>().destroyhill();

                    nexttimetofire = Time.time + Firerate_secs;

                }

            
                
            }

        }
    }
}
 
