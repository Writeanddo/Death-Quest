using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SAFE : MonoBehaviour
{
    public string correctcode;


    [SerializeField] TMP_Text code;

    [SerializeField] List<string> codelist = new List<string>();


    [SerializeField] Animator anim;




    public void addnumber(string number)
    {
        if(number == "cancel")
        {
            clear();
            AudioManager.instance.playsound(1);
        }

        else if(number == "enter")
        {
            ENTER();
            
        }
        else
        {
            codelist.Add(number);

            rendernumber();
            AudioManager.instance.playsound(1);
        }

        
       
    }

    public void clear()
    {
        codelist.Clear();
        code.text = "";
    }

    private void rendernumber()
    {
        code.text = string.Join("", codelist.ToArray());

    
    }


    void ENTER()
    {
        if(code.text == correctcode)
        {
            Debug.Log("correct");
            //play open safe anim;
            //play correct sound

            anim.SetTrigger("open");
            AudioManager.instance.playsound(2);
        }

        else
        {
            Debug.Log("incorrect");
            //play incrorrect sound
            clear();
            AudioManager.instance.playsound(3);
        }
    }
}
