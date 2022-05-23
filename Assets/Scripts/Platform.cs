using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] GameObject[] Platforms;

    [SerializeField] Platformorder[] Platformorder;

    [SerializeField] Material bad;


    void Start()
    {
        int randomnumber = Random.Range(0,Platformorder.Length);
        Platformorder Randomplatformorder = Platformorder[randomnumber];


        int Platformorderindex = 0;
        Debug.Log(randomnumber);

        for(int i = 0; i < Platforms.Length; i++)
        {
       
            // only check when divisble by 2. i.e left hand side

            if(i % 2 == 0)
            {
                //left hand side is solid
                if(Randomplatformorder.getpositions()[Platformorderindex] == "left")
                {
                    Platforms[i + 1].GetComponent<Collider>().enabled = false;
                    Platforms[i + 1].GetComponent<Renderer>().material = bad;
                }

                //right hand side is solid
                else
                {
                    Platforms[i].GetComponent<Collider>().enabled = false;
                    Platforms[i].GetComponent<Renderer>().material = bad;
                }

                Platformorderindex++;
            }
        }

    
    }

}
