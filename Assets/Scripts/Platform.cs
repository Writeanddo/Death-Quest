using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Platform : MonoBehaviour
{
    public static Platform instance;

    [SerializeField] GameObject[] Platforms;

    [SerializeField] Platformorder[] Platformorder;

    [SerializeField] Material bad;

    [SerializeField] List<string> correctstringorderlist = new List<string>();
    public string correctorderstring;

    [SerializeField] TMP_Text pickuptext;
    [SerializeField] TMP_Text gameobjecttext;


    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        int randomnumber = Random.Range(0,Platformorder.Length);
        Platformorder Randomplatformorder = Platformorder[randomnumber];


        int Platformorderindex = 0;

        for(int i = 0; i < Platforms.Length; i++)
        {
       
            // only check when divisble by 2. i.e left hand side

            if(i % 2 == 0)
            {
                //left hand side is solid
                if(Randomplatformorder.getpositions()[Platformorderindex] == "left")
                {
                    Platforms[i + 1].GetComponent<Collider>().enabled = false;
                }

                //right hand side is solid
                else
                {
                    Platforms[i].GetComponent<Collider>().enabled = false;
                }

                Platformorderindex++;
            }
        }

        for (int i = 0; i < Randomplatformorder.getpositions().Length; i++)
        {
            if (Randomplatformorder.getpositions()[i] == "right")
            {
                correctstringorderlist.Add((i + 1).ToString() + ")" + "Right\n");
            }
            
            else
            {
                correctstringorderlist.Add((i + 1).ToString() + ")" + "Left\n");
            }
        }

        correctorderstring = string.Join("", correctstringorderlist.ToArray());

        pickuptext.text = correctorderstring;
        gameobjecttext.text = correctorderstring;
    
    }

  


}
